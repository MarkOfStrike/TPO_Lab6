using System;
using TPO_Lab6.Initial;
using Xunit;

namespace TPO_Lab6.Tests
{
    public class SiteTest : IClassFixture<TestStartupInitializerDefault>
    {

        private readonly TestStartupInitializerDefault _initializer;
        private readonly HomePage.HomePage _page;

        public SiteTest(TestStartupInitializerDefault initializer)
        {
            _initializer = initializer;
            _page = new HomePage.HomePage(initializer);
        }

        

        [Fact]
        public void TestNavBar()
        {
            _initializer.EnsureServerRestart();
            _page.Navigate();

            _page.ClickTrast();
            Assert.Equal("Траст сайта (Сервис) - Seo проверка сайта и оценка качества ссылок онлайн", _page.Title);

            _page.ClickAnalizeBar();
            Assert.Equal("Seo анализ сайта Бесплатно (также проверка сайтов списком)", _page.Title);

            _page.ClickBlog();
            Assert.Equal("Обсуждение и информация сервиса XTool.ru", _page.Title);

            _page.ClickFAQ();
            Assert.Equal("Ответы на часто задаваемые вопросы", _page.Title);

            _page.ClickRecomend();
            Assert.Equal("Рекомендации оптимизаторам по использованию сервиса", _page.Title);

            _page.ClickReviews();
            Assert.Equal("Отзывы о сайтах - оставить отзыв", _page.Title);

            _page.ClickApi();
            Assert.Equal("API сервиса xtool.ru - версия 2.0", _page.Title);

            _page.ClickContacts();
            Assert.Equal("Наши контакты - техническая поддержка пользователей сервиса", _page.Title);

            _page.ClickReklama();
            Assert.Equal("Реклама на нашем сайте.", _page.Title);

            _initializer.Driver.Close();
            _initializer.Driver.Dispose();

        }

        [Fact]
        public void TestLeftMenu()
        {
            _initializer.EnsureServerRestart();

            _page.Navigate();

            _page.ClickAudit();
            Assert.Equal("Seo аудит сайта - заказать на Xtool.ru", _page.Title);

            _page.ClickBackLinks();
            Assert.Equal("Поиск и Анализ Обратных Ссылок - проверка внешних ссылок на сайт", _page.Title);

            _page.ClickInformerUpdate();
            Assert.Equal("Информер апдейтов Яндекса (тиц и выдачи) и гугл (Google pr) для вашего сайта", _page.Title);

            _page.ClickMyIpPort();
            Assert.Equal("Мой айпи адрес, узнать IP", _page.Title);

            _page.ClickAnalize();
            Assert.Equal("Seo анализ сайта Бесплатно (также проверка сайтов списком)", _page.Title);

            _page.ClickAttendance();
            Assert.Equal("Проверка посещаемости сайта бесплатно (также проверка сайтов списком)", _page.Title);

            _page.ClickYandexIks();
            Assert.Equal("Проверка Яндекс ИКС сайта Бесплатно (также проверка сайтов списком)", _page.Title);

            _page.ClickPlugin();
            Assert.Equal("Плагин для Sape.ru, других бирж и просто seo анализа - xtool_checker", _page.Title);

            _initializer.Driver.Close();
            _initializer.Driver.Dispose();
        }

        [Fact]
        public void TestAuth()
        {
            _initializer.EnsureServerRestart();

            _page.Navigate();

            Assert.True(_page.IsEnableEmail);
            Assert.True(_page.IsEnablePassword);
            Assert.True(_page.IsEnableBtnSubmit);

            string inCorrectEmail = "asdasdasdas";
            string correctEmail = "presentcom@mail.ru";
            string pass = "qwerty123";

            var ex = Assert.Throws<Exception>(() => { _page.EmailText = inCorrectEmail; });
            Assert.Equal("Email incorrect", ex.Message);

            _page.EmailText = correctEmail;
            Assert.Equal(correctEmail, _page.EmailText);

            _page.PassText = pass;

            _page.SubmitBtnClick();

            _initializer.Driver.Close();
            _initializer.Driver.Dispose();

        }


    }
}
