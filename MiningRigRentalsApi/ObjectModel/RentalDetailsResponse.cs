using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiningRigRentalsApi.Converters;
using Newtonsoft.Json;

namespace MiningRigRentalsApi.ObjectModel
{
	public class RentalDetails
	{
		public uint id;
		public uint rigid;
		public string name;
		[JsonProperty("start_time")]
		[JsonConverter(typeof(PhpDateTimeConverter))]
		public DateTime starttime;
		public string renter;
		public string region;
		public string type;
		public RentalHashrate hashrate;
		public double price;
		public uint length;
		public string status;
		public double? left;
	}

	public class RentalHashrate
	{
		public ulong advertised;
		public string average;
		[JsonProperty("5min")]
		public double min5;
		[JsonProperty("30min")]
		public double min30;
		[JsonProperty("60min")]
		public double min60;
	}
}
