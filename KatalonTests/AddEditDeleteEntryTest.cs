using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestClass]
    public class AddEditDeleteEntryTest
    {
        private static IWebDriver driver;
        private StringBuilder verificationErrors;
        private static string baseURL;
        private bool acceptNextAlert = true;
        
        [ClassInitialize]
        public static void InitializeClass(TestContext testContext)
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.katalon.com/";
        }
        
        [ClassCleanup]
        public static void CleanupClass()
        {
            try
            {
                //driver.Quit();// quit does not close the window
                driver.Close();
                driver.Dispose();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
        
        [TestInitialize]
        public void InitializeTest()
        {
            verificationErrors = new StringBuilder();
        }
        
        [TestCleanup]
        public void CleanupTest()
        {
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [TestMethod]
        public void TheAddEditDeleteEntryTest()
        {
            driver.Navigate().GoToUrl("http://localhost:5580/");
            driver.FindElement(By.LinkText("Create entry")).Click();
            driver.FindElement(By.Id("UserName")).Click();
            driver.FindElement(By.Id("UserName")).Clear();
            driver.FindElement(By.Id("UserName")).SendKeys("testUser");
            driver.FindElement(By.Id("Room")).Click();
            driver.FindElement(By.Id("Room")).Clear();
            driver.FindElement(By.Id("Room")).SendKeys("testRoom101");
            driver.FindElement(By.Id("Time")).Click();
            driver.FindElement(By.Id("Time")).Clear();
            driver.FindElement(By.Id("Time")).SendKeys("Apr 6 2019 4:12PM");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Time'])[1]/following::input[2]")).Click();
            Assert.AreEqual("testUser", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Functions'])[1]/following::td[1]")).Text);
            Assert.AreEqual("testRoom101", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='testUser'])[1]/following::td[1]")).Text);
            Assert.AreEqual("Apr 6 2019 4:12PM", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='testRoom101'])[1]/following::td[1]")).Text);
            driver.FindElement(By.LinkText("Edit")).Click();
            driver.FindElement(By.Id("UserName")).Click();
            driver.FindElement(By.Id("UserName")).Clear();
            driver.FindElement(By.Id("UserName")).SendKeys("testUser1");
            driver.FindElement(By.Id("Room")).Click();
            driver.FindElement(By.Id("Room")).Clear();
            driver.FindElement(By.Id("Room")).SendKeys("testRoom102");
            driver.FindElement(By.Id("Time")).Click();
            driver.FindElement(By.Id("Time")).Clear();
            driver.FindElement(By.Id("Time")).SendKeys("Apr 6 2019 4:13PM");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Time'])[1]/following::input[2]")).Click();
            Assert.AreEqual("testUser1", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Functions'])[1]/following::td[1]")).Text);
            Assert.AreEqual("testRoom102", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='testUser1'])[1]/following::td[1]")).Text);
            Assert.AreEqual("Apr 6 2019 4:13PM", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='testRoom102'])[1]/following::td[1]")).Text);
            driver.FindElement(By.LinkText("Delete")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
