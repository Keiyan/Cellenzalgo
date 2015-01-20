using Microsoft.VisualStudio.TestTools.UnitTesting;
using SumOfTwo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfTwoTests
{
    [TestClass]
    public class FileReadTests
    {
        [TestMethod, ExpectedException(typeof(FileNotFoundException))]
        public void ReadFile_WhenFileDoesNotExists_Throw()
        {
            var prg = new Program();
            prg.ReadFile("smucktz");
        }

        [TestMethod]
        public void ReadFile_WhenFileIsEmpty_ReturnEmptyArray()
        {
            string path = Path.GetTempFileName();
            using (var s = File.CreateText(path)) { }
            try
            {
                var prg = new Program();
                var result = prg.ReadFile(path);

                Assert.IsNotNull(result);
                Assert.AreEqual(0, result.Length);
            }
            finally
            {
                File.Delete(path);
            }
        }

        [TestMethod, ExpectedException(typeof(FormatException))]
        public void ReadFile_WhenFileContainsInvalidData_Throws()
        {
            string path = Path.GetTempFileName();
            using (var s = File.CreateText(path))
            {
                s.WriteLine("albert");
            }
            try
            {
                var prg = new Program();
                var result = prg.ReadFile(path);
            }
            finally
            {
                File.Delete(path);
            }
        }

        [TestMethod]
        public void ReadFile_WhenFileContainsDigits_ReturnArray()
        {
            string path = Path.GetTempFileName();
            using (var s = File.CreateText(path))
            {
                s.WriteLine("12345");
                s.WriteLine("-98765432109876543");
                s.WriteLine("0");
            }
            try
            {
                var prg = new Program();
                var result = prg.ReadFile(path);

                Assert.IsNotNull(result);
                Assert.AreEqual(3, result.Length);
                Assert.AreEqual(12345, result[0]);
                Assert.AreEqual(-98765432109876543L, result[1]);
                Assert.AreEqual(0, result[2]);
            }
            finally
            {
                File.Delete(path);
            }
        }
    }
}
