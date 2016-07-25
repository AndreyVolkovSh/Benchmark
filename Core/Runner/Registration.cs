using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace Benchmark.Runner {
    public class Registration {
        static Registration currentCore;
        DataSet currentSet;
        Registration() {
            currentSet = new DataSet(Constants.Registration);
            if(!File.Exists(Constants.Registration)) return;
            currentSet.ReadXml(Constants.RegistrationPath);
        }
        public static Registration Current {
            get {
                if(currentCore == null)
                    currentCore = new Registration();
                return currentCore;
            }
        }
        public string[] Rivals {
            get { return Read(Constants.RivalTable, Constants.RivalColumn); }
        }
        public string[] Products {
            get { return Read(Constants.ProductTable, Constants.ProductColumn); }
        }
        public bool WriteRival(string name) {
            return Write(Constants.RivalTable, name);
        }
        public bool WriteProduct(string name) {
            return Write(Constants.ProductTable, name);
        }
        public bool AcceptChanges() {
            try {
                currentSet.AcceptChanges();
                currentSet.WriteXml(Constants.RegistrationPath, XmlWriteMode.WriteSchema);
                return true;
            }
            catch {
                return false;
            }
        }
        public IEnumerable<TestAssembly> Dlls() {
            using(TestAssemblies enumerator = new TestAssemblies(this)) {
                yield return enumerator.Current;
                while(enumerator.MoveNext())
                    yield return enumerator.Current;
            }
        }
        DataTable GetTable(string name) {
            return currentSet.Tables[name];
        }
        bool Write(string tableName, string name) {
            try {
                DataTable table = GetTable(tableName);
                if(table == null) return false;
                table.Rows.Add(name);
                return true;
            }
            catch {
                return false;
            }
        }
        string[] Read(string tableName, string columnName) {
            try {

                DataTable table = GetTable(tableName);
                if(table == null) return null;
                List<string> values = new List<string>();
                foreach(DataRow row in table.Rows) {
                    string value = GetValue<string>(row, columnName);
                    values.Add(value);
                }
                return values.ToArray();
            }
            catch {
                return null;
            }
        }
        T GetValue<T>(DataRow row, string columnName) where T : class {
            return row[columnName] as T;
        }
    }
    public class TestAssembly {
        public TestAssembly(string product, string rival) {
            Product = product;
            Rival = rival;
        }
        public string Product {
            get;
            private set;
        }
        public string Rival {
            get;
            private set;
        }
        public string Dll {
            get { return string.Format(Constants.TestAssembliesFormat, Product, Rival); }
        }
    }
    class TestAssemblies : IEnumerator<TestAssembly> {
        string[] products, rivals;
        int productIndex, rivalIndex;
        int productCount, rivalCount;
        public TestAssemblies(Registration registration) {
            products = registration.Products;
            rivals = registration.Rivals;
            productCount = products.Count();
            rivalCount = rivals.Count();
            Reset();
        }
        #region IEnumerator<string> Members
        public TestAssembly Current {
            get { return new TestAssembly(CurrentProduct, CurrentRival); }
        }
        string CurrentProduct {
            get { return GetObject(products, productIndex); }
        }
        string CurrentRival {
            get { return GetObject(rivals, rivalIndex); }
        }
        string GetObject(string[] objects, int index) {
            if(index >= objects.Count()) return string.Empty;
            return objects[index];
        }
        #endregion
        #region IDisposable Members
        bool isDisposing;
        public void Dispose() {
            if(isDisposing) return;
            isDisposing = true;
            products = rivals = null;
            productCount = rivalCount = 0;
            Reset();
        }
        #endregion
        #region IEnumerator Members
        object IEnumerator.Current {
            get { return Current; }
        }
        public bool MoveNext() {
            if(rivalCount == 0) return false;
            rivalIndex++;
            if(rivalCount == rivalIndex) {
                rivalIndex = 0;
                productIndex++;
            }
            return productCount > productIndex;
        }
        public void Reset() {
            productIndex = rivalIndex = 0;
        }
        #endregion
    }
}