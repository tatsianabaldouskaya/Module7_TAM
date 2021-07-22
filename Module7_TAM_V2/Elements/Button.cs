using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module7_TAM_V2.Elements
{
    public class Button : BaseElement
    {
        public Button(IWebElement element):base(element)
        {
        }
        public void ClickButton(IWebElement element)
        {
            WaitForIsVisible(element).Click();
        }
    }
}
