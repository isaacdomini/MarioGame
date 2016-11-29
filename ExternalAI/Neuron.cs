using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.AI
{
    public class Neuron
    {
        private int _numInputs;
        private List<double> _weights;

        public int NumInputs
        {
            get { return _numInputs;}
        }

        public List<double> Weights
        {
            get { return _weights; }
            set { _weights = value; }
        }

        public Neuron(int NumInputs)
        {
            _weights = new List<double>();
            Random rand = new Random();
            double weight;
            //There's a bias weight, hence the +1
            for (int i = 0; i < NumInputs + 1; ++i)
            {
                weight = rand.NextDouble();
                if (rand.Next(2) == 1)
                    weight *= -1;
                _weights.Add(weight);
            }
            _numInputs = NumInputs;
        }
    }
}
