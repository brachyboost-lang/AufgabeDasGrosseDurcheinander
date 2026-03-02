using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DasGroßeDurcheinander
{
    sealed class CargoAdministration
    { 
        public static List<Cargo> CargoContainer = [];

        public static List<Cargo> Hall1 = []; //Die Halle 1 ist für Klasse 1: Explosive Güter
        public static List<Cargo> Hall7 = []; //Die Halle 7 ist für Klasse 7: Radioaktive Güter
        public static List<Cargo> Hall9 = []; //Die Halle 9 ist für Klasse 9: Wenig Gefährliche Stoffe

        public static void ImportCargo()
        {

            for(int i = 0; i < 10; i++)
            {
                var r = new Random().Next(3);
                Cargo g = r == 0 ? new Category1() : r == 1 ? new Category7() : new Category9();
                CargoContainer.Add(g);

            }
        }

        public static void InspectCargo()
        {
            foreach(var g in Hall1)
            {
                
                if(g.GetType() == typeof(Category9))
                {
                    Console.WriteLine("Was macht das Eis hier es schmilzt geschmolzen");
     
                }
                else if (g.GetType() == typeof(Category7))
                {
                    Console.WriteLine("Radioaktive Strahlung in der Halle der Sprengstoff ist jetzt Radioaktiv");
               
                }
                else
                {
                    Console.WriteLine("Richtig verräumt");
                }
            }

            foreach (var g in Hall7)
            {
                if (g.GetType() == typeof(Category9))
                {
                    Console.WriteLine("Da ist jetzt Radioaktivverseuchtes Speiseeis im Halle 7");
     
                }
                else if (g.GetType() == typeof(Category1))
                {
                    Console.WriteLine("KABOOOM!!!!");
                   
                }
                else
                {
                    Console.WriteLine("Richtig verräumt");
                }
            }

            foreach (var g in Hall9)
            {
                if (g.GetType() == typeof(Category7))
                {
                    Console.WriteLine("Das Ganze Eis in Halle 9 ist jetzt Radioaktiv verseucht");
                  
                }
                else if (g.GetType() == typeof(Category1))
                {
                    Console.WriteLine("KABOOOM!!!!");
                  
                }
                else
                {
                    Console.WriteLine("Richtig verräumt");
                }
            }


        }

    }

    public abstract class Cargo
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Label { get; set; }

        protected string? Classification { get; set; }


        public Cargo() 
        {
            int i = new Random().Next(3);
            Label = i == 0 ? "Klasse 7: Uran 235" : i == 1 ? "Klasse 1: Plastiksprengstoff" : "Klasse 9: Mit CO2 versetztes Speiseeis";        
        }

       internal string ZeigeInfo(Cargo obj)
       { 
            return obj.Label ?? "";
       }

        public void ReadLabel()
        {
            Console.WriteLine($"\n\nID: {Id}\nEtikett: {Label}\nTatsächliche Probe und Zuordnung: {Classification}");
        }
    }

    public class Category1 : Cargo
    {
        public Category1() : base()
        {
            Classification = "Halle 1: Explosive Güter";
        }
    }

    public class Category7 : Cargo
    {
        public Category7() : base()
        {
            Classification = "Halle 7: Radioaktive Güter";
        }
    }

    public class Category9 : Cargo
    {
        public Category9() : base()
        {
            Classification = "Halle 9: Wenig Gefärliche Stoffe";
        }
    }



}
