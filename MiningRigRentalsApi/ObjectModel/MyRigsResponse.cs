using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiningRigRentalsApi.ObjectModel
{
	public class MyRigs
	{
		public MyRigsRecords[] records;
	}
	public class MyRigsRecords
	{
		public int id;
		public string name;
		public string rpi;
		public string type;
		public int online;
		public double price;
		public double price_hr;
		public uint minhrs;
		public uint maxhrs;
		public double rating;
		public string status;
		public string hashrate_nice;
		public ulong hashrate;
	}
}
