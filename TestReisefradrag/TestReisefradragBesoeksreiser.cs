using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reisefradrag.Dto;
using Reisefradrag.services;

namespace TestReisefradrag.UnitTests
{
    [TestClass]
    public class TestReisefradragBesoeksreiser
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
            var besoeksReiser = new List<Besoeksreise>();

            var fradrag = FradragsBeregner.BeregnFradrag(new(), besoeksReiser, 0);

            Assert.AreEqual(0, fradrag);
        }

        [TestMethod]
        public void EnArbeidsreise_Under50Kantall1()
        {
            var besoeksReiser = new List<Besoeksreise>()
            {
                new Besoeksreise()
                {
                    km = 30000,
                    antall = 1
                }
            };

            var fradrag = FradragsBeregner.BeregnFradrag(new(), besoeksReiser, 0);

            Assert.AreEqual(23000, fradrag);
        }

        [TestMethod]
        public void EnArbeidsreise_Over50Kantall1()
        {
            var besoeksReiser = new List<Besoeksreise>()
            {
                new Besoeksreise()
                {
                    km = 60000,
                    antall = 1
                }
            };

            var fradrag = FradragsBeregner.BeregnFradrag(new(), besoeksReiser, 0);

            Assert.AreEqual(60000, fradrag);
        }

        [TestMethod]
        public void EnArbeidsreise_Over75Kantall1()
        {
            var besoeksReiser = new List<Besoeksreise>()
            {
                new Besoeksreise()
                {
                    km = 80000,
                    antall = 1
                }
            };

            var fradrag = FradragsBeregner.BeregnFradrag(new(), besoeksReiser, 0);

            Assert.AreEqual(70500, fradrag);
        }

        [TestMethod]
        public void EnArbeidsreise_Over50Kantall2()
        {
            var besoeksReiser = new List<Besoeksreise>()
            {
                new Besoeksreise()
                {
                    km = 30000,
                    antall = 2
                }
            };

            var fradrag = FradragsBeregner.BeregnFradrag(new(), besoeksReiser, 0);

            Assert.AreEqual(60000, fradrag);
        }

        [TestMethod]
        public void ToArbeidsreiser_Under50Kantall1()
        {
            var besoeksReiser = new List<Besoeksreise>()
            {
                new Besoeksreise()
                {
                    km = 10000,
                    antall = 1
                },
                new Besoeksreise()
                {
                    km = 15000,
                    antall = 1
                }
            };

            var fradrag = FradragsBeregner.BeregnFradrag(new(), besoeksReiser, 0);

            Assert.AreEqual(15500, fradrag);
        }

        [TestMethod]
        public void ToArbeidsreiser_Over50Kantall3()
        {
            var besoeksReiser = new List<Besoeksreise>()
            {
                new Besoeksreise()
                {
                    km = 10000,
                    antall = 3
                },
                new Besoeksreise()
                {
                    km = 15000,
                    antall = 3
                }
            };

            var fradrag = FradragsBeregner.BeregnFradrag(new(), besoeksReiser, 0);

            Assert.AreEqual(70500, fradrag);
        }

        [TestMethod]
        public void MangeArbeidsreiser_UliktAntall()
        {
            var besoeksReiser = new List<Besoeksreise>()
            {
                new Besoeksreise()
                {
                    km = 7295,
                    antall = 2
                },
                new Besoeksreise()
                {
                    km = 19245,
                    antall = 1
                },
                new Besoeksreise()
                {
                    km = 1,
                    antall = 100
                }
                ,
                new Besoeksreise()
                {
                    km = 1239,
                    antall = 13
                }
            };

            var fradrag = FradragsBeregner.BeregnFradrag(new(), besoeksReiser, 0);

            Assert.AreEqual(53029.4M, fradrag);
        }
    }
}
