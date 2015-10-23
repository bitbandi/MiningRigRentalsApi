using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace MiningRigRentalsApi.ObjectModel
{
	public class RigData
	{
		/// <summary>
		/// id of the rig. 
		/// </summary>
		public int id { get; set; }

		/// <summary>
		/// The name of the rig.
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// The name of the rig.
		/// </summary>
		public ulong? hashrate { get; set; }

		/// <summary>
		/// used with 'hashrate', can be 'kh','mh','gh','th'.
		/// </summary>
		public string hash_type { get; set; }

		/// <summary>
		/// price in BTC per mhash per day
		/// </summary>
		public double? price { get; set; }

		/// <summary>
		/// minimum rental length.
		/// </summary>
		public uint? min_hours { get; set; }

		/// <summary>
		/// maximum rental length
		/// </summary>
		public uint? max_hours { get; set; }
	}
}
