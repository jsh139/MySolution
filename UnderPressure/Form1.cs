using SunGardAS.CMS.Service.Authentication;
using SunGardAS.IocContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SunGardAS.CMS.Domain.DataStore.Customer;
using SunGardAS.CMS.Domain.DataStore.IncidentManagement;
using SunGardAS.Data.Static;

namespace UnderPressure
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            labMessage.Text = "Reading events...";
            progressBar.Maximum = Convert.ToInt32(txtIterations.Text);
            progressBar.Step = 0;

            var eventId = (long)((ComboItem) cboEvent.SelectedItem).Value;
            var then = DateTime.Now;

            for (var i=1; i <= progressBar.Maximum; i++)
            {
                txtLog.AppendText(string.Format("Reading event id {0} - iteration {1}\r\n", eventId, i));
                Application.DoEvents();

                EventHelper.GetEventDefinition(eventId);
                progressBar.PerformStep();
            }

            var time = DateTime.Now - then;
            txtLog.AppendText(string.Format("Total time {0}\r\n", time));
            labMessage.Text = "Select an event...";
        }

        private void SetPrincipal(long customerId, long secUserId)
        {
            // Admin
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
            var customerList = AutoIoc.Get<ICustomerDataStore, List<CustomerRec>>(ds => ds.GetCustomers())
                .Select(cust => new ComboItem {Text = cust.UrlId, Value = cust})
                .OrderBy(c => c.Text)
                .ToList();

            cboDatabase.Items.Clear();
            cboDatabase.DisplayMember = "Text";
            cboDatabase.ValueMember = "Value";
            cboDatabase.DataSource = customerList;

            labMessage.Text = "Select a database...";
        }

        private void cboDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            labMessage.Text = "Getting events...";

            var db = ((ComboItem)cboDatabase.SelectedItem).Value as CustomerRec;
            if (db == null) 
                return;

            labDatabase.Text = db.Database;

            Application.DoEvents();

            SetPrincipal(db.PkCustomer, 411377);

            GetEvents();
        }

        private void GetEvents()
        {
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
            labMessage.Text = "Select an event...";
        }
    }
}
