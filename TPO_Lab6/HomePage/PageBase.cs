using System;
using System.Collections.Generic;
using System.Text;

using TPO_Lab6.Initial;

namespace TPO_Lab6.HomePage
{
    public abstract class PageBase
    {
        protected readonly ITestStartupInitializer Initializer;

        protected PageBase(ITestStartupInitializer initializer)
        {
            this.Initializer = initializer;
        }

        public abstract Uri Uri { get; }
        public string Title => Initializer.Driver.Title;

        public void Navigate()
        {
            Initializer.Driver.Navigate().GoToUrl(Uri);
        }
    }
}
