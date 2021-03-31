using log4net;
using OpenQA.Selenium;
using Zendesk.AutoFramework.Browser;

namespace Zendesk.Sell.Automation.Browser.PageObjects
{
    public class SettingsPage : AbstractPage
    {
        #region Constructor
        public SettingsPage(IWebDriver driver, ILog log) : base(driver, log)
        {

        }
        #endregion

        #region Selectors
        private By LeadsLink => By.XPath("//a[text()='Leads']");
        private By LeadStatusLink => By.XPath("//a[text()='Lead Status']");
        private By EditButton => By.XPath("(//button[text()='Edit'])[7]");
        private By NameTextBox => By.XPath("(//input[@id='name'])[5]");
        private By SaveButton => By.XPath("(//button[(text()='Save')])[2]");
        private By LeadsHeaderLink => By.Id("nav-working-leads");

        #endregion
        #region Page Actions
        public override bool IsLoaded()
        {
            WaitForLoad(LeadsLink);
            return Driver.FindElement(LeadsLink).Displayed;
        }
        public SettingsPage UpdateLeadStatus(string statusValue)
        {
            var leadLink = Driver.FindElement(LeadsLink);
            ClickOnElement(leadLink);
            var leadStatus = Driver.FindElement(LeadStatusLink);
            ClickOnElement(leadStatus);
            var editButton = Driver.FindElement(EditButton);
            ClickOnElement(editButton);
            var nameStatusBox = Driver.FindElement(NameTextBox);
            SetTextOnElement(nameStatusBox, statusValue);
            var saveButton = Driver.FindElement(SaveButton);
            ClickOnElement(saveButton);
            return this;
        }
        public LeadsPage NavigateLeadsPage()
        {
            var leadsHeaderLink = Driver.FindElement(LeadsHeaderLink);
            ClickOnElement(leadsHeaderLink);
            return new LeadsPage(Driver, Log);
        }
        #endregion
    }
}
