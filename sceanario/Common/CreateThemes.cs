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
using WCMAutomation.Services.Themes;
using WCMAutomation.Services.ThemeManagement;
using WCMAutomation.Services.WidgetLibrary;
using NUnit.Framework;

namespace WCMAutomation.TestScenarios
{
    [UnicornAttributes.ExecuteTestCase(UnicornEnums.ExecuteType.Execute)]
    [UnicornAttributes.Module((int)Modules.Common)]
    [UnicornAttributes.TestCasePriority(UnicornEnums.Priority.Priority1)]
    public class LoginTestScenario : DriverInitializer
    {
        //A global variables
        ITestDataService testDataService = Factory.UnicornServices.GetTestDataService();
        //IWebDriver _Driver;
        //Context context;
     
        LoginPage LoginPage = null;
        HomePage HomePage = null;
        ThemesPage ThemesPage = null;
        ThemeViewPage ThemeViewPage = null;
        ThemeEditorPage ThemeEditorPage = null;
        ThemeManagementPage ThemeManagementPage = null;
        WidgetLibraryPage WidgetLibraryPage = null;
        WidgetEditorPage WidgetEditorPage = null;
       
        override public void Execute(long testScenarioId, long testCaseId, string testCaseName)
        {
            InitializeWCMApp("CreateThemes",testCaseId);

        
            LoginPage = new LoginPage(testInputCache);
            HomePage = new HomePage(testInputCache);
            ThemesPage = new ThemesPage(testInputCache);
            ThemeViewPage = new ThemeViewPage(testInputCache);
            ThemeEditorPage = new ThemeEditorPage(testInputCache);
            ThemeManagementPage = new ThemeManagementPage(testInputCache);
            WidgetLibraryPage = new WidgetLibraryPage(testInputCache);
            WidgetEditorPage = new WidgetEditorPage(testInputCache);
          
            
            // int AvailableOptionsCount;
            //string[] WidgetName = testDataService.GetFieldValue("WidgetNames").Split(',');
            //String ThemeName = testDataService.GetFieldValue("ThemeName");
            ////String ThemeName = "Auto_Theme";

            // int AvailableOptionsCount;
            string[] WidgetName = LoginPage.GetTestDataByFieldName("WidgetNames").Split(',');
            String ThemeName = LoginPage.GetTestDataByFieldName("ThemeName");
            



            string[] NewWidgetName = new string[WidgetName.Length];
            for (int i=0;i<WidgetName.Length;i++)
            {
                NewWidgetName[i] = ThemeName + "_" + (i + 1).ToString();
            }


            //Login Test scenario : Test Case 1
            LoginPage.Login();
            LoginPage.RoleSiteSelection();
            Assert.IsTrue(HomePage.VerifyHomePageIsLoaded());

          
           // LoginService.VerifyLogin(context);

            //Verify default user has all the permission : Test Case 2
            //CommonMethods.Delay(1);
            //AvailableOptionsCount = HomePageService.AvailableOptions(context);
            //HomePageService.VerifyMaxpermission(AvailableOptionsCount);

            if (ThemeName.Contains("_Edited"))
            {
                //Edit Widgets
                HomePage.NavigateToWidgetLibrary();
               
                for (int i = 0; i < WidgetName.Length; i++)
                {
                    WidgetLibraryPage.DeleteIfWidgetNameIsAlreadyExist(WidgetName[i], NewWidgetName[i]);

                    WidgetLibraryPage.CopyDefaultWidget(WidgetName[i], NewWidgetName[i]);

                    WidgetLibraryPage.EditNewWidget(NewWidgetName[i]);

                    WidgetEditorPage.EditWidget(WidgetName[i], ThemeName);

                  //  WidgetEditorPage.EditIcon(2); // 1 for background 2 for Icon and 3 for video

                }
            }   


            
            //Create a Theme
            HomePage.NavigateToThemes();
            
            String DashBoardType;
            if (ThemeName.Contains("_UC_"))
            {
                DashBoardType = "Un-Carded";
            }
            else
            {
                DashBoardType = " Carded";
            }

           
            for (int i = 0; i < WidgetName.Length; i++)
            {
                WidgetName[i] = WidgetName[i].Trim();
            }

            if (ThemesPage.VerifyThemeNameAlreadyExists(ThemeName))
            {
                ThemesPage.DeleteExistingTheme(ThemeName);
            }
            ThemesPage.CopyDefaultTheme(ThemeName);

            ThemesPage.EditTheme(ThemeName);



            ThemeViewPage.EditDashBoard(DashBoardType, "DM");

            ThemeEditorPage.DeleteWidgets();

            ThemeEditorPage.AddBackGround();

            ThemeEditorPage.AddWidget(ThemeName.Contains("_Edited")?NewWidgetName:WidgetName);

            ThemeViewPage.EditDashBoard(DashBoardType, "LVDS");

            ThemeEditorPage.DeleteWidgets();

            ThemeEditorPage.AddBackGround();

            ThemeEditorPage.AddWidget(ThemeName.Contains("_Edited")?NewWidgetName:WidgetName);



            ThemeViewPage.SubmitForApproval();

            HomePage.NavigateToThemeManagement();

            ThemeManagementPage.ApproveTheme(ThemeName);

            ThemeManagementPage.PublishTheme(ThemeName);

           // ThemesPage.VerifyWhetherThemeCreatedSuccessfully(ThemeName);

        }

        override public List<Tuple<bool, string, int>> Validate(long testScenarioId, long testCaseId, string testCaseName)
        {
            //_Driver.Close();
            //_Driver.Quit();
            return testInputCache.Context.TestResult;
        }



        //LoginPage, HomePage, ThemesPage


    }
}
