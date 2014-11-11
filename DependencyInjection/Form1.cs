using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace DependencyInjection
{
	public partial class Form1 : Form
	{
		WindsorContainer container;
		Notify notify;

		public Form1()
		{
			InitializeComponent();

			container = new WindsorContainer();
			container.Register(Component.For<Notify>());
			container.Register(Component.For<IAction>().ImplementedBy<LogToFile>());

			notify = container.Resolve<Notify>();
		}

		private void btnLog_Click(object sender, EventArgs e)
		{
			//Notify notify = new Notify(new LogToFile());
			//txtLog.Text = notify.Send(Text.Trim());

			txtLog.Text = notify.Send(txtMessage.Text);
		}

		private void btnSMS_Click(object sender, EventArgs e)
		{
			Notify notify = new Notify(new SendSMS());
			txtLog.Text = notify.Send(txtMessage.Text);
		}

		private void btnEmail_Click(object sender, EventArgs e)
		{
			Notify notify = new Notify(new SendEmail());
			txtLog.Text = notify.Send(txtMessage.Text);
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			container.Dispose();
		}
	}
}
