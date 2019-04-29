﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Timereporter.Core.Collections;
using Timereporter.Core.Models;

namespace Timereporter.EventLogTask
{
	class Program
	{
		static void Main(string[] args)
		{
			var tracker = ObjectFactory.Instance.EventLogTracker();
			tracker.OnProgressChanged += Tracker_OnProgressChanged;
			var dateTimeValueFactory = ObjectFactory.Instance.DateTimeValueFactory();
			Date mondayAgo = WorkdayHelper.GetThreeMondaysAgo(dateTimeValueFactory.LocalToday());
			var minMaxes = tracker.FindBy(new EventLogQuery("^ESENT$", "Application", mondayAgo));
			
			Console.WriteLine("done!\r\n");
			Console.WriteLine(minMaxes.PrettyPrint());
			Console.WriteLine("Press any key to close.");
			Console.ReadKey();
		}

		private static void Tracker_OnProgressChanged()
		{
			Console.Write(".");
		}
	}
}
