using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using MiningRigRentalsApi.ObjectModel;
using MiningRigRentalsApi.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;
using RestSharp.Authenticators;

namespace MiningRigRentalsApi
{
	public class Api
	{
		internal readonly string apiKey;
		internal readonly string apiSecret;
		internal readonly WebProxy proxy;

		public JsonSerializerSettings JsonSettings = new JsonSerializerSettings
			{
				DefaultValueHandling = DefaultValueHandling.Ignore,
				ContractResolver = new CamelCasePropertyNamesContractResolver(),

			};
		public Api(
			string apiKey,
			string apiSecret)
			: this(apiKey, apiSecret, null)
		{
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="apiKey">Your API Key</param>
		/// <param name="apiSecret">Your API Secret </param>
		/// <param name="proxy">Proxy for connections.</param>
		public Api(
			string apiKey,
			string apiSecret,
			WebProxy proxy)
		{
			this.apiKey = !string.IsNullOrEmpty(apiKey) ? apiKey : ConfigurationManager.AppSettings["ApiKey"];
			this.apiSecret = !string.IsNullOrEmpty(apiSecret) ? apiSecret : ConfigurationManager.AppSettings["ApiSecret"];
			if (string.IsNullOrEmpty(this.apiKey) || string.IsNullOrEmpty(this.apiSecret))
			{
				throw new ArgumentException("The API key / secret must not be empty. A valid API key and API secret should be used in the Api constructor or an appSettings configuration element with <add key='ApiKey' value='my_api_key' /> and <add key='ApiSecret' value='my_api_secret' /> should exist.", "apiKey");
			}

			this.proxy = proxy;
		}

		protected virtual RestClient CreateClient()
		{
			var client = new RestClient("https://www.miningrigrentals.com/api/v1/")
				{
					Proxy = this.proxy,
					Authenticator = GetAuthenticator()
				};

			client.AddHandler("*", new JsonNetDeseralizer(JsonSettings));
			return client;
		}

		protected virtual IAuthenticator GetAuthenticator()
		{
			return new ApiAuthenticator(apiKey, apiSecret);
		}

		protected virtual IRestRequest CreateRequest(string action, string methodparameter)
		{
			return CreateRequest(action, methodparameter, Method.POST);
		}

		protected virtual IRestRequest CreateRequest(string action, string methodparameter, Method method)
		{
			var post = new RestRequest(action, method)
				{
					RequestFormat = DataFormat.Json,
					JsonSerializer = new JsonNetSerializer(JsonSettings),
				};

			return post.AddParameter("method", methodparameter);
		}

		/// <summary>
		/// fooo. 
		/// See: https://www.miningrigrentals.com/apidoc
		/// 
		/// </summary>
		/// <param name="type">.</param>
		/// <returns></returns>
		public RigList ListRigs(string type)
		{
			var client = CreateClient();

			var req = CreateRequest("rigs", "list")
						.AddParameter("type", type);
			var resp = client.Execute<MiningRigRentalsResponse<RigList>>(req);

			if (resp.ErrorException != null)
				throw resp.ErrorException;

			if (!resp.Data.Success)
				throw new Exception(resp.Data.Errors[0]);

			return resp.Data.Data;
		}

		public MyRigs ListMyRigs()
		{
			var client = CreateClient();

			var req = CreateRequest("account", "myrigs");
			var resp = client.Execute<MiningRigRentalsResponse<MyRigs>>(req);

			if (resp.ErrorException != null)
				throw resp.ErrorException;

			if (!resp.Data.Success)
				throw new Exception(resp.Data.Errors[0]);

			return resp.Data.Data;
		}

		public MyRentals ListMyRentals()
		{
			var client = CreateClient();

			var req = CreateRequest("account", "myrentals");
			var resp = client.Execute<MiningRigRentalsResponse<MyRentals>>(req);

			if (resp.ErrorException != null)
				throw resp.ErrorException;

			if (!resp.Data.Success)
				throw new Exception(resp.Data.Errors[0]);

			return resp.Data.Data;
		}

		public RigDetails GetRigDetails(uint id)
		{
			var client = CreateClient();

			var req = CreateRequest("rigs", "detail")
						.AddParameter("id", id);
			var resp = client.Execute<MiningRigRentalsResponse<RigDetails>>(req);

			if (resp.ErrorException != null)
				throw resp.ErrorException;

			if (!resp.Data.Success)
				throw new Exception(resp.Data.Errors[0]);

			return resp.Data.Data;
		}

		public RentalDetails GetRentalDetails(uint id)
		{
			var client = CreateClient();

			var req = CreateRequest("rental", "detail")
						.AddParameter("id", id);
			var resp = client.Execute<MiningRigRentalsResponse<RentalDetails>>(req);

			if (resp.ErrorException != null)
				throw resp.ErrorException;

			if (!resp.Data.Success)
				throw new Exception(resp.Data.Errors[0]);

			return resp.Data.Data;
		}

		public string UpdateRig(RigData data)
		{
			var client = CreateClient();

			var req = CreateRequest("rigs", "update")
						.AddObject(data);

			var resp = client.Execute<MiningRigRentalsResponse<string>>(req);

			if (resp.ErrorException != null)
				throw resp.ErrorException;

			if (!resp.Data.Success)
				throw new Exception(resp.Data.Errors[0]);

			return resp.Data.Data;
		}

		public Balance GetBalance()
		{
			var client = CreateClient();

			var req = CreateRequest("account", "balance");
			var resp = client.Execute<MiningRigRentalsResponse<Balance>>(req);

			if (resp.ErrorException != null)
				throw resp.ErrorException;

			if (!resp.Data.Success)
				throw new Exception(resp.Data.Errors[0]);

			return resp.Data.Data;
		}

		public List<Pool> ListFavoritePools()
		{
			var client = CreateClient();

			var req = CreateRequest("account", "pools");
			var resp = client.Execute<MiningRigRentalsResponse<List<Pool>>>(req);

			if (resp.ErrorException != null)
				throw resp.ErrorException;

			return resp.Data.Data;
		}

		public List<Profile> ListProfiles()
		{
			var client = CreateClient();

			var req = CreateRequest("account", "profiles");
			var resp = client.Execute<MiningRigRentalsResponse<List<Profile>>>(req);

			if (resp.ErrorException != null)
				throw resp.ErrorException;

			if (!resp.Data.Success)
				throw new Exception(resp.Data.Errors[0]);

			return resp.Data.Data;
		}

	}
}
