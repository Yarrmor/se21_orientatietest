using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jelle_Grol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jelle_Grol.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        [TestMethod()]
        public void BTWTarief_wordt_onafhankelijk_van_overerving_teruggegeven()
        {
            IInkomsten s = new Feestzaal(new DateTime(2015, 03, 03), 3);
            BTWTarief teControleren = BTWTarief.Hoog;

            Assert.AreEqual(teControleren, s.BTWTarief);
            Assert.AreEqual(teControleren, ((Verhuur)s).BTWTarief);
            Assert.AreEqual(teControleren, ((Feestzaal)s).BTWTarief);

            // Illustration: can not be changed from outside the class. 
            // Enforced at compile time.
            // s.BTWTarief = BTWTarief.Laag;
            
        }
    }
}