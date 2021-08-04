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
    public class VerifyUploadThemes : DriverInitializer

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

            //Navigate to Themes screen.
            HomePage.NavigateToThemes();

            //Verify Themes page is loaded
            Assert.IsTrue(ThemesPage.VerifyThemesPageIsLoaded());

             //Get the list of Theme we want to copy - excel data
            string[] ThemeName = ThemesPage.GetTestDataByFieldName("ThemeName").Split(',');
            //Get the list of widget we wan to copy - excel data
            string[] WidgetName = WidgetLibraryPage.GetTestDataByFieldName("WidgetNamesForDMTheme").Split(',');
            string[] PageName = ThemeViewPage.GetTestDataByFieldName("PageName").Split(',');

            //upload theme
            if (ThemesPage.VerifyThemeNameAlreadyExists(ThemeName[1])==true)
            { ThemesPage.DeleteExistingTheme(ThemeName[1]);
            }
            Assert.True(ThemesPage.uploadTheme(ThemeName[1]));
            ThemesPage.EditTheme(ThemeName[1]);

            //copy and delete page
            Assert.True(ThemeViewPage.CopyPage(" Carded", "DM", PageName[0]));
            Assert.True(ThemeViewPage.DeletePage("DM", "Copy"));
            //Assert.True(ThemeViewPage.CopyPage(" Carded", "LVDS", PageName[1]));
            //Assert.True(ThemeViewPage.DeletePage("LVDS", "Copy"));
            //Assert.True(ThemeViewPage.CopyPage("FolderPage", "DM", PageName[2]));
            //Assert.True(ThemeViewPage.DeletePage("Folder", "Copy"));
            //Assert.True(ThemeViewPage.CopyPage("Property Page", "LVDS", PageName[3]));
            //Assert.True(ThemeViewPage.DeletePage("Property", "Copy"));

            //ThemeViewPage.EditDashBoard(" Carded", "DM");
            //ThemeEditorPage.DeleteWidgets();
            //ThemeEditorPage.AddBackGround();
            //ThemeEditorPage.AddWidget(WidgetName);
            //WidgetEditorPage.EditAllWidget();
            //ThemeViewPage.EditDashBoard("Un-Carded", "DM");
            //ThemeEditorPage.DeleteWidgets();
            //ThemeEditorPage.AddBackGround();
            //ThemeEditorPage.AddWidget(WidgetName);
            //ThemeViewPage.EditDashBoard(" Carded", "LVDS");
            //ThemeEditorPage.DeleteWidgets();
            //ThemeEditorPage.AddBackGround();
            //ThemeEditorPage.AddWidget(WidgetName);
            //ThemeViewPage.EditDashBoard("FolderPage", "DM");
            //ThemeEditorPage.DeleteWidgets();
            //ThemeEditorPage.AddBackGround();
            //ThemeEditorPage.AddWidget(WidgetName);
            //ThemeViewPage.EditDashBoard("FolderPage", "LVDS");
            //ThemeEditorPage.DeleteWidgets();
            //ThemeEditorPage.AddBackGround();
            //ThemeEditorPage.AddWidget(WidgetName);

            ThemeViewPage.SubmitForApproval();
            HomePage.NavigateToThemeManagement();
            ThemeManagementPage.ApproveTheme(ThemeName[1]);
            ThemeManagementPage.PublishTheme(ThemeName[1]);

            //Verify user is able to edit theme ,which is already published.
            HomePage.NavigateToThemes();
            ThemesPage.EditTheme(ThemeName[1]);
            ThemeViewPage.EditDashBoard(" Carded", "DM");
            ThemeEditorPage.DeleteWidgets();
            ThemeEditorPage.AddBackGround();
            ThemeEditorPage.AddWidget(WidgetName);
            ThemeViewPage.SubmitForApproval();
            HomePage.NavigateToThemeManagement();
            ThemeManagementPage.ApproveTheme(ThemeName[1]);
            ThemeManagementPage.PublishTheme(ThemeName[1]);


        }

        override public List<Tuple<bool, string, int>> Validate(long testScenarioId, long testCaseId, string testCaseName)
        {
            //testInputCache.Driver.Close();
            //testInputCache.Driver.Quit();
            return testInputCache.Context.TestResult;
        }

    }

}

