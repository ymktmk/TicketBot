using System;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTest
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));

            driver.Navigate().GoToUrl(@"https://t.livepocket.jp/login?acroot=header-res-new_p_u_nl");

            driver.FindElement(By.Name("login")).SendKeys("tomoaki2001111@icloud.com");
            driver.FindElement(By.Name("password")).SendKeys("tkst2340");
            driver.FindElement(By.Name("action")).Click();
            // 買いたいチケット

            System.Threading.Thread.Sleep(500);

            // 変更する--------------------------------------------------------
            driver.Navigate().GoToUrl(@"https://t.livepocket.jp/e/5p4xs");

            // 要素出るまで待つ   変更する----------------------------------------
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement selectElement = wait.Until(e => e.FindElement(By.Id("ticket-449554")));

            // スクロール
            var element = driver.FindElement(By.Id("ticket-449554"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();

            // 購入枚数
            var selectObject = new SelectElement(selectElement);
            selectObject.SelectByValue("1");

            driver.FindElements(By.TagName("button"))[2].Click();

            // 支払い方法
            IWebElement selectElementMethod = wait.Until(e => e.FindElement(By.Id("other_payment_method_select_img")));
            selectElementMethod.Click();

            // コンビニ選択
            //WebDriverWait waitConvenient = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement selectElementConvenient = wait.Until(e => e.FindElement(By.Id("cvs_select")));
            var selectObjectConvenient = new SelectElement(selectElementConvenient);
            selectObjectConvenient.SelectByValue("002");

            // 同意
            driver.FindElement(By.Id("agreement_check_lp")).Click();

            // 購入
            driver.FindElement(By.Name("sbm")).Click();

            Console.ReadKey();
            driver.Quit();
        }

        private static object SelectElement(IWebElement element)
        {
            throw new NotImplementedException();
        }
    }
}