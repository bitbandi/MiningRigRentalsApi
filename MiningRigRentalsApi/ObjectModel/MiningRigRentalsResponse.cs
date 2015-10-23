using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace MiningRigRentalsApi
{
	public class MiningRigRentalsResponse<T>
    {
        public bool Success { get; set; }

        public string[] Errors { get; set; }

		public T Data { get; set; }

		[JsonProperty("message")]
        internal string Error
        {
            set
            {
                if (this.Errors == null)
                {
                    this.Errors = new[] { value };
                }
                else
                {
                    this.Errors = new List<string>(this.Errors)
                        {
                            value
                        }.ToArray();
                }
            }
        }
    }
}
