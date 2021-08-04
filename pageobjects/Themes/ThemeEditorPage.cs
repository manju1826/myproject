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
    class ThemeEditorPage : BasePage
    {

        #region Elements

        public ISeleniumButtonService ConfirmWidgetDeleteButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//*[contains(text(),'SG WCM Alert')]/../../md-dialog-actions/button[2]");
        public ISeleniumButtonService AddWidgetButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//*[@id='pageeditor']/div[2]/div/button[1]");
        public ISeleniumButtonService PagePropertyButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//*[@id='pageeditor']/div[2]/div/button[2]");
        public ISeleniumButtonService SaveButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//*[@id='pageeditor']/div[3]/button[2]");
        public ISeleniumButtonService CancelButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//*[@id='pageeditor']/div[3]/button[1]");
      //  public ISeleniumButtonService PropertyImageButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//div[@class='icon sg_banner sg_image ng-scope']");
        public ISeleniumButtonService PropertyImageButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//div[@class='sg_banner sg_image ng-scope']");
        public ISeleniumTextBoxService GlobalizationKeyTextBox = Factory.ElementServices.GetWebTextBox(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//input[@aria-label='Globalization Key']", UnicornEnums.WebTextBoxControl.WebTextBox);
        public ISeleniumButtonService AddNewButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//button[contains(.,'Add New')]");
        public ISeleniumButtonService PropertyImageResourceButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//div[@class='icon sg_banner sg_image']");
        public ISeleniumButtonService PropertyDescirptionButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//div[@class='note-editor note-frame panel panel-default']");
        private ISeleniumTextBoxService EnterTextforPropertyPage = Factory.ElementServices.GetWebTextBox(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//div[@class='note-editing-area']/div[@class='note-editable panel-body']", UnicornEnums.WebTextBoxControl.WebTextBox);
      

        public ISeleniumTextBoxService PropertyTitleTextBox = Factory.ElementServices.GetWebTextBox(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, " //input[@id='propertypageheader']", UnicornEnums.WebTextBoxControl.WebTextBox);
        public ISeleniumButtonService PropertySaveButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, " //button[@data-ng-click='globalizationpropertyViewModel.save();']");

        public ISeleniumButtonService Property4KDMImageButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//div/div[@class='imageHolder']/div[@class='sg_banner sg_image ng-scope']");
        public ISeleniumButtonService Property4KDMImageResourceButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//div[@class='icon sg_banner sg_image']");

        public ISeleniumButtonService PropertyV32ImageButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//div/div[@class='imageHolder']/div[@class='sg_banner sg_image ng-scope']");
        public ISeleniumButtonService PropertyV32ImageResourceButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//div[@class='icon sg_banner sg_image']");

        public ISeleniumButtonService PropertyNextButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//button[@data-ng-style='widget.sg_button']");
        public ISeleniumButtonService PropertyMapButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//button[@data-ng-click='linkPropertyPage()']");
        public ISeleniumButtonService MapPropertyPageButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//div[@class='snap']");
        public ISeleniumButtonService PropertyMapPageButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//button[@data-ng-click='mapfolderview()']");
        //Notification page
        public ISeleniumButtonService NotificationLayout = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//div[@data-ng-style='widget.sg_title']/..");
        public ISeleniumButtonService NotificationText = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//div/div[@class='notification ng-scope']/div/div[@data-ng-style='widget.sg_container']");
        public ISeleniumButtonService NotificationImage = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//div/div[@class='notification ng-scope']/div/div[@data-ng-style='widget.sg_container']/div[@class='notification_img sg_image']");
        public ISeleniumButtonService WidgetElement(int i)
        {
            ISeleniumButtonService WidgetElement = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//li[@class='widgetHolder ng-scope ui-draggable']/../li[" + (i + 1).ToString() + "]/button/..");
            return WidgetElement;
        }


        public ISeleniumButtonService WidgetDeleteButton(int i)
        {
            //ISeleniumButtonService WidgetDeleteButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//li[@class='widgetHolder ng-scope ui-draggable']/../li["+(i+1).ToString()+"]/button");
            ISeleniumButtonService WidgetDeleteButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "(//li[@class='widgetHolder ng-scope ui-draggable'])[" + i.ToString() + "]/button");
            return WidgetDeleteButton;
        }

        public ISeleniumButtonService ChooseButton = Factory.ElementServices.GetWebButton(ElementSearchTypeConstants.CONST_SEARCH_BY_XPATH, "//span[contains(text(),'Choose ')]/..");

        #endregion

        public ThemeEditorPage(TestInputCache testInputCache) : base(testInputCache)
        {
           
        }
        public void DeleteWidgets()
        {
            IList<IWebElement> list = _driver.FindElements(By.XPath("//*[@id='widgetRow']/li[@class='widgetHolder ng-scope ui-draggable']"));

            for (int i = list.Count; i >= 1; i--)
            {
                ScrollToElement(_driver.FindElement(By.XPath("(//li[@class='widgetHolder ng-scope ui-draggable'])[" + i.ToString() + "]")));

                new Actions(_driver).MoveToElement(_driver.FindElement(By.XPath("(//li[@class='widgetHolder ng-scope ui-draggable'])["+ i.ToString()+ "]"))).Build().Perform();
                Delay(1);

                WidgetDeleteButton(i).Click(_driver);
                Delay(1);

                ConfirmWidgetDeleteButton.Click(_driver);
                Delay(1);
            }

        }
        public void AddBackGround()
        {
            Delay(1);
            PagePropertyButton.Click(_driver);
            Delay(1);
            ChooseButton.Click(_driver);
            Delay(2);

            ScrollToElement(_driver.FindElement(By.XPath("(//button[contains(.,'Select')])[1]")));
            _driver.FindElement(By.XPath("(//button[contains(.,'Select')])[1]")).Click();
            Delay(1);
        }
        public void AddPropertyImage(string PropertyPageName)
        {
            Delay(1);
            PropertyImageButton.Click(_driver);
            GlobalizationKeyTextBox.ClearText(_driver);
            Delay(1);
            GlobalizationKeyTextBox.EnterText(_driver, GetTestDataByFieldName("PropertyName"));
            AddNewButton.Click(_driver);
            PropertyImageResourceButton.Click(_driver);
            Delay(1);
            ChooseButton.Click(_driver);
            Delay(2);
            ScrollToElement(_driver.FindElement(By.XPath("(//button[contains(.,'Select')])[1]")));
            _driver.FindElement(By.XPath("(//button[contains(.,'Select')])[1]")).Click();
            Delay(2);
            PropertyDescirptionButton.Click(_driver);
            Delay(1);
            EnterTextforPropertyPage.EnterText(_driver, "Property page text test");
            Delay(3);
            PropertyTitleTextBox.ClearText(_driver);
            Delay(1);
            PropertyTitleTextBox.EnterText(_driver, "NEW Title");
            Delay(1);
            PropertySaveButton.Click(_driver);
            WaitForSave();
            Delay(2);
            PropertyNextButton.Click(_driver);
            Delay(1);
            PropertyMapButton.Click(_driver);
            Delay(1);
            MapPropertyPageButton.Click(_driver);
            PropertyMapPageButton.Click(_driver);
            Delay(1);
            SaveButton.Click(_driver);
            WaitForSave(); //wait for the save toast message
            CancelButton.Click(_driver);
            WaitForPageLoad();
            Delay(1);
        }
        public void AddPropertyImage4K(string PropertyPageName)
        {
            Delay(2);
            //PropertyImageButton.Click(_driver);
            Property4KDMImageButton.Click(_driver);
            Delay(1);
            GlobalizationKeyTextBox.ClearText(_driver);
            Delay(1);
            GlobalizationKeyTextBox.EnterText(_driver, "PropertyPage4KDM");
            AddNewButton.Click(_driver);
            Property4KDMImageResourceButton.Click(_driver);
            Delay(1);
            ChooseButton.Click(_driver);
            Delay(2);
            ScrollToElement(_driver.FindElement(By.XPath("(//button[contains(.,'Select')])[1]")));
            _driver.FindElement(By.XPath("(//button[contains(.,'Select')])[1]")).Click();   
            Delay(1);
            PropertyDescirptionButton.Click(_driver);
            Delay(1);
            EnterTextforPropertyPage.EnterText(_driver, "4KDM Property page text test");
            Delay(1);
            PropertyTitleTextBox.ClearText(_driver);
            Delay(1);
            PropertyTitleTextBox.EnterText(_driver, "4KDM Title");
            Delay(1);
            PropertySaveButton.Click(_driver);
            WaitForSave();
            Delay(2);
            PropertyNextButton.Click(_driver);
            Delay(1);
            PropertyMapButton.Click(_driver);
            Delay(1);
            MapPropertyPageButton.Click(_driver);
            PropertyMapPageButton.Click(_driver);
            Delay(1);
            SaveButton.Click(_driver);
            WaitForSave(); //wait for the save toast message
            CancelButton.Click(_driver);
            WaitForPageLoad();
            //_driver.Navigate().Back();
            Delay(1);
        }

        public void AddPropertyImageV32(string PropertyPageName)
        {
    
            Delay(2);
            PropertyV32ImageButton.Click(_driver);
            Delay(1);
            GlobalizationKeyTextBox.ClearText(_driver);
            Delay(1);
            GlobalizationKeyTextBox.EnterText(_driver, "PropertyPageV32");
            AddNewButton.Click(_driver);
            PropertyV32ImageResourceButton.Click(_driver);
            Delay(1);
            ChooseButton.Click(_driver);
            Delay(2);
            ScrollToElement(_driver.FindElement(By.XPath("(//button[contains(.,'Select')])[1]")));
            _driver.FindElement(By.XPath("(//button[contains(.,'Select')])[1]")).Click();
            Delay(1);
            PropertyDescirptionButton.Click(_driver);
            Delay(1);
            EnterTextforPropertyPage.EnterText(_driver, "V32 Property page text test");
            Delay(1);
            PropertyTitleTextBox.ClearText(_driver);
            Delay(1);
            PropertyTitleTextBox.EnterText(_driver, "V32 Title");
            Delay(1);
            PropertySaveButton.Click(_driver);
            WaitForSave();
            Delay(2);
            PropertyNextButton.Click(_driver);
            Delay(1);
            PropertyMapButton.Click(_driver);
            Delay(1);
            MapPropertyPageButton.Click(_driver);
            PropertyMapPageButton.Click(_driver);
            Delay(1);
            SaveButton.Click(_driver);
            // WaitForPageLoad();
            Delay(3);
            WaitForSave(); //wait for the save toast message
            CancelButton.Click(_driver);
            WaitForPageLoad();
            //_driver.Navigate().Back();
            Delay(1);
        }

        public void AddWidget(String[] WidgetName)
        {
            for (int i = 0; i < WidgetName.Length; i++)
            {
                if (i == 0)
                {
                    AddWidgetButton.Click(_driver);
                    Delay(1);
                }
                IWebElement WidgetElement = _driver.FindElement(By.XPath("//*[@*[contains(., '" + WidgetName[i] + "')]]"));
                //IWebElement WidgetElement = _driver.FindElement(By.XPath("//*[@*[contains(., 'E-Cash_[Medium-IconText]')]]"));
                //IWebElement WidgetElement = _driver.FindElement(By.XPath("//*[@*[contains(., 'E-Cash [Medium-IconText]')]]"));
               

                ScrollToElement(WidgetElement);
                Delay(1/100);

                new Actions(_driver).ClickAndHold(WidgetElement).Build().Perform();

                new Actions(_driver).MoveToElement(_driver.FindElement(By.Id("widgetRow")), 50, 70).Build().Perform();
                Delay(1/100);

                new Actions(_driver).MoveByOffset(800, 250).Build().Perform();
                Delay(1/100);

                new Actions(_driver).Release(WidgetElement).Build().Perform();
                Delay(1 / 100);       
            }
            SaveButton.Click(_driver);
            WaitForPageLoad();

            WaitForSave(); //wait for the save toast message

            CancelButton.Click(_driver);
            WaitForPageLoad();
            //_driver.Navigate().Back();
            Delay(1);
            



        }
        //Notification

        public void AddNotificationImage()
        {
            Delay(2);
           
           NotificationLayout.Click(_driver);
            Delay(1);
            //ChooseButton.Click(_driver);
            EditLabel("//*[contains(@class,'sg_title')]");

            Delay(2);
           // ScrollToElement(_driver.FindElement(By.XPath("(//button[contains(.,'Select')])[1]")));
            //_driver.FindElement(By.XPath("(//button[contains(.,'Select')])[1]")).Click();
           // Delay(1);
            NotificationImage.Click(_driver);
            Delay(1);
            ChooseButton.Click(_driver);
            Delay(2);
            ScrollToElement(_driver.FindElement(By.XPath("(//button[contains(.,'Select')])[1]")));
            _driver.FindElement(By.XPath("(//button[contains(.,'Select')])[2]")).Click();
            Delay(1);
            SaveButton.Click(_driver);
           // WaitForPageLoad();
            WaitForSave(); //wait for the save toast message
            CancelButton.Click(_driver);
            WaitForPageLoad();
            //_driver.Navigate().Back();
            Delay(1);
        }

        public void EditLabel(String LabelXpath)
        {
            IWebElement WidgetElement = new WebDriverWait(_driver, TimeSpan.FromSeconds(3)).Until(ExpectedConditions.ElementIsVisible(By.XPath(LabelXpath)));

            new Actions(_driver).MoveToElement(WidgetElement).Click().Build().Perform();
            Delay(1);

            new Actions(_driver).MoveToElement(_driver.FindElement(By.XPath("//*[contains(text(),'format_italic')]/.."))).Click().Build().Perform();
            Delay(1 / 100);

            new Actions(_driver).MoveToElement(_driver.FindElement(By.XPath("//*[contains(text(),'format_bold')]/.."))).Click().Build().Perform();
            Delay(1 / 100);

            new Actions(_driver).MoveToElement(_driver.FindElement(By.XPath("//*[contains(text(),'format_underlined')]/.."))).Click().Build().Perform();
            Delay(1 / 100);

            new Actions(_driver).MoveToElement(_driver.FindElement(By.XPath("//input[starts-with(@class,'colorpicker_value')]"))).Click().SendKeys(" ").Build().Perform();
            Delay(1 / 100);

            new Actions(_driver).MoveToElement(_driver.FindElement(By.XPath("//input[starts-with(@class,'colorpicker_value')]"))).Click().SendKeys("#" + System.Guid.NewGuid().ToString().Substring(0, Math.Min(System.Guid.NewGuid().ToString().Length, 6))).Build().Perform();

            new Actions(_driver).MoveToElement(_driver.FindElement(By.XPath(" //*[contains(text(),'format_align_left')]/.."))).Click().Build().Perform();

            
        }


    }


}

