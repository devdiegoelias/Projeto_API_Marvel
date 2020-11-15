using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;



namespace ProjetoPagouFacil
{
    class PersonagensRepository
    {
        HttpClient client;

        string host = "http://gateway.marvel.com";
        string link = "/v1/public/series?ts=1&apikey=473da253b3977826288936c4a61c0991&hash=8be15a064f1557728066139e0619aaf6";

        List<Personagens> PersonagemMarvel = new List<Personagens>();

        public PersonagensRepository()
        {
            if (client == null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri(host);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            }
        }  
        
        public void GetPersonagens()
        {
            Console.WriteLine("Consultando API ...");
            HttpResponseMessage response = client.GetAsync(link).Result;

            try
            {
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;

                    dynamic results = JsonConvert.DeserializeObject<dynamic>(result);
                    var PersonagensJson = results["data"]["results"];

                    List<Personagens> Persona = new List<Personagens>();

                    /*
                         Os dados poderia ser inseridos diretamente da API para o arquivo, mas para manter melhor o codigo organizado e com uma melhor manutenibilidade,
                         foi criado uma class "Personagens" para os dados, assim podem ser tratados da melhor maneira orientado a objetos.
                    */

                    foreach (var items in PersonagensJson)
                    {
                        string id = items["id"];
                        string description = items["description"];
                        string series = items["resourceURI"];

                        Personagens Personagem = new Personagens(id, description, series);

                        var itemComics = items["comics"]["items"];
                        Personagem.addComics(itemComics);

                        var itemStories = items["stories"]["items"];
                        Personagem.addStories(itemStories);

                        var itemEvents = items["events"]["items"];
                        Personagem.addEvents(itemEvents);

                        PersonagemMarvel.Add(Personagem);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro durante o processamento: " + e.Message);
            }
        }

        public void GeraArquivoNaTela()
        {
            foreach (var imprimir in PersonagemMarvel)
            {
                imprimir.imprimirTela();
            }
        }

        public void GeraArquivo()
        {
            Console.WriteLine("Gerando Arquivo!");
            Arquivo.geraArquivo(PersonagemMarvel);
        }
    }
}
