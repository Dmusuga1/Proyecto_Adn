using ADN.DM;
using ADN.DT;
using ADN.SUP;
using System;
using System.Linq;
using System.Net;

namespace ADN.BM
{
    public class BMMutant : IBMMutant
    {
        public HttpStatusCode DetectarMutant(DTAdn dna)
        {
            try
            {
                string[,] matrix;
                DTParameter data = new DTParameter();

                if (dna.dna != null )
                {
                    char[] CountCharacters = dna.dna[0].ToCharArray();
                    int cantidad = CountCharacters.Length;
                    data.adn = string.Join("", dna.dna);
                    data.isMutante = false;
                    if (cantidad > 0)
                    {
                        if (cantidad > 3 && dna.dna.Length > 3)
                        {
                            matrix = new string[cantidad, cantidad];
                            for (int i = 0; i < cantidad; i++)
                            {
                                char[] characters = dna.dna[i].ToCharArray();
                                string charsStr = new string(characters);

                                for (int j = 0; j < characters.Length; j++)
                                {
                                    matrix[i, j] = characters[j].ToString();
                                }
                            }

                            int Oblicua = AlgoritmoMutant(matrix, cantidad/2, cantidad/2, "Oblicua");
                            int Horizontal = AlgoritmoMutant(matrix, cantidad, cantidad/2, "Horizontal");
                            int Vertical = AlgoritmoMutant(matrix, cantidad/2, cantidad, "Vertical");
                            if (Oblicua > 0 || Horizontal > 0 || Vertical > 0)
                            {
                                data.isMutante = true;
                            }
                        }

                        var response = new DMGeneral<DTParameter>().Add(SUPProcedures.sp_InsertAdn, data);

                        if (data.isMutante)
                        {
                            return HttpStatusCode.OK;
                        }

                        return HttpStatusCode.Forbidden;
                    }
                }
                return HttpStatusCode.NotAcceptable;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int AlgoritmoMutant(string[,] dna, int length_i, int length_j, string tipo)
        {
            try
            {
                int contador = 0;

                for (int i = 0; i < length_i; i++)
                {
                    for (int j = 0; j < length_j; j++)
                    {
                        if (tipo == "Oblicua")
                        {
                            if (dna[i, j] == dna[i + 1, j + 1] &&
                           dna[i + 1, j + 1] == dna[i + 2, j + 2] &&
                           dna[i + 2, j + 2] == dna[i + 3, j + 3])
                            {
                                contador = contador + 1;
                            }
                        }
                        else if (tipo == "Horizontal")
                        {
                            if (dna[i, j] == dna[i, j + 1] &&
                                dna[i, j + 1] == dna[i, j + 2] &&
                                dna[i, j + 2] == dna[i, j + 3])
                            {
                                contador = contador + 1;
                            }
                        }
                        else
                        {
                            if (dna[i, j] == dna[i + 1, j] &&
                                dna[i + 1, j] == dna[i + 2, j] &&
                                dna[i + 2, j] == dna[i + 3, j])
                            {
                                contador = contador + 1;
                            }
                        }

                    }
                }

                return contador;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DTStats stat()
        {
            DTStats response = new DTStats();

            try
            {
                response = new DMGeneral<DTStats>().GetListSQL(SUPProcedures.sp_stats, null).First();
            }
            catch (Exception)
            {

                throw;
            }
            return response;
        }
    }
}
