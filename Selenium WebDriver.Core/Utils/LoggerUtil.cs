using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using log4net.Core;
using OpenQA.Selenium;
using Selenium_WebDriver.Core.Interfaces;

namespace Selenium_WebDriver.Core.Utils
{
    public static class LoggerUtil
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(LoggerUtil));

        public static void InitializeLoggerUtil()
        {
            string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config");

            if (!File.Exists(configPath))
            {
                Console.WriteLine($"[Log4net] Config file not found at: {configPath}");
            }

            XmlConfigurator.Configure(new FileInfo(configPath));
        }

        public static void Debug(string message) => Log.Debug(message);

        public static void Debug(string message, Exception ex) => Log.Debug(message, ex);

        public static void Info(string message) => Log.Info(message);

        public static void Info(string message, Exception ex) => Log.Info(message, ex);

        public static void Warn(string message) => Log.Warn(message);

        public static void Warn(string message, Exception ex) => Log.Warn(message, ex);

        public static void Error(string message) => Log.Error(message);

        public static void Error(string message, Exception ex) => Log.Error(message, ex);

        public static void Error(string message, By locator, Exception ex) => Log.Error(message + " Locator:" + locator.ToString(), ex);

        public static void Fatal(string message) => Log.Fatal(message);

        public static void Fatal(string message, Exception ex) => Log.Fatal(message, ex);

        public static void SetContext(string key, string value)
        {
            LogicalThreadContext.Properties[key] = value;
        }

        public static void ClearContext(string key)
        {
            LogicalThreadContext.Properties.Remove(key);
        }
    }
}
