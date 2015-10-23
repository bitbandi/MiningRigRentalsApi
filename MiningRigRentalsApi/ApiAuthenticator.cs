using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Extensions;

namespace MiningRigRentalsApi
{
	public class ApiAuthenticator : IAuthenticator
	{
		private readonly string apiKey;
		private readonly string apiSecret;

		public ApiAuthenticator(string apiKey, string apiSecret)
		{
			this.apiKey = apiKey;
			this.apiSecret = apiSecret;
		}

		public void Authenticate(IRestClient client, IRestRequest request)
		{
			var nonce = GetNonce();

			var url = client.BuildUri(request);

			request.AddParameter("nonce", nonce, ParameterType.GetOrPost);
			var @params = request.Parameters.Where(p => p.Type == ParameterType.GetOrPost)
				.Select(p => p.Name.UrlEncode() + "=" + p.Value.ToString().UrlEncode());
 
			var hmacSig = GenerateSignature(string.Join("&", @params.ToArray()), this.apiSecret);

			request.AddHeader("x-api-key", this.apiKey)
				   .AddHeader("x-api-sign", hmacSig);
		}

		/// <summary>
		/// The nonce is a positive integer number that must increase with every request you make.
		/// The ACCESS_SIGNATURE header is a HMAC-SHA256 hash of the nonce concatentated with the full URL and body of the HTTP request, encoded using your API secret.
		/// In some distributed scenarios, it might be necessary to override the implementation of this method to allow cluster of computers to make individual payment requests to server
		/// where synchronization of the nonce is necessary.
		/// </summary>
		/// <returns></returns>
		protected virtual string GetNonce()
		{
			return DateTime.UtcNow.Ticks.ToString();
		}


		public static string GenerateSignature(string body, string appSecret)
		{
			return GetHMACInHex(appSecret, body);
		}

		internal static string GetHMACInHex(string key, string data)
		{
			var hmacKey = Encoding.UTF8.GetBytes(key);

			using (var signatureStream = new MemoryStream(Encoding.UTF8.GetBytes(data)))
			{
				var hex = new HMACSHA1(hmacKey).ComputeHash(signatureStream)
					.Aggregate(new StringBuilder(), (sb, b) => sb.AppendFormat("{0:x2}", b), sb => sb.ToString());

				return hex;
			}
		}
	}
}
