using OpenQA.Selenium;
using System;
using System.Collections.Generic;


using WCMAutomation.Utilities;
using OpenQA.Selenium.Interactions;
using UnicornLibrary.Selenium.BaseClasses;
using UnicornLibrary.Unicorn.Factory;
using UnicornLibrary.Unicorn.IServices;
using UnicornLibrary.UnicornLogger;

using UnicornLibrary.Unicorn.IServices.IElementServices.ISeleniumService;
using WCMAutomation.UIAutomation.Core;
using UnicornLibrary.Unicorn.Utilities;

namespace WCMAutomation.Services.Common
{
    class HomePage : BasePage
    {
        ITestDataService testDataService = Factory.UnicornServices.GetTestDataService();

        #region Elements

        public ISeleniumButtonService leftSideBar = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//*[@id='aside']");
        public ISeleniumButtonService listOfOptions = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//*[@id='nav']/nav/ul/div");

        public ISeleniumButtonService SelectOptions(int i) // i=1:dashboard, i=2:Themes, i=3:Widget libray, i=4:Assets, i=5:User manegement, i=6:Schedule, i=7:Theme management, i=8:Manage, i=9:Globalization ,i=10:Site Management ,i=11:Organization Level ,i=12:Manage Multisite,1=13: General Content settings
        {
            //ISeleniumButtonService SelectOptions = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, " html/body/div[1]/aside[1]/div/div/div/div/div/div[2]/nav/ul/div[" + i + "]/li/a");
            ISeleniumButtonService SelectOptions = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//div[contains(@class,'leftmenu')]["+i+"]");
            return SelectOptions;
        }

        //option to shown about and logout option
        public ISeleniumButtonService rightsideoption = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//i[contains(text(),'more_vert')]");
        // Logout button 
        public ISeleniumButtonService logoutButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//span[contains(text(),'Logout')]");

        //AboutUsScreen
        public ISeleniumButtonService aboutusoption = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//span[contains(text(),'About us')]");
        public ISeleniumButtonService aboutusscreen = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//md-content/h4/../div[@class='aboutus_text']");

        //Username in home page
        // public ISeleniumButtonService usernameText = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//div/span[@class='ng-binding' and contains(text(),'Casino.bclc.com')]");
        public ISeleniumButtonService usernameText = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//div/span[@class='tealtext ng-binding' and contains(text(),'(WCMADMIN)')]");


        //rolename
        public ISeleniumButtonService rolenameText = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//span[@class='tealtext ng-binding']");
        //span[contains(text(),'(WCMADMIN)')]

        //timeZone
        public ISeleniumButtonService TimeZoneText = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//span[@class='timeZone ng-binding']");

        #endregion


        public HomePage(TestInputCache testInputCache) : base(testInputCache)
        {

        }


        #region Methods

        public bool VerifyHomePageIsLoaded()
        {
            return leftSideBar.IsVisible(_driver);
        }
        public int AvailableOptions()
        {

            new Actions(_driver).MoveToElement(_driver.FindElement(By.XPath("//*[@id='nav']/nav/ul")), 0, 0).Build().Perform();
            Delay(1);
            IList<IWebElement> DmElementsCount = _driver.FindElements(By.XPath("//*[@id='nav']/nav/ul/div"));

            return DmElementsCount.Count;
        }

        public void VerifyLogout()
              //public string VerifyLogout()
        {

            //Click on Logout button
            rightsideoption.Click(_driver);
            logoutButton.Click(_driver);
            Delay(1);
            //return _driver.Url;

        }

        //verify the about us Details
        public bool VerfiyAboutUsDetails()
        {
            rightsideoption.Click(_driver);
            aboutusoption.Click(_driver);
            Delay(1);
            string aboutusText = aboutusscreen.Text(_driver);
            _driver.FindElement(By.XPath("//div[contains(.,'About us')]//button[contains(.,'close')]")).Click();
            Delay(1);
            var expectedaboutUsText = GetTestDataByFieldName("Aboutusdetails");
            bool verfiyAboutUsDetails = aboutusText.Equals(expectedaboutUsText);
            return verfiyAboutUsDetails;


        }

        //verify the username ,role and TimeZone
        public bool VerifyUserName()
        {
            Delay(2);
            string username = usernameText.Text(_driver);
            var Expectedusername = GetTestDataByFieldName("Expectedusername");
            bool VerifyUserName = username.Equals(Expectedusername);
            return VerifyUserName;
        }
        //verify the role
        public bool VerifyRoleName()
        {
            Delay(2);
            string rolename = rolenameText.Text(_driver);
            var Expectedrolename = GetTestDataByFieldName("Expectedrolename");
            bool VerifyRoleName = rolename.Equals(Expectedrolename);
            Delay(5);
            return VerifyRoleName;
        }
        //verify the TimeZone
        public bool VerifyTimeZoneName()
        {
            Delay(5);
            string timezonename = TimeZoneText.Text(_driver);
            var ExpectedtimeZone = GetTestDataByFieldName("ExpectedtimeZone");
            bool VerifyTimeZoneName = timezonename.Equals(ExpectedtimeZone);
            return VerifyTimeZoneName;
        }
        public void VerifyMaxpermission(int ElementsCount)
        {

            if (ElementsCount != TestCaseConstants.MAX_PERMISSION)
            {
                _testInputCache.Context.TestResult.Add(Tuple.Create(false, "***FAIL: Default user don't have all the permissions. ", 1));
            }
            else
            {
                _testInputCache.Context.TestResult.Add(Tuple.Create(true, "Default user has all the permissions", 1));
            }
        }

        public void NavigateToDashboard()
        {
            new Actions(_driver).MoveToElement(_driver.FindElement(By.XPath("//*[@id='nav']/nav/ul")), 0, 0).Build().Perform();
            Delay(1);

            SelectOptions(1).Click(_driver);
            Delay(1);
            WaitForPageLoad();
        }

        public void NavigateToThemes()
        {
            new Actions(_driver).MoveToElement(_driver.FindElement(By.XPath("//*[@id='nav']/nav/ul")), 0, 0).Build().Perform();
            Delay(1);

            SelectOptions(2).Click(_driver);
            Delay(1);
            WaitForPageLoad();
        }

        public void NavigateToWidgetLibrary()
        {
            new Actions(_driver).MoveToElement(_driver.FindElement(By.XPath("//*[@id='nav']/nav/ul")), 0, 0).Build().Perform();
            Delay(1);

            SelectOptions(3).Click(_driver);
            Delay(1);

            WaitForPageLoad();

            //new Actions(_driver).MoveToElement(_driver.FindElement(By.XPath("html/body/header/div/ul/li[1]"))).Build().Perform();
            //Delay(1);
        }

        public void NavigateToAssets()
        {
            new Actions(_driver).MoveToElement(_driver.FindElement(By.XPath("//*[@id='nav']/nav/ul")), 0, 0).Build().Perform();
            Delay(1);

            SelectOptions(4).Click(_driver);
            Delay(1);
            WaitForPageLoad();
        }

        public void NavigateToUserManagement()
        {
            new Actions(_driver).MoveToElement(_driver.FindElement(By.XPath("//*[@id='nav']/nav/ul")), 0, 0).Build().Perform();
            Delay(1);

            SelectOptions(5).Click(_driver);
            Delay(1);
            WaitForPageLoad();
        }

        public void NavigateToRoleManagement()
        {
            new Actions(_driver).MoveToElement(_driver.FindElement(By.XPath("//*[@id='nav']/nav/ul")), 0, 0).Build().Perform();
            Delay(3);
            SelectOptions(5).Click(_driver);
            Delay(3);
            new Actions(_driver).MoveToElement(_driver.FindElement(By.XPath("//*[@id='nav']/nav/ul")), 0, 0).Build().Perform();
            Delay(2);
            var RoleManagement=( _driver.FindElement(By.XPath("//span[contains(text(),'Role Management')]")));
            RoleManagement.Click();
            Delay(2);
            WaitForPageLoad();
        }
        public void NavigateToSchedule()
        {
            new Actions(_driver).MoveToElement(_driver.FindElement(By.XPath("//*[@id='nav']/nav/ul")), 0, 0).Build().Perform();
            Delay(1);

            SelectOptions(6).Click(_driver);
            Delay(1);
            WaitForPageLoad();
        }

        public void NavigateToThemeManagement()
        {
            new Actions(_driver).MoveToElement(_driver.FindElement(By.XPath("//*[@id='nav']/nav/ul")), 0, 0).Build().Perform();
            Delay(1);

            SelectOptions(7).Click(_driver);
            Delay(1);
            WaitForPageLoad();
        }

        public void NavigateToManage()
        {
            new Actions(_driver).MoveToElement(_driver.FindElement(By.XPath("//*[@id='nav']/nav/ul")), 0, 0).Build().Perform();
            Delay(1);

            SelectOptions(8).Click(_driver);
            Delay(1);
            WaitForPageLoad();
        }

        public void NavigateToGlobalization()
        {
            new Actions(_driver).MoveToElement(_driver.FindElement(By.XPath("//*[@id='nav']/nav/ul")), 0, 0).Build().Perform();
            Delay(1);

            SelectOptions(9).Click(_driver);
            Delay(1);
            WaitForPageLoad();
        }

        public void NavigateToSiteManagement()
        {
            new Actions(_driver).MoveToElement(_driver.FindElement(By.XPath("//*[@id='nav']/nav/ul")), 0, 0).Build().Perform();
            Delay(1);

            SelectOptions(10).Click(_driver);
            Delay(1);
            WaitForPageLoad();
        }

        public void NavigateToOrganizationLevel()
        {
            new Actions(_driver).MoveToElement(_driver.FindElement(By.XPath("//*[@id='nav']/nav/ul")), 0, 0).Build().Perform();
            Delay(1);

            SelectOptions(11).Click(_driver);
            Delay(1);
            WaitForPageLoad();
        }
        public void NavigateToManageMultisite()
        {
            new Actions(_driver).MoveToElement(_driver.FindElement(By.XPath("//*[@id='nav']/nav/ul")), 0, 0).Build().Perform();
            Delay(1);

            SelectOptions(12).Click(_driver);
            Delay(1);
            WaitForPageLoad();
        }

        public void NavigateToGeneralContentSettings()
        {
            new Actions(_driver).MoveToElement(_driver.FindElement(By.XPath("//*[@id='nav']/nav/ul")), 0, 0).Build().Perform();
            Delay(1);

            SelectOptions(13).Click(_driver);
            Delay(1);
            WaitForPageLoad();
        }

        public void NavigateToManageContentServer()
        {
            new Actions(_driver).MoveToElement(_driver.FindElement(By.XPath("//*[@id='nav']/nav/ul")), 0, 0).Build().Perform();
            Delay(1);



            SelectOptions(14).Click(_driver);
            Delay(1);
            WaitForPageLoad();
        }

        #endregion
    }

}
