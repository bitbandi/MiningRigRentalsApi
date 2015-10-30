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
	}
}
