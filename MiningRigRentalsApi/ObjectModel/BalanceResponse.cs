using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiningRigRentalsApi.ObjectModel
{
	public class Balance
	{
		public double confirmed { get; internal set; }
		public double unconfirmed { get; internal set; }
	}
}
