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
        //[DataRow(40,100, 0.4)]
        [TestMethod]
        public void Stats( )
        {
            //Para esta prueba se requiere datos de la base de datos
            _obj = new BMMutant();
            //arrange -> Variables
            
            DTStats data = new DTStats();
            data.count_human_dna = 6;
            data.count_mutant_dna = 7;
            data.ratio = Convert.ToDecimal(1.2);
            DTStats expect = data;

            //act
            var response = _obj.stat();

            //Assert -> Evaluar respuestas
            Assert.AreEqual(expect.ratio, response.ratio);
        }
    }
}
