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
using WCMAutomation.Services.WidgetLibrary;
using WCMAutomation.Services.Themes;
using WCMAutomation.Services.ThemeManagement;

namespace WCMAutomation.TestScenarios
{
    [UnicornAttributes.ExecuteTestCase(UnicornEnums.ExecuteType.Execute)]
    [UnicornAttributes.Module((int)Modules.Common)]
    [UnicornAttributes.TestCasePriority(UnicornEnums.Priority.Priority1)]
    public class VerifyShareTheme : DriverInitializer

    {
        //A global variables
        ITestDataService testDataService = Factory.UnicornServices.GetTestDataService();


        LoginPage LoginPage = null;
        HomePage HomePage = null;
        WidgetLibraryPage WidgetLibraryPage = null;
        WidgetEditorPage WidgetEditorPage = null;
        ThemesPage ThemesPage = null;
        ThemeViewPage ThemeViewPage = null;
        ThemeEditorPage ThemeEditorPage = null;
        ThemeManagementPage ThemeManagementPage = null;
        SchedulePage SchedulePage = null;
        override public void Execute(long testScenarioId, long testCaseId, string testCaseName)
        {
            InitializeWCMApp("Login", testCaseId);

            //Initialise Page objects
            LoginPage = new LoginPage(testInputCache);
            HomePage = new HomePage(testInputCache);
            WidgetLibraryPage = new WidgetLibraryPage(testInputCache);
            WidgetEditorPage = new WidgetEditorPage(testInputCache);
            ThemesPage = new ThemesPage(testInputCache);
            ThemeViewPage = new ThemeViewPage(testInputCache);
            ThemeEditorPage = new ThemeEditorPage(testInputCache);
            ThemeManagementPage = new ThemeManagementPage(testInputCache);
            SchedulePage = new SchedulePage(testInputCache);
            LoginPage.Login();
            LoginPage.RoleSiteSelection();

            //Navigate to Themes screen.
            HomePage.NavigateToThemes();

            //Verify Themes page is loaded
            Assert.IsTrue(ThemesPage.VerifyThemesPageIsLoaded());

             //Get the list of Theme we want to copy - excel data
            string[] ThemeName = ThemesPage.GetTestDataByFieldName("ThemeName").Split(',');
            //Get the list of widget we wan to copy - excel data
            string[] WidgetName = WidgetLibraryPage.GetTestDataByFieldName("WidgetNamesForDMTheme").Split(',');
            string[] PageName = ThemeViewPage.GetTestDataByFieldName("PageName").Split(',');

           
            if (ThemesPage.VerifyThemeNameAlreadyExists(ThemeName[11])==true)
            { ThemesPage.DeleteExistingTheme(ThemeName[11]);
            }
            ThemesPage.CopyDefaultTheme(ThemeName[11]);
            ThemesPage.EditTheme(ThemeName[11]);
            ThemeViewPage.SubmitForApproval();
            HomePage.NavigateToThemeManagement();
            ThemeManagementPage.ApproveTheme(ThemeName[11]);
            ThemeManagementPage.PublishTheme(ThemeName[11]);

            HomePage.NavigateToThemes();
            ThemesPage.VerifyShareTheme(ThemeName[11]);
            ThemesPage.EditTheme(ThemeName[11]);
            ThemeViewPage.SubmitForApproval();
            HomePage.NavigateToThemeManagement();
            ThemeManagementPage.ApproveTheme(ThemeName[11]);
            ThemeManagementPage.PublishTheme(ThemeName[11]);
            HomePage.NavigateToSchedule();

            if (SchedulePage.VerifyScheduleThemeNameAlreadyExists(ThemeName[11]) == true)
            {
                SchedulePage.DeleteExisitingSchedule(ThemeName[11]);
            }

            Assert.True(SchedulePage.AddSchedule());


        }

        override public List<Tuple<bool, string, int>> Validate(long testScenarioId, long testCaseId, string testCaseName)
        {
            //testInputCache.Driver.Close();
            //testInputCache.Driver.Quit();
            return testInputCache.Context.TestResult;
        }

    }

}

