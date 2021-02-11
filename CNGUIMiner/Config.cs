using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimusBlueMiner
{
    public class Config
    {
        public List<Coin> Coins { get; set; }
        public string HelpText { get; set; }
    }

    public class Coin {
        public string Name { get; set; }
        public string PoolUrl { get; set; }
        public string WebUrl { get; set; }
        public string PoolPort { get; set; }
        public string Algo { get; set; }
    }
}
