using System.Collections.Generic;
using System.IO;

namespace Benchmark.Common {
    public class AssemblyCache : IList<FileInfo> {
        HashSet<string> assemblyNameCache;
        HashSet<FileInfo> assembliesCore;
        public AssemblyCache() {
            assemblyNameCache = new HashSet<string>();
            assembliesCore = new HashSet<FileInfo>();
        }
        #region IList<FileInfo> Members
        int IList<FileInfo>.IndexOf(FileInfo item) { return -1; }
        void IList<FileInfo>.Insert(int index, FileInfo item) { }
        void IList<FileInfo>.RemoveAt(int index) { }
        FileInfo IList<FileInfo>.this[int index] {
            get { return null; }
            set { }
        }
        #endregion

        #region ICollection<FileInfo> Members
        public void Add(FileInfo item) {
            string fullName = item.FullName;
            if(assemblyNameCache.Contains(fullName)) return;
            assembliesCore.Add(item);
            assemblyNameCache.Add(fullName);
        }
        public void Clear() {
            assemblyNameCache.Clear();
            assembliesCore.Clear();
        }
        public bool Contains(FileInfo item) {
            return assemblyNameCache.Contains(item.FullName);
        }
        public void CopyTo(FileInfo[] array, int arrayIndex) {
            assembliesCore.CopyTo(array, arrayIndex);
        }
        public int Count {
            get { return assembliesCore.Count; }
        }
        public bool IsReadOnly {
            get { return false; }
        }
        public bool Remove(FileInfo item) {
            if(assemblyNameCache.Remove(item.FullName))
                return assembliesCore.Remove(item);
            return false;
        }
        #endregion

        #region IEnumerable<FileInfo> Members
        public IEnumerator<FileInfo> GetEnumerator() {
            return assembliesCore.GetEnumerator();
        }
        #endregion

        #region IEnumerable Members
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
        #endregion
    }
}