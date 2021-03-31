﻿using log4net;
using OpenQA.Selenium;

namespace Zendesk.AutoFramework.Browser
{
    public abstract class AbstractWidget : AbstractBrowser
    {
        public AbstractWidget(IWebDriver driver, ILog log) : base(driver, log)
        {
            
        }
    }
}
