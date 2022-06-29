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
                string[,] matriz;
                DTParameter data = new DTParameter();

                if (dna.dna != null)
                {
                    int columnas = dna.dna.Length;
                    char[] CountCharacters = dna.dna[0].ToCharArray();
                    int filas = CountCharacters.Length;
                    data.adn = string.Join("", dna.dna);
                    data.isMutante = false;
                    if (filas > 0)
                    {
                        if (filas > 3 && columnas > 3)
                        {
                            //Crear matriz
                            matriz = new string[columnas, filas];
                            int count = 0;
                            foreach (var item in dna.dna)
                            {
                                char[] characters = item.ToCharArray();
                                for (int j = 0; j < characters.Length; j++)
                                {
                                    matriz[count, j] = characters[j].ToString();
                                }
                                count = count + 1;
                            }

                            int Oblicua = AlgoritmoMutant(matriz, filas - 3, filas - 3, "Oblicua");
                            int Vertical = AlgoritmoMutant(matriz, columnas - 3, filas, "Vertical");
                            int Horizontal = AlgoritmoMutant(matriz, columnas, filas - 3, "Horizontal");

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
            catch (Exception ex)
            {

                throw ex;
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
