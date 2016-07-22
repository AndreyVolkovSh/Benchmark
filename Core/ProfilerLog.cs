using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Win32;

namespace Profiler {
    public class ProfilerLog {
        static byte[] ResultToBytes<T>(T result) where T : class {
            if(result == null) return null;
            BinaryFormatter formatter = new BinaryFormatter();
            using(var ms = new MemoryStream()) {
                formatter.Serialize(ms, result);
                return ms.ToArray();
            }
        }
        static T BytesToResult<T>(byte[] bytes) where T : class {
            if(bytes == null) return null;
            BinaryFormatter formatter = new BinaryFormatter();
            using(var ms = new MemoryStream()) {
                ms.Write(bytes, 0, bytes.Length);
                ms.Seek(0, SeekOrigin.Begin);
                return formatter.Deserialize(ms) as T;
            }
        }
        public static void Create() {
            if(!FileExists || KeyExists) return;
            RegistryKey key = Registry.LocalMachine.CreateSubKey(Constants.LogKey, RegistryKeyPermissionCheck.ReadWriteSubTree);
            if(key != null) {
                RegistryKey subKey = key.CreateSubKey(Constants.LogName, RegistryKeyPermissionCheck.ReadWriteSubTree);
                string fullPath = Path.GetFullPath(Constants.LogPath);
                key.SetValue("MaxSize", int.MaxValue, RegistryValueKind.DWord);
                key.SetValue("Flags", 1, RegistryValueKind.DWord);
                key.SetValue("File", fullPath, RegistryValueKind.ExpandString);
                subKey.Close();
            }
            key.Close();
        }
        public static void Clear() {
            if(!LogExists) return;
            EventLog log = EventLog;
            log.Clear();
        }
        public static void Trace(string message, EventLogEntryType type, ProfilerLogResult result) {
            if(!LogExists) return;
            EventLog log = EventLog;
            ProfilerLogEntry entry = new ProfilerLogEntry(message, type, result);
            log.WriteEntry(message, type, 0, 0, ResultToBytes(entry));
        }
        static bool FileExists {
            get { return File.Exists(Constants.LogPath); }
        }
        static EventLog EventLog {
            get {
                EventLog log = new EventLog(Constants.LogName);
                log.Source = Constants.LogName;
                return log;
            }
        }
        static bool KeyExists {
            get {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(Constants.LogKey);
                if(key == null) return false;
                key.Close();
                return true;
            }
        }
        static bool LogExists {
            get { return FileExists && KeyExists; }
        }
        public static List<ProfilerLogEntry> GetResults() {
            if(!LogExists) return null;
            string fullPath = Path.GetFullPath(Constants.LogPath);
            List<ProfilerLogEntry> results = new List<ProfilerLogEntry>();
            using(EventLogReader reader = new EventLogReader(fullPath, PathType.FilePath)) {
                EventRecord record = reader.ReadEvent();
                while(record != null) {
                    results.Add(ToResult(record.Properties));
                    record = reader.ReadEvent();
                }
            }
            return results;
        }
        static ProfilerLogEntry ToResult(IList<EventProperty> properties) {
            if(properties.Count() <= 1) return null;
            return BytesToResult<ProfilerLogEntry>(properties[1].Value as byte[]);
        }
    }
    [Serializable]
    public class ProfilerLogResult {
        public int Perfomance {
            get;
            set;
        }
    }
    [Serializable]
    public class ProfilerLogEntry {
        public ProfilerLogEntry(string message, EventLogEntryType logType, ProfilerLogResult result) {
            Message = message;
            LogType = logType;
            Result = result;
        }
        public int Perfomance {
            get {
                if(Result == null) return -1;
                return Result.Perfomance;
            }
        }
        public string Message {
            get;
            private set;
        }
        public ProfilerLogResult Result {
            get;
            private set;
        }
        public EventLogEntryType LogType {
            get;
            private set;
        }
    }
    public class ProfilerLogEntryComparer : IComparer<ProfilerLogEntry> {
        #region IComparer<ProfilerLogEntry> Members
        public int Compare(ProfilerLogEntry x, ProfilerLogEntry y) {
            return Comparer<int>.Default.Compare(x.Perfomance, y.Perfomance);
        }
        #endregion
    }
}