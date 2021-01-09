using System;
using System.Collections.Generic;
using System.Text;

using OpenQA.Selenium;

namespace TPO_Lab6.Initial
{
    public interface ITestStartupInitializer
    {
        /// <summary>
        /// Корневой адрес сервера для тестирования.
        /// </summary>
        Uri RootUri { get; }

        /// <summary>
        /// Драйвер для тестирования.
        /// </summary>
        IWebDriver Driver { get; }
    }
}
