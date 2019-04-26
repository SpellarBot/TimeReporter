﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Timereporter.Api.Collections;
using Timereporter.Api.Entities;

namespace Timereporter.Api.Controllers
{
	// Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;
	[Route("api/[controller]")]
	[ApiController]
	public class EventsController : ControllerBase
	{
		// GET api/values
		//[HttpGet]
		//public ActionResult<IEnumerable<string>> Get()
		//{
		//	return new string[] { "value1", "value2" };
		//}

		[HttpGet("{year:int}/{month:int}")]
		public IEnumerable<Event> Get(int year, int month)
		{
			var events = new Events();
			return events.FindByMoment(year, month);
		}

		[HttpGet("{year:int}/{month}/{day:int}")]
		public IEnumerable<Event> Get(int year, int month, int day)
		{
			var events = new Events();
			return events.FindByMoment(year, month, day);
		}

		/// <summary>
		/// Moment in UNIX-timestamp. Example:
		/// curl -k -d "" -X POST https://localhost:44388/api/events/random/1556238242
		/// </summary>
		/// <param name="value"></param>
		[HttpPost("{kind}/{moment:double}")]
		public void Post(string kind, int moment)
		{
			var events = new Events();
			events.Add(new Event(kind, moment));
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
