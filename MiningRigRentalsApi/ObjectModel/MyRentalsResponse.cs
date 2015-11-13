using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiningRigRentalsApi.Converters;
using Newtonsoft.Json;

namespace MiningRigRentalsApi.ObjectModel
{
	public class MyRentals
	{
		public MyRentalsRecords[] records;
	}
	public class MyRentalsRecords
	{
		public int id;
		public int rigid;
		public string name;
		public string type;
		public int online;
		public double price;
		[JsonProperty("start_time")]
		[JsonConverter(typeof(PhpDateTimeConverter))]
		public DateTime starttime;
		public string status;
		public double vailable_in_hours;
		public MyRentalsHashrateAdvertised advertised;
		public MyRentalsHashrateCurrent current;
		public MyRentalsHashrateAverage average;
	}

	public class MyRentalsHashrateAdvertised
	{
		public string hashrate_nice;
		public ulong hashrate;
	}

	public class  MyRentalsHashrateCurrent
	{
		public double hash_5m;
		public string hash_5m_nice;
		public double hash_30m;
		public string hash_30m_nice;
		public double hash_1h;
		public string hash_1h_nice;
	}

	public class MyRentalsHashrateAverage
	{
		public double hashrate;
		public string hashrate_nice;
		public double percent;
	}

}
