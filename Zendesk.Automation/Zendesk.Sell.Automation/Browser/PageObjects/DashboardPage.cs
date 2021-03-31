using log4net;
using OpenQA.Selenium;
using Zendesk.AutoFramework.Browser;

namespace Zendesk.Sell.Automation.Browser.PageObjects
{
    public class DashboardPage : AbstractPage
    {
        #region Constructor
        public DashboardPage(IWebDriver driver, ILog log) : base(driver, log)
        {

        }
        #endregion

        #region Selectors
        private By Dashboard => By.XPath("div[contains(text(),'My Dashboard')]");
        private By LeadsLink => By.Id("nav-working-leads");
        #endregion

        #region Page Actions
        public override bool IsLoaded()
        {
            WaitForLoad(Dashboard);
            return Driver.FindElement(Dashboard).Displayed;
        }

        public LeadsPage NavigateLeadsPage()
        {
            var leadsLink = Driver.FindElement(LeadsLink);
            ClickOnElement(leadsLink);
            return new LeadsPage(Driver,Log);
        }
        #endregion
    }
}
