using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml;

namespace GetDynatraceXml
{
    public partial class Form1 : Form
    {
        private const string DashboardLocation = "http://10.140.28.61:8020/rest/management/dashboard/WebRequestsByPurePath";
        private const string UserName = "josh.hoffman";
        private const string Password = "trenT000";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnDoIt_Click(object sender, EventArgs e)
        {
            var xml = new XmlDocument();

            try
            {
                var request = WebRequest.Create(DashboardLocation);
                var credential = new NetworkCredential(UserName, Password);

                request.Credentials = credential;
                request.PreAuthenticate = true;

                var response = request.GetResponse();
                var answer = response.GetResponseStream();

                if (answer != null)
                {
                    using (var stream = new StreamReader(answer))
                    {
                        var content = stream.ReadToEnd(); //the string of the whole xml
                        response.Close();
                        xml.LoadXml(content);
                    }

                    txtDisplay.Text = xml.OuterXml;
                }
                else
                {
                    MessageBox.Show("No data found", MessageBoxIcon.Warning.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MessageBoxIcon.Error.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
