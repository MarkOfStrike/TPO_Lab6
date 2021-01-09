using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

using TPO_Lab6.Initial;

namespace TPO_Lab6.HomePage
{
    public class HomePage : PageBase
    {
        public override Uri Uri => new Uri(Initializer.RootUri, "");

        private string _currentUrl;

        public string CurrentUrl => _currentUrl;

        public IWebElement GetElement(EnumBy by, string findElement)
        {
            switch (by)
            {
                case EnumBy.Css:
                    return Initializer.Driver.FindElement(By.CssSelector(findElement));
                case EnumBy.Path:
                    return Initializer.Driver.FindElement(By.XPath(findElement));
                default:
                    return null;
            }
        }

        public void PerfomanceClick(IWebElement element, string checkTitle)
        {
            Initializer.Driver.Scripts().ExecuteScript("arguments[0].click();", element);
            WebDriverWait wait = new WebDriverWait(Initializer.Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.TitleContains(checkTitle));
        }

        private void ClickElement(IWebElement element, string checkTitle)
        {
            Initializer.Driver.Scripts().ExecuteScript("arguments[0].click();", element);
            WebDriverWait wait = new WebDriverWait(Initializer.Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.TitleContains(checkTitle));
        }

        #region Nav

        public IWebElement Trast => GetElement(EnumBy.Css, "[href*='/']");
        public IWebElement AnalizeBar => GetElement(EnumBy.Css, "[href*='/analyze/']");
        public IWebElement Blog => GetElement(EnumBy.Css, "[href*='/blog/']");
        public IWebElement FAQ => GetElement(EnumBy.Css, "[href*='/faq/']");
        public IWebElement Recomend => GetElement(EnumBy.Css, "[href*='/recomend/']");
        public IWebElement Reviews => GetElement(EnumBy.Css, "[href*='/reviews/']");
        public IWebElement Api => GetElement(EnumBy.Css, "[href*='/api/']");
        public IWebElement Contacts => GetElement(EnumBy.Css, "[href*='/contacts/']");
        public IWebElement Reklama => GetElement(EnumBy.Css, "[href*='/reklama/']");

        #endregion

        #region Вход

        public IWebElement Email => GetElement(EnumBy.Path, "//*[@id='login']");
        public IWebElement Password => GetElement(EnumBy.Path, "//*[@id='pass']");
        public IWebElement BtnLogin => GetElement(EnumBy.Path, "//*[@id='btn-login']");


        #endregion

        #region Меню слева

        private string ClassName => "[class*='list-group-item menu-links']";

        public IWebElement SeoAudit => GetElement(EnumBy.Css, $"{ClassName}[href*='/seo-audit/']");
        public IWebElement BackLinks => GetElement(EnumBy.Css, $"{ClassName}[href*='/backlinks/']");
        public IWebElement InformerUpdate => GetElement(EnumBy.Css, $"{ClassName}[href*='/updates-informer/']");
        public IWebElement MyIpPort => GetElement(EnumBy.Css, $"{ClassName}[href*='/ip/']");
        public IWebElement Analize => GetElement(EnumBy.Css, $"{ClassName}[href*='/analyze/']");
        public IWebElement Attendance => GetElement(EnumBy.Css, $"{ClassName}[href*='/analyze/poseshchaemost-sajta/']");
        public IWebElement YandexIks => GetElement(EnumBy.Css, $"{ClassName}[href*='/analyze/yandex-iks/']");
        public IWebElement Plugin => GetElement(EnumBy.Css, $"{ClassName}[href*='/plugin/']");


        #endregion


        #region Click NavBar

        public void ClickTrast() => ClickElement(Trast, "Траст сайта (Сервис) - Seo проверка сайта и оценка качества ссылок онлайн");
        public void ClickAnalizeBar() => ClickElement(AnalizeBar, "Seo анализ сайта Бесплатно (также проверка сайтов списком)");
        public void ClickBlog() => ClickElement(Blog, "Обсуждение и информация сервиса XTool.ru");
        public void ClickFAQ() => ClickElement(FAQ, "Ответы на часто задаваемые вопросы");
        public void ClickRecomend() => ClickElement(Recomend, "Рекомендации оптимизаторам по использованию сервиса");
        public void ClickReviews() => ClickElement(Reviews, "Отзывы о сайтах - оставить отзыв");
        public void ClickApi() => ClickElement(Api, "API сервиса xtool.ru - версия 2.0");
        public void ClickContacts() => ClickElement(Contacts, "Наши контакты - техническая поддержка пользователей сервиса");
        public void ClickReklama() => ClickElement(Reklama, "Реклама на нашем сайте.");

        #endregion

        #region Click left menu

        public void ClickAudit() => ClickElement(SeoAudit, "Seo аудит сайта - заказать на Xtool.ru");
        public void ClickBackLinks() => ClickElement(BackLinks, "Поиск и Анализ Обратных Ссылок - проверка внешних ссылок на сайт");
        public void ClickInformerUpdate() => ClickElement(InformerUpdate, "Информер апдейтов Яндекса (тиц и выдачи) и гугл (Google pr) для вашего сайта");
        public void ClickMyIpPort() => ClickElement(MyIpPort, "Мой айпи адрес, узнать IP");
        public void ClickAnalize() => ClickElement(Analize, "Seo анализ сайта Бесплатно (также проверка сайтов списком)");
        public void ClickAttendance() => ClickElement(Attendance, "Проверка посещаемости сайта бесплатно (также проверка сайтов списком)");
        public void ClickYandexIks() => ClickElement(YandexIks, "Проверка Яндекс ИКС сайта Бесплатно (также проверка сайтов списком)");
        public void ClickPlugin() => ClickElement(Plugin, "Плагин для Sape.ru, других бирж и просто seo анализа - xtool_checker");

        #endregion

        #region Login action

        public string EmailText
        {
            get { return Email.GetAttributeValue(); }
            set
            {
                Regex reg = new Regex(@"^[0-9a-z_-]+@[0-9a-z_-]+\.[a-z]{2,5}");

                var email = value;

                if (reg.IsMatch(email))
                {
                    Email.SendKeys(value);
                }
                else
                {
                    throw new Exception("Email incorrect");
                }

            }
        }
        public string PassText { get { return Password.GetAttributeValue(); } set { Password.SendKeys(value); } }

        public bool IsEnableEmail => Email.Displayed;
        public bool IsEnablePassword => Password.Displayed;

        public bool IsEnableBtnSubmit => BtnLogin.Displayed;

        public void SubmitBtnClick()=> Initializer.Driver.Scripts().ExecuteScript("arguments[0].click();", BtnLogin);

        #endregion

        #region Конструктор

        public HomePage(ITestStartupInitializer initializer) : base(initializer)
        {
        }

        #endregion



    }


    public static class ElementExstension
    {
        public static string GetAttributeValue(this IWebElement element) => element.GetAttribute("value");
    }

    public static class DriverExtension
    {
        public static IJavaScriptExecutor Scripts(this IWebDriver driver)
        {
            return (IJavaScriptExecutor)driver;
        }
    }

    public enum EnumBy
    {
        Css,
        Path
    }
}
