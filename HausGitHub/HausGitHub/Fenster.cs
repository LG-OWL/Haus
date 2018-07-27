using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Haus
{
    class Fenster
    {
        Logger logger = LogManager.GetCurrentClassLogger();
        public bool IsOpen
        {
            get; set;
        }
        public Fenster()
        {
            //Fenster zu
            IsOpen = false;
        }

        public void ChangeState()
        {
            if (IsOpen)
            {
                IsOpen = false;
            }
            else
            {
                IsOpen = true;
            }
        }
    }
}
