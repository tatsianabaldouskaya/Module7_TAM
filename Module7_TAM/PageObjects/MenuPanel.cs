using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Module7_TAM.PageObjects
{
    class MenuPanel
    {
        private readonly By composeButton = By.XPath("//div[@class='T-I T-I-KE L3']");
        private readonly By inboxFolder = By.XPath("//a[contains(@href,'#inbox')]");
        private readonly By starredFolder = By.XPath("//a[contains(@href,'#starred')]");
        private readonly By snoozedFolder = By.XPath("//a[contains(@href,'#snoozed')]");
        private readonly By sentFolder = By.XPath("//a[contains(@href,'#sent')]");
        private readonly By draftsFolder = By.XPath("//a[contains(@href,'#drafts')]");
    }
}
