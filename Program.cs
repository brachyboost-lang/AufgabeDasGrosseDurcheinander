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
            CheckForGoods();
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
            Console.WriteLine("Cargocontainer vollstaendig durchsucht.\t(Druecken Sie eine Tasten um zum Menu zurueckzukehren.");
            Console.ReadKey();
            MainMenu();
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
            Console.WriteLine("Alle Gueter wurden sortiert.\t(Druecken Sie eine Taste um zum Menu zurueckzukehren)");
            Console.ReadKey();
            MainMenu();
        }
        private static void CheckHalls()
        {
            for (int i = CargoAdministration.Hall1.Count - 1; i >= 0; i--)
            {
                var c = CargoAdministration.Hall1[i];
                bool matches = (c.Label.Contains("Klasse 1") || c.Label.Contains("Explosive") || c.Label.Contains("Explosive Gueter"));
                if (!matches)
                {
                    Console.WriteLine("Falsches Etikett in Halle 1:"); 
                    c.ReadLabel();
                    CargoAdministration.CargoContainer.Add(c);
                    CargoAdministration.Hall1.RemoveAt(i);
                    Console.WriteLine($"ID: {c.Id} wurde in den Cargocontainer umgelagert."); 
                }
            }
            for (int i = CargoAdministration.Hall7.Count - 1; i >= 0; i--)
            {
                var c = CargoAdministration.Hall7[i];
                bool matches = (c.Label.Contains("Klasse 7") || c.Label.Contains("Radioaktiv") || c.Label.Contains("Radioaktive"));
                if (!matches)
                {
                    Console.WriteLine("Falsches Etikett in Halle 7:");
                    c.ReadLabel();
                    CargoAdministration.CargoContainer.Add(c);
                    CargoAdministration.Hall7.RemoveAt(i);
                    Console.WriteLine($"ID: {c.Id} wurde in den Cargocontainer umgelagert.");
                }
            }
            for (int i = CargoAdministration.Hall9.Count - 1; i >= 0; i--)
            {
                var c = CargoAdministration.Hall9[i];
                bool matches = (c.Label.Contains("Klasse 9") || c.Label.Contains("Wenig") || c.Label.Contains("Wenig Gefaehrliche") || c.Label.Contains("Wenig Gefährliche"));
                if (!matches)
                {
                    Console.WriteLine("Falsches Etikett in Halle 9:");
                    c.ReadLabel();
                    CargoAdministration.CargoContainer.Add(c);
                    CargoAdministration.Hall9.RemoveAt(i);
                    Console.WriteLine($"ID: {c.Id} wurde in den Cargocontainer umgelagert.");
                }
            }
            Console.WriteLine("Alle Hallen wurden ueberprueft.\t(Druecken Sie eine Taste um zum Menu zurueckzukehren)");
            Console.ReadKey();
            MainMenu();
        }
        private static void CorrectLabelInContainer()
        {
            foreach (var c in CargoAdministration.CargoContainer)
            {
                if (c is Category1)
                {
                    c.Label = "Explosive Gueter";
                    Console.WriteLine($"{c.Id} wurde verändert.");
                }
                else if (c is Category7)
                {
                    c.Label = "Radioaktive Gueter";
                    Console.WriteLine($"{c.Id} wurde verändert.");
                }
                else
                {
                    c.Label = "Wenig Gefaehrliche Stoffe";
                    Console.WriteLine($"{c.Id} wurde verändert.");
                }
            }
            Console.WriteLine("Alle Etiketten im Container wurden korrigiert.\t(Druecken Sie eine Taste um zum Menu zurueckzukehren)");
            MainMenu();
        }
        private static void CheckForGoods()
        {
            if (CargoAdministration.CargoContainer.Count == 0)
            {
                Console.WriteLine("Keine Gueter im Container, bitte warten auf neue Lieferung.");
            }
            else
            {
                Console.WriteLine("Gueter in Cargocontainer gefunden. \nWollen Sie den Container inspizieren? Y/N");
                string input = Console.ReadLine();
                if (input != null)
                {
                    if (input.ToUpper() == "Y")
                    {
                        CheckContainer();
                    }
                    else
                    {
                        MainMenu();
                    }
                }
            }
        }
        private static void MainMenu()
        {
            if (CargoAdministration.Hall1.Count > 0 || CargoAdministration.Hall7.Count > 0 || CargoAdministration.Hall9.Count > 0)
            {
                Inspection();
            }
            Console.WriteLine("Bitte Auswaehlen:\n1. Labels korrigieren\n2. Güter aus Container in Hallen lagern\n3. Labels in Hallen überprüfen\n0. Programm beenden");
            string choice = Console.ReadLine();
            if (choice != null)
            {
                if (choice == "1")
                {
                    CorrectLabelInContainer();
                }
                else if (choice == "2")
                {
                    SortContainerToHall();
                }
                else if (choice == "3")
                {
                    CheckHalls();
                }
                else if (choice == "0")
                {
                    Console.WriteLine("Programm wird beendet.");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    Console.WriteLine("Ungueltige Auswahl.");
                    MainMenu();
                }
            }
        }
        private static void Inspection()
        {
            Random inspectionChance = new Random();
            inspectionChance.Next(0, 101);

            if (inspectionChance.Next(0, 101) < 20)
            {
                Console.WriteLine("UEBERASCHUNGSBESUCH! Inspektor kommt vorbei und will den Container inspizieren.\t(Druecken Sie eine Taste um fortzufahren)");
                Console.ReadKey();
                CargoAdministration.InspectCargo();
                Console.ReadKey();
            }
            else
            {
                return;
            }
        }
    }
}
