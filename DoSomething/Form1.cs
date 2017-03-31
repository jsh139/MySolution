using DoSomething.IocSetup;
using SunGardAS.Caching.NCache;
using SunGardAS.CMS.Domain.Config;
using SunGardAS.Encryption;
using System;
using System.Windows.Forms;

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
            //Cursor.Current = Cursors.WaitCursor;

            //AutoIoc.Using<IAuthenticationService>(auth => auth.Login(10, 411377));

            //var jobList = AutoIoc.Get<IRtoClockJobScheduler, List<long>>(rto =>
            //{
            //    var timeToRun = DateTime.UtcNow.AddMinutes(2);
            //    var jobs = new List<long>();

            //    for (var i = 0; i < 250; i++)
            //    {
            //        jobs.Add(rto.ScheduleRtoClockJob(i, timeToRun));
            //        Application.DoEvents();
            //    }

            //    return jobs;
            //});

            //Cursor.Current = Cursors.Default;
            //MessageBox.Show(string.Format("{0} jobs created.", jobList.Count));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AutoIocConfig.Register();

            var configHelper = new GlobalDatabaseConfigOptionManager();
            NcacheContainer.Initialize(configHelper.GetNcacheCacheId());
        }

        private void DoIt(object sender, EventArgs e)
        {
            var key = "XEEnDeDLDewibn64jWnt8hNK0LyyR6vo88A/zxK2k2I=";
            var vector = "UlbWXaOzIHBPecZb58MbrQ==";

            var encryptor = new RindjaelEncrypter(key, vector);

            var encryptedString = encryptor.EncryptString("LDRPS<img src='x' onerror='alert(1);'>");
            txtOutput.Text = encryptedString;
        }
    }
}
