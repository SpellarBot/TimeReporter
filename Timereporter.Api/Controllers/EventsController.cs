﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Timereporter.Api.Collections;
using Timereporter.Core.Models;
using Events = Timereporter.Core.Models.Events;

namespace Timereporter.Api.Controllers
{
	// Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;
	[Route("api/[controller]")]
	[ApiController]
	public class EventsController : ControllerBase
	{
		private readonly IEventLog events;

		public EventsController(IEventLog events)
		{
			this.events = events;
		}

		// GET api/values
		//[HttpGet]
		//public ActionResult<IEnumerable<string>> Get()
		//{
		//	return new string[] { "value1", "value2" };
		//}

		[HttpGet("{from:long}/{to:long}")]
		public IEnumerable<Event> Find(long from, long to)
		{
			return events.FindBy((from, to));
		}

		//[HttpGet("{year:int}/{month}/{day:int}")]
		//public IEnumerable<Event> Find(int year, int month, int day)
		//{
		//	return events.FindBy(new Date(year, month, day));
		//}

		/// <summary>
		/// Moment in UNIX-timestamp. Example:
		/// curl -k -d "" -X POST https://localhost:44388/api/events/random/1556238242
		/// </summary>
		/// <param name="value"></param>
		[HttpPost]
		public void Post(Events events_)
		{
			events.AddRange(events_.Events_);
		}

		//// PUT api/values/5
		//[HttpPut("{id}")]
		//public void Put(int id, [FromBody] string value)
		//{
		//}

		//// DELETE api/values/5
		//[HttpDelete("{id}")]
		//public void Delete(int id)
		//{
		//}
	}
}
