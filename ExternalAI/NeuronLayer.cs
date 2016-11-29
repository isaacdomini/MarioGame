using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.AI
{
    public class NeuronLayer
    {
        private int _numNeurons;
        private List<Neuron> _neurons;

        public List<Neuron> Neurons
        {
            get { return _neurons; }
        }

        public NeuronLayer(int NumNeurons, int NumInputsPerNeuron)
        {
            _neurons = new List<Neuron>();
            _numNeurons = NumNeurons;
            for (int i = 0; i < _numNeurons; ++i)
            {
                _neurons.Add(new Neuron(NumInputsPerNeuron));
            }
        }
    }
}
