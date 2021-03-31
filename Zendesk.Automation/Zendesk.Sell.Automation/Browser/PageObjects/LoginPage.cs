using log4net;
using OpenQA.Selenium;
using Zendesk.AutoFramework.Browser;

namespace Zendesk.Sell.Automation.Browser.PageObjects
{
    public class LoginPage : AbstractPage
    {
        #region Constructor
        public LoginPage(IWebDriver driver, ILog log) : base(driver, log)
        {

        }
        #endregion

        #region Selectors
        private By EmailId => By.Id("user_email");
        private By Password => By.Id("user_password");
        private By SignInButton => By.XPath("//button[contains(text(), 'Sign in')]");
        
        #endregion
        #region Page Actions
        public override bool IsLoaded()
        {
            WaitForLoad(EmailId);
            return Driver.FindElement(EmailId).Displayed;
        }
        public DashboardPage Login()
        {
            var emailIdInput = Driver.FindElement(EmailId);
            SetTextOnElement(emailIdInput, "leroseg649@asfalio.com");
            var passwordInput = Driver.FindElement(Password);
            SetTextOnElement(passwordInput, "test12");
            var signInButton = Driver.FindElement(SignInButton);
            ClickOnElement(signInButton);
            return new DashboardPage(Driver, Log);
        }
        #endregion
    }
}
