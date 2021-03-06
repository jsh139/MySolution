﻿using DoSomething.IocSetup;
//using SunGardAS.Caching.NCache;
//using SunGardAS.CMS.Domain.Config;
//using SunGardAS.Encryption;
using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using PushSharp.Apple;
using SunGardAS.IocContainer;
using SunGardAS.CMS.Domain.DynamicData.Scalar;
using SunGardAS.Data.Static;
using System.Collections.Generic;
using SunGardAS.CMS.Domain.DataStore.Authentication;
using SunGardAS.Security.Principal;
using System.Threading;
using SunGardAS.Data.Static.Core;
using SunGardAS;

namespace DoSomething
{
    public partial class Form1 : Form
    {
        private const long AdminSecUserId = 411377;

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
            //AutoIocConfig.Register();

            //var configHelper = new GlobalDatabaseConfigOptionManager();
            //NcacheContainer.Initialize(configHelper.GetNcacheCacheId());
        }

        private void DoIt(object sender, EventArgs e)
        {
            //var v1 = new Version("1.1.2.1");
            //var v2 = new Version("1.1.2");

            //var comp = v1.CompareTo(v2);

            AutoIocConfig.Register();

            RecreatePrincipal();

            var scalarAgent = AutoIoc.Resolve<IScalarAgent>();
            var assessmentDef = new AssessmentDef();

            for (int i=1; i < 60; i++)
            {
                var request = new ScalarPutRequest
                {
                    Id = 0,
                    Entity = AssessmentDef.TablePhysName,
                    ColumnUpdates = new Dictionary<string, object>
                    {
                        { assessmentDef.FkAssessmentTemplate.PhysFullName, 1 },
                        { assessmentDef.AssessmentId.PhysFullName, $"ASR00{i}" },
                        { assessmentDef.Name.PhysFullName, i.ToString() },
                    },
                };

                scalarAgent.Put(request);
            }

            // var certificate = new X509Certificate2("C:\\Users\\jack.stillwell\\Downloads\\PushSharpCert.p12");
            //var certificate =
            //    new X509Certificate2(File.ReadAllBytes("C:\\Users\\josh.hoffman\\Downloads\\PushSharpCert.p12"));
            //var appleConfig =
            //    new ApnsConfiguration(ApnsConfiguration.ApnsServerEnvironment.Sandbox, certificate, false)
            //    {
            //        InternalBatchSize = 2000,
            //        InternalBatchingWaitPeriod = TimeSpan.FromMilliseconds(500)
            //    };
            //var connManager = new ApnsServiceBroker(appleConfig);
            //var notification = new ApnsNotification
            //{
            //    DeviceToken = "CDB66775904DFFE078E7FDB76FBBD893C5B6E2A1FFAD0A240955E0A10EEF60E8",
            //    Payload = new JObject(
            //        new JProperty("aps",
            //            new JObject(
            //                new JProperty("alert",
            //                    new JObject(
            //                        new JProperty("title", "test apns message from assurance title"),
            //                        new JProperty("body", "test apns message from assurance body")
            //                    )
            //                )
            //            )
            //        )
            //    )
            //};
            //connManager.OnNotificationSucceeded += s =>
            //{
            //    txtOutput.AppendText(string.Format("success for message: {0}", s.Payload["aps"]["alert"]));
            //    txtOutput.AppendText("hit enter to exit");
            //    //Console.ReadLine();
            //};
            //connManager.OnNotificationFailed += (s, ex) =>
            //{
            //    txtOutput.AppendText(string.Format("failure for message: {0}", s.Payload["aps"]["alert"]));
            //    txtOutput.AppendText("hit enter to exit");
            //    //Console.ReadLine();
            //};
            //connManager.Start();
            //connManager.QueueNotification(notification);
            //txtOutput.AppendText("hit enter to exit");
            //Console.ReadLine();
        }

        private void RecreatePrincipal()
        {
            CustomerRec customerRec = null;
            CustomerExtensionRec customerExtensionRec = null;

            AutoIoc.Using<ICustomerDataStore>(dataStore =>
            {
                customerRec = dataStore.GetCustomer(10);
                customerExtensionRec = dataStore.GetCustomerExtension(10);
            });

            var adminUser = AutoIoc.Get<IUnauthenticatedSecUserDataStore, SecUserRec>(dataStore =>
                dataStore.GetSecUser(customerRec, AdminSecUserId));
            var identity = new SungardAsIdentity(adminUser.UserName, AdminSecUserId, adminUser.FirstName,
                adminUser.LastName, adminUser.Email, "Admin");

            var customer = new SungardAsCustomer(10, "ldrps")
            {
                DbServer = ".\\SQL2017",
                DbDatabase = "ldrps11",
                DbUserName = "sa",
                DbPassword = "Ldrps10@".Secure(),
                IntegratedLogin = false,
                UrlId = customerRec.UrlId,
                MaxNamedUsers = customerRec.MaxNamedUsers,
            };

            customer.LastMetadataUpdateTime = customerExtensionRec?.LastMetadataUpdateTime;
            customer.SystemLockoutProcess = customerExtensionRec?.SystemLockoutProcess;
            customer.SystemLockoutInitiator = customerExtensionRec?.SystemLockoutInitiator;

            Thread.CurrentPrincipal = new SungardAsPrincipal(identity, customer, -2, null);
        }
    }
}
