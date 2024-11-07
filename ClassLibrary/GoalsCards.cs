using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class GoalsCards
    {
        public string Name { get; set; }

        public int Goals {  get; set; }

        public int YellowCards { get; set; }

        public override string ToString()
        {
            return $"{Name} {Goals} {YellowCards}";
        }
    }
}
