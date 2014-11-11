using System;
using DependencyInjection;
using Xunit;
using Moq;

namespace DependencyInjectionTest
{
	public class LogActionTest
	{
		[Fact]
		public void TestLog()
		{
			const string s = "Test logged to file.";

			var LogMoq = new Mock<IAction>();
			LogMoq.Setup(u => u.ActOnNotification("Test")).Returns(s);
			
			var not = new Notify(LogMoq.Object);

			string t = not.Send("Test");
			
			Assert.Equal<string>(s, t); 
		}

		[Fact]
		public void TestSMS()
		{
			const string s = "Test sent via SMS.";
			Notify not = new Notify(new SendSMS());

			string t = not.Send("Test");

			Assert.Equal<string>(s, t); 
		}

		[Fact(Skip="Can't figure this out")]
		public void TestMath()
		{
			Assert.Equal(5, 6);
		}
	}
}
