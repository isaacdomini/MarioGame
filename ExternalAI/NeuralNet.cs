using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.AI
{
    public class NeuralNet
    {
        private int _numInputs;
        private int _numOutputs;
        private int _numHiddenLayers;
        private int _neuronsPerHiddenLayer;
        private List<NeuronLayer> _layers;

        public NeuralNet()
        {
            _layers = new List<NeuronLayer>();
        }

        public void CreateNet(int NumInputs, int NumOutputs, int HiddenLayers = 1, int NeuronsPerLayer = 4)
        {
            _numInputs = NumInputs;
            _numOutputs = NumOutputs;
            _numHiddenLayers = HiddenLayers;
            _neuronsPerHiddenLayer = NeuronsPerLayer;
            int previousNeurons = _numInputs;
            for (int i = 0; i < HiddenLayers; ++i)
            {
                _layers.Add(new NeuronLayer(_neuronsPerHiddenLayer, previousNeurons));
                previousNeurons = _neuronsPerHiddenLayer;
            }
            _layers.Add(new NeuronLayer(_numOutputs, previousNeurons));
        }

        private double Sigmoid(double x)
        {
            return 1/(1 + Math.Exp(-x));
        }

        public List<double> GetWeights()
        {
            List<double> weights = new List<double>();
            for (int i = 0; i < _numHiddenLayers; ++i)
            {
                for (int j = 0; i < _layers[i].Neurons.Count; j++)
                {
                    weights.AddRange(_layers[i].Neurons[j].Weights);
                    weights.RemoveAt(weights.Count - 1);
                }
            }
            return weights;
        }

        public int GetNumberOfWeights()
        {
            return GetWeights().Count();
        }

        public void PutWeights(List<double> weights)
        {
            for (int i = 0; i < _numHiddenLayers; ++i)
            {
                for (int j = 0; i < _layers[i].Neurons.Count; j++)
                {
                    _layers[i].Neurons[j].Weights = weights;
                }
            }
        }

        public List<double> Update(List<double> inputs)
        {
            List<double> outputs = new List<double>();

            int weightCount = 0;

            if (inputs.Count != _numInputs)
            {
                return outputs;
            }

            for (int i = 0; i < _numHiddenLayers + 1; i++)
            {
                if (i > 0)
                    inputs = outputs;

                outputs.Clear();

                weightCount = 0;

                for (int j = 0; j < _layers[i].Neurons.Count; j++)
                {
                    double netinput = 0;
                    int NumInputs = _layers[i].Neurons[j].NumInputs;

                    for (int k = 0; k < NumInputs - 1; k++)
                    {
                        netinput += _layers[i].Neurons[j].Weights[k]*inputs[weightCount++];
                    }

                    netinput += _layers[i].Neurons[j].Weights[NumInputs - 1]*-1;

                    outputs.Add(Sigmoid(netinput));

                    weightCount = 0;
                }

            }

            return outputs;
        }
    }
}
