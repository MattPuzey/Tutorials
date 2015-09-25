using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerMax3000Console
{
    public class MenuItem
    {
        public string Title;
        public string Description;

        public double Price
        {
            get { return _price; }
            set {
                if (value > 0)
                {
                    _price = value;
                }
                else
                {
                    throw new Exception("You cannot have a free or negative valued items.");
                }
            }
        }

        private double _price;
    }
}
