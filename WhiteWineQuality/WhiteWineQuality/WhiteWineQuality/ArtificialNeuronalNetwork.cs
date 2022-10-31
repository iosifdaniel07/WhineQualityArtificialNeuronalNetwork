using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WhiteWineQuality {
    public class ArtificialNeuronalNetwork {

        public List<Artificial_Neuron> inputLayerList;
        public List<Artificial_Neuron> hiddenLayerList;
        public List<Artificial_Neuron> outputLayerList;
        public int numberNeuronsHiddenLayer;
        public double learningRate;
        public double errorTraining;
        public List<NormalizedWine> trainingList;
        public List<NormalizedWine> testList;
        public int numberStepsForEpoch;
        public bool flagTraining = true;
        public List<double> stepErrorList;
        public double eroareEpoca = 0;
        public double eroarePas;
        private int activareHidden = 0;
        private int activareOutput = 0;
        public double procentTestare;
        public int count;

        public ArtificialNeuronalNetwork(List<NormalizedWine> trainingList, List<NormalizedWine> testList, int numberNeuronsHiddenLayer, double learningRate, double errorTraining, int actHidden,int actOutput) {
            this.numberNeuronsHiddenLayer = numberNeuronsHiddenLayer;
            this.learningRate = learningRate;
            this.errorTraining = errorTraining;
            this.trainingList = trainingList;
            this.testList = testList;

            activareHidden = actHidden;
            activareOutput = actOutput;

            inputLayerList = new List<Artificial_Neuron>();
            hiddenLayerList = new List<Artificial_Neuron>();
            outputLayerList = new List<Artificial_Neuron>();

            numberStepsForEpoch = trainingList.Count;
            stepErrorList = new List<double>();
        }

        public void training(BackgroundWorker worker)
        {
            bool epoca1 = true;
            int counterEpoci = 0;
            do
            {
                if (epoca1)
                {
                    //pas1
                    initInputLayerStep1();
                    forwardStep1();
                    backpropagation(0);
                    //restul pasilor
                    for(int i = 1; i < trainingList.Count; i++)
                    {
                        generalInitInputLayer(i);
                        generalForward(i);
                        backpropagation(i);
                    }

                    epoca1 = false;
                    counterEpoci++;
                }
                else
                {
                    for (int i = 0; i < trainingList.Count; i++)
                    {
                        generalInitInputLayer(i);
                        generalForward(i);
                        backpropagation(i);
                    }
                    counterEpoci++;
                }

                //eroare epoca
                eroareEpoca = 0;
                for(int i = 0; i < stepErrorList.Count; i++)
                {
                    eroareEpoca += stepErrorList[i];
                }
                eroareEpoca /= stepErrorList.Count;
                stepErrorList.Clear();
                worker.ReportProgress(counterEpoci, eroareEpoca);

            } while(eroareEpoca >= errorTraining && flagTraining);

            errorTraining = eroareEpoca;////////////
        }

        private void initInputLayerStep1()
        {
            Artificial_Neuron newInputNeuron = new Artificial_Neuron(1);
            newInputNeuron._globalOutput = trainingList[0].Fixed_acidity;
            inputLayerList.Add(newInputNeuron);
            Artificial_Neuron newInputNeuron2 = new Artificial_Neuron(1);
            newInputNeuron2._globalOutput = trainingList[0].Volatile_acidity;
            inputLayerList.Add(newInputNeuron2);
            Artificial_Neuron newInputNeuron3 = new Artificial_Neuron(1);
            newInputNeuron3._globalOutput = trainingList[0].Citric_acid;
            inputLayerList.Add(newInputNeuron3);
            Artificial_Neuron newInputNeuron4 = new Artificial_Neuron(1);
            newInputNeuron4._globalOutput = trainingList[0].Residual_sugar;
            inputLayerList.Add(newInputNeuron4);
            Artificial_Neuron newInputNeuron5 = new Artificial_Neuron(1);
            newInputNeuron5._globalOutput = trainingList[0].Chlorides;
            inputLayerList.Add(newInputNeuron5);
            Artificial_Neuron newInputNeuron6 = new Artificial_Neuron(1);
            newInputNeuron6._globalOutput = trainingList[0].Free_sulfur_dioxide;
            inputLayerList.Add(newInputNeuron6);
            Artificial_Neuron newInputNeuron7 = new Artificial_Neuron(1);
            newInputNeuron7._globalOutput = trainingList[0].Total_sulfur_dioxide;
            inputLayerList.Add(newInputNeuron7);
            Artificial_Neuron newInputNeuron8 = new Artificial_Neuron(1);
            newInputNeuron8._globalOutput = trainingList[0].Density;
            inputLayerList.Add(newInputNeuron8);
            Artificial_Neuron newInputNeuron9 = new Artificial_Neuron(1);
            newInputNeuron9._globalOutput = trainingList[0].PH;
            inputLayerList.Add(newInputNeuron9);
            Artificial_Neuron newInputNeuron10 = new Artificial_Neuron(1);
            newInputNeuron10._globalOutput = trainingList[0].Sulphates;
            inputLayerList.Add(newInputNeuron10);
            Artificial_Neuron newInputNeuron11 = new Artificial_Neuron(1);
            newInputNeuron11._globalOutput = trainingList[0].Alcohol;
            inputLayerList.Add(newInputNeuron11);
           
        } 

        private void forwardStep1()
        {
            //hidden Layer
            var random = new Random();
            for (int i = 0; i < numberNeuronsHiddenLayer; ++i)
            {
                Artificial_Neuron newHiddenLayerNeuron = new Artificial_Neuron(11);//11 intrari(11 neuroni intrare)
                for (int j = 0; j < inputLayerList.Count; ++j)
                {
                    newHiddenLayerNeuron._inputX.Add(inputLayerList[j]._globalOutput);
                    double newWeight = random.NextDouble() * 2 - 1; //[-1;1]
                    newHiddenLayerNeuron._weight.Add(newWeight); //initializare tarie sinaptica
                }
               
                newHiddenLayerNeuron.sumFunction();  //functia suma pentru fiecare neuron
                if(activareHidden == 0)
                {
                    newHiddenLayerNeuron.functiaSigmoidala(0, 1); // teta=0, g=1
                }
                if(activareHidden == 1)
                {
                    newHiddenLayerNeuron.functiaTangentaHiperbolica(0, 1);
                }
                
                hiddenLayerList.Add(newHiddenLayerNeuron);
            }
            //output Layer
            Artificial_Neuron outputNeuron = new Artificial_Neuron(numberNeuronsHiddenLayer);
            for (int i = 0; i < hiddenLayerList.Count; ++i)
            {
                outputNeuron._inputX.Add(hiddenLayerList[i]._globalOutput);
                double newWeight = random.NextDouble() * 2 - 1;
                outputNeuron._weight.Add(newWeight);
            }
            outputNeuron.sumFunction();
            if(activareOutput == 0)
            {
                outputNeuron.functiaSigmoidala(0, 1);
            }
            if(activareOutput == 1)
            {
                outputNeuron.functiaTangentaHiperbolica(0, 1);
            }

            outputLayerList.Add(outputNeuron);
            double eroarePas1 = Math.Pow(outputLayerList[0]._globalOutput - trainingList[0].Quality,2);
            eroarePas1 /= 2;
            stepErrorList.Add(eroarePas1);
        }

        private void backpropagation(int pas)
        {
            if(activareOutput == 0)
            {
                outputLayerList[0].eroare = (outputLayerList[0]._globalOutput - trainingList[pas].Quality) * outputLayerList[0]._activation * (1 - outputLayerList[0]._activation);
            }
            if(activareOutput == 1)
            {
                outputLayerList[0].eroare = (outputLayerList[0]._globalOutput - trainingList[pas].Quality) * (1 - Math.Pow(outputLayerList[0]._activation,2));
            }
           
            //modificare tarii output-hiden layer
            for(int i = 0; i < hiddenLayerList.Count; ++i)
            {
                double delta = learningRate * hiddenLayerList[i]._globalOutput * outputLayerList[0].eroare;
                outputLayerList[0]._weight[i] -= delta;

                //calculare eroare neuroni hidden
                if(activareHidden == 0)
                {
                    hiddenLayerList[i].eroare = outputLayerList[0].eroare * outputLayerList[0]._weight[i] * hiddenLayerList[i]._activation * (1 - hiddenLayerList[i]._activation);
                }
                if(activareHidden == 1)
                {
                    hiddenLayerList[i].eroare = outputLayerList[0].eroare * outputLayerList[0]._weight[i] * (1 - Math.Pow(hiddenLayerList[i]._activation,2));
                }

            }
            //modificare tarii hidden-input
            for(int i = 0; i < hiddenLayerList.Count; ++i)
            {
                for (int j = 0; j < inputLayerList.Count; ++j)
                {
                    double delta = learningRate * inputLayerList[j]._globalOutput * hiddenLayerList[i].eroare;
                    hiddenLayerList[i]._weight[j] -= delta;
                }
            }

        }

        private void generalInitInputLayer(int pas)
        {  
            inputLayerList[0]._globalOutput = trainingList[pas].Fixed_acidity;
            inputLayerList[1]._globalOutput = trainingList[pas].Volatile_acidity;
            inputLayerList[2]._globalOutput = trainingList[pas].Citric_acid;
            inputLayerList[3]._globalOutput = trainingList[pas].Residual_sugar;
            inputLayerList[4]._globalOutput = trainingList[pas].Chlorides;
            inputLayerList[5]._globalOutput = trainingList[pas].Free_sulfur_dioxide;
            inputLayerList[6]._globalOutput = trainingList[pas].Total_sulfur_dioxide;
            inputLayerList[7]._globalOutput = trainingList[pas].Density;
            inputLayerList[8]._globalOutput = trainingList[pas].PH;
            inputLayerList[9]._globalOutput = trainingList[pas].Sulphates;
            inputLayerList[10]._globalOutput = trainingList[pas].Alcohol;
        }

        private void generalForward(int pas)
        {
            //hidden Layer
            for (int i = 0; i < hiddenLayerList.Count; ++i)
            {
                for (int j = 0; j < inputLayerList.Count; ++j)
                {
                    hiddenLayerList[i]._inputX[j] = inputLayerList[j]._globalOutput;
                }

                hiddenLayerList[i].sumFunction();  //functia suma pentru fiecare neuron
              
                if (activareHidden == 0)
                {
                    hiddenLayerList[i].functiaSigmoidala(0, 1); // teta=0, g=1
                }
                if (activareHidden == 1)
                {
                    hiddenLayerList[i].functiaTangentaHiperbolica(0, 1);
                }
            }
            //output Layer
            for (int i = 0; i < hiddenLayerList.Count; ++i)
            {
                outputLayerList[0]._inputX[i] = hiddenLayerList[i]._globalOutput;
            }
            outputLayerList[0].sumFunction();
            if (activareOutput == 0)
            {
                outputLayerList[0].functiaSigmoidala(0, 1);
            }
            if (activareOutput == 1)
            {
                outputLayerList[0].functiaTangentaHiperbolica(0, 1);
            }
           

            double eroarePas1 = Math.Pow(outputLayerList[0]._globalOutput - trainingList[pas].Quality, 2);
            eroarePas1 /= 2;
            stepErrorList.Add(eroarePas1);
        }

        public void test(BackgroundWorker workertest)
        {
             count = 0;
           
            for (int i = 0; i < testList.Count; ++i)
            {

                inputLayerList[0]._globalOutput = testList[i].Fixed_acidity;
                inputLayerList[1]._globalOutput = testList[i].Volatile_acidity;
                inputLayerList[2]._globalOutput = testList[i].Citric_acid;
                inputLayerList[3]._globalOutput = testList[i].Residual_sugar;
                inputLayerList[4]._globalOutput = testList[i].Chlorides;
                inputLayerList[5]._globalOutput = testList[i].Free_sulfur_dioxide;
                inputLayerList[6]._globalOutput = testList[i].Total_sulfur_dioxide;
                inputLayerList[7]._globalOutput = testList[i].Density;
                inputLayerList[8]._globalOutput = testList[i].PH;
                inputLayerList[9]._globalOutput = testList[i].Sulphates;
                inputLayerList[10]._globalOutput = testList[i].Alcohol;

                //hidden Layer
                for (int k = 0; k < hiddenLayerList.Count; ++k)
                {
                    for (int j = 0; j < inputLayerList.Count; ++j)
                    {
                        hiddenLayerList[k]._inputX[j] = inputLayerList[j]._globalOutput;
                    }

                    hiddenLayerList[k].sumFunction();  //functia suma pentru fiecare neuron

                    if (activareHidden == 0)
                    {
                        hiddenLayerList[k].functiaSigmoidala(0, 1); // teta=0, g=1
                    }
                    if (activareHidden == 1)
                    {
                        hiddenLayerList[k].functiaTangentaHiperbolica(0, 1);
                    }
                }
                //output Layer
                for (int k = 0; k < hiddenLayerList.Count; ++k)
                {
                    outputLayerList[0]._inputX[k] = hiddenLayerList[k]._globalOutput;
                }
                outputLayerList[0].sumFunction();
                if (activareOutput == 0)
                {
                    outputLayerList[0].functiaSigmoidala(0, 1);
                }
                if (activareOutput == 1)
                {
                    outputLayerList[0].functiaTangentaHiperbolica(0, 1);
                }

                double err = Math.Abs(outputLayerList[0]._globalOutput - trainingList[i].Quality);
                Console.WriteLine("eroare training " + errorTraining);
                Console.WriteLine("output " + outputLayerList[0]._globalOutput);
                Console.WriteLine("tinta " + trainingList[i].Quality);
                Console.WriteLine();

                if (err < errorTraining)
                {
                    count++;
                }
                workertest.ReportProgress(i);

            }
           
            procentTestare = ((double)count / (double)trainingList.Count) * 100;
        }

    }
}
