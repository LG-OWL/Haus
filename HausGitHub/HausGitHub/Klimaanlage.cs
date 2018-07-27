using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;


namespace Haus
{
    class Klimaanlage
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public bool IsOn
        {
            get;
            set;
        }
        public Klimaanlage()
        {
            //Klimaanlage aus
            IsOn = false;
        }

        public void ChangeState()
        {
            if (IsOn)
            {
                IsOn = false;
            }
            else
            {
                IsOn = true;
            }
        }
    }
}
