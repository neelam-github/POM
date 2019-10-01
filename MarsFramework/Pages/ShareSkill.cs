
using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace MarsFramework.Pages
{
    internal class ShareSkill
    {
        private IWebDriver driver;
        public ShareSkill(IWebDriver driver)
           
        {
            this.driver = driver; 
        }


        //Click on ShareSkill Button
           IWebElement ShareSkillButton => driver.FindElement(By.LinkText("Share Skill"));

        //Enter the Title in textbox
        // [FindsBy(How = How.Name, Using = "title")]
        IWebElement Title => driver.FindElement(By.Name("title"));

        //Enter the Description in textbox
        IWebElement Description => driver.FindElement(By.Name("description"));

        //Click on Category Dropdown
        
        IWebElement CategoryDropDown => driver.FindElement(By.Name("categoryId"));

        //Click on SubCategory Dropdown
        //[FindsBy(How = How.Name, Using = "subcategoryId")]
        IWebElement SubCategoryDropDown => driver.FindElement(By.Name("subcategoryId"));

        //Enter Tag names in text box
        IWebElement Tags => driver.FindElement(By.XPath("//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]"));

        //Select the Service type
       // IWebElement ServiceTypeOptions => driver.FindElement(By.LinkText("One-off service"));
        //Location Type
        IWebElement LocationTypeOption => driver.FindElement(By.XPath("//form/div[6]/div[@class='twelve wide column']/div/div[@class = 'field']"));

        //Click on Start Date 
        //[FindsBy(How = How.Name, Using = "startDate")]
        IWebElement Date => driver.FindElement(By.Name("startDate"));

        //Click on End Date dropdown
        //[FindsBy(How = How.Name, Using = "endDate")]
        IWebElement EndDate => driver.FindElement(By.Name("endDate"));

        //Storing the table of available days
        //[FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[@class='ui container']/div[@class='listing']/form[@class='ui form']/div[7]/div[2]/div[1]")]
        IList <IWebElement> CheckBox => driver.FindElements(By.Name("Ävailable"));

        //Storing the start time
        IWebElement StartTime => driver.FindElement(By.XPath("//input[@name ='StartTime' and @index = '1']"));        //Click on EndTime dropdown
        
        IWebElement EndTime => driver.FindElement(By.XPath("//input[@name ='EndTime' and @index = '1']"));        //Click on EndTime dropdown

        //Click on Skill Trade option
        IWebElement skillTradeOption => driver.FindElement(By.XPath("//input[@name ='skillTrades' and @value = 'false']"));

        //Enter Skill Exchange
        IWebElement SkillExchange => driver.FindElement(By.XPath("//*[@id='service - listing - section']/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input"));


        //Click on Active/Hidden option
        [FindsBy(How = How.XPath, Using = "//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement ActiveOption { get; set; }

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }

        internal void EnterShareSkill()
        {
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");

            //Click on the share skill button
            ShareSkillButton.Click();

            //Enter the Title
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));

            //Enter the description
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));

            //click the category
           // CategoryDropDown.Click();
            SelectElement select = new SelectElement(CategoryDropDown);
            select.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Category"));

            //Click on subcategory dropdown
            SelectElement select1 = new SelectElement(SubCategoryDropDown);
            select1.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory"));

            //Enter the tag
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));

            //Select the servicetypeoptions
            //Thread.Sleep(2000);
           // ServiceTypeOptions.Click();

            //Select Location type
            LocationTypeOption.Click();

            //Click on Start date 
            string dateVal = GlobalDefinitions.ExcelLib.ReadData(2, "startdate");
            selectDateByJs(driver, Date, dateVal);


            //Click on End date dropdown
            String dateVal1 =GlobalDefinitions.ExcelLib.ReadData(2, "Enddate");
            selectDateByJs(driver, EndDate, dateVal1);

            //Click on chackboxes,to select days

            int size = CheckBox.Count;//This will tell number of checkboxes

            for(int i=0; i<size; i++)//Start the loop for first checkbox to last checkbox
            {

                 String label = CheckBox.ElementAt(i).GetAttribute("label");
                Console.WriteLine(label);
                if (label == GlobalDefinitions.ExcelLib.ReadData(2, "Selectday"))
                {
                    CheckBox.ElementAt(i).Click();
                    break;
                }

            }

            //Select start time
            StartTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));
            //StartTimeDropDown.Click();

            //Select End time
            EndTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));

            //Click on SkillTradeOptions
            skillTradeOption.Click();
            
            //Enter the skill exchange
            SkillExchange.Click();

             

            //Click on Active/Hidden options
            ActiveOption.Click();

            //Click on save
            Save.Click();

        }

        public static void selectDateByJs(IWebDriver driver, IWebElement element, String dateVal)
        {
            IJavaScriptExecutor js = ((IJavaScriptExecutor)driver);
            js.ExecuteScript("arguments[0].setAttribute('value','" + dateVal + "');", element);

        }

        internal static void EditShareSkill()
        {

        }
      }
    }
