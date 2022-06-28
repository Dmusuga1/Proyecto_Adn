using ADN.BM;
using ADN.DT;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class TestStat
    {
        private BMMutant _obj;
        [DataRow(40,100, 0.4)]
        [TestMethod]
        public void Stats(int count_mutant, int count_human, decimal ratio )
        {
            _obj = new BMMutant();
            //arrange -> Variables
            
            DTStats data = new DTStats();
            data.count_human_dna = count_human;
            data.count_mutant_dna = count_mutant;
            data.ratio = Convert.ToDecimal(ratio);
            DTStats expect = data;

            //act
            var response = _obj.stat();

            //Assert -> Evaluar respuestas
            Assert.AreEqual(expect, response);
        }
    }
}
