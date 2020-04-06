using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ASPCoreToDo.Utils
{
	public class HttpController
	{
		private HttpClient _client;

		public HttpClient Client
		{
			get { return _client; }
			set { _client = value; }
		}


		public HttpController(Uri uri)
		{
			_client = new HttpClient();
			Client.BaseAddress = uri;
		}

	}
}
