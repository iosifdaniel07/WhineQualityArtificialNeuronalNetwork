using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace WhiteWineQuality {
    public partial class Form1 : Form {

        private List<Wine> listWine;
        private List<NormalizedWine> listNormWine;
        private List<NormalizedWine> listtrainingWine;
        private List<NormalizedWine> listtestWine;
        private DataGridView dataGridViewTraining;
        private DataGridView dataGridViewTest;
        private ArtificialNeuronalNetwork artificialNeuronalNetwork;
        private System.Windows.Forms.Label trainingData;
        private System.Windows.Forms.Label testData;
        private PointPairList pointPairsList = new PointPairList();
        public BackgroundWorker workerTraining;
        public BackgroundWorker workerTest;
        private int neuroniHiddenLayer ;
        private double rataInvatare;
        private double eroareAdmisa;
        private int activareHidden;
        private int activareoutput;
        
        public Form1() {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            dataGridView1.Visible = false;
            zedGraphControl1.Visible = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            panel1.Visible = false;

            numericUpDownEroare.Increment = 0.0001m;
            numericUpDownEroare.Value = 0.001m;
            numericUpDownEroare.DecimalPlaces = 5;

            numericUpDowninvatare.Increment = 0.01m;
            numericUpDowninvatare.Value = 0.2m;
            numericUpDowninvatare.DecimalPlaces = 2;

            panel2.Visible = false;
        }

        //initial wine data
        private void backgroundWorkerWine_DoWork(object sender, DoWorkEventArgs e) {
            // BackgroundWorker worker = (BackgroundWorker)sender;

            var importer = new ReadCSV();
            listWine = importer.getListOfObjects(@"C:\Users\DanielIosif\Documents\GitHub\WhineQualityArtificialNeuronalNetwork\WhiteWineQuality\wine.csv");
            e.Result = listWine;
        }

        private void backgroundWorkerWine_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            dataGridView1.DataSource = e.Result;
            dataGridView1.Visible = true;
        }

        //normalized wine data
        private void backgroundWorkerWineNormalization_DoWork(object sender, DoWorkEventArgs e) {
            // BackgroundWorker worker = (BackgroundWorker)sender;

            var importer = new ReadCSV();
            listWine = importer.getListOfObjects(@"C:\Users\DanielIosif\Documents\GitHub\WhineQualityArtificialNeuronalNetwork\WhiteWineQuality\wine.csv");

            listNormWine = ReadCSV.norminalization(listWine);
            e.Result = listNormWine;
        }

        private void btnInputData_Click(object sender, EventArgs e) {

            if(listWine == null) {
                BackgroundWorker worker;
                worker = new BackgroundWorker();
                worker.DoWork += new DoWorkEventHandler(backgroundWorkerWine_DoWork);
                worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorkerWine_RunWorkerCompleted);
                worker.RunWorkerAsync();
                worker.Dispose();
            }
            else {
                dataGridView1.DataSource = listWine;
                dataGridView1.Visible = true;
                if (dataGridViewTest != null && dataGridViewTraining != null) {
                    dataGridViewTraining.Visible = false;   
                    dataGridViewTest.Visible = false;
                    zedGraphControl1.Visible = false;
                    panel1.Visible = false;
                    panel2.Visible = false;
                }
            }
     
        }

        private void btnNormalization_Click(object sender, EventArgs e) {

            if (listWine != null) {
                if(listNormWine == null) {
                    BackgroundWorker worker;
                    worker = new BackgroundWorker();
                    worker.DoWork += new DoWorkEventHandler(backgroundWorkerWineNormalization_DoWork);
                    worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorkerWine_RunWorkerCompleted);
                    worker.RunWorkerAsync();
                    worker.Dispose();
                }
                else {
                    dataGridView1.DataSource = listNormWine;
                    dataGridView1.Visible = true;
                    if (dataGridViewTest != null && dataGridViewTraining != null) {
                        dataGridViewTraining.Visible = false;
                        dataGridViewTest.Visible = false;
                        zedGraphControl1.Visible = false;
                        panel1.Visible = false;
                        panel2.Visible = false;
                    }
                }
            }
        }

        public void intializeTrainingAndTestLists() {

            listtrainingWine = new List<NormalizedWine>();
            listtestWine = new List<NormalizedWine>();


            double numberDataTraining = (70 * listNormWine.Count) / 100;
          
            List<int> listPositionTrainingData = new List<int>();
            Random random = new Random();
            int newPosition = random.Next(0, listNormWine.Count - 1);
            listPositionTrainingData.Add(newPosition);



            for (int i = 1; i < numberDataTraining; ++i) {

                while (true) {
                    newPosition = random.Next(0, listNormWine.Count - 1);
                    if (listPositionTrainingData.Contains(newPosition) == false) {
                        listPositionTrainingData.Add(newPosition);
                        break;
                    }
                }
            }

            for (int i = 0; i < listNormWine.Count; ++i) {
                if (listPositionTrainingData.Contains(i) == true) {
                    listtrainingWine.Add(listNormWine[i]);
                }
                else {
                    listtestWine.Add(listNormWine[i]);
                }
            }
        }

        private void backgroundWorkerTestAndTraining_DoWork(object sender, DoWorkEventArgs e) {
            intializeTrainingAndTestLists();
        }

        private void backgroundWorkerTestAndTraining_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            showTrainingAndTestGrids();
        }

        private void showTrainingAndTestGrids() {
            dataGridView1.Visible = false;

            dataGridViewTraining = new DataGridView();
            dataGridViewTest = new DataGridView();

            dataGridViewTraining.DataSource = listtrainingWine;
            dataGridViewTest.DataSource = listtestWine;

            int height = dataGridView1.Height / 2;
            height -= 50;
            int width = dataGridView1.Width;
            int x = dataGridView1.Location.X;
            int y = dataGridView1.Location.Y;

            trainingData = new System.Windows.Forms.Label();
            trainingData.Text = "Antrenare: " + listtrainingWine.Count;
            trainingData.Location = new Point(x, y + 10);
            this.Controls.Add(trainingData);

            dataGridViewTraining.Size = new Size(width, height);
            dataGridViewTraining.Location = new Point(x, y + 35);
            this.Controls.Add(dataGridViewTraining);

            testData = new System.Windows.Forms.Label();
            testData.Text = "Testare: " + listtestWine.Count;
            testData.Location = new Point(x, y + height + 50);
            this.Controls.Add(testData);

            dataGridViewTest.Size = new Size(width, height);
            dataGridViewTest.Location = new Point(x, (y + height) + 75);
            this.Controls.Add(dataGridViewTest);
        }

        private void button1_Click(object sender, EventArgs e) {
            if(listNormWine != null) {
                if(listtrainingWine == null && listtestWine == null) {
                    BackgroundWorker worker;
                    worker = new BackgroundWorker();
                    worker.DoWork += new DoWorkEventHandler(backgroundWorkerTestAndTraining_DoWork);
                    worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorkerTestAndTraining_RunWorkerCompleted);
                    worker.RunWorkerAsync();
                    worker.Dispose();
                }
                else {
                    dataGridView1.Visible = false;
                    zedGraphControl1.Visible = false;
                    panel1.Visible = false;
                    panel2.Visible = false;
                    showTrainingAndTestGrids();
                }
            }
        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            if (listNormWine != null && dataGridViewTest != null)
            {
            
                dataGridView1.Visible = false;
                dataGridViewTest.Visible = false;
                dataGridViewTraining.Visible = false;
                testData.Visible = false;
                trainingData.Visible = false;
                panel2.Visible = false;
                panel1.Visible = true;
                zedGraphControl1.Visible = true;

           
            }
        }

        public void completTraining_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           // Console.WriteLine(artificialNeuronalNetwork.eroareEpoca);
        }

        private void WorkerTraining_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            textBox1.Text = e.UserState.ToString();
            textBox2.Text = "Epoca: " + e.ProgressPercentage.ToString();
            PointPair pointPair = new PointPair(e.ProgressPercentage, (double)e.UserState);
            pointPairsList.Add(pointPair);

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate(); 
        }

        private void do_Work_Training(object sender, DoWorkEventArgs e)
        {
            artificialNeuronalNetwork = new ArtificialNeuronalNetwork(listtrainingWine, listtestWine, neuroniHiddenLayer, rataInvatare,eroareAdmisa, activareHidden,activareoutput);//training rate=0.4//22   15, 0.8, 0.001
            artificialNeuronalNetwork.training(workerTraining);
        }


        private void STOP_Click(object sender, EventArgs e)
        {
            artificialNeuronalNetwork.flagTraining = false;
        }

        private void START_Click(object sender, EventArgs e)
        {
            GraphPane myPane = zedGraphControl1.GraphPane;
            myPane.Title.Text = "Wine Quality";
            myPane.XAxis.Title.Text = "Epochs";
            myPane.YAxis.Title.Text = "Error";

            pointPairsList.Clear();
            myPane.CurveList.Clear();

            myPane.AddCurve("Epoch Error", pointPairsList, Color.Red, SymbolType.None);
             

            eroareAdmisa = (double)numericUpDownEroare.Value;
            neuroniHiddenLayer = (int)numericUpDownNeuroni.Value;
            rataInvatare = (double)numericUpDowninvatare.Value;
            activareHidden = comboBoxHidden.SelectedIndex;
            activareoutput = comboBoxOutput.SelectedIndex;

            Console.WriteLine("eraore admisa" + eroareAdmisa);
            Console.WriteLine("neuroni hiddden" + neuroniHiddenLayer);
            Console.WriteLine("rata invatare" +rataInvatare);
            Console.WriteLine("hidden"  + activareHidden);
            Console.WriteLine("output" + activareoutput);

              workerTraining = new BackgroundWorker();
              workerTraining.DoWork += new DoWorkEventHandler(do_Work_Training);
              workerTraining.WorkerReportsProgress = true;
              workerTraining.ProgressChanged += WorkerTraining_ProgressChanged;
              workerTraining.RunWorkerCompleted += new RunWorkerCompletedEventHandler(completTraining_RunWorkerCompleted);
              workerTraining.RunWorkerAsync();
              workerTraining.Dispose();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridViewTest.Visible = false;
            dataGridViewTraining.Visible = false;
            
            testData.Visible = false;
            trainingData.Visible = false;
            panel2.Visible = true;
            panel1.Visible = false;
            zedGraphControl1.Visible = false;

        }

        private void do_Test_Training(object sender, DoWorkEventArgs e)
        {
            artificialNeuronalNetwork.test(workerTest);
        }

        private void WorkerTest_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
           progressBar1.Value =  e.ProgressPercentage;
        }

        public void completTest_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            /*            textBox3.Text = artificialNeuronalNetwork.count.ToString() + " rezultate corecte din "
                            + artificialNeuronalNetwork.testList.Count.ToString() + 
                            " Procent :" + artificialNeuronalNetwork.procentTestare.ToString() +"%";*/
            double a = artificialNeuronalNetwork.procentTestare;
            textBox3.Text = " Procent :" + a.ToString() + "%"; 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = artificialNeuronalNetwork.testList.Count;

            workerTest = new BackgroundWorker();
            workerTest.DoWork += new DoWorkEventHandler(do_Test_Training);
            workerTest.WorkerReportsProgress = true;
            workerTest.ProgressChanged += WorkerTest_ProgressChanged;
            workerTest.RunWorkerCompleted += completTest_RunWorkerCompleted;
            workerTest.RunWorkerAsync();
            workerTest.Dispose();
        }
    }
}
