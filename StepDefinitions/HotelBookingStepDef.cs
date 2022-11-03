using NUnit.Framework;
using SeleniumExtras.PageObjects;
using TestAutomationSolutionCSharp.Framework;
using TestAutomationSolutionCSharp.PageClass;

namespace TestAutomationSolutionCSharp.StepDefinitions
{
    [Binding]
    internal class HotelBookingStepDef
    {
        private SContext sc = null;
        private HotelBookingPage bookingPage;

        public HotelBookingStepDef(SContext sc1)
        {
            sc = sc1;
            bookingPage = new HotelBookingPage(sc);
            PageFactory.InitElements(sc.getDriver(), bookingPage);

        }

        [Given(@"I check the availability of a deluxe room")]
        public void GivenICheckTheAvailabilityOfADeluxeRoom()
        {
            Assert.IsTrue(bookingPage.checkRoomAvailibility(), "Check Availibility of Deluxe Room");
        }

        [When(@"I book the room")]
        public void WhenIBookTheRoom()
        {
            Assert.IsTrue(bookingPage.bookARoom(), "Book a Deluxe Room");
        }

        [Then(@"I verify the booking")]
        public void ThenIVerifyTheBooking()
        {
            Assert.IsTrue(bookingPage.verifyRoomBooking(), "Verify the booking");
        }
    }
}
