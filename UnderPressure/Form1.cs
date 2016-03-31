using SunGardAS.CMS.Service.Authentication;
using SunGardAS.IocContainer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using SunGardAS.CMS.Domain.DataStore.Customer;
using SunGardAS.CMS.Domain.DataStore.IncidentManagement;
using SunGardAS.CMS.Domain.IncidentManagement.EventDefinition;
using SunGardAS.Data.Static;

namespace UnderPressure
{
    public partial class Form1 : Form
    {
        private EventDefinitionProvider _eventDefinitionProvider;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var eventDef = new EventDefinition();
            _eventDefinitionProvider = (EventDefinitionProvider)AutoIoc.Resolve(typeof(IEventDefinitionProvider));
            Cursor.Current = Cursors.WaitCursor;
            labMessage.Text = "Reading events...";
            txtLog.AppendText(string.Format("Reading events from {0}\r\n", chkDatabase.Checked ? "database" : "cache"));
            progressBar.Value = 0;
            progressBar.Maximum = Convert.ToInt32(txtIterations.Text);
            
            var eventId = (long)((ComboItem) cboEvent.SelectedItem).Value;
            var then = DateTime.Now;

            for (var i=1; i <= progressBar.Maximum; i++)
            {
                txtLog.AppendText(string.Format("Reading event id {0} - iteration {1}\r\n", eventId, i));
                txtLog.ScrollToCaret();
                Application.DoEvents();

                eventDef = _eventDefinitionProvider.GetEventDefinition(eventId, chkDatabase.Checked);
                progressBar.Increment(1);
            }

            var time = DateTime.Now - then;

            using (Stream s = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(s, eventDef);
                txtLog.AppendText(string.Format("Total time {0}. Object length {1}\r\n\r\n", time, s.Length));
            }

            labMessage.Text = "Select an event...";
            Cursor.Current = Cursors.Default;
        }

        private void SetPrincipal(long customerId, long secUserId)
        {
            // Admin
            labMessage.Text = "Logging in...";
            Application.DoEvents();
            AutoIoc.Using<IAuthenticationService>(auth => auth.Login(customerId, secUserId));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IocSetup.Initialize();
            NcacheConfig.Setup();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();
            GetDatabases();
        }

        private void GetDatabases()
        {
            Cursor.Current = Cursors.WaitCursor;
            Application.DoEvents();
            var customerList = AutoIoc.Get<ICustomerDataStore, List<CustomerRec>>(ds => ds.GetCustomers())
                .Select(cust => new ComboItem {Text = cust.UrlId, Value = cust})
                .OrderBy(c => c.Text)
                .ToList();

            cboDatabase.Items.Clear();
            cboDatabase.DisplayMember = "Text";
            cboDatabase.ValueMember = "Value";
            cboDatabase.DataSource = customerList;

            Cursor.Current = Cursors.Default;
        }

        private void cboDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            var db = ((ComboItem)cboDatabase.SelectedItem).Value as CustomerRec;
            if (db == null) 
                return;

            labDatabase.Text = db.Database;

            Application.DoEvents();

            SetPrincipal(db.PkCustomer, 411377);

            GetEvents();
            Cursor.Current = Cursors.Default;
            labMessage.Text = "Select an event...";
        }

        private void GetEvents()
        {
            labMessage.Text = "Getting event list...";
            Application.DoEvents();

            var eventList = AutoIoc.Get<IEventDataStore, List<EventRec>>(ds => ds.GetEventList())
                .Select(e => new ComboItem { Text = string.Format("{0} ({1})", e.Name, e.PkEvent), Value = e.PkEvent })
                .OrderBy(c => c.Text)
                .ToList();

            cboEvent.DataSource = null;
            cboEvent.Items.Clear();
            cboEvent.DisplayMember = "Text";
            cboEvent.ValueMember = "Value";
            cboEvent.DataSource = eventList;

            btnDoIt.Enabled = cboEvent.Items.Count > 0;
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtLog.Text = string.Empty;
        }
    }
}
