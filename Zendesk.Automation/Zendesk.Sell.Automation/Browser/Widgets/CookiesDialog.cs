using log4net;
using OpenQA.Selenium;
using Zendesk.AutoFramework.Browser;
using Zendesk.Sell.Automation.Browser.PageObjects;

namespace Zendesk.Sell.Automation.Browser.Widgets
{
    public class CookiesDialog : AbstractWidget
    {
        #region Constructor
        public CookiesDialog(IWebDriver driver, ILog log) : base(driver, log)
        {

        }
        #endregion

        #region Selectors
        private By CookieSetting => By.Id("onetrust-pc-btn-handler");
        private By Frame => By.XPath("//*[@id='onetrust-group-container']/parent::div");
        private By IAgreeButton => By.Id("onetrust-accept-btn-handler");
        #endregion

        #region Page Actions

        public override bool IsLoaded()
        {
            return WaitForLoad(Frame) != null;
        }
        
        public LoginPage AcceptCookies()
        {
            var dialogFrame = Driver.FindElement(Frame);
            Driver.SwitchTo().Frame(dialogFrame);
            var acceptButton = Driver.FindElement(IAgreeButton);
            ClickOnElement(acceptButton);
            Log.Info($"AcceptCookies");
            return new LoginPage(Driver, Log);
        }
        #endregion
    }
}