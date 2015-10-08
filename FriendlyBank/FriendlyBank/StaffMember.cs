using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendlyBank
{
    public class StaffMember
    {
        private int ageValue;

        public int Age
        {
            set
            {
                if ((value > 0) && (value < 120))
                {
                    this.ageValue = value;
                }
            }
            get
            {
                return this.ageValue;
            }
        }

        public int AgeInMonths
        {
            get { return this.ageValue*12; }
        }
    }
}
