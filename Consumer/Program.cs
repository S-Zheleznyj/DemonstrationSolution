using System.Configuration;
using System.Collections.Specialized;

var testConfig = ConfigurationManager.AppSettings.Get("host");

Console.WriteLine(testConfig);