using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
	public class Notify
	{
		IAction _action = null;

		public Notify(IAction action)
		{
			_action = action;
		}

		public string Send(string Message)
		{
			return _action.ActOnNotification(Message);
		}
	}
}
