using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using CesarBmx.Shared.Common.Extensions;

namespace CesarBmx.Shared.Logging.Extensions
{
    public static class SplunkExtension
    {
        public static void LogSplunkInformation<T>(this ILogger logger, T payload)
        {
            var payloadName = typeof(T).Name;
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
                if (item.Value is Dictionary<string, object> obj1)
                {
                    str += obj1.AsSplunkKeyValueString(item.Key) + ", ";
                }
                else if (item.Value is List<string> obj2)
                {
                    var index = 1;
                    foreach (var str1 in obj2)
                    {
                        str += item.Key + "_" + index + "=" + str1 + ", ";
                        index++;
                    }
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
                    // ReSharper disable once PossibleNullReferenceException
                    else if (!item.Value.ToString().Contains(" "))
                    {
                        str += pref + item.Key + "=" + value + ", ";
                    }
                    else
                    {
                        var maxSize = 30;
                        var longText = item.Value.ToString();
                        if (longText?.Length > maxSize) longText = longText.Substring(0, 30);
                        str += pref + item.Key + "=\"" + $"{longText}" + " {...}\", ";
                    }
                }
            }
            return str.Length > 0 ? str.Substring(0, str.Length - 2) : str;
        }
    }
}
