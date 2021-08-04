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
    public class VerifyCopyDefaulthemes : DriverInitializer
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
            string[] WidgetName = ThemesPage.GetTestDataByFieldName("NewWidgetNames").Split(',');
            string[] PageName = ThemeViewPage.GetTestDataByFieldName("PageName").Split(',');
           
            //Copy the default theme
            HomePage.NavigateToSchedule();
            if (SchedulePage.VerifyScheduleThemeNameAlreadyExists(ThemeName[2]) == true)
            {
                SchedulePage.DeleteExisitingSchedule(ThemeName[2]);
            }
            HomePage.NavigateToThemes();
            if (ThemesPage.VerifyThemeNameAlreadyExists(ThemeName[2])==true)
            { ThemesPage.DeleteExistingTheme(ThemeName[2]); }
                
             ThemesPage.CopyDefaultTheme(ThemeName[2]);

              //download default Theme
              ThemesPage.DownlaodTheme(ThemeName[2]);

              ThemesPage.VerifyOpendraftClickable();
              //Edit the theme
             ThemesPage.EditTheme(ThemeName[2]);

            //Verify Default Pages available 
            Assert.IsTrue(ThemeViewPage.VerifyDefaultCardedDMIsVisible());
            Assert.IsTrue(ThemeViewPage.VerifyDefaultUnCardedDMIsVisible());
            Assert.IsTrue(ThemeViewPage.VerifyDefaultUnCardedLVDSIsVisible());
            Assert.IsTrue(ThemeViewPage.VerifyDefaultCardedLVDSIsVisible());
            Assert.IsTrue(ThemeViewPage.VerifyDefaultFolderDMIsVisible());
            Assert.IsTrue(ThemeViewPage.VerifyDefaultFolderLVDSIsVisible());
            Assert.IsTrue(ThemeViewPage.VerifyPropertyDMPageIsVisible());
            Assert.IsTrue(ThemeViewPage.VerifyPropertyLVDSPagIsVisible());

                //copy page
                ThemeViewPage.CopyPage(" Carded", "DM", PageName[0]);
                //Assign Rule to copy page
                //Assert.IsTrue(ThemeViewPage.AssignRules("DM", "Copy"));
                ThemeViewPage.CopyPage(" Carded", "LVDS",PageName[1]);
                //Assert.IsTrue(ThemeViewPage.AssignRules("LVDS", "Copy"));
                ThemeViewPage.CopyPage("FolderPage", "DM", PageName[2]);
                ThemeViewPage.CopyPage("Property Page", "LVDS", PageName[3]);
                
            //Edit the copied page
                ThemeViewPage.EditDashBoard("DM", "Copy");
                ThemeEditorPage.DeleteWidgets();
                ThemeEditorPage.AddBackGround();
                ThemeEditorPage.AddWidget(WidgetName);

                ThemeViewPage.EditDashBoard("LVDS", "Copy");
                ThemeEditorPage.DeleteWidgets();
                ThemeEditorPage.AddBackGround();
                ThemeEditorPage.AddWidget(WidgetName);
                ThemeViewPage.SubmitForApproval();
                ThemesPage.VerifyPendingApprovalClickable();
            
                //Navigate to ThemeManagement screen.
                HomePage.NavigateToThemeManagement();

                ThemeManagementPage.ApproveTheme(ThemeName[2]);
                HomePage.NavigateToThemes();
                ThemesPage.VerifyApprovedClickable(ThemeName[2]);
                HomePage.NavigateToThemeManagement();
                ThemeManagementPage.PublishTheme(ThemeName[2]);
                HomePage.NavigateToThemes();
                ThemesPage.VerifyOpendraftClickable();
                ThemesPage.VerifyAllButtonClickable();
            if (ThemesPage.VerifyThemeNameAlreadyExists(ThemeName[3]) == true)
            { 
             ThemesPage.DeleteExistingTheme(ThemeName[3]);
            }
            ThemesPage.VerifyPublishedClickable(ThemeName[2]);
            //ThemesPage.VerifyShareTheme(ThemeName[2]);
         
     }

        override public List<Tuple<bool, string, int>> Validate(long testScenarioId, long testCaseId, string testCaseName)
        {
            //testInputCache.Driver.Close();
            //testInputCache.Driver.Quit();
            return testInputCache.Context.TestResult;
        }

    }

}

