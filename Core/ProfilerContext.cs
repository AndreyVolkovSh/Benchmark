using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Profiler {
    public class ProfilerContext : IDisposable {
        const string sourceName = "DX_Profiler";
        string logName = "DX_Profiler_Log";
        public ProfilerContext() {
            CreateLog();
        }
        protected void CreateLog() {
            if(EventLog.SourceExists(sourceName)) return;
            EventLog.CreateEventSource(sourceName, logName);            
        }
        protected void DeleteLog() {
            if (!EventLog.SourceExists(sourceName)) return;
            EventLog.DeleteEventSource(sourceName);
            EventLog.Delete(logName);
        }
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
        public static void Trace(string message, EventLogEntryType type, ProfilerResult result) {
            if(!EventLog.SourceExists(sourceName)) return;
            EventLog.WriteEntry(sourceName, message, type, 0, 0, ResultToBytes(result));
        }
        public List<ProfilerLog> GetResults() {
            if(!EventLog.SourceExists(sourceName)) return null;
            IEnumerable<EventLog> logs = EventLog.GetEventLogs().Where(x => x.Log == logName);
            if(logs == null || logs.Count() == 0) return null;
            EventLog log = logs.First();
            if(log.Entries == null) return null;
            List<ProfilerLog> results = new List<ProfilerLog>();
            foreach(EventLogEntry entry in log.Entries) {
                ProfilerResult result = BytesToResult<ProfilerResult>(entry.Data);
                results.Add(new ProfilerLog(entry.Message, entry.EntryType, result));
            }
            return results;
        }
        #region IDisposable Members
        void IDisposable.Dispose() {
            DeleteLog();
        }
        #endregion
    }
    [Serializable]
    public class ProfilerResult {
        public int Perfomance {
            get;
            set;
        }
    }
    [Serializable]
    public class ProfilerLog {
        public ProfilerLog(string message, EventLogEntryType logType, ProfilerResult result) {
            Message = message;
            LogType = logType;
            Result = result;
        }
        public int GetPerfomance() {
            if(Result == null) return -1;
            return Result.Perfomance;
        }
        public string Message {
            get;
            private set;
        }
        public ProfilerResult Result {
            get;
            private set;
        }
        public EventLogEntryType LogType {
            get;
            private set;
        }
    }
}