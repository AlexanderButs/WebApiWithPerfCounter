using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading;

using Microsoft.Owin.Hosting;

namespace WebApiWithPerfCounter
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

			using (var webHost = WebApp.Start<Startup>("http://127.0.0.1:5000/"))
			{
				var process = Process.GetCurrentProcess();
				using (var counter = new PerformanceCounter("Process", "Thread Count", process.ProcessName, true))
				{
					Console.WriteLine(counter.NextValue());
				}

				PerformanceCounter.CloseSharedResources();

				Console.ReadLine();

				Console.WriteLine("Exit1");
			}

			PerformanceCounter.CloseSharedResources();

			Console.WriteLine("Exit2");
		}
	}
}