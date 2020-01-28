using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace MyUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string otp = null;
            bool result = MySecurityLib.Security.GenerateOTP(out otp);
            Assert.AreEqual(true, result);
            Assert.AreNotEqual(String.Empty, otp);
            //Assert.is
        }
        [TestMethod]
        public void TestMethod2()
        {
            string data = null;
            bool result = MySecurityLib.Security.Encrypt("pswd", out data);
            Assert.AreEqual(true, result);
            Debug.WriteLine(data);
            Assert.AreNotEqual(String.Empty, data);
        }
        [TestMethod]
        public void TestMethod3()
        {
            string pswd = "uonFDG0wiRw=";
            string data = null;
            bool result = MySecurityLib.Security.Decrypt(pswd, out data);
            Assert.AreEqual(true, result);
          //  Debug.WriteLine(data);
           //Assert.AreNotEqual(String.Empty, data);
        }
    }

}
