using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haus
{
    class Licht
    {
        public bool IsOn
        {
            get; set;
        }

        public Licht()
        {
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
