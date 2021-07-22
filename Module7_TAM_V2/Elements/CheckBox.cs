using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module7_TAM_V2.Elements
{
    class CheckBox: BaseElement
    {

        public CheckBox(IWebElement element): base(element)
        {
            
        }
        //public void SetChecked(bool value)
        //{
        //    if (value != IsChecked())
        //    {
        //        element.Click();
        //    }
        //}

        //public bool IsChecked()
        //{
        //    return element.Selected();
        //}
    }
}
