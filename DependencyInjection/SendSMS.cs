using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
	public class SendSMS : IAction
	{
		public string ActOnNotification(string Message)
		{
			return Message + " sent via SMS.";
		}
	}
}
