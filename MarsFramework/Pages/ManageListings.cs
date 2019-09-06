using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;

namespace MarsFramework.Pages
{
    internal class ManageListings
    {
        private IWebDriver driver;
        public ManageListings(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Click on Manage Listings Link
        IWebElement manageListingsLink => driver.FindElement(By.LinkText("Manage Listings"));

        //View the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='eye icon'])[1]")]
        IWebElement view => driver.FindElement(By.XPath("//i[@class ='eye icon']"));
        //Delete the listing
        IWebElement delete => driver.FindElement(By.XPath("//*[@id='listing - management - section']/div[2]/div[1]/table/tbody/tr/td[8]/i[3]"));

        //Edit the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='outline write icon'])[1]")]
        private IWebElement edit { get; set; }


        internal void Listings()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");

            manageListingsLink.Click(); //Click on manage listing link from home page
            view.Click(); //Click on view

        }

        internal void Edit()
        {
            //Click on Edit button
            edit.Click();

            //Validate the Page
            Thread.Sleep(2000);
            String myTitle1 = GlobalDefinitions.driver.Title;
            Console.WriteLine(myTitle1);
            Assert.That(myTitle1, Is.EqualTo("ServiceListing"));




            ShareSkill.EditShareSkill();

        }

        internal void Delete()
        {
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListing");
            manageListingsLink.Click();

            String Title = GlobalDefinitions.ExcelLib.ReadData(2, "Title");
            String Action = GlobalDefinitions.ExcelLib.ReadData(2, "Deleteaction");
            if (Title == "Selenium" & Action == "Yes")
            {
                delete.Click();
                driver.SwitchTo().Alert().Accept();
            }

        }
    }
}
           
    

