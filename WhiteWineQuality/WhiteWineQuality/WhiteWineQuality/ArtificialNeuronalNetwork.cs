using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteWineQuality {
    public class ArtificialNeuronalNetwork {

        public Artificial_Neuron inputLayerList;
        public Artificial_Neuron hiddenLayerList;
        public Artificial_Neuron outputLayerList;
        public int numberNeuronsHiddenLayer;
        public double learningRate;
        public double errorTraining;
        public List<NormalizedWine> trainingList;
        public List<NormalizedWine> testList;
        public int numberStepsForEpoch;
       /* var random = new Random();
        var rDouble = random.NextDouble(0,1);*/
        public ArtificialNeuronalNetwork(List<NormalizedWine> trainingList, List<NormalizedWine> testList,int numberNeuronsHiddenLayer, double learningRate, double errorTraining) {
            this.numberNeuronsHiddenLayer = numberNeuronsHiddenLayer;
            this.learningRate = learningRate;
            this.errorTraining = errorTraining;
            this.trainingList = trainingList;
            this.testList = testList;

            inputLayerList = new Artificial_Neuron(11);
            hiddenLayerList = new Artificial_Neuron(numberNeuronsHiddenLayer);
            outputLayerList = new Artificial_Neuron(10);

            numberStepsForEpoch = trainingList.Count;
        }

        public 
        
    }
}
