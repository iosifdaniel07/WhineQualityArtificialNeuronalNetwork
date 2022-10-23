using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhiteWineQuality {
    public partial class Form1 : Form {

        private List<Wine> listWine;
        private List<NormalizedWine> listNormWine;
        private List<NormalizedWine> listtrainingWine;
        private List<NormalizedWine> listtestWine;
        private DataGridView dataGridViewTraining;
        private DataGridView dataGridViewTest;
        public Form1() {
            InitializeComponent();
            dataGridView1.Visible = false;
        }

        //initial wine data
        private void backgroundWorkerWine_DoWork(object sender, DoWorkEventArgs e) {
            // BackgroundWorker worker = (BackgroundWorker)sender;

            var importer = new ReadCSV();
            listWine = importer.getListOfObjects(@"D:\Teme\Inteligenta Artificiala\WhiteWineQuality\wine.csv");
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
            listWine = importer.getListOfObjects(@"D:\Teme\Inteligenta Artificiala\WhiteWineQuality\wine.csv");

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

            Label trainingData = new Label();
            trainingData.Text = "Antrenare: " + listtrainingWine.Count;
            trainingData.Location = new Point(x, y + 10);
            this.Controls.Add(trainingData);

            dataGridViewTraining.Size = new Size(width, height);
            dataGridViewTraining.Location = new Point(x, y + 35);
            this.Controls.Add(dataGridViewTraining);

            Label testData = new Label();
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
                    showTrainingAndTestGrids();
                }
            }
        }
    }
}
