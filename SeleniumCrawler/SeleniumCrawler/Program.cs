using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;


namespace SeleniumCrawler
{
    class Program: Attribute
    {
        static public int Field1 = 0;

        static void Main(string[] args)
        {
            /// <summary>
            ///    Environment.CurrentDirectory 부분이 공백일 경우는 Path 문제가 발생할 수있음
            /// </summary>
            using (IWebDriver driver = new ChromeDriver(Environment.CurrentDirectory))
            {
                driver.Url = "https://www.naver.com/";
 
                IWebElement q = driver.FindElement(By.Id("query"));
                q.Clear();
                q.SendKeys("오늘 날씨");
                driver.FindElement(By.Id("search_btn")).Click();
            }
        }
    }
    
}
