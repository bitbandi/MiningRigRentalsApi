using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
		//        [JsonConverter(typeof(IsoDateTimeConverter))]
		//        public DateTime start_time;
		public string status;
		public double vailable_in_hours;
	}
}
