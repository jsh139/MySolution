using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
	public class LogToFile : IAction
	{
		public string ActOnNotification(string Message)
		{
			if (Write(Message))
				return Message + " logged to file.";
			else
				throw new NotImplementedException();
		}

		private bool Write(string Message)
		{
			return true;
		}
				
	}
}
