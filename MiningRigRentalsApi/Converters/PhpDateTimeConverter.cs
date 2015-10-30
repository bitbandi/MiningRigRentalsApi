using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MiningRigRentalsApi.Converters
{
	public class PhpDateTimeConverter : DateTimeConverterBase
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			// TODO: test this
			writer.WriteRawValue(((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss") + " UTC");
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.Value == null) return null;
			var dt = DateTime.ParseExact(reader.Value.ToString().Replace(" UTC", ""), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
			dt = DateTime.SpecifyKind(dt, DateTimeKind.Utc);
			return dt.ToUniversalTime();
		}
	}
}
