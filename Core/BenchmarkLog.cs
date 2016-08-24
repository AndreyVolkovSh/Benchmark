using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Win32;

namespace Benchmark {
    public class BenchmarkLog {
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
            if(LogExists) return;
            EventLog.CreateEventSource(Constants.LogName, Constants.LogName);

        }
        public static void Clear() {
            if(!LogExists) return;
            using(EventLog log = GetEventLog())
                log.Clear();
        }
        public static void Trace(string message, EventLogEntryType type, BenchmarkLogResult result) {
            if(!LogExists) return;
            BenchmarkLogEntry entry = new BenchmarkLogEntry(message, type, result);
            using(EventLog log = GetEventLog())
                log.WriteEntry(message, type, 0, 0, ResultToBytes(entry));
        }
        static EventLog GetEventLog() {
            EventLog log = new EventLog(Constants.LogName);
            log.Source = Constants.LogName;
            return log;
        }
        static bool LogExists {
            get {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(Constants.LogKey);
                if(key == null) return false;
                key.Close();
                return true;
            }
        }
        public static List<BenchmarkLogEntry> GetResults() {
            if(!LogExists) return null;
            using(EventLogConfiguration config = new EventLogConfiguration(Constants.LogName)) {
                string fullPath = config.LogFilePath;
                List<BenchmarkLogEntry> results = new List<BenchmarkLogEntry>();
                using(EventLogReader reader = new EventLogReader(fullPath, PathType.FilePath)) {
                    EventRecord record = reader.ReadEvent();
                    while(record != null) {
                        results.Add(ToResult(record.Properties));
                        record = reader.ReadEvent();
                    }
                }
                return results;
            }
        }
        static BenchmarkLogEntry ToResult(IList<EventProperty> properties) {
            if(properties.Count() <= 1) return null;
            return BytesToResult<BenchmarkLogEntry>(properties[1].Value as byte[]);
        }
    }
    [Serializable]
    public class BenchmarkLogResult {
        public int Perfomance {
            get;
            set;
        }
    }
    [Serializable]
    public class BenchmarkLogEntry {
        public BenchmarkLogEntry(string message, EventLogEntryType logType, BenchmarkLogResult result) {
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
        public BenchmarkLogResult Result {
            get;
            private set;
        }
        public EventLogEntryType LogType {
            get;
            private set;
        }
    }
    public class BenchmarkLogEntryComparer : IComparer<BenchmarkLogEntry> {
        #region IComparer<BenchmarkLogEntry> Members
        public int Compare(BenchmarkLogEntry x, BenchmarkLogEntry y) {
            return Comparer<int>.Default.Compare(x.Perfomance, y.Perfomance);
        }
        #endregion
    }
}