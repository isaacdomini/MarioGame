using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.AI
{
    public class Genome
    {
        private List<double> _weights;
        private double _fitness;

        public double Fitness
        {
            get { return _fitness; }
        }

        Genome(List<double> w)
        {
            _weights = w;
        }
    }
}
