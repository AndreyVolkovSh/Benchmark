using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;

namespace Grid.Tests {
    public partial class TestGridGroupingSorting : UserControl {
        public EventHandler Completed;
        public EventHandler Ready;
        int lockRaise = 0;
        public TestGridGroupingSorting() {
            IDataStore store = XpoDefault.GetConnectionProvider(connection, AutoCreateOption.DatabaseAndSchema);
            store = new WaitCursorWrapper(store);
            XpoDefault.DataLayer = new SimpleDataLayer(store);
            InitializeComponent();
            xpServerCollectionSource1.Session.ObjectsLoaded += Session_ObjectsLoaded;
        }
        protected override void DestroyHandle() {
            base.DestroyHandle();
            xpServerCollectionSource1.Session.ObjectsLoaded -= Session_ObjectsLoaded;
        }
        void Session_ObjectsLoaded(object sender, ObjectsManipulationEventArgs e) {
            if(lockRaise > 0) return;
            if(Ready != null)
                Ready(this, EventArgs.Empty);
            lockRaise++;
        }
        string connection = "data source=(localdb)\\v11.0;integrated security=SSPI;initial catalog=ServerModeGridProjects500K";
        void ClearSortingGrouping() {
            gridView1.BeginUpdate();
            gridView1.ClearGrouping();
            gridView1.ClearSorting();
            gridView1.EndUpdate();
        }
        private void xpAsyncServerModeSource1_ResolveSession(object sender, ResolveSessionEventArgs e) {
            try {
                Session session = new Session();
                session.ConnectionString = connection;
                session.Connect();
                session.ObjectsLoaded += Session_ObjectsLoaded;
                e.Session = session;
                e.Tag = session;
            }
            catch {
                e.Session = new Session(new SimpleDataLayer(new InMemoryDataStore()));
                e.Tag = null;
            }
        }

        private void xpAsyncServerModeSource1_DismissSession(object sender, ResolveSessionEventArgs e) {
            Session session = e.Tag as Session;
            if(session != null) {
                session.Dispose();
                session.ObjectsLoaded -= Session_ObjectsLoaded;
            }
        }

        public void InstantFeedbackUI() {
            Cursor.Current = Cursors.WaitCursor;
            ClearSortingGrouping();
            gridControl1.DataSource = xpAsyncServerModeSource1;
            Cursor.Current = Cursors.Default;
        }

        public void ServerMode() {
            Cursor.Current = Cursors.WaitCursor;
            ClearSortingGrouping();
            gridControl1.DataSource = xpServerCollectionSource1;
            Cursor.Current = Cursors.Default;
        }

        public void SQLTable() {
            Cursor.Current = Cursors.WaitCursor;
            ClearSortingGrouping();
            gridControl1.DataSource = new XPCollection<ServerSideGridTest>();
            Cursor.Current = Cursors.Default;
        }

        void StartGroupingSorting(object sender, EventArgs e) {
        }
        void EndGroupingSorting(object sender, EventArgs e) {
            if(Completed != null)
                Completed(this, EventArgs.Empty);
        }
        public void Group_1() {
            this.gridView1.StartSorting += new EventHandler(StartGroupingSorting);
            this.gridView1.EndSorting += new EventHandler(EndGroupingSorting);
            colSubject.GroupIndex = 0;
            this.gridView1.StartSorting -= new EventHandler(StartGroupingSorting);
            this.gridView1.EndSorting -= new EventHandler(EndGroupingSorting);
        }
        public void Group_2() {
            this.gridView1.StartSorting += new EventHandler(StartGroupingSorting);
            colSubject.GroupIndex = 0;
            this.gridView1.StartSorting -= new EventHandler(StartGroupingSorting);
            this.gridView1.EndSorting += new EventHandler(EndGroupingSorting);
            colFrom.GroupIndex = 1;
            this.gridView1.EndSorting -= new EventHandler(EndGroupingSorting);
        }

        public void Sort_1() {
            this.gridView1.StartSorting += new EventHandler(StartGroupingSorting);
            this.gridView1.EndSorting += new EventHandler(EndGroupingSorting);
            colExpression.SortIndex = 0;
            this.gridView1.StartSorting -= new EventHandler(StartGroupingSorting);
            this.gridView1.EndSorting -= new EventHandler(EndGroupingSorting);
        }

        public void Sort_2() {
            this.gridView1.StartSorting += new EventHandler(StartGroupingSorting);
            colSubject.SortIndex = 0;
            this.gridView1.StartSorting -= new EventHandler(StartGroupingSorting);
            this.gridView1.EndSorting += new EventHandler(EndGroupingSorting);
            colSize.SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
            colSize.SortIndex = 1;
            this.gridView1.EndSorting -= new EventHandler(EndGroupingSorting);
        }
    }
    [DeferredDeletion(false)]
    public class ServerSideGridTest : XPObject {
        public ServerSideGridTest(Session session) : base(session) { }
        [Indexed]
        public string Subject;
        [Indexed]
        public string From;
        [Indexed]
        public DateTime Sent;
        [Indexed]
        public Int64 Size;
        [Indexed]
        public bool HasAttachment;
        [Indexed]
        public int Priority;
    }
    public class WaitCursorWrapper : IDataStore {
        public readonly IDataStore Nested;
        public WaitCursorWrapper(IDataStore nested) {
            this.Nested = nested;
        }
        public AutoCreateOption AutoCreateOption {
            get { return Nested.AutoCreateOption; }
        }
        public ModificationResult ModifyData(params ModificationStatement[] dmlStatements) {
            try {
                Cursor.Current = Cursors.WaitCursor;
                return Nested.ModifyData(dmlStatements);
            }
            finally {
                Cursor.Current = Cursors.Default;
            }
        }
        public SelectedData SelectData(params SelectStatement[] selects) {
            try {
                Cursor.Current = Cursors.WaitCursor;
                return Nested.SelectData(selects);
            }
            finally {
                Cursor.Current = Cursors.Default;
            }
        }
        public UpdateSchemaResult UpdateSchema(bool dontCreateIfFirstTableNotExist, params DBTable[] tables) {
            try {
                Cursor.Current = Cursors.WaitCursor;
                return Nested.UpdateSchema(dontCreateIfFirstTableNotExist, tables);
            }
            finally {
                Cursor.Current = Cursors.Default;
            }
        }
    }
}
