using System;
using System.Collections.Generic;
using UnicornLibrary.Unicorn.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using WCMAutomation.Utilities;
using WCMAutomation.Services;
using UnicornLibrary.UnicornLogger;
using UnicornLibrary.Unicorn.Factory;
using UnicornLibrary.Unicorn.IServices;
using WCMAutomation.Services.Common;

using NUnit.Framework;

namespace WCMAutomation.TestScenarios
{
    [UnicornAttributes.ExecuteTestCase(UnicornEnums.ExecuteType.Execute)]
    [UnicornAttributes.Module((int)Modules.Common)]
    [UnicornAttributes.TestCasePriority(UnicornEnums.Priority.Priority1)]
    public class VerifyLoginWithValidCredentials : DriverInitializer
    {
        //A global variables
        ITestDataService testDataService = Factory.UnicornServices.GetTestDataService();
        
     
        LoginPage LoginPage = null;
        HomePage HomePage = null;
      
        override public void Execute(long testScenarioId, long testCaseId, string testCaseName)
        {           
            InitializeWCMApp("Login",testCaseId);

            //Initialise Page objects
            LoginPage = new LoginPage(testInputCache);
            HomePage = new HomePage(testInputCache);

            //Login
            LoginPage.Login();
            LoginPage.RoleSiteSelection();

            //Verify login in home page
            Assert.IsTrue(HomePage.VerifyHomePageIsLoaded());

            //Verify username,rolename and timezone
           Assert.IsTrue(HomePage.VerifyUserName());

            //Assert.IsTrue(HomePage.VerifyRoleName());

            //Assert.IsTrue(HomePage.VerifyTimeZoneName());


            //Verify AboutUsscreen
            Assert.IsTrue(HomePage.VerfiyAboutUsDetails());

            //verify logout
            //string URL = HomePage.VerifyLogout();
            HomePage.VerifyLogout();
            //Assert.True(URL.Contains("logout"));

           //URL.EndsWith(TestCaseConstants.CONST_WCMLoginURLEnd);

        }
        

        override public List<Tuple<bool, string, int>> Validate(long testScenarioId, long testCaseId, string testCaseName)
        {
            //testInputCache.Driver.Close();
            //testInputCache.Driver.Quit();
            return testInputCache.Context.TestResult;
        }



    }
}
