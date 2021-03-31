using log4net;
using OpenQA.Selenium;
using Zendesk.AutoFramework.Browser;
using Zendesk.Sell.Automation.Browser.PageObjects;

namespace Zendesk.Sell.Automation.Browser.Widgets
{
    public class AddLeadWidget : AbstractWidget
    {
        #region Constructor
        public AddLeadWidget(IWebDriver driver, ILog log) : base(driver, log)
        {

        }
        #endregion

        #region Selectors
        private By FirstNameBox => By.XPath("//input[contains(@placeholder,'First Name')]");
        private By LastNameBox => By.XPath("//input[contains(@placeholder,'Last Name')]");
        private By CompanyNameBox => By.XPath("//input[contains(@placeholder,'Add company to search by name')]");
        private By SaveButton => By.XPath("//button[@data-action='save']");
        private string  CompanyNameCell => "//div[text()='%s']";
        #endregion

        #region Page Actions
        public override bool IsLoaded()
        {
            WaitForLoad(FirstNameBox);
            return Driver.FindElement(FirstNameBox).Displayed;
        }

        public LeadsPage CreateLead(string fName, string lName, string companyName)
        {
            var firstNameBox = Driver.FindElement(FirstNameBox);
            SetTextOnElement(firstNameBox, fName);
            var lastNameBox = Driver.FindElement(LastNameBox);
            SetTextOnElement(lastNameBox, lName);
            var companyNameBox = Driver.FindElement(CompanyNameBox);
            SetTextOnElement(companyNameBox, companyName);
            var saveButton = Driver.FindElement(SaveButton);
            ClickOnElement(saveButton);
            Log.Info($"SetInitialLeadDataForCompany, value={companyName}");
            return new LeadsPage(Driver, Log);
        }
        #endregion
    }
}