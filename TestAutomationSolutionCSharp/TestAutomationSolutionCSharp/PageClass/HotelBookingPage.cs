using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Xml.Linq;
using TestAutomationSolutionCSharp.Framework;

namespace TestAutomationSolutionCSharp.PageClass
{
    public class HotelBookingPage : AbstractPage
    {
        private SContext sc;

        public HotelBookingPage(SContext scenarioContext) : base(scenarioContext)
        {
            sc = scenarioContext;
        }

        //Locators
        [FindsBy(How = How.Id, Using = "date-start")]
		public IWebElement arrivalDate { get; set; }

        [FindsBy(How = How.Id, Using = "to-place")]
        public IWebElement numberOfNights { get; set; }

        [FindsBy(How = How.Name, Using = "wbe_product[adult_count]")]
        public IWebElement numberOfAdults { get; set; }

        [FindsBy(How = How.Name, Using = "wbe_product[children_count]")]
        public IWebElement numberOfChildren { get; set; }

        [FindsBy(How = How.Name, Using = "commit")]
        public IWebElement bookNowButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//h2[contains(text(),'Deluxe Appartment')]")]
        public IWebElement deluxeApartmentCategory { get; set; }

        [FindsBy(How = How.XPath, Using = "(//h2[contains(text(),'Deluxe Appartment')]/following::table//tr[last()])//td[last()]/span")]
        public IWebElement deluxeApartmentRoom { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@type='number'])[1]")]
        public IWebElement addOn1 { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@type='number'])[2]")]
        public IWebElement addOn2 { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@type='submit'])[1]")]
        public IWebElement addSelectedAddOns { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@title='E-mail']")]
        public IWebElement emailId { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@title='Last name']")]
        public IWebElement lastName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@title='First name']")]
        public IWebElement firstName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@title='Phone']")]
        public IWebElement phoneNumber { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@title='Credit Card']")]
        public IWebElement creditCardRadioButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@title='I agree with the hotel and guarantee policy']")]
        public IWebElement agreePolicyRadioButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Create Booking']")]
        public IWebElement createBookingButton { get; set; }

        [FindsBy(How = How.Id, Using = "cardNumber")]
        public IWebElement cardNumber { get; set; }

        [FindsBy(How = How.Id, Using = "credit_card_collect_purchase_address")]
        public IWebElement billingAddressLine { get; set; }

        [FindsBy(How = How.Id, Using = "credit_card_collect_purchase_zip")]
        public IWebElement zip { get; set; }

        [FindsBy(How = How.Id, Using = "credit_card_collect_purchase_city")]
        public IWebElement city { get; set; }

        [FindsBy(How = How.Id, Using = "credit_card_collect_purchase_state")]
        public IWebElement state { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        public IWebElement payButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//h1[text()='Thank you for your booking!']")]
        public IWebElement successMessage { get; set; }


        public Boolean checkRoomAvailibility()
        {
            sc.getDriver().Url = "https://www.clock-software.com/demo-clockpms/index.html"; //launch app
            checkRoomAvailability();//check room availability
            return true;
        }

        private void checkRoomAvailability()
        {
            String dateAfter = sc.getRandomDateString();
            webSendKeys(arrivalDate, dateAfter);
            webClearField(numberOfNights);
            webClickElement(numberOfNights);
            webSendKeys(numberOfNights, "4");
            webClearField(numberOfAdults);
            webSendKeys(numberOfAdults, "2");
            webClearField(numberOfChildren);
            webSendKeys(numberOfChildren, "0");
            webClickElement(bookNowButton);
            switchToIFrame("clock_pms_iframe_1"); //switch to frame
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0,1400)");//scroll down to the page

            if (webIsElementDisplayed(deluxeApartmentRoom))
            {
                webClickElement(deluxeApartmentRoom);
            }
            else
            {
                Assert.Fail("No Deluxe Room Available for this date");
            }
        }

        public Boolean bookARoom()
        {
            selectAddOns();//select add-ons
            createBooking();//provide guest details and create booking
            enterCardDetails();//provide card details
            enterBillingDetails();//enter billing details
            return true;
        }

        private void selectAddOns()
        {
            webSendKeys(addOn1, "1");
            webSendKeys(addOn2, "1");
            jsClickWithoutWait(addSelectedAddOns);
        }

        private void createBooking()
        {

            webSendKeys(emailId, "virat.kholi@gmail.com");
            webSendKeys(lastName, "kholi");
            webSendKeys(firstName, "virat");
            webSendKeys(phoneNumber, "07332288990");
            webClickElement(creditCardRadioButton);
            webClickElement(agreePolicyRadioButton);
            webClickElement(createBookingButton);
        }

        private void enterCardDetails()
        {
            String dropDownBrand = "credit_card_collect_purchase[brand]";
            String expiryMonth = "credit_card_collect_purchase[expire_month]";
            String expiryYear = "credit_card_collect_purchase[expire_year]";

            webSendKeys(cardNumber, "4929 0000 0000 6");
            selectDropDownByName(dropDownBrand, "VISA");
            selectDropDownByName(expiryMonth, "05");
            selectDropDownByName(expiryYear, "2025");

        }

        private void enterBillingDetails()
        {
            String country = "credit_card_collect_purchase[country]";

            webSendKeys(billingAddressLine, "10 Park Hill Bvld");
            webSendKeys(zip, "43015");
            webSendKeys(city, "London");
            webSendKeys(state, "Sussex");
            selectDropDownByName(country, "United Kingdom");
            webClickElement(payButton);

        }

        public Boolean verifyRoomBooking()
        {
            if (webIsElementDisplayed(successMessage))
            {
                return true;
            }
            else
            {
                return false;
            }

        }


    }
}
