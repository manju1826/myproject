using OpenQA.Selenium;
using System;
using System.Collections.Generic;



using OpenQA.Selenium.Support.UI;
using WCMAutomation.Utilities;
using OpenQA.Selenium.Interactions;
using UnicornLibrary.Selenium.BaseClasses;
using UnicornLibrary.Unicorn.Factory;
using UnicornLibrary.Unicorn.IServices;
using UnicornLibrary.UnicornLogger;

using UnicornLibrary.Unicorn.IServices.IElementServices.ISeleniumService;
using WCMAutomation.UIAutomation.Core;
using UnicornLibrary.Unicorn.Utilities;

namespace WCMAutomation.Services.Themes
{
    class ThemesPage : BasePage
    {

        #region Elements
        private ISeleniumButtonService pageTitleText = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//div[@class='page_title']/span[contains(text(),'Themes')]");
        public ISeleniumButtonService AllThemeButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//md-tab-item[contains(.,'All')]");
        public ISeleniumButtonService OpenDraftButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//md-tab-item[contains(.,'Open Draft')]");
        public ISeleniumButtonService PendingApprovalButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//md-tab-item[contains(.,'Pending Approval')]");
        public ISeleniumButtonService ApprovedButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//md-tab-item[contains(.,'Approved')]");
        public ISeleniumButtonService PublishedButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//md-tab-item[contains(.,'Published')]");
        public ISeleniumButtonService RetiredButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//md-tab-item[contains(.,'Retired')]");
        public ISeleniumButtonService RestoredButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//md-tab-item[contains(.,'Restored')]");
        public ISeleniumButtonService SharedTabButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//md-tab-item[contains(.,'Shared')]");
        public ISeleniumButtonService ShareButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//button[contains(.,'Share')]");
        public ISeleniumButtonService SwitchSiteButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//button[@aria-owns='menu_container_1']");
        public ISeleniumButtonService AcceptButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//button[contains(.,' Accept')]");
        public ISeleniumTextBoxService AcceptCommentTextBox = Factory.ElementServices.GetWebTextBox(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//textarea[@name='txtacceptancecmds']", UnicornEnums.WebTextBoxControl.WebTextBox);
        public ISeleniumButtonService SubmitButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//*[@name='formthemeacceptancecmds']//*[span[text()='Submit']]");
        public ISeleniumTextBoxService NewThemeTextBox = Factory.ElementServices.GetWebTextBox(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//input[@name='newthemename']", UnicornEnums.WebTextBoxControl.WebTextBox);
        public ISeleniumButtonService NewThemeButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//button[contains(.,'New Theme')]");
        public ISeleniumButtonService OverrideButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//button//*[contains(text(),'Override')]/..");

        public ISeleniumButtonService ConfirmDeleteButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//button//*[contains(text(),'Delete')]/..");
        public ISeleniumButtonService DefaultThemeCopyButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//*[@id='themeUtilityHeader']/div/div/div/div[contains(text(),'Copy')]");
        public ISeleniumTextBoxService ThemeNameTextBox = Factory.ElementServices.GetWebTextBox(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//*[contains(text(),'Copy Theme')]/../../../md-content//*[contains(text(),'Theme Name')]/../input", UnicornEnums.WebTextBoxControl.WebTextBox);
        public ISeleniumButtonService CreateThemeButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//*[contains(text(),'Copy Theme')]/../../../md-content//button");
        public ISeleniumButtonService CreateNeWThemeButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//*[@id='themeUtilityHeader']/div/div/div/div[contains(text(),'Create')]");
        //Create New Theme Elements
        public ISeleniumTextBoxService CreateNeWThemeNameTextBox = Factory.ElementServices.GetWebTextBox(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//*[contains(text(),'Create New Theme')]/../../../md-content//*[contains(text(),'Theme Name')]/../input", UnicornEnums.WebTextBoxControl.WebTextBox);
        public ISeleniumButtonService DMPageButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//img[@src='Admin/Assets/PageLayout/DM DashBoard.png']");
        public ISeleniumButtonService LVDSPageButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//img[@src='Admin/Assets/PageLayout/LVDS Dashboard.png']");
        public ISeleniumButtonService CreateButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//button[@data-ng-click='createnewtheme()']");
        //upload Theme
        public ISeleniumButtonService UploadThemeButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//*[@id='themeUtilityHeader']/div/div/div/div[contains(text(),'Upload')]");
        public ISeleniumTextBoxService ChooseButtonButton = Factory.ElementServices.GetWebTextBox(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//input[@id='FileThemeUpload']", UnicornEnums.WebTextBoxControl.WebTextBox);
        public ISeleniumTextBoxService UploadThemeNameTextBox = Factory.ElementServices.GetWebTextBox(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//*[contains(text(),'Theme Upload')]/../../../md-content//*[contains(text(),'Theme Name')]/../input", UnicornEnums.WebTextBoxControl.WebTextBox);
        public ISeleniumButtonService SubmitUploadButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//*[@name='themeuploadform']//*[span[text()='Submit']]");

        public ISeleniumButtonService CopyThemeButton(String ThemeName)
        {
                ISeleniumButtonService CopyThemeButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//div[contains(.,'" + ThemeName + "')]/../../../div[2]/button/*[contains(text(),'content_copy')]/..");
        return CopyThemeButton;
    }
        public ISeleniumButtonService ThemeNameElement(String ThemeName)    
        {
            ISeleniumButtonService ThemeNameElement = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//div[contains(.,'" + ThemeName + "')]/../../../div[2]/button[2]/../..");
            return ThemeNameElement;
        }
        public ISeleniumButtonService ThemeDeleteButton(String ThemeName)
        {
            //ISeleniumButtonService ThemeDeleteButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//div[contains(.,'"+ThemeName+"')]/../../../div[2]/button[4]");
            ISeleniumButtonService ThemeDeleteButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//div[contains(.,'" + ThemeName + "')]/../../../div[2]/button/*[contains(text(),'delete')]/..");
            return ThemeDeleteButton;
        }
        public ISeleniumButtonService ThemeEditButton(String ThemeName)
        {
            ISeleniumButtonService ThemeEditButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//div[contains(.,'" + ThemeName + "')]/../../../div[2]/button/*[contains(text(),'mode_edit')]/..");
            return ThemeEditButton;
        }


        public ISeleniumButtonService ThemeDownloadButton(String ThemeName)
        {
            ISeleniumButtonService ThemeDownloadButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//div[contains(.,'" + ThemeName + "')]/../../../div[2]/button/*[contains(text(),'file_download')]/..");
            return ThemeDownloadButton;
        }

        public ISeleniumButtonService ShareThemeButton(String ThemeName)
        {
            ISeleniumButtonService ShareThemeButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//div[contains(.,'" + ThemeName + "')]/../../../div[2]/button/*[contains(text(),'share')]/..");
            return ShareThemeButton;
        }
        public ISeleniumButtonService SelectSiteOptions(int i) 
        {
            ISeleniumButtonService SelectSiteOptions = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//div[contains(@class,'theme-list')]//div[@class='ng-scope'][" + i + "]/md-checkbox");
            return SelectSiteOptions;
        }
        public ISeleniumButtonService SiteOptions(int i)
        {
            ISeleniumButtonService SiteOptions = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//div[contains(@class,'_md md-open-menu-container')]//md-menu-item[@class='ng-scope'][" + i + "]/button");
            return SiteOptions;
        }
        public ISeleniumButtonService PreviewShareThemeButton(String ThemeName)
        {
            ISeleniumButtonService PreviewShareThemeButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//div[contains(.,'" + ThemeName + "')]/../../../div[2]/button/*[contains(text(),'visibility')]/..");
            return PreviewShareThemeButton;
        }
        #endregion

        public ThemesPage(TestInputCache testInputCache) : base(testInputCache)
        {

        }


        #region Methods
        public bool VerifyThemesPageIsLoaded()
        {
            Delay(1);
            return pageTitleText.IsVisible(_driver);
         
        }

        public void VerifyAllButtonClickable()
        {
            PendingApprovalButton.Click(_driver);
            WaitForPageLoad();
            AllThemeButton.Click(_driver);
            WaitForPageLoad();
            Delay(1);
    
        }

        public void VerifyOpendraftClickable()
        {
            PendingApprovalButton.Click(_driver);
            WaitForPageLoad();
            OpenDraftButton.Click(_driver);
            WaitForPageLoad();
            Delay(1);
        }

        public void VerifyPendingApprovalClickable()
        {
            Delay(2);
            PendingApprovalButton.Click(_driver);
            WaitForPageLoad();
            Delay(1);
        }

        public void VerifyApprovedClickable(String ThemeName)
        {
            ApprovedButton.Click(_driver);
            WaitForPageLoad();
            Delay(1);
            _driver.FindElement(By.XPath("//span[@class='themename_box_cont  ng-binding' and contains(text(),'" + ThemeName + "')]"));
            ThemeDownloadButton(ThemeName).Click(_driver);
            Delay(1);
            WaitForPageLoad();
            Delay(1);
        }

        public void VerifyPublishedClickable(String ThemeName)
        {
            PublishedButton.Click(_driver);
            WaitForPageLoad();
            Delay(1);
            ScrollToElement(_driver.FindElement(By.XPath("//span[@class='themename_box_cont  ng-binding' and contains(text(),'" + ThemeName + "')]")));
            CopyThemeButton(ThemeName).Click(_driver);
            Delay(1);
            ThemeNameTextBox.EnterText(_driver, "CopyEXISTINGTHEME");
            CreateThemeButton.Click(_driver);
            WaitForPageLoad();
            WaitForSave();
            Delay(1);
        }
         public void VerifyShareTheme(String ThemeName)
        {
            PublishedButton.Click(_driver);
            WaitForPageLoad();
            Delay(1);
            if (ShareThemeButton(ThemeName).IsEnabled(_driver))
            {

                ShareThemeButton(ThemeName).Click(_driver);
                Delay(1);
                SelectSiteOptions(3).Click(_driver);
                Delay(1);
                ShareButton.Click(_driver);
                WaitForPageLoad();
                SwitchSiteButton.Click(_driver);
                SiteOptions(3).Click(_driver);
                WaitForPageLoad();
                Delay(1);
                AllThemeButton.Click(_driver);
                Delay(1);
                if (VerifyThemeNameAlreadyExists("ShareTheme") == true)
                {
                    DeleteExistingTheme("ShareTheme");
                }
                SharedTabButton.Click(_driver);
                WaitForPageLoad();
                Delay(1);
                PreviewShareThemeButton(ThemeName).Click(_driver);
                WaitForPageLoad();
                AcceptButton.Click(_driver);
                AcceptCommentTextBox.EnterText(_driver, "Accepted Shared theme");
                SubmitButton.Click(_driver);
                WaitForPageLoad();
                if (OverrideButton.IsVisible(_driver))
                    {
                    NewThemeTextBox.EnterText(_driver, "ShareTheme2");
                    NewThemeButton.Click(_driver);
                    WaitForPageLoad();
                    AllThemeButton.Click(_driver);
                    WaitForPageLoad();
                }
            }
            else
            {
                AllThemeButton.Click(_driver);
            }
        }
        public void CreateNewTheme(String ThemeName)
            {

            _driver.Manage().Timeouts().ImplicitWait =TimeSpan.FromSeconds(5);
            CreateNeWThemeButton.Click(_driver);
            Delay(1);
            CreateNeWThemeNameTextBox.EnterText(_driver, ThemeName);
            Delay(1 / 100);
            DMPageButton.Click(_driver);
            LVDSPageButton.Click(_driver);
            CreateButton.Click(_driver);
            WaitForPageLoad();
            Delay(15);
       

        }
        public Boolean VerifyThemeNameAlreadyExists(String ThemeName)
        {

            //new Actions(_driver).MoveToElement(_driver.FindElement(By.XPath("html/body/header/div/ul/li[1]"))).Build().Perform();
            //Delay(1);
            //while (_driver.PageSource.Contains("Loading...")) { };
            //Delay(1);

            //AllThemeButton.Click(_driver);
            //var li = _driver.FindElement(By.XPath("//*[@id='pagewrapper']/div[3]/md-tabs/md-tabs-wrapper/md-tabs-canvas/md-pagination-wrapper/md-tab-item[1]"));            
            //li.Click();
            //while (_driver.PageSource.Contains("Loading...")) { };
            //Delay(3);
            Delay(2);
            PublishedButton.Click(_driver);
            Delay(1);
            AllThemeButton.Click(_driver);
            WaitForPageLoad();
            _driver.Manage().Timeouts().ImplicitWait =TimeSpan.FromSeconds(5);
            IList<IWebElement> list = _driver.FindElements(By.XPath("//div[contains(.,'"+ThemeName +"')]"));
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            if (list.Count > 0)
            {
                Delay(2);
                return true;
            }
            else return false;
        }

        public void DeleteExistingTheme( String ThemeName)
        {
            //ScrollToElement( _driver.FindElement(By.XPath("//div[contains(.,'" + ThemeName + "')]/../../../div[2]/button/*[contains(text(),'delete')]/../..")));
            //ScrollToElement(_driver.FindElement(By.XPath("//div[contains(.,'" + ThemeName + "')]")));
            Delay(1);
         // _driver.FindElement(By.XPath("//span[@class='themename_box_cont  ng-binding' and contains(text(),'" + ThemeName + "')]"));
            ScrollToElement(_driver.FindElement(By.XPath("//span[@class='themename_box_cont  ng-binding' and contains(text(),'" + ThemeName + "')]")));

            if (_driver.PageSource.Contains(ThemeName))
                Delay(1);
            {
                ThemeDeleteButton(ThemeName).Click(_driver);
                Delay(1);

                ConfirmDeleteButton.Click(_driver);
                Delay(2);
                WaitForPageLoad();
                Delay(2);
            }
         
        }

        


        public void CopyDefaultTheme( String ThemeName)
        {
            WaitForPageLoad();          
            DefaultThemeCopyButton.Click(_driver);
            Delay(2);

            ThemeNameTextBox.EnterText(_driver,ThemeName);
            Delay(1/100);

            CreateThemeButton.Click(_driver);
            new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='loading_text']/..")));
            WaitForPageLoad();
            Delay(2);

            /*WaitForSave(context);*/ //wait for the save toast message
        }

        public void DownlaodTheme(String ThemeName)
        {
            ScrollToElement(_driver.FindElement(By.XPath("//span[@class='themename_box_cont  ng-binding' and contains(text(),'" + ThemeName + "')]")));
            Delay(1);

            ThemeDownloadButton(ThemeName).Click(_driver);
            Delay(1);
            WaitForPageLoad();
            Delay(1);

        }
        public bool uploadTheme(String ThemeName)
        {
            WaitForPageLoad();
            UploadThemeButton.Click(_driver);
            WaitForPageLoad();
            Delay(1);
            ChooseButtonButton.EnterText(_driver, @"C:\Users\mtripathi\Downloads\Upload\UploadDefault.zip");
            //ChooseButtonButton.EnterText(_driver, @"C:\Users\kamreshbabu1.old\Downloads\UploadDefault.zip");
            Delay(1);
            SubmitUploadButton.Click(_driver);
            WaitForPageLoad();
            string MessageOnUpload= WaitForToastMessage();
            var ExpectedUploadMessage = GetTestDataByFieldName("ExpectedUploadMessage");
            bool VerifyUploadMessage = MessageOnUpload.Contains(ExpectedUploadMessage);
            return VerifyUploadMessage;
        }

        public void EditTheme( String ThemeName)
        {
            //ScrollToElement( _driver.FindElement(By.XPath("//div[contains(.,'" + ThemeName + "')]/../../../div[2]/button/*[contains(text(),'mode_edit')]/..")));
            ScrollToElement(_driver.FindElement(By.XPath("//span[@class='themename_box_cont  ng-binding' and contains(text(),'" + ThemeName + "')]")));
            Delay(1);

            ThemeEditButton(ThemeName).Click(_driver);
            Delay(1);
            WaitForPageLoad();
            Delay(1);
        }

        public void VerifyWhetherThemeCreatedSuccessfully( String ThemeName)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            IList<IWebElement> list = _driver.FindElements(By.XPath("//span[@class='themename_box_cont  ng-binding' and contains(text(),'" + ThemeName + "')]"));
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            if (list.Count > 0)
            {
                _testInputCache.Context.TestResult.Add(Tuple.Create(true, "\"" + ThemeName + "\": Theme Created Successfully", 1));
            }

            else
            {
                _testInputCache.Context.TestResult.Add(Tuple.Create(false, "***FAIL:\""+ThemeName+"\": Theme Creation failed due to unexpeted error", 1));
            }

        }


        #endregion

    }




}
