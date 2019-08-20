using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DevSpacesBootcamp.Web.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace DevSpacesBootcamp.Web.Controllers
{
	public class HomeController : Controller
	{

		private static HttpClient _client;

		private static HttpClient Client
		{
			get
			{
				if (_client == null)
				{
					_client = new HttpClient();
				}
				return _client;
			}
		}


		public async Task<IActionResult> Index()
		{
			var request = new HttpRequestMessage()
			{
				RequestUri = new Uri("http://devspacesbootcampbackend/data")
			};

			if (Request.Headers.ContainsKey("azds-route-as"))
			{
				request.Headers.Add("azds-route-as", Request.Headers["azds-route-as"] as IEnumerable<string>);
			}

			var response = await Client.SendAsync(request);

			string[] data = JsonConvert.DeserializeObject<string[]>(response.Content.ReadAsStringAsync().Result);

			return View(data);
		}

		public IActionResult About()
		{
			ViewData["Message"] = "Your application description page.";

			return View();
		}

		public IActionResult Contact()
		{
			ViewData["Message"] = "Your contact page.";

			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
