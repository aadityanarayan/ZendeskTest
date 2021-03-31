using NUnit.Framework;
using Zendesk.Sell.Automation.Browser.PageObjects;

namespace Zendesk.Sell.Automation.Tests
{
    [TestFixture]
    class UiTests : BaseTests
    {
        [TestCase("CompanyName", "First")]
       public void VerifyMapsDestination(string companyName, string statusValue)
        {
            var loginPage = new LoginPage(Driver, Logger);
            //Todo: Correct account should be provided in test data
            var dashboardPage = loginPage.Login();
            var leadsPage = dashboardPage.NavigateLeadsPage();
            var assertionMsg = "Leads Page is not loaded";
            Assert.IsTrue(leadsPage.IsLoaded(), assertionMsg);
            Logger.Info("Creating a new lead");
            var addLeadWidget = leadsPage.AddNewLead();
            leadsPage = addLeadWidget.CreateLead("testFirst", "testLast", companyName);
            var settingsPage = leadsPage.NavigateSettingsPage();
            Logger.Info("Updating the lead status");
            settingsPage.UpdateLeadStatus(statusValue);
            leadsPage = settingsPage.NavigateLeadsPage();
            leadsPage.VerifyStatusColumnValuesChanged(statusValue);
        }
    }
}
