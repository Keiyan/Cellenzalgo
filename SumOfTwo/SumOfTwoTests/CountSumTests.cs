using Microsoft.VisualStudio.TestTools.UnitTesting;
using SumOfTwo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfTwoTests
{
    [TestClass]
    public class CountSumTests
    {
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CountSum_WhitNullData_Throws()
        {
            var prg = new Program();
            prg.CountSum(null, 0, 0);
        }

        [TestMethod]
        public void CountSum_WithEmptyData_Return0()
        {
            var prg = new Program();
            var result = prg.CountSum(new long[] { }, 0, 0);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CountSum_WithNoCandidate_Return0()
        {
            var prg = new Program();
            var result = prg.CountSum(new long[] 
            { 
                1,
                2,
                3,
                4,
                5
            }, 0, 0);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CountSum_With1Candidate_Return1()
        {
            var prg = new Program();
            var result = prg.CountSum(new long[] 
            { 
                1,
                2,
                3,
                4,
                5
            }, 0, 3);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CountSum_WithAllCandidates_ReturnMax()
        {
            var prg = new Program();
            var result = prg.CountSum(new long[] 
            { 
                1,
                2,
                3,
                4,
                5
            }, 0, long.MaxValue);

            Assert.AreEqual(10, result);
        }
    }
}
