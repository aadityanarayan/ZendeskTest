using System;
using System.Diagnostics;
using log4net;
using log4net.Config;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Zendesk.AutoFramework.Helper;
using Zendesk.Sell.Automation.Browser.PageObjects;

namespace Zendesk.Sell.Automation.Tests
{
    public class BaseTests
    {
        #region Properties Constants
        private const string DriverExe = "chromedriver";
        private const string EnvName = "Develop";
        public static IWebDriver Driver { get; private set; }
        public static string AssemblyPath { get; private set; }
        public static AppEnvironment Env { get; private set; }

        protected static readonly ILog Logger = LogManager.GetLogger(typeof(BaseTests));
        #endregion

        #region NUnit Functions

        [OneTimeSetUp] // one time before each execution of Test Suite
        public void OneTimeBrowserSetUp()
        {
            Console.WriteLine("Inside OneTimeSetUp");
            AssemblyPath = Framework.GetAssemblyPath();
            Env = Framework.GetAppEnvironment(EnvName);
            KillChromeDriver();
        }

        [SetUp] // one time before each test
        public void SetUp()
        {
            Console.WriteLine("Inside SetUp");
            Console.WriteLine("Starting Test named: " + TestContext.CurrentContext.Test.MethodName);

            BasicConfigurator.Configure();

            var chromeService = ChromeDriverService.CreateDefaultService(AssemblyPath);
            Driver = new ChromeDriver(chromeService);
            ManageDriver();
            var loginPage = new LoginPage(Driver, Logger);
            var assertionMsg = $"Successfully navigate Browser to {Env.AppUrl}";
            Assert.DoesNotThrow(() => loginPage.NavigateUrl(Env.AppUrl), assertionMsg);
            Logger.Info(assertionMsg);
            //var cookiesDialog = new CookiesDialog(Driver, Logger);
            //if (cookiesDialog.IsLoaded())
            //{
            //    cookiesDialog.AcceptCookies();
            //    Logger.Info("Accepted all Google cookies");
            //}
        }

        [TearDown]
        public void TearDown()
        {
            Logger.Debug("Inside TearDown");
            Driver.Close();
            KillChromeDriver();
        }
        #endregion

        #region Private functions

        private void KillChromeDriver()
        {
            var processesChromeDriver = Process.GetProcessesByName(DriverExe);
            foreach (Process p in processesChromeDriver)
            {
                p.Kill();
            }
        }

        private void ManageDriver()
        {
            var myTimeout = Driver.Manage().Timeouts();
            myTimeout.ImplicitWait = TimeSpan.FromSeconds(60);  

            Driver.Manage().Window.Maximize();
            var sizeWnd = Driver.Manage().Window.Size;
            Logger.Debug($"Browser maximized; Size x={sizeWnd.Width}, y={sizeWnd.Height}");
        }

        #endregion
    }
}