using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reisefradrag.Dto;
using Reisefradrag.services;

namespace TestReisefradrag
{
    [TestClass]
    public class TestReisefradragReiseUtgifter
    {
        public ReisefradragBeregner2017 FradragsBeregner { get; set; }

        [TestInitialize]
        public void Init()
        {
            FradragsBeregner = new ReisefradragBeregner2017();
        }

        [TestMethod]
        public void IngenReiseutgifterEnkelAvstandsUtgift_ReturnAvstandsfradrag()
        {
            var reiseUtgift = 0M;
            var arbeidsReiser = new List<Arbeidsreise>()
            {
                new Arbeidsreise()
                {
                    km = 30000,
                    antall = 1
                }
            };

            var fradrag = FradragsBeregner.BeregnFradrag(arbeidsReiser, new(), reiseUtgift);

            Assert.AreEqual(23000, fradrag);
        }

        [TestMethod]
        public void IngenReiseutgifterEnkelBesoeksUtgift_ReturnBesoeksfradrag()
        {
            var reiseUtgift = 0M;
            var besoeksReiser = new List<Besoeksreise>()
            {
                new Besoeksreise()
                {
                    km = 30000,
                    antall = 1
                }
            };

            var fradrag = FradragsBeregner.BeregnFradrag(new(), besoeksReiser, reiseUtgift);

            Assert.AreEqual(23000, fradrag);
        }

        [TestMethod]
        public void ReiseutgiftUnderTerskelEnkelAvstandsUtgift_ReturnAvstandsfradrag()
        {
            var reiseUtgift = 1625.9M;
            var arbeidsReiser = new List<Arbeidsreise>()
            {
                new Arbeidsreise()
                {
                    km = 30000,
                    antall = 1
                }
            };

            var fradrag = FradragsBeregner.BeregnFradrag(arbeidsReiser, new(), reiseUtgift);

            Assert.AreEqual(23000, fradrag);
        }

        [TestMethod]
        public void ReiseutgiftOverTerskelEnkelAvstandsUtgift_ReturnAvstandsfradrag()
        {
            var reiseUtgift = 3625.9M;
            var arbeidsReiser = new List<Arbeidsreise>()
            {
                new Arbeidsreise()
                {
                    km = 30000,
                    antall = 1
                }
            };

            var fradrag = FradragsBeregner.BeregnFradrag(arbeidsReiser, new(), reiseUtgift);

            Assert.AreEqual(26625.9M, fradrag);
        }
    }
}
