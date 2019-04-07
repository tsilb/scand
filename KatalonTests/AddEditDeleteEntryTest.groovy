import static com.kms.katalon.core.checkpoint.CheckpointFactory.findCheckpoint
import static com.kms.katalon.core.testcase.TestCaseFactory.findTestCase
import static com.kms.katalon.core.testdata.TestDataFactory.findTestData
import static com.kms.katalon.core.testobject.ObjectRepository.findTestObject
import com.kms.katalon.core.checkpoint.Checkpoint as Checkpoint
import com.kms.katalon.core.checkpoint.CheckpointFactory as CheckpointFactory
import com.kms.katalon.core.mobile.keyword.MobileBuiltInKeywords as MobileBuiltInKeywords
import com.kms.katalon.core.model.FailureHandling as FailureHandling
import com.kms.katalon.core.testcase.TestCase as TestCase
import com.kms.katalon.core.testcase.TestCaseFactory as TestCaseFactory
import com.kms.katalon.core.testdata.TestData as TestData
import com.kms.katalon.core.testdata.TestDataFactory as TestDataFactory
import com.kms.katalon.core.testobject.ObjectRepository as ObjectRepository
import com.kms.katalon.core.testobject.TestObject as TestObject
import com.kms.katalon.core.webservice.keyword.WSBuiltInKeywords as WSBuiltInKeywords
import com.kms.katalon.core.webui.driver.DriverFactory as DriverFactory
import com.kms.katalon.core.webui.keyword.WebUiBuiltInKeywords as WebUiBuiltInKeywords
import internal.GlobalVariable as GlobalVariable
import com.kms.katalon.core.webui.keyword.WebUiBuiltInKeywords as WebUI
import com.kms.katalon.core.mobile.keyword.MobileBuiltInKeywords as Mobile
import com.kms.katalon.core.webservice.keyword.WSBuiltInKeywords as WS

import com.thoughtworks.selenium.Selenium
import org.openqa.selenium.firefox.FirefoxDriver
import org.openqa.selenium.WebDriver
import com.thoughtworks.selenium.webdriven.WebDriverBackedSelenium
import static org.junit.Assert.*
import java.util.regex.Pattern
import static org.apache.commons.lang3.StringUtils.join

WebUI.openBrowser('https://www.katalon.com/')
def driver = DriverFactory.getWebDriver()
String baseUrl = "https://www.katalon.com/"
selenium = new WebDriverBackedSelenium(driver, baseUrl)
selenium.open("http://localhost:5580/")
selenium.click("link=Create entry")
selenium.click("id=UserName")
selenium.type("id=UserName", "testUser")
selenium.click("id=Room")
selenium.type("id=Room", "testRoom101")
selenium.click("id=Time")
selenium.type("id=Time", "Apr 6 2019 4:12PM")
selenium.click("xpath=(.//*[normalize-space(text()) and normalize-space(.)='Time'])[1]/following::input[2]")
assertEquals("testUser", selenium.getText("xpath=(.//*[normalize-space(text()) and normalize-space(.)='Functions'])[1]/following::td[1]"));
assertEquals("testRoom101", selenium.getText("xpath=(.//*[normalize-space(text()) and normalize-space(.)='testUser'])[1]/following::td[1]"));
assertEquals("Apr 6 2019 4:12PM", selenium.getText("xpath=(.//*[normalize-space(text()) and normalize-space(.)='testRoom101'])[1]/following::td[1]"));
selenium.click("link=Edit")
selenium.click("id=UserName")
selenium.type("id=UserName", "testUser1")
selenium.click("id=Room")
selenium.type("id=Room", "testRoom102")
selenium.click("id=Time")
selenium.type("id=Time", "Apr 6 2019 4:13PM")
selenium.click("xpath=(.//*[normalize-space(text()) and normalize-space(.)='Time'])[1]/following::input[2]")
assertEquals("testUser1", selenium.getText("xpath=(.//*[normalize-space(text()) and normalize-space(.)='Functions'])[1]/following::td[1]"));
assertEquals("testRoom102", selenium.getText("xpath=(.//*[normalize-space(text()) and normalize-space(.)='testUser1'])[1]/following::td[1]"));
assertEquals("Apr 6 2019 4:13PM", selenium.getText("xpath=(.//*[normalize-space(text()) and normalize-space(.)='testRoom102'])[1]/following::td[1]"));
selenium.click("link=Delete")
