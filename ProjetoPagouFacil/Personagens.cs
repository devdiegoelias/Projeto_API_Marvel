using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace ProjetoPagouFacil
{
    class Personagens
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Series { get; set; }

        public ICollection<String> Comics { get; set; } = new List<string>();
        public ICollection<String> Stories { get; set; } = new List<string>(); 
        public ICollection<String> Events { get; set; } = new List<string>();

        public Personagens(string id, string description, string series)
        {
            Id = id;
            Series = series.Substring(43);
            if (!string.IsNullOrEmpty(description)) { Description = description; } else { Description = "Sem registro"; };
        }

        public void addComics(dynamic itemComics)
        {
            if (itemComics.Count > 0)
            {
                foreach (var campo in itemComics)
                {
                    Comics.Add(Convert.ToString(campo["name"]));
                }
            }
            else
            {
                Comics.Add(Convert.ToString("Sem registro"));
            }
        }
        public void addStories(dynamic itemStories)
        {
            if (itemStories.Count > 0)
            {
                foreach (var campo in itemStories)
                {
                    Stories.Add(Convert.ToString(campo["name"]));
                }
            }
            else
            {
                Stories.Add(Convert.ToString("Sem registro"));
            }
        }
        public void addEvents(dynamic itemEvents)
        {
            if (itemEvents.Count > 0)
            {
                foreach (var campo in itemEvents)
                {
                    Events.Add(Convert.ToString(campo["name"]));
                }
            }
            else
            {
                Events.Add(Convert.ToString("Sem registro"));
            }
        }

        public void imprimirTela()
        {
            Console.WriteLine("ID: " + Id);
            Console.WriteLine("Descrição : " + Description);
            Console.WriteLine("Serie: " + Series);

            Console.WriteLine(" ------ Comics ------");

            foreach (var c in Comics)
            {
                Console.WriteLine("Name Comics: " + c);
            }

            Console.WriteLine(" ------ Stories ------");

            foreach (var s in Stories)
            {
                Console.WriteLine("Name Stories: " + s);
            }

            Console.WriteLine(" ------ Events ------");

            foreach (var e in Events)
            {
                Console.WriteLine("Name Events: " + e);
            }
            Console.WriteLine("");
            Console.WriteLine(" --- --- --- --- --- --- ---");
            Console.WriteLine("");
        }
    }
}
