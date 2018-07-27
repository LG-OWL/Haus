using NLog;
using System;

namespace Haus
{
    class Program
    {
        //First and last day
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static Hauslogik houselogic = new Hauslogik();
        static void Main(string[] args)
        {
            string option; 
            logger.Info("The program has been started."); 
            DoGreeting();
            do
            {
                Console.WriteLine(PresentOptions());
                option = Console.ReadLine();
                int pause = 5000;
                switch (option)
                {
                    case "1"://Light
                        Console.WriteLine(GetStateLightForResponse(houselogic.IsLightOn()));
                        houselogic.ChangeCurrentStateOfLight();
                        break;
                    case "2"://Jalosien
                        Console.WriteLine("[hoch|runter] Prozentzahl");
                        string value = Console.ReadLine();
                        try
                        {
                            houselogic.ChangeCurrentMovementOfJalosien(value);
                            Console.WriteLine(GetStateJalosienForAll(houselogic.GetCurrentMovementOfJalosien()));
                        }
                        catch (ArgumentException argumentexeption)
                        {
                            Console.WriteLine(argumentexeption.Message);
                        }
                        break;
                    case "3"://Window
                        try
                        {
                            houselogic.CanChangeStateOfWindow();
                            Console.WriteLine(GetStateWindowForResponse(houselogic.IsWindowOpen()));
                            houselogic.ChangeCurrentStateOfWindow();
                        }
                        catch (ArgumentException)
                        {
                            logger.Warn("Warn: Air conditioner was still on.");
                            houselogic.ChangeCurrentStateOfAirConditioner();
                            Console.WriteLine(GetStateAirconditioningForResponse(houselogic.IsAirConditioningOn()) + "\n" +
                               GetStateWindowForResponse(houselogic.IsWindowOpen()));
                            houselogic.ChangeCurrentStateOfWindow();
                        }
                        break;
                    case "4"://Air conditioning
                        try
                        {
                            houselogic.CanChangeStateOfAirconditioner();
                            houselogic.ChangeCurrentStateOfAirConditioner();
                            Console.WriteLine(GetStateAirconditioningForResponse(houselogic.IsAirConditioningOn()));
                        }
                        catch (ArgumentException)
                        {
                            logger.Warn("Warn: Windows were still open.");
                            houselogic.ChangeCurrentStateOfWindow();
                            Console.WriteLine(GetStateWindowForResponse(houselogic.IsWindowOpen()) + "\n" +
                               GetStateAirconditioningForResponse(houselogic.IsAirConditioningOn()));
                            houselogic.ChangeCurrentStateOfAirConditioner();
                        }
                        break;
                    case "5"://Leaving
                        pause = 0;
                        break;
                    default:
                        logger.Warn("Warn: Unknown option has been chosen.");
                        Console.WriteLine("Ungültige Eingabe");
                        break;
                }
                System.Threading.Thread.Sleep(pause);
                Console.Clear();
            } while (option != "5");
        }
        //OUTPUT
        static void DoGreeting()
        {
            string name;
            Console.WriteLine("Bitte geben Sie ihren Namen ein");
            name = Console.ReadLine();
            Console.WriteLine("Willkommen zurück " + name);
        }
        static string PresentOptions()
        {
            return "\n Was kann ich für Sie tun? \n 1.) " + GetStateLightForOption(houselogic.IsLightOn()) + " \n 2.) " + GetStateJalosienForAll(houselogic.GetCurrentMovementOfJalosien()) +
                    "\n 3.) " + GetStateWindowForOption(houselogic.IsWindowOpen()) + " \n 4.) " + GetStateAirconditioningForOption(houselogic.IsAirConditioningOn()) + "\n 5.) Schließen \n " +
                    "Bitte geben Sie für die jeweilige Option ihre Zahl ein.";
        }
        //WINDOW
        static string GetStateWindowForOption(bool isOn)
        {
            if (isOn)
            {
                return "Fenster sind offen.";
            }
            return "Fenster sind zu.";
        }

        static string GetStateWindowForResponse(bool isOn)
        {
            if (isOn)
            {
                return "Fenster wird zugemacht.";
            }
            return "Fenster wird aufgemacht.";
        }

        //LIGHT
        static string GetStateLightForOption(bool isOn)
        {
            if (isOn)
            {
                return "Lichter sind an.";
            }
            return "Lichter sind aus.";
        }

        static string GetStateLightForResponse(bool isOn)
        {
            if (isOn)
            {
                return "Licht wird ausgemacht.";
            }
            return "Licht wird angemacht.";
        }

        //Jalosien
        static string GetStateJalosienForAll(int currentMovement)
        {
            return "Die Jalosien sind momentan zu " + currentMovement.ToString() + "% unten";
        }

        //Air conditioning
        static string GetStateAirconditioningForOption(bool isOn)
        {
            if (!isOn)
            {
                return "Klimaanlage kann angemacht werden.";
            }
            return "Klimaanlage kann ausgemacht werden.";
        }

        static string GetStateAirconditioningForResponse(bool isOn)
        {
            if (!isOn)
            {
                return "Klimaanlage wird ausgemacht.";
            }
            return "Klimaanlage wird angemacht.";
        }
        //ERROR
        static string Error()
        {
            return "Da muss ein Fehler unterlaufen sein.";
        }
    }
}
