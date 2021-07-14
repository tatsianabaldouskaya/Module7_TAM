using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module7_TAM_V2.Utils
{
    public class Randomizer
    {
        public static int GetRandom()
        {
            Random rnd = new Random();
            int value = rnd.Next();
            return value;
        }
    }
}
