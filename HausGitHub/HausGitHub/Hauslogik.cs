using NLog;
using System;
using System.Text.RegularExpressions;

namespace Haus
{
    class Hauslogik
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        Fenster window;
        Jalosien jalosien;
        Klimaanlage airconditioning;
        Licht light;
        //Vorher: public Schnittstelle(ref Fenster window, ref Jalosien jalosien, ref Klimaanlage airconditioning, ref Licht light)
        public Hauslogik()
        {
            window = new Fenster();
            jalosien = new Jalosien();
            airconditioning = new Klimaanlage();
            light = new Licht();
        }

        public bool IsLightOn()
        {
            return light.IsOn;
        }

        public bool IsWindowOpen()
        {
            return window.IsOpen;
        }

        public bool IsAirConditioningOn()
        {
            return airconditioning.IsOn;
        }
        //Jalosien
        public void CanChangeMovementOfJalosien(string value)
        {
            Regex rgx = new Regex(@"^(hoch|runter)\s[0-9]{1,3}$");
            if (!rgx.IsMatch(value))
            {
                throw new ArgumentException("Falsche Eingabe");
            }
        }

        public void ChangeCurrentMovementOfJalosien(string value)
        {
            jalosien.ProcessJalosienMovement(value);
        }

        public int GetCurrentMovementOfJalosien()
        {
            return jalosien.CurrentMovement;
        }
        //Light
        public void ChangeCurrentStateOfLight()
        {
            light.ChangeState();
        }
        //Window
        public void CanChangeStateOfWindow()
        {
            if (airconditioning.IsOn)
                throw new ArgumentException("Klimaanlage noch an");
        }

        public void ChangeCurrentStateOfWindow()
        {
            window.ChangeState();
        }
        //Air conditioner
        public void CanChangeStateOfAirconditioner()
        {
            if (window.IsOpen)
                throw new ArgumentException("Fenster noch offen");
        }

        public void ChangeCurrentStateOfAirConditioner()
        {
            airconditioning.ChangeState();
        }

    }
}
