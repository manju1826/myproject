using OpenQA.Selenium;
using System;
using System.Collections.Generic;



using WCMAutomation.Utilities;
using OpenQA.Selenium.Interactions;
using UnicornLibrary.Selenium.BaseClasses;
using UnicornLibrary.Unicorn.Factory;
using UnicornLibrary.Unicorn.IServices;
using UnicornLibrary.UnicornLogger;
using OpenQA.Selenium.Support.UI;
using UnicornLibrary.Unicorn.IServices.IElementServices.ISeleniumService;
using WCMAutomation.UIAutomation.Core;
using UnicornLibrary.Unicorn.Utilities;


namespace WCMAutomation.Services.Themes
{
    class ThemeViewPage : BasePage
    {

        #region Elements

        public ISeleniumButtonService SubmitForApprovalButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//*[contains(text(),' Submit for Approval')]/..");

        //public ISeleniumButtonService CommentsSubmitlButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//*[1][contains(text(),'Submit')]/..");
        public ISeleniumButtonService CommentsSubmitlButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//form[@name='formcmds']/div[@class='pagewrapper']/button/span[contains(text(),'Submit')]/..");

        //public ISeleniumTextBoxService SubmitForApprovalCommentTextBox = Factory.ElementServices.GetWebTextBox(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//div[@class='pagewrapper']//textarea", UnicornEnums.WebTextBoxControl.WebTextBox);
        public ISeleniumTextBoxService SubmitForApprovalCommentTextBox = Factory.ElementServices.GetWebTextBox(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//textarea[@name='txtcmd']", UnicornEnums.WebTextBoxControl.WebTextBox);


        public ISeleniumButtonService EditPageElement(String DashboardType, String PageType)
        {
            // ISeleniumButtonService EditPageElement = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//*[@id='" + (DashboardType == "carded" ? "pagegroupcardeddashboard" : "pagegroupun-cardeddashboard") + "']//*[contains(.,'"+PageType+"')]//button[contains(.,'mode_edit')]");
            // ISeleniumButtonService EditPageElement = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//div[contains(text(),'" + (DashboardType == "Carded" ? " Carded" : "Un-Carded") + " " + PageType + "')]/../../../div/button[contains(.,'mode_edit')]");
            ISeleniumButtonService EditPageElement = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//div[contains(text(),'" + DashboardType + " " + PageType + "')]/../../../div/button[contains(.,'mode_edit')]");
            
            return EditPageElement;
        }

        public ISeleniumButtonService EditPageNotification(String NotificationType, String PageType)
        {
            ISeleniumButtonService EditPageNotification = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//div[contains(text(),'" + NotificationType + " " + PageType + "')]/../../../div/button[contains(.,'mode_edit')]");

            return EditPageNotification;
        }
        public ISeleniumButtonService CopyPageElement(String DashboardType, String PageType)
        { 
            ISeleniumButtonService CopyPageElement = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//div[contains(text(),'" + DashboardType + " " + PageType + "')]/../../../div/button[contains(.,'content_copy')]");
            return CopyPageElement;
        }

        public ISeleniumButtonService RulesButtonElement(String DashboardType, String PageType)
        {
            ISeleniumButtonService RulesButtonElement = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//div[contains(text(),'" + DashboardType + " " + PageType + "')]/../../../div/button[contains(.,'playlist_add_check')]");
            
            return RulesButtonElement;
        }

         //rule sync screen
        public ISeleniumButtonService RuleSyncbutton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//button/md-icon");
        ////md-icon/i[contains(text(),'sync')]
        public ISeleniumButtonService DeleteButtonElement(String DashboardType, String PageType)
        {
            ISeleniumButtonService DeleteButtonElement = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//div[contains(text(),'" + DashboardType + " " + PageType + "')]/../../../div/button[contains(.,'delete')]");

            return DeleteButtonElement;
        }
        public ISeleniumButtonService DeletePageConfirmButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//button[contains(.,'Delete')]");

        //Add new page button
        public ISeleniumButtonService AddNewPagebutton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//button/span[contains(text(),'Add New Page')]");
        public ISeleniumTextBoxService PageNameTextBox = Factory.ElementServices.GetWebTextBox(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//input[@name='ThemePageName']", UnicornEnums.WebTextBoxControl.WebTextBox);
        public ISeleniumButtonService NewPageType = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//md-select[@placeholder='Select']");
        public ISeleniumButtonService DMPageButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//img[@src='Admin/Assets/PageLayout/DM DashBoard.png']");
        public ISeleniumButtonService CreatePageButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//button[@data-ng-click='PageViewViewModel.createlayout();']");
        public ISeleniumButtonService LVDSPageButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//img[@src='Admin/Assets/PageLayout/LVDS Property.png']");
        public ISeleniumTextBoxService CopyPageNameTextBox = Factory.ElementServices.GetWebTextBox(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//input[@name='pageName']", UnicornEnums.WebTextBoxControl.WebTextBox);
        public ISeleniumButtonService CreateCopyPageButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//button/span[contains(text(),'Create page')]");
        // club selection
        public ISeleniumButtonService SelectClubOptions(int i) 
        {
            ISeleniumButtonService SelectClubOptions = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//div[contains(text(),'Club Level')]/../div[@layout='row']/div[" + i + "]/md-checkbox");
            return SelectClubOptions;
        }

        //Playertag  selection
        public ISeleniumButtonService PlayerTagCheckboxButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//div[div[contains(text(),'Player Tags')]]//md-checkbox[@aria-label='Select ALL']");
        public ISeleniumButtonService ApplyRuleButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//button[@data-ng-click='PageViewViewModel.applyrules()']");

        //default pages
        public ISeleniumButtonService DefaultCardedDMPage = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//div[@class='pagelayout_cont ng-scope']//div[contains(.,'Default Carded DM')]");
        public ISeleniumButtonService DefaultUnCardedDMPage = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//div[@class='pagelayout_cont ng-scope']//div[contains(.,'Default Un-Carded DM')]");
        public ISeleniumButtonService FolderPageDM = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//div[@class='pagelayout_cont ng-scope']//div[contains(.,'FolderPage DM')]");
        public ISeleniumButtonService DefaultCardedLVDSPage = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//div[@class='pagelayout_cont ng-scope']//div[contains(.,'Default Carded LVDS')]");
        public ISeleniumButtonService DefaultUnCardedLVDSPage = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//div[@class='pagelayout_cont ng-scope']//div[contains(.,'Default Un-Carded LVDS')]");
        public ISeleniumButtonService FolderPageLVDS = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//div[@class='pagelayout_cont ng-scope']//div[contains(.,'FolderPage LVDS')]");
        public ISeleniumButtonService PropertyPageDM = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//div[@class='pagelayout_cont ng-scope']//div[contains(.,'Property Page DM')]");
        public ISeleniumButtonService PropertyPageLVDS = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//div[@class='pagelayout_cont ng-scope']//div[contains(.,'Property Page LVDS')]");



        #endregion

        public ThemeViewPage(TestInputCache testInputCache) : base(testInputCache)
        {
            
        }

        #region Methods

       

        public void EditDashBoard( String DashboardType, String PageType)
        {
            ScrollToElement(_driver.FindElement(By.XPath("//div[contains(text(),'" + DashboardType + " " + PageType + "')]/../../../div/button[contains(.,'mode_edit')]")));
            EditPageElement(DashboardType, PageType).Click(_driver);
            //WaitForPageLoad();
            Delay(1);
        }

        public void SubmitForApproval()
        {
            Delay(5);
            SubmitForApprovalButton.Click(_driver);
            Delay(1/100);
            SubmitForApprovalCommentTextBox.EnterText(_driver,"Submit for Approval");
            Delay(1 / 100);
            CommentsSubmitlButton.Click(_driver);
            Delay(1);
            WaitForPageLoad();

        }

        public void AddNewFolderPage()
        {
            
            WaitForPageLoad();
            AddNewPagebutton.Click(_driver);
            Delay(1 / 100);
            PageNameTextBox.EnterText(_driver, GetTestDataByFieldName("FolderName"));
            Delay(1 / 100);
            NewPageType.Click(_driver);
            //select folder page
            new WebDriverWait(_driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//md-option/div[contains(text(),'Folder Page')]"))).Click();
            DMPageButton.Click(_driver);
            Delay(1 / 100);
            CreatePageButton.Click(_driver);
            Delay(1);
            WaitForPageLoad();
         }

        public void AddNewPropertyPage(string PropertyPageName)
        {

            WaitForPageLoad();
            AddNewPagebutton.Click(_driver);
            Delay(1 / 100);
            PageNameTextBox.EnterText(_driver, PropertyPageName);
            Delay(1 / 100);
            NewPageType.Click(_driver);
            //select Property page
            new WebDriverWait(_driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//md-option/div[contains(text(),'Property Page')]"))).Click();
            LVDSPageButton.Click(_driver);
            Delay(1 / 100);
            CreatePageButton.Click(_driver);
            Delay(1);
            WaitForPageLoad();
        }

        public bool CopyPage(String DashboardType, String PageType,String PageName)
        {

            ScrollToElement(_driver.FindElement(By.XPath("//div[contains(text(),'" + DashboardType + " " + PageType + "')]/../../../div/button[contains(.,'content_copy')]")));
            Delay(2);
            CopyPageElement(DashboardType, PageType).Click(_driver);
            Delay(1);
            CopyPageNameTextBox.EnterText(_driver,PageName);
            CreateCopyPageButton.Click(_driver);
            WaitForPageLoad();
            bool MessageVerify = WaitForToastMessage().Contains("Page created");
            WaitForSave();
            Delay(1);
            return MessageVerify;

        }

        public bool DeletePage(String DashboardType, String PageType)
        {

            ScrollToElement(_driver.FindElement(By.XPath(" //div[contains(text(),'" + DashboardType + " " + PageType + "')]/../../../div/button[contains(.,'delete')]")));
            Delay(2);
            DeleteButtonElement(DashboardType, PageType).Click(_driver);
            Delay(1);
            DeletePageConfirmButton.Click(_driver);
            WaitForPageLoad();
            bool MessageVerify = WaitForToastMessage().Contains("Page deleted Successfully");
            WaitForSave();
            Delay(1);
            return MessageVerify;
        }


        public bool AssignRules(String DashboardType, String PageType)
        {
            ScrollToElement(_driver.FindElement(By.XPath(" //div[contains(text(),'" + DashboardType + " " + PageType + "')]/../../../div/button[contains(.,'playlist_add_check')]")));
           
            RulesButtonElement(DashboardType, PageType).Click(_driver);
            WaitForPageLoad();
            RuleSyncbutton.Click(_driver);
            WaitForPageLoad();
            string MessageOnsync = WaitForToastMessage();
            var ExpectedRuleSyncMessage = GetTestDataByFieldName("ExpectedRuleSyncMessage");
            bool VerifySyncRules = MessageOnsync.Contains(ExpectedRuleSyncMessage);
            IList<IWebElement> ClubCount = _driver.FindElements(By.XPath("//div[contains(text(),'Club Level')]/../div[@layout='row']/div/md-checkbox"));
            SelectClubOptions(2).Click(_driver);
            PlayerTagCheckboxButton.Click(_driver);
            ScrollToElement(_driver.FindElement(By.XPath("//button[@data-ng-click='PageViewViewModel.applyrules()']")));
            ApplyRuleButton.Click(_driver);
            WaitForPageLoad();
            string MessageOnApplyRule = WaitForToastMessage();
            var ExpectedRuleApplyMessage = GetTestDataByFieldName("ExpectedRuleApplyMessage");
            bool VerifyApplyRules = MessageOnApplyRule.Contains(ExpectedRuleApplyMessage);
            Delay(1);
            return VerifyApplyRules;
      }

       public bool VerifyDefaultCardedDMIsVisible()
        {
            Delay(1);
            return DefaultCardedDMPage.IsVisible(_driver);
        }

        public bool VerifyDefaultUnCardedDMIsVisible()
        {
            Delay(1);
            return DefaultUnCardedDMPage.IsVisible(_driver);
        }

        public bool VerifyDefaultCardedLVDSIsVisible()
        {
            Delay(1);
            return DefaultUnCardedLVDSPage.IsVisible(_driver);
        }

        public bool VerifyDefaultUnCardedLVDSIsVisible()
        {
            Delay(1);
            return DefaultUnCardedLVDSPage.IsVisible(_driver);
        }

        public bool VerifyFolderDMPageIsVisible()
        {
            Delay(1);
            return FolderPageDM.IsVisible(_driver);
  
        }

        public bool VerifyDefaultFolderLVDSIsVisible()
        {
            Delay(1);
            return FolderPageLVDS.IsVisible(_driver);
        }

        public bool VerifyDefaultFolderDMIsVisible()
        {
            Delay(1);
            return FolderPageDM.IsVisible(_driver);
        }

        public bool VerifyPropertyDMPageIsVisible()
        {
            Delay(1);
            return PropertyPageDM.IsVisible(_driver);
        }

        public bool VerifyPropertyLVDSPagIsVisible()
        {
            Delay(1);
            return PropertyPageLVDS.IsVisible(_driver);
        }

        public void EditNotification(String NotificationType, String PageType)
        {
            ScrollToElement(_driver.FindElement(By.XPath("//div[contains(text(),'" + NotificationType + " " + PageType + "')]/../../../div/button[contains(.,'mode_edit')]")));
            EditPageNotification(NotificationType, PageType).Click(_driver);
            //WaitForPageLoad();
            Delay(1);
        }

        #endregion
    }
}
