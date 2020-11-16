using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjetoPagouFacil
{
    class Arquivo
    {
        public static void geraArquivo(List<Personagens> PersonagensMarvel)
        {
            string caminho = @"c:\Projeto_API_Marvel\personagensmarvel.txt";

            var text = PersonagensMarvel.ToString();

            try
            {
                using (StreamWriter sw = File.CreateText(caminho))
                {
                    foreach (var imprimir in PersonagensMarvel)
                    {
                        sw.WriteLine("ID: " + imprimir.Id);
                        sw.WriteLine("Descrição: " + imprimir.Description);
                        sw.WriteLine("Serie: " + imprimir.Series);

                        sw.WriteLine("");
                        sw.WriteLine(" ------ Comics ------");

                        foreach (var c in imprimir.Comics)
                        {
                            sw.WriteLine("Name Comics: " + c);
                        }

                        sw.WriteLine("");
                        sw.WriteLine(" ------ Stories ------");

                        foreach (var s in imprimir.Stories)
                        {
                            sw.WriteLine("Name Stories: " + s);
                        }

                        sw.WriteLine("");
                        sw.WriteLine(" ------ Events ------");

                        foreach (var e in imprimir.Events)
                        {
                            sw.WriteLine("Name Events: " + e);
                        }
                        sw.WriteLine("");
                        sw.WriteLine(" --- --- --- --- --- --- --- --- --- --- # --- --- --- --- --- --- --- --- --- ---");
                        sw.WriteLine("");
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Erro ao processar o arquivo!: " + e.Message);
            }
        }
    }
}
