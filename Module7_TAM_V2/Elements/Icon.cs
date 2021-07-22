using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module7_TAM_V2.Elements
{
    public class Icon : BaseElement
    {
        public Icon(IWebElement element) : base(element)
        {

        }
        public void ClickIcon(IWebElement webElement)
        {
            WaitForIsVisible(webElement).Click();
        }
    }
}
