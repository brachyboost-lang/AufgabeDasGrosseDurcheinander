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
            Program.CheckContainer();
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
    }
}
