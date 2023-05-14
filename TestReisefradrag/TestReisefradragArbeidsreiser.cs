using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reisefradrag.Dto;
using Reisefradrag.services;

namespace TestReisefradrag.UnitTests
{
    [TestClass]
    public class TestReisefradragArbeidsreiser
    {
        public ReisefradragBeregner2017 FradragsBeregner { get; set; }

        [TestInitialize]
        public void Init()
        {
            FradragsBeregner = new ReisefradragBeregner2017();
        }

        [TestMethod]
        public void IngenArbeidsreiser_ReturnIngenFradrag()
        {
            var arbeidsReiser = new List<Arbeidsreise>();

            var fradrag = FradragsBeregner.BeregnFradrag(arbeidsReiser, new(), 0);

            Assert.AreEqual(0, fradrag);
        }

        [TestMethod]
        public void EnArbeidsreise_Under50Kantall1()
        {
            var arbeidsReiser = new List<Arbeidsreise>()
            {
                new Arbeidsreise()
                {
                    km = 30000,
                    antall = 1
                }
            };

            var fradrag = FradragsBeregner.BeregnFradrag(arbeidsReiser, new(), 0);

            Assert.AreEqual(23000, fradrag);
        }

        [TestMethod]
        public void EnArbeidsreise_Over50Kantall1()
        {
            var arbeidsReiser = new List<Arbeidsreise>()
            {
                new Arbeidsreise()
                {
                    km = 60000,
                    antall = 1
                }
            };

            var fradrag = FradragsBeregner.BeregnFradrag(arbeidsReiser, new(), 0);

            Assert.AreEqual(60000, fradrag);
        }

        [TestMethod]
        public void EnArbeidsreise_Over75Kantall1()
        {
            var arbeidsReiser = new List<Arbeidsreise>()
            {
                new Arbeidsreise()
                {
                    km = 80000,
                    antall = 1
                }
            };

            var fradrag = FradragsBeregner.BeregnFradrag(arbeidsReiser, new(), 0);

            Assert.AreEqual(70500, fradrag);
        }

        [TestMethod]
        public void EnArbeidsreise_Over50Kantall2()
        {
            var arbeidsReiser = new List<Arbeidsreise>()
            {
                new Arbeidsreise()
                {
                    km = 30000,
                    antall = 2
                }
            };

            var fradrag = FradragsBeregner.BeregnFradrag(arbeidsReiser, new(), 0);

            Assert.AreEqual(60000, fradrag);
        }

        [TestMethod]
        public void ToArbeidsreiser_Under50Kantall1()
        {
            var arbeidsReiser = new List<Arbeidsreise>()
            {
                new Arbeidsreise()
                {
                    km = 10000,
                    antall = 1
                },
                new Arbeidsreise()
                {
                    km = 15000,
                    antall = 1
                }
            };

            var fradrag = FradragsBeregner.BeregnFradrag(arbeidsReiser, new(), 0);

            Assert.AreEqual(15500, fradrag);
        }

        [TestMethod]
        public void ToArbeidsreiser_Over50Kantall3()
        {
            var arbeidsReiser = new List<Arbeidsreise>()
            {
                new Arbeidsreise()
                {
                    km = 10000,
                    antall = 3
                },
                new Arbeidsreise()
                {
                    km = 15000,
                    antall = 3
                }
            };

            var fradrag = FradragsBeregner.BeregnFradrag(arbeidsReiser, new(), 0);

            Assert.AreEqual(70500, fradrag);
        }

        [TestMethod]
        public void MangeArbeidsreiser_UliktAntall()
        {
            var arbeidsReiser = new List<Arbeidsreise>()
            {
                new Arbeidsreise()
                {
                    km = 7295,
                    antall = 2
                },
                new Arbeidsreise()
                {
                    km = 19245,
                    antall = 1
                },
                new Arbeidsreise()
                {
                    km = 1,
                    antall = 100
                }
                ,
                new Arbeidsreise()
                {
                    km = 1239,
                    antall = 13
                }
            };

            var fradrag = FradragsBeregner.BeregnFradrag(arbeidsReiser, new(), 0);

            Assert.AreEqual(53029.4M, fradrag);
        }
    }
}
