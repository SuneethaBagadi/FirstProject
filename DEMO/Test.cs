using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DEMO
{
    public class Test
    {
        IWebDriver d;
        [SetUp]
        public void Launch()
        {
            d = new ChromeDriver();
            d.Navigate().GoToUrl("http://adactin.com/HotelApp/index.php");
            d.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));
            d.Manage().Window.Maximize();
        }
        [Test]
        public void Login()
        {

            try
            {
                var LBtn = d.FindElement(By.Id("login"));
                if (LBtn.Displayed)
                {
                    d.FindElement(By.Id("username")).SendKeys("TestUser2015");
                    d.FindElement(By.Id("password")).SendKeys("sample");
                    d.FindElement(By.Id("login")).Click();
                    IWebElement SearchBtn = d.FindElement(By.XPath("html/body/table[2]/tbody/tr[1]/td[1]"));
                    if (SearchBtn.Text == "Welcome to AdactIn Group of Hotels")
                    {
                        Console.WriteLine("login Success");
                        Screenshot ss = ((ITakesScreenshot)d).GetScreenshot();
                        ss.SaveAsFile("d:\\ADACT\\loginsuccess.png", System.Drawing.Imaging.ImageFormat.Png);

                    }
                    else
                    {
                        Console.WriteLine("Login fail");
                        Screenshot ss = ((ITakesScreenshot)d).GetScreenshot();
                        ss.SaveAsFile("d:\\ADACT\\loginfail.png", System.Drawing.Imaging.ImageFormat.Png);
                    }
                }
                else
                {
                    Console.WriteLine("Launch App Fail");
                    Screenshot ss = ((ITakesScreenshot)d).GetScreenshot();
                    ss.SaveAsFile("D:\\ADACT\\launchAppFail.png", System.Drawing.Imaging.ImageFormat.Png);
                }
            }
            catch (Exception e)
            {

            }

        }
        [Test]
        public void CheckInDate()
        {

            try
            {
                d.FindElement(By.Id("username")).SendKeys("TestUser2015");
                d.FindElement(By.Id("password")).SendKeys("sample");
                d.FindElement(By.Id("login")).Click();
                IWebElement SearchBtn = d.FindElement(By.XPath("html/body/table[2]/tbody/tr[1]/td[1]"));
                if (SearchBtn.Text == "Welcome to AdactIn Group of Hotels")
                {
                    d.FindElement(By.Id("location")).SendKeys("L" + Keys.Enter);
                    d.FindElement(By.Id("hotels")).SendKeys("Hotel S" + Keys.Enter);
                    d.FindElement(By.Id("room_type")).SendKeys("Do" + Keys.Enter);
                    d.FindElement(By.Id("room_nos")).SendKeys("4" + Keys.Enter);
                    d.FindElement(By.Id("datepick_in")).Clear();
                    d.FindElement(By.Id("datepick_in")).SendKeys("15/01/2017");
                    d.FindElement(By.Id("datepick_out")).Clear();
                    d.FindElement(By.Id("datepick_out")).SendKeys("12/01/2017");
                    d.FindElement(By.Id("adult_room")).SendKeys("4" + Keys.Enter);
                    d.FindElement(By.Id("child_room")).SendKeys("3");
                    d.FindElement(By.Id("Submit")).Click();
                    d.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));
                    Screenshot ss = ((ITakesScreenshot)d).GetScreenshot();
                    ss.SaveAsFile("D:\\ADACT\\ErrorMsg1.png", System.Drawing.Imaging.ImageFormat.Png);
                }
                else
                {
                    Console.WriteLine("Search Page is not displayed");
                    Screenshot ss = ((ITakesScreenshot)d).GetScreenshot();
                    ss.SaveAsFile("D:\\ADACT\\SearchFail.png", System.Drawing.Imaging.ImageFormat.Png);
                }

            }
            catch (Exception e)
            {

            }
        }
        [Test]
        public void CheckOutDate()
        {

            try
            {
                d.FindElement(By.Id("username")).SendKeys("TestUser2015");
                d.FindElement(By.Id("password")).SendKeys("sample");
                d.FindElement(By.Id("login")).Click();
                IWebElement SearchBtn = d.FindElement(By.XPath("html/body/table[2]/tbody/tr[1]/td[1]"));
                if (SearchBtn.Text == "Welcome to AdactIn Group of Hotels")
                {
                    d.FindElement(By.Id("location")).SendKeys("L" + Keys.Enter);
                    d.FindElement(By.Id("hotels")).SendKeys("Hotel S" + Keys.Enter);
                    d.FindElement(By.Id("room_type")).SendKeys("Do" + Keys.Enter);
                    d.FindElement(By.Id("room_nos")).SendKeys("4" + Keys.Enter);
                    d.FindElement(By.Id("datepick_in")).Clear();
                    d.FindElement(By.Id("datepick_in")).SendKeys("15/01/2017");
                    d.FindElement(By.Id("datepick_out")).Clear();
                    d.FindElement(By.Id("datepick_out")).SendKeys("12/01/2017");
                    d.FindElement(By.Id("adult_room")).SendKeys("4" + Keys.Enter);
                    d.FindElement(By.Id("child_room")).SendKeys("3");
                    d.FindElement(By.Id("Submit")).Click();
                    d.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));
                    Screenshot ss = ((ITakesScreenshot)d).GetScreenshot();
                    ss.SaveAsFile("D:\\ADACT\\ErrorMsg2.png", System.Drawing.Imaging.ImageFormat.Png);
                }
                else
                {
                    Console.WriteLine("Search Page is not displayed");
                    Screenshot ss = ((ITakesScreenshot)d).GetScreenshot();
                    ss.SaveAsFile("D:\\ADACT\\SearchFail.png", System.Drawing.Imaging.ImageFormat.Png);
                }

            }
            catch (Exception e)
            {

            }

        }
        [TearDown]
        public void Quit()
        {
            d.Dispose();
        }
    }
}
