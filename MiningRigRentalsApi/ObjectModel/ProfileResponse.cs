using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiningRigRentalsApi.ObjectModel
{
	public class Profile
	{
		public int id;
		public string name;
		public string type;
		public Pool[] pools;
	}
}
