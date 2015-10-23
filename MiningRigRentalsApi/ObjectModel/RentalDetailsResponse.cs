using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiningRigRentalsApi.ObjectModel
{
	public class RentalDetails
	{
		public int id;
		public int rigid;
		public string name;
		//public DateTime start_time;
		public string renter;
		public string type;
		public double price;
		public int length;
		public string status;
		public double? left;
	}

}
