using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteWineQuality {
    public class Artificial_Neuron {
        public double _globalInput = 0;
        public double _globalOutput = 0;
        public double _activation = 0;
        public int _numberInput = 1;
        public List<double> _inputX;
        public List<double> _weight; //taria sinaptica
       
        public Artificial_Neuron(int numberOfInput) {
            _numberInput = numberOfInput;
            _weight = new List<double>();
            _inputX = new List<double>();
        }

        public void sumFunction() {
            double sum = 0;
            for (var i = 0; i < _numberInput; i++) {
                sum += _weight[i] * _inputX[i];
            }
            _globalInput = sum;
        }

        public void produs() {
            double prod = 1;
            for (var i = 0; i < _numberInput; i++) {
                prod *= _weight[i] * _inputX[i];
            }
            _globalInput = prod;
        }

        public void minim() {
            double min = _weight[0] * _inputX[0];
            for (var i = 1; i < _numberInput; i++) {
                if ((_weight[i] * _inputX[i]) < min) {
                    min = _weight[i] * _inputX[i];
                }
            }
            _globalInput = min;
        }

        public void maxim() {
            double maxim = _weight[0] * _inputX[0];
            for (var i = 1; i < _numberInput; i++) {
                if ((_weight[i] * _inputX[i]) > maxim) {
                    maxim = _weight[i] * _inputX[i];
                }
            }
            _globalInput = maxim;
        }

        public void functiaTreapta(double teta) { //R->{0,1}
            double x = _globalInput;
            if (x >= teta) {
                _activation = 1;
            }
            else if (x < teta) {
                _activation = 0;
            }
            _globalOutput = _activation;
        }

        public void functiaSemn(double teta) {//R->{-1;1}
            double x = _globalInput;
            if (x >= teta) {
                _activation = 1;
            }
            else if (x < teta) {
                _activation = -1;
            }
            _globalOutput = _activation;
        }

        public void functiaSigmoidala(double teta, double g) { //R->(0;1)
            //g-controleaza panta /g < inseamna panta mai lenta
            double x = _globalInput;
            _activation = 1 / (1 + Math.Pow(Math.E, -g * (x - teta)));
            _globalOutput = _activation;
        }

        public void functiaTangentaHiperbolica(double teta, double g) { //R->(-1;1)
            double x = _globalInput;
            _activation = (Math.Pow(Math.E, g * (x - teta)) - Math.Pow(Math.E, -g * (x - teta)))
                / (Math.Pow(Math.E, g * (x - teta)) + Math.Pow(Math.E, -g * (x - teta)));
            _globalOutput = _activation;
        }

        public void functiaLiniara(double teta, double a) { // R->[-1;1]
            double x = _globalInput - teta;
            if (x < (-1 / a)) {
                _activation = -1;
            }
            else if (x >= (-1 / a) && x <= (1 / a)) {
                _activation = a * x;
            }
            else if (x > 1 / a) {
                _activation = 1;
            }
            _globalOutput = _activation;
        }

        public void activareSigmoidala() {
            if (_activation >= 0.5) {
                _globalOutput = 1;
            }
            else if (_activation < 0.5) {
                _globalOutput = 0;
            }
        }

        public void activareTangentaLiniara() {
            if (_activation >= 0) {
                _globalOutput = 1;
            }
            else if (_activation < 0) {
                _globalOutput = -1;
            }
        }

        public void activareTreapta() {
            _globalOutput = _activation;
        }

        public void activareSemn() {
            _globalOutput = _activation;
        }
    }

}
