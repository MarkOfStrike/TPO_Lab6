using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TPO_Lab6.Initial
{
    public abstract class TestStartupInitializer : ITestStartupInitializer
    {
        private Lazy<Uri> _rootUriInitializer;
        private Lazy<IWebDriver> _driverInitializer;

        public Uri RootUri => _rootUriInitializer.Value;
        public IWebDriver Driver => _driverInitializer.Value;


        protected TestStartupInitializer()
        {
            InitLazy();
        }

        private void InitLazy()
        {
            _rootUriInitializer = new Lazy<Uri>(StartAndGetRootUri);
            _driverInitializer = new Lazy<IWebDriver>(CreateWebDriver);
        }

        protected static void RunInBackgroundThread(Action action)
        {
            var isDone = new ManualResetEvent(false);
            ExceptionDispatchInfo edi = null;
            new Thread(() =>
            {
                try
                {
                    action();
                }
                catch (Exception ex)
                {
                    edi = ExceptionDispatchInfo.Capture(ex);
                }

                isDone.Set();
            }).Start();

            if (!isDone.WaitOne(TimeSpan.FromSeconds(10)))
                throw new TimeoutException("Timed out waiting for: " + action);

            if (edi != null)
                throw edi.SourceException;
        }

        protected virtual Uri StartAndGetRootUri()
        {

            return new Uri("https://xtool.ru/");
        }

        public void Dispose() => Dispose(true);

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Driver?.Dispose();
            }
        }

        public void EnsureServerRestart()
        {
            Dispose();
            InitLazy();
        }


        protected abstract IWebDriver CreateWebDriver();
    }

    public class TestStartupInitializerDefault : TestStartupInitializer
    {
        /// <inheritdoc />
        protected override IWebDriver CreateWebDriver()
        {
            var service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;

            var options = new ChromeOptions();
            //options.AddArgument("headless");
            options.AddArgument("--user-agent=Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.517 Safari/537.36");
            options.AddArgument("--window-size=1920,1080");
            var driver = new ChromeDriver(service, options);
            return driver;
        }
    }
}
