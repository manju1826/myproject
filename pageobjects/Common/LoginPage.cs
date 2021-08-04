using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

using WCMAutomation.Utilities;
using UnicornLibrary.Selenium.BaseClasses;
using UnicornLibrary.Unicorn.Factory;
using UnicornLibrary.Unicorn.IServices.IElementServices.ISeleniumService;
using UnicornLibrary.Unicorn.IServices;
using UnicornLibrary.UnicornLogger;
using UnicornLibrary.Unicorn.Utilities;

using WCMAutomation.UIAutomation.Core;

namespace WCMAutomation.Services
{
    public class LoginPage : BasePage
    {
        ITestDataService testDataService = Factory.UnicornServices.GetTestDataService();

        #region Elements
        //Add elements of the page
        public ISeleniumTextBoxService userNameTextBox = Factory.ElementServices.GetWebTextBox(ElementSearchTypeConstants.CONST_SEARCH_BY_NAME, "userName", UnicornEnums.WebTextBoxControl.WebTextBox);
        public ISeleniumTextBoxService passwordTextBox = Factory.ElementServices.GetWebTextBox(ElementSearchTypeConstants.CONST_SEARCH_BY_NAME, "Password", UnicornEnums.WebTextBoxControl.WebTextBox);
        //public ISeleniumButtonService loginButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//*[@id='parallalstage']/div[4]/div/md-content/form/button");
       // public ISeleniumButtonService loginButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//*[@id='parallalstage']/div[4]/div/div/div[1]/md-content/form/button");
        public ISeleniumButtonService loginButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//button[@class='userSubmit ng-binding']");
        //Reset button
        public ISeleniumButtonService resetButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_ID, "btnReset");

        

        //Bypass Button
        public ISeleniumButtonService bypassButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//*[@id=\'myCarousel\']/div/div/div/div/div[1]/div/img");

        //To log error message
        // public ISeleniumTextBoxService LoginErrorMSg = Factory.ElementServices.GetWebTextBox(ElementSearchTypeConstants.CONST_SEARCH_BY_ID, "ErrorAuthentication", UnicornEnums.WebTextBoxControl.WebTextBox);
        //To check Login success 

        //public ISeleniumDropDownService userRole = Factory.ElementServices.GetWebDropdown(TestCaseConstants.CONST_ID, "select_4", UnicornEnums.WebDropDownControl.WebBootStrapDropdown);

        //public ISeleniumDropDownService userSiteCombobox = Factory.ElementServices.GetWebDropdown(TestCaseConstants.CONST_ID, "select_6", UnicornEnums.WebDropDownControl.WebDropdown);

        // Error message
        public ISeleniumTextBoxService LoginErrorMSg = Factory.ElementServices.GetWebTextBox(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//span[contains(@class,'md-toast-text')]", UnicornEnums.WebTextBoxControl.WebTextBox);
         
        

        #endregion


        public LoginPage(TestInputCache testInputCache) : base(testInputCache)
        {
           
        }



        #region Methods

        public void Login()
        {
            //Navigate to WCM Url
            _driver.GoToURL(GetTestDataByFieldName("ApplicationUrl"));
            //objDelay(3);

            userNameTextBox.EnterText(_driver, GetTestDataByFieldName("UserName"));
            passwordTextBox.EnterText(_driver, GetTestDataByFieldName("Password"));
            Delay(3);

            //Click on Login button
            loginButton.Click(_driver);
            Delay(1);

          
        }

        public void RoleSiteSelection()
        {
            
            //var RoleDropdownVisible = _driver.FindElements(By.XPath("//label[contains(.,'Role')]"));
            //if (RoleDropdownVisible.Count > 0)
            //{
                var userRole = GetTestDataByFieldName("UserRole");
                var siteCode = GetTestDataByFieldName("SiteCode");
                new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.Id("select_4"))).Click();
                var drp = new WebDriverWait(_driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//md-option/div[contains(text(),'" + userRole + "')]")));
                drp.Click();

                //site selection
                _driver.FindElement(By.Id("select_6")).Click();
                var drp2 = new WebDriverWait(_driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//md-option/div[contains(text(),'" + siteCode + "')]")));
                drp2.Click();

                _driver.FindElement(By.Id("btnGo")).Click();

                new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.UrlContains(TestCaseConstants.CONST_WCMHOMEURL));
           // }
           
            
        }

        

        public bool VerifyInvalidLogin()
        {
            //Navigate to WCM Url
            _driver.GoToURL(GetTestDataByFieldName("ApplicationUrl"));
            //objDelay(3);

            userNameTextBox.EnterText(_driver, GetTestDataByFieldName("UserName"));
            passwordTextBox.EnterText(_driver, GetTestDataByFieldName("Password"));
            Delay(3);
            //Click on Login button
            loginButton.Click(_driver);
            Delay(3);
            //Invalid Login and Verify the message
            return WaitForToastMessage().Contains("UserNotFound");
        }


        public void VerifyLogin()
        {
            if (!(_driver.Url.EndsWith(TestCaseConstants.CONST_WCMHOMEURL, StringComparison.InvariantCultureIgnoreCase)))
            {
                _testInputCache.Context.TestResult.Add(Tuple.Create(false, "***fail: login failed due to unexpeted error", 1));
            }
            else
            {
                _testInputCache.Context.TestResult.Add(Tuple.Create(true, "logged in successfully", 1));

            }
            //Console.ReadLine();
        }

        #endregion
    }
}

