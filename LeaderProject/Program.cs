using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace Leader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver("C:\\Users\\erfan\\Downloads\\chromedriver_win32");
            driver.Navigate().GoToUrl("https://www.leader.ir/");
            Console.WriteLine("opened browser");

            var es = driver.FindElements(By.XPath("/html/body/footer/nav[1]/div/div[2]/div/div[1]/div[1]/ul/li"));
            int x = es.Count();
            List<string> esText = new List<string>();

            for (int i = 1; i <= x; i++)
            {
                var e = driver.FindElement(By.XPath($"/html/body/footer/nav[1]/div/div[2]/div/div[1]/div[1]/ul/li[{i}]")).Text;
                Console.WriteLine(e);
                esText.Add(e);


                if (e == "بیانات")
                {
                    var ce = driver.FindElement(By.XPath($"/html/body/footer/nav[1]/div/div[2]/div/div[1]/div[1]/ul/li[{i}]"));
                    Thread.Sleep(1000);
                    ce.Click();
                }
            }

            var n = driver.FindElements(By.XPath("/html/body/main/div[1]/section[1]/main/div[2]/ul/li"));
            var ts = driver.FindElements(By.XPath("/html/body/main/div[1]/section[1]/main/div[3]/ul/li"));

            for (int i = 2; i <= 2; i++)
            {
                var t = driver.FindElement(By.XPath($"/html/body/main/div[1]/section[1]/main/div[2]/ul/li[{i}]"));
                Thread.Sleep(1000);
                t.Click();

                for (int j = 1; j <= ts.Count; j++)
                {
                    Thread.Sleep(1000);
                    var st = driver.FindElement(By.XPath($"/html/body/main/div[1]/section[1]/main/div[3]/ul/li[{j}]"));
                    Thread.Sleep(1000);
                    st.Click();
                    Thread.Sleep(1000);

                    var nl = driver.FindElements(By.XPath("/html/body/main/div[1]/section[2]/main/ul"));
                    Thread.Sleep(1000);

                    if (nl.Count == 0)
                    {
                        driver.Navigate().Refresh();
                    }

                    for (int k = 1; k <= nl.Count; k++)
                    {
                        Thread.Sleep(1000);

                        var nk = driver.FindElement(By.XPath($"/html/body/main/div[1]/section[2]/main/ul[{k}]/li/div[2]/h6/a[2]"));
                        nk.Click();


                        var te = driver.FindElement(By.XPath("/html/body/main/div[1]/section/main/article[1]/div[1]/time/h6")).Text;
                        var ti = driver.FindElement(By.XPath("/html/body/main/div[1]/section/main/article[1]/div[2]/h3")).Text;
                        var no = driver.FindElement(By.XPath("/html/body/main/div[1]/section/main/article[2]/div[2]")).Text;
                        te = new string(te.Where(c => !char.IsPunctuation(c)).ToArray());

                        string statementsDetails = $"{ti}\n\n + {no}";
                        Thread.Sleep(1000);
                        File.WriteAllText($@"C:\Users\erfan\source\repos\LeaderProject\{te}.txt", statementsDetails);
                        Thread.Sleep(1000);


                        try
                        {
                            driver.Navigate().Back();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }


                        var t_Years = driver.FindElement(By.XPath($"/html/body/main/div[1]/section[1]/main/div[2]/ul/li[{i}]"));
                        Thread.Sleep(500);

                        t_Years.Click();


                        Thread.Sleep(500);
                        var sT_Month = driver.FindElement(By.XPath($"/html/body/main/div[1]/section[1]/main/div[3]/ul/li[{j}]"));

                        sT_Month.Click();
                        Thread.Sleep(500);
                    }
                }
            }
            //driver.Quit();
        }
    }
}
