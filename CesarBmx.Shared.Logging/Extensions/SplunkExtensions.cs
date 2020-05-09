using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using CesarBmx.Shared.Common.Extensions;

namespace CesarBmx.Shared.Logging.Extensions
{
    public static class SplunkExtensions
    {
        public static void LogSplunkInformation<T>(this ILogger logger, T payload)
        {
            var payloadName = typeof(T).Name;

            if (payloadName.EndsWith("Request"))
                payloadName = payloadName.Remove(payloadName.Length - 7);

            logger.LogSplunkInformation(payloadName, payload);
        }
        public static void LogSplunkInformation(this ILogger logger, string eventId, object payload)
        {
            var dictionary = payload.AsDictionary();
            var keyValues = dictionary.AsSplunkKeyValueString();
            if (keyValues.Length > 0) keyValues = ", " + keyValues;

            logger.LogInformation($"Event={eventId}" + keyValues);
        }
        public static void LogSplunkError(this ILogger logger, Exception ex)
        {
            logger.LogError(ex, $"Message=\"{ex.Message}\"");
        }
        public static string AsSplunkKeyValueString(this Dictionary<string, object> dictionary, string prefix = null)
        {
            var str = string.Empty;
            foreach (var item in dictionary)
            {
                if (item.Value is Dictionary<string, object> obj)
                {
                    str += obj.AsSplunkKeyValueString(item.Key) + ", ";
                }
                else
                {
                    // Cover scenarios like: Description=""
                    var pref = prefix?.Length > 0 ? prefix + "_" : string.Empty;
                    var value = item.Value == null || item.Value.ToString() == string.Empty ? "" : item.Value;
                    if (item.Value == null)
                    {
                        str += pref + item.Key + "=null, ";
                    }
                    else if (item.Value is DateTime)
                    {
                        str += pref + item.Key + $"=\"{item.Value}\", ";
                    }
                    else if (item.Key == "JobFailed")
                    {
                        str += pref + item.Key + $"=\"{item.Value}\", ";
                    }
                    else if (!item.Value.ToString().Contains(" "))
                    {
                        str += pref + item.Key + "=" + value + ", ";
                    }
                    else
                    {
                        str += pref + item.Key + "=\"{...}\", ";
                    }
                }
            }
            return str.Length > 0 ? str.Substring(0, str.Length - 2) : str;
        }
    }
}
