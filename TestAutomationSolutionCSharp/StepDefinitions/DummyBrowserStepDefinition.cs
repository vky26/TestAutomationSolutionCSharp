
using TestAutomationSolutionCSharp.Framework;
using TestAutomationSolutionCSharp.PageClass;

namespace TestAutomationSolutionCSharp.StepDefinitions
{
    [Binding]
    public class DummyBrowserStepDefinition
    {
        private readonly ScenarioContext _scenarioContext;
        private SContext sc=null;
        private DummyPage dummyPage;

        public DummyBrowserStepDefinition(SContext sc1)
        {
            sc = sc1;
            dummyPage = new DummyPage(sc);

        }
        [Given(@"I open the browser")]
        public void GivenIOpenTheBrowser()
        {
            dummyPage.openApp();
        }

        [Given(@"login to the application")]
        public void GivenLoginToTheApplication()
        {
            dummyPage.loginApp();
        }

        [Then(@"logout of the application")]
        public void ThenLogoutOfTheApplication()
        {
            //dummyPage.closeApp();
        }
    }
}