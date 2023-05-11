using Reisefradrag.Dto;

namespace Reisefradrag.services
{
    public class ReisefradragBeregner2017 : IReisefradragBeregner
    {
        const decimal EgenAndel = 22000M;
        const decimal ReiseUtgiftThreshold = 3400M;

        public decimal BeregnFradrag(List<Arbeidsreise> arbeidsReiser, List<Besoeksreise> besoeksreiser, decimal utgifterBomFergeEtc)
        {
            var avstandsUtgifter = GetAvstandsUtgifter(arbeidsReiser, besoeksreiser);
            var reiseUtgifter = GetReiseUtgifter(utgifterBomFergeEtc);

            var utgifter = avstandsUtgifter + reiseUtgifter;
            var fradrag = utgifter - EgenAndel;
            if(fradrag < 0)
            {
                return 0;
            }

            return fradrag;
        }

        private decimal GetReiseUtgifter(decimal utgifterBomFergeEtc)
        {
            if(utgifterBomFergeEtc > ReiseUtgiftThreshold)
            {
                return utgifterBomFergeEtc;
            }

            return 0M;
        }

        private decimal GetAvstandsUtgifter(List<Arbeidsreise> arbeidsReiser, List<Besoeksreise> besoeksreiser)
        {
            var totalAvstand = GetTotalAvstand(arbeidsReiser, besoeksreiser);

            decimal avstandsUtgifter = totalAvstand * 1.5M;
            if (totalAvstand > 50000)
            {
                avstandsUtgifter = 50000 * 1.5M;
                var avstandOver50K = totalAvstand - 50000;
                avstandsUtgifter += avstandOver50K * 0.7M;
            }

            return avstandsUtgifter;
        }

        private long GetTotalAvstand(List<Arbeidsreise> arbeidsReiser, List<Besoeksreise> besoeksreiser)
        {
            long totalAvstand = 0;
            foreach (var arbReise in arbeidsReiser)
            {
                totalAvstand += arbReise.antall * arbReise.km;
            }

            foreach (var besReise in besoeksreiser)
            {
                totalAvstand += besReise.antall * besReise.km;
            }

            if (totalAvstand > 75000)
            {
                return 75000;
            }

            return totalAvstand;
        }
    }
}
