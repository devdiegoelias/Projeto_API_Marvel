using System;
using System.Collections.Generic;

namespace ProjetoPagouFacil
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando Projeto");

            PersonagensRepository p = new PersonagensRepository();
            p.GetPersonagens();

            // Caso seja desejado a impressão dos dados também na tela, descomentar a linha abaixo
            //p.GeraArquivoNaTela();

            //Metordo para gerar arquivo
            p.GeraArquivo();

            Console.WriteLine("Concluido!");
        }
    }
}
