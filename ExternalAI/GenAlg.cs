using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.AI
{
    public class GenAlg
    {
        private List<Genome> _genomePopulation;
        private int _popSize;
        private int _genomeLength;
        private double _totalFitness;
        private double _bestFitness;
        private double _averageFitness;
        private double _worstFitness;
        private int _fittestGenome;
        private double _mutationRate;
        private double _crossoverRate;
        private int _generation;
    }
}
