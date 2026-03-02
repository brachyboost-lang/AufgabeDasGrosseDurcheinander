//Sie Erhalten Einen Container mit verschiedenen Gütern. Diese müssen Sie sortieren und auswerten.
//Das Problem  Die Gueter wurden den falschen Gefahrenklassen zugeordnet, also tragen die falschen Etiketten.

//Aufgabe 1: Schreibe ein LINQ Query um alle Güter aus der Container-Liste in der Konsole Auszugeben  
//Aufgabe 2: Schreiben Sie eine Methode, die die Güter in die richtigen Hallen sortiert und eine Auswertung
//über die falsch gelagerten Güter ausgibt.
//Aufgabe 3: Schreiben Sie eine Methode die die Etiketten der Güter Korrigiert, damit die Güter in Zukunft richtig gelagert werden können.
//Aufgabe 4: Schreiben Sie eine Methode der automatisch alle Hallen prüft auf falsche Etiketten.

//WICHTIG: Sie dürfen nur in der Program.cs arbeiten und die CargoAdministration.cs nicht verändern!!!

namespace DasGroßeDurcheinander
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CargoAdministration.ImportCargo();
            Console.WriteLine("Neue Lieferung eingetroffen\t(Drücken Sie eine Taste zum anzeigen.)");
            Console.ReadKey();
            CheckContainer();
            Console.WriteLine("Auswahl:\n1.");
            CorrectLabelInContainer();
            SortContainerToHall();
            CheckHalls();
            CargoAdministration.InspectCargo();
        }

        private static void CheckContainer()
        {
            var query = from c in CargoAdministration.CargoContainer
                        select c;
            int count = 0;
            Console.WriteLine("Cargocontainer Inhalt:");
            foreach (var c in query)
            {
                count++;
                Console.WriteLine($"{count}. {c.Label}");
            }
            count = 0;
            Console.WriteLine("Cargocontainer vollständig durchsucht.");
        }
        private static void SortContainerToHall()
        {

            for (int i = CargoAdministration.CargoContainer.Count - 1; i >= 0; i--)
            {
                var c = CargoAdministration.CargoContainer[i];
                if (c is Category1)
                {
                    CargoAdministration.Hall1.Add(c);
                }
                else if (c is Category7)
                {
                    CargoAdministration.Hall7.Add(c);
                }
                else
                {
                    CargoAdministration.Hall9.Add(c);
                }
                CargoAdministration.CargoContainer.RemoveAt(i);
            }
        }
        private static void CheckHalls()
        {
            foreach (var c in CargoAdministration.Hall1)
            {
                if (c is not Category1)
                {
                    Console.WriteLine($"Falsches Etikett in Halle 1: {c.ReadLabel}");
                    CargoAdministration.CargoContainer.Add(c);
                    CargoAdministration.Hall1.Remove(c);
                    Console.WriteLine($"ID: {c.Id} wurde in den Cargocontainer umgelagert.");
                }
            }
            foreach (var c in CargoAdministration.Hall7)
            {
                if (c is not Category7)
                {
                    Console.WriteLine($"Falsches Etikett in Halle 7: {c.ReadLabel}");
                    CargoAdministration.CargoContainer.Add(c);
                    CargoAdministration.Hall7.Remove(c);
                    Console.WriteLine($"ID: {c.Id} wurde in den Cargocontainer umgelagert.");
                }
            }
            foreach (var c in CargoAdministration.Hall9)
            {
                if (c is not Category9)
                {
                    Console.WriteLine($"Falsches Etikett in Halle 9: {c.ReadLabel}");
                    CargoAdministration.CargoContainer.Add(c);
                    CargoAdministration.Hall9.Remove(c);
                    Console.WriteLine($"ID: {c.Id} wurde in den Cargocontainer umgelagert.");
                }
            }
        }
        private static void CorrectLabelInContainer()
        {
            foreach (var c in CargoAdministration.CargoContainer)
            {
                if (c is Category1)
                {
                    c.Label = "Explosive Güter";
                    Console.WriteLine($"{c.Id} wurde verändert.");
                }
                else if (c is Category7)
                {
                    c.Label = "Radioaktive Güter";
                    Console.WriteLine($"{c.Id} wurde verändert.");
                }
                else
                {
                    c.Label = "Wenig Gefährliche Stoffe";
                    Console.WriteLine($"{c.Id} wurde verändert.");
                }
            }
        }
    }
}
