using Reisefradrag.Dto;

namespace Reisefradrag.services
{
    public interface IReisefradragBeregner
    {
        public decimal BeregnFradrag(List<Arbeidsreise> arbeidsReiser, List<Besoeksreise> besoeksreiser, decimal utgifterBomFergeEtc);
    }
}
