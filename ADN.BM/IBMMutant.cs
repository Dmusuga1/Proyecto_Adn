using ADN.DT;
using System.Net;

namespace ADN.BM
{
    public interface IBMMutant
    {
        HttpStatusCode DetectarMutant(DTAdn dna);

        DTStats stat();
    }
}
