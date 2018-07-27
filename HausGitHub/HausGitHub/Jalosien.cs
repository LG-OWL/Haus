using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Haus
{
    public class Jalosien
    {
        private int currentMovement;
        public Jalosien()
        {
            //Jalosien sind oben
            currentMovement = 0;
        }

        public int CurrentMovement
        {
            get { return currentMovement; }
            set
            {
                if (currentMovement + value > 100)
                {
                    currentMovement = 100;
                }
                else
                {
                    if (currentMovement + value < 0)
                    {
                        currentMovement = 0;
                    }
                    else
                    {
                        currentMovement += value;
                    }
                }
            }
        }

        public void ProcessJalosienMovement(string value)
        {
            Regex rgxUpDown = new Regex(@"hoch");
            string[] substrings;
            int goingUpDown, percentage;
            substrings = value.Split(' ');
            if (rgxUpDown.IsMatch(substrings[0]))
            {
                goingUpDown = -1;
            }
            else
            {
                goingUpDown = 1;
            }
            percentage = int.Parse(substrings[1]);
            CurrentMovement = goingUpDown * percentage;
        }
    }
}
