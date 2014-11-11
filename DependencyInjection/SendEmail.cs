using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
	class SendEmail : IAction
	{
		public string ActOnNotification(string Message)
		{
			return Message + " sent via email.";
		}
	}
}
