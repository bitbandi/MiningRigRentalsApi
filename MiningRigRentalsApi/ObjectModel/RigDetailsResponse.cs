using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using MiningRigRentalsApi.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MiningRigRentalsApi.ObjectModel
{
	public class RigDetails
	{
		public uint id;
		public uint rentalid;
		public string name;
		[JsonProperty("start_time")]
		[JsonConverter(typeof(PhpDateTimeConverter))]
		public DateTime starttime;
		public string owner;
		public string region;
		public string type;
		public RentalHashrate hashrate;
		public RigHours hours;
		public double available_in_hours;
		public double price;
		public string status;

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

	public class RigHours
	{
		public ushort min;
		public ushort max;
	}
}
