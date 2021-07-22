using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module7_TAM_V2.Elements
{
    public class InputField : BaseElement
    {
        public InputField(IWebElement element) : base(element)
        {

        }
        public void InputText(IWebElement element, string text)
        {
            WaitForIsVisible(element).SendKeys(text);
        }
    }
}
