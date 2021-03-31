using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using Zendesk.AutoFramework.Browser;
using Zendesk.Sell.Automation.Browser.Widgets;

namespace Zendesk.Sell.Automation.Browser.PageObjects
{
    public class LeadsPage : AbstractPage
    {
        #region Constructor
        public LeadsPage(IWebDriver driver, ILog log) : base(driver, log)
        {

        }
        #endregion

        #region Selectors
        private By AddLead => By.XPath("//button/div[text()='Add']");
        private By AddNewLeadButton => By.XPath("//span[text()='Lead']");
        private By StatusCell => By.XPath("//*[text()='First']");
        private By SelectCheckBox => By.XPath("////div[@class='_3PE--Checkbox--frame']/div");
        private By DeleteButton => By.XPath("//*[text()='Delete']");
        private By DeletePopUpButton => By.XPath("//div[contains(text(), 'Delete the selected')]/preceding-sibling::div/div/div");
        private By DeleteConfirmationButton => By.XPath("//button[@data-action='delete-confirmation-button']");
        private By SettingsLink => By.Id("nav-settings");
        private By StatusColumnValue => By.XPath("(//div[@data-column='status']/div/div)[2]");
        #endregion

        #region Page Actions
        public override bool IsLoaded()
        {
            WaitForLoad(AddLead);
            return Driver.FindElement(AddLead).Displayed;
        }


        public AddLeadWidget AddNewLead()
        {
            var addLeadButton = Driver.FindElement(AddLead);
            ClickOnElement(addLeadButton);
            var addNewLeadButton = Driver.FindElement(AddNewLeadButton);
            ClickOnElement(addNewLeadButton);
            return new AddLeadWidget(Driver, Log);

        }

        public SettingsPage NavigateSettingsPage()
        {
            var settingsLink = Driver.FindElement(SettingsLink);
            ClickOnElement(settingsLink);
            return new SettingsPage(Driver, Log);
        }

        public LeadsPage VerifyStatusColumnValuesChanged(string statusValue)
        {
            var statusColumnValue = Driver.FindElement(StatusColumnValue);
            Assert.True(statusColumnValue.Displayed);
            Assert.AreEqual(statusValue, GetTextOfElement(statusColumnValue), "The value didn't changed for status column : {0}", statusColumnValue);
            return this;
        }
        #endregion
    }
}
