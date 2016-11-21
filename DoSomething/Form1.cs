using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DoSomething.IocSetup;
using SunGardAS.Caching.NCache;
using SunGardAS.CMS.Domain.Config;
using SunGardAS.CMS.Domain.IncidentManagement.RtoClock;
using SunGardAS.CMS.Service.Authentication;
using SunGardAS.IocContainer;

namespace DoSomething
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ScheduleRtoClockJobs(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            AutoIoc.Using<IAuthenticationService>(auth => auth.Login(10, 411377));

            var jobList = AutoIoc.Get<IRtoClockJobScheduler, List<long>>(rto =>
            {
                var timeToRun = DateTime.UtcNow.AddMinutes(2);
                var jobs = new List<long>();

                for (var i = 0; i < 250; i++)
                {
                    jobs.Add(rto.ScheduleRtoClockJob(i, timeToRun));
                    Application.DoEvents();
                }

                return jobs;
            });

            Cursor.Current = Cursors.Default;
            MessageBox.Show(string.Format("{0} jobs created.", jobList.Count));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AutoIocConfig.Register();

            var configHelper = new GlobalDatabaseConfigOptionManager();
            NcacheContainer.Initialize(configHelper.GetNcacheCacheId());
        }
    }
}
