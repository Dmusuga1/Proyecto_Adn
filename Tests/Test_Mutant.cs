using ADN.BM;
using ADN.DT;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;

namespace Tests
{
    [TestClass]
    public class Test_Mutant
    {
        private BMMutant _obj;
        
        [TestMethod]
        public void InvalidNullMutant_DetectarHumano()
        {
            _obj = new BMMutant();
            //arrange -> Variables
            DTAdn dna = new DTAdn();
            dna.dna = null;
            HttpStatusCode expect = HttpStatusCode.NotAcceptable;

            //act
            var response = _obj.DetectarMutant(dna);

            //Assert -> Evaluar respuestas
            Assert.AreEqual(expect, response);
        }

        [TestMethod]
        public void TrueMutant_DetectarHumano()
        {
            _obj = new BMMutant();
            //arrange -> Variables
            DTAdn dna = new DTAdn();
            string[] ArrayAdn;
            ArrayAdn = new string[] { "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG" };
            dna.dna = ArrayAdn;

            HttpStatusCode expect = HttpStatusCode.OK;

            //act
            var response = _obj.DetectarMutant(dna);

            //Assert -> Evaluar respuestas
            Assert.AreEqual(expect, response);
        }

        [TestMethod]
        public void FalseMutant_DetectarHumano()
        {
            _obj = new BMMutant();
            //arrange -> Variables
            DTAdn dna = new DTAdn();
            string[] ArrayAdn;
            ArrayAdn = new string[] { "TTGCGA", "CAGTCC", "TTATGT", "AGAAGG", "ACCCTA", "TCACTG" };
            dna.dna = ArrayAdn;

            HttpStatusCode expect = HttpStatusCode.Forbidden;

            //act
            var response = _obj.DetectarMutant(dna);

            //Assert -> Evaluar respuestas
            Assert.AreEqual(expect, response);
        }

        [TestMethod]
        public void TrueMutant7X7_DetectarHumano()
        {
            _obj = new BMMutant();
            //arrange -> Variables
            DTAdn dna = new DTAdn();
            string[] ArrayAdn;
            ArrayAdn = new string[] { "AACCGCT", "CTCACTT", "ACGCTAT", "ACGGGCC", "CACAGCC", "CCACAGT", "TAACAAG" };
            dna.dna = ArrayAdn;

            HttpStatusCode expect = HttpStatusCode.OK;

            //act
            var response = _obj.DetectarMutant(dna);

            //Assert -> Evaluar respuestas
            Assert.AreEqual(expect, response);
        }


        [TestMethod]
        public void FalseMutant6X6_DetectarHumano()
        {
            _obj = new BMMutant();
            //arrange -> Variables
            DTAdn dna = new DTAdn();
            string[] ArrayAdn;
            ArrayAdn = new string[] { "CAGTCA", "GTCAGT", "CAGTCA", "GTCAGT", "CAGTCA", "GTCAGT" };
            dna.dna = ArrayAdn;

            HttpStatusCode expect = HttpStatusCode.Forbidden;

            //act
            var response = _obj.DetectarMutant(dna);

            //Assert -> Evaluar respuestas
            Assert.AreEqual(expect, response);
        }

        [TestMethod]
        public void TrueMutant5X5_DetectarHumano()
        {
            _obj = new BMMutant();
            //arrange -> Variables
            DTAdn dna = new DTAdn();
            string[] ArrayAdn;
            ArrayAdn = new string[] { "CATTA", "GGTCT", "TTATG", "CTTAG", "CGTAT" };
            dna.dna = ArrayAdn;

            HttpStatusCode expect = HttpStatusCode.Forbidden;

            //act
            var response = _obj.DetectarMutant(dna);

            //Assert -> Evaluar respuestas
            Assert.AreEqual(expect, response);
        }

        [TestMethod]
        public void TrueMutant4X4_DetectarHumano()
        {
            _obj = new BMMutant();
            //arrange -> Variables
            DTAdn dna = new DTAdn();
            string[] ArrayAdn;
            ArrayAdn = new string[] { "ATGC", "CAGT", "TTAT", "AGAA"};
            dna.dna = ArrayAdn;

            HttpStatusCode expect = HttpStatusCode.OK;

            //act
            var response = _obj.DetectarMutant(dna);

            //Assert -> Evaluar respuestas
            Assert.AreEqual(expect, response);
        }

        [TestMethod]
        public void FalseMutant3X3_DetectarHumano()
        {
            _obj = new BMMutant();
            //arrange -> Variables
            DTAdn dna = new DTAdn();
            string[] ArrayAdn;
            ArrayAdn = new string[] { "ATG", "CAG", "TTA"};
            dna.dna = ArrayAdn;

            HttpStatusCode expect = HttpStatusCode.Forbidden;

            //act
            var response = _obj.DetectarMutant(dna);

            //Assert -> Evaluar respuestas
            Assert.AreEqual(expect, response);
        }

        [TestMethod]
        public void FalseMutant2X3_DetectarHumano()
        {
            _obj = new BMMutant();
            //arrange -> Variables
            DTAdn dna = new DTAdn();
            string[] ArrayAdn;
            ArrayAdn = new string[] { "AT", "CG", "TT" };
            dna.dna = ArrayAdn;

            HttpStatusCode expect = HttpStatusCode.Forbidden;

            //act
            var response = _obj.DetectarMutant(dna);

            //Assert -> Evaluar respuestas
            Assert.AreEqual(expect, response);
        }

        public void FalseMutant1X1_DetectarHumano()
        {
            _obj = new BMMutant();
            //arrange -> Variables
            DTAdn dna = new DTAdn();
            string[] ArrayAdn;
            ArrayAdn = new string[] { "A" };
            dna.dna = ArrayAdn;

            HttpStatusCode expect = HttpStatusCode.Forbidden;

            //act
            var response = _obj.DetectarMutant(dna);

            //Assert -> Evaluar respuestas
            Assert.AreEqual(expect, response);
        }


    }
}
