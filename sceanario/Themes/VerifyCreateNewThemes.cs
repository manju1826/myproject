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
    public class VerifyCreateNewThemes : DriverInitializer
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

            LoginPage.Login();
            LoginPage.RoleSiteSelection();

            //Navigate to widgetlibrary screen.
            HomePage.NavigateToThemes();

            //Verify Themes page is loaded
            Assert.IsTrue(ThemesPage.VerifyThemesPageIsLoaded());

            //Get the list of Theme we want to copy - excel data
            string[] ThemeName = ThemesPage.GetTestDataByFieldName("ThemeName").Split(',');
            string[] WidgetName = ThemesPage.GetTestDataByFieldName("NewWidgetNames").Split(',');
            string[] PageName = ThemeViewPage.GetTestDataByFieldName("PageName").Split(',');
            string[] PropertyPageName = ThemeViewPage.GetTestDataByFieldName("PropertyName").Split(',');

            //get data from unicorn Db
            // string[] newWidgetName=testDataService.GetFieldValue("WidgetNames").Split(',');

            //Verify themeName Already 
            if(ThemesPage.VerifyThemeNameAlreadyExists(ThemeName[0])==true)
            {       //Delete the theme if exists
                ThemesPage.DeleteExistingTheme(ThemeName[0]);
            }
      

             //Create new theme
            ThemesPage.CreateNewTheme(ThemeName[0]);
            ThemesPage.EditTheme(ThemeName[0]);

            //Add folder and Property Page
            ThemeViewPage.AddNewFolderPage();
            ThemeViewPage.AddNewPropertyPage(PropertyPageName[0]);
            ThemeViewPage.AddNewPropertyPage(PropertyPageName[1]);

            //Edit
            ThemeViewPage.EditDashBoard("Un-Carded", "DM");
            ThemeEditorPage.AddBackGround();
            ThemeEditorPage.AddWidget(WidgetName);

            //carded DM dashboard
            ThemeViewPage.EditDashBoard(" Carded", "DM");
            ThemeEditorPage.AddBackGround();
            ThemeEditorPage.AddWidget(WidgetName);

            ThemeViewPage.EditDashBoard("Un-Carded", "LVDS");
            ThemeEditorPage.AddBackGround();
            ThemeEditorPage.AddWidget(WidgetName);

            ThemeViewPage.EditDashBoard(" Carded", "LVDS");
            ThemeEditorPage.AddBackGround();
            ThemeEditorPage.AddWidget(WidgetName);

            ThemeViewPage.EditDashBoard("FolderPage", "DM");
            //ThemeEditorPage.AddBackGround();
            ThemeEditorPage.AddWidget(WidgetName);

            ThemeViewPage.EditDashBoard("PropertyPage", "LVDS");
            ThemeEditorPage.AddPropertyImage(PropertyPageName[0]);

            ThemeViewPage.SubmitForApproval();

            //Navigate to ThemeManagement screen.
            HomePage.NavigateToThemeManagement();

            ThemeManagementPage.ApproveTheme(ThemeName[0]);

            ThemeManagementPage.PublishTheme(ThemeName[0]);

            ThemeManagementPage.RetireTheme(ThemeName[0]);
     }

        override public List<Tuple<bool, string, int>> Validate(long testScenarioId, long testCaseId, string testCaseName)
        {
            //testInputCache.Driver.Close();
            //testInputCache.Driver.Quit();
            return testInputCache.Context.TestResult;
        }

    }

}

