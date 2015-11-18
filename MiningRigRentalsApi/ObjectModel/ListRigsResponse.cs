using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json.Serialization;

namespace MiningRigRentalsApi.ObjectModel
{
	public struct RigList
	{
		public RigListInfo info;
		public RigListRecords[] records;
	}
	public class RigListInfoStats
	{
		public uint rigs;
		public ulong hash;
	}
	public class RigListInfoPrice
	{
		public double lowest;
		public double last_10;
		public double last;
	}
	public class RigListInfo
	{
		public int start_num;
		public int end_num;
		public uint total;
		public RigListInfoStats available;
		public RigListInfoStats rented;
		public RigListInfoPrice price;
	}
	public class RigListRecords
	{
		public int id;
		public string name;
		public double price;
		public double price_hr;
		public uint minhrs;
		public uint maxhrs;
		public double rating;
		public string status;
		public string hashrate_nice;
		public ulong hashrate;
		public double rpi;

		[OnError]
		internal void HandleError(StreamingContext context, ErrorContext errorContext)
		{
			if (errorContext.Member.Equals("rpi"))
			{
				(errorContext.OriginalObject as RigListRecords).rpi = double.NaN;
				errorContext.Handled = true;
			}
		}
	}
}
