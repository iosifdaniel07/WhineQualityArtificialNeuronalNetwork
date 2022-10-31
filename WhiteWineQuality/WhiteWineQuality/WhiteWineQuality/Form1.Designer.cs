namespace WhiteWineQuality {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnInputData = new System.Windows.Forms.Button();
            this.btnNormalization = new System.Windows.Forms.Button();
            this.btnTrain = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.STOP = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxOutput = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxHidden = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownEroare = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDowninvatare = new System.Windows.Forms.NumericUpDown();
            this.labellearning = new System.Windows.Forms.Label();
            this.numericUpDownNeuroni = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.START = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEroare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDowninvatare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNeuroni)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 50);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1845, 773);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnInputData
            // 
            this.btnInputData.Location = new System.Drawing.Point(116, 12);
            this.btnInputData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInputData.Name = "btnInputData";
            this.btnInputData.Size = new System.Drawing.Size(136, 33);
            this.btnInputData.TabIndex = 1;
            this.btnInputData.Text = "Date initiale";
            this.btnInputData.UseVisualStyleBackColor = true;
            this.btnInputData.Click += new System.EventHandler(this.btnInputData_Click);
            // 
            // btnNormalization
            // 
            this.btnNormalization.Location = new System.Drawing.Point(301, 12);
            this.btnNormalization.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNormalization.Name = "btnNormalization";
            this.btnNormalization.Size = new System.Drawing.Size(136, 33);
            this.btnNormalization.TabIndex = 2;
            this.btnNormalization.Text = "Date Normalizate";
            this.btnNormalization.UseVisualStyleBackColor = true;
            this.btnNormalization.Click += new System.EventHandler(this.btnNormalization_Click);
            // 
            // btnTrain
            // 
            this.btnTrain.Location = new System.Drawing.Point(733, 12);
            this.btnTrain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(136, 33);
            this.btnTrain.TabIndex = 3;
            this.btnTrain.Text = "Antrenare";
            this.btnTrain.UseVisualStyleBackColor = true;
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(889, 12);
            this.btnTest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(136, 33);
            this.btnTest.TabIndex = 4;
            this.btnTest.Text = "Testare";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(461, 12);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(251, 33);
            this.button1.TabIndex = 5;
            this.button1.Text = "Previzualizare date antrenare si test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(31, 70);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(1749, 644);
            this.zedGraphControl1.TabIndex = 7;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1046, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 8;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(1046, 68);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 9;
            // 
            // STOP
            // 
            this.STOP.Location = new System.Drawing.Point(24, 61);
            this.STOP.Name = "STOP";
            this.STOP.Size = new System.Drawing.Size(75, 23);
            this.STOP.TabIndex = 10;
            this.STOP.Text = "STOP";
            this.STOP.UseVisualStyleBackColor = true;
            this.STOP.Click += new System.EventHandler(this.STOP_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBoxOutput);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.comboBoxHidden);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.numericUpDownEroare);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.numericUpDowninvatare);
            this.panel1.Controls.Add(this.labellearning);
            this.panel1.Controls.Add(this.numericUpDownNeuroni);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.START);
            this.panel1.Controls.Add(this.STOP);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Location = new System.Drawing.Point(599, 718);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1181, 100);
            this.panel1.TabIndex = 11;
            // 
            // comboBoxOutput
            // 
            this.comboBoxOutput.FormattingEnabled = true;
            this.comboBoxOutput.Items.AddRange(new object[] {
            "Sigmoidala",
            "Tangenta"});
            this.comboBoxOutput.Location = new System.Drawing.Point(866, 64);
            this.comboBoxOutput.Name = "comboBoxOutput";
            this.comboBoxOutput.Size = new System.Drawing.Size(121, 24);
            this.comboBoxOutput.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(713, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 16);
            this.label6.TabIndex = 22;
            this.label6.Text = "Activare output layer";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(713, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "Activare hidden layer";
            // 
            // comboBoxHidden
            // 
            this.comboBoxHidden.FormattingEnabled = true;
            this.comboBoxHidden.Items.AddRange(new object[] {
            "Sigmoidala",
            "Tangenta"});
            this.comboBoxHidden.Location = new System.Drawing.Point(866, 18);
            this.comboBoxHidden.Name = "comboBoxHidden";
            this.comboBoxHidden.Size = new System.Drawing.Size(121, 24);
            this.comboBoxHidden.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1043, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 16);
            this.label4.TabIndex = 19;
            this.label4.Text = "Pas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1043, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "Eroare";
            // 
            // numericUpDownEroare
            // 
            this.numericUpDownEroare.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDownEroare.Location = new System.Drawing.Point(539, 46);
            this.numericUpDownEroare.Name = "numericUpDownEroare";
            this.numericUpDownEroare.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownEroare.TabIndex = 17;
            this.numericUpDownEroare.Value = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(437, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Eroare admisa";
            // 
            // numericUpDowninvatare
            // 
            this.numericUpDowninvatare.Location = new System.Drawing.Point(277, 65);
            this.numericUpDowninvatare.Name = "numericUpDowninvatare";
            this.numericUpDowninvatare.Size = new System.Drawing.Size(120, 22);
            this.numericUpDowninvatare.TabIndex = 15;
            this.numericUpDowninvatare.Value = new decimal(new int[] {
            8,
            0,
            0,
            65536});
            // 
            // labellearning
            // 
            this.labellearning.AutoSize = true;
            this.labellearning.Location = new System.Drawing.Point(126, 71);
            this.labellearning.Name = "labellearning";
            this.labellearning.Size = new System.Drawing.Size(87, 16);
            this.labellearning.TabIndex = 14;
            this.labellearning.Text = "Rata invatare";
            // 
            // numericUpDownNeuroni
            // 
            this.numericUpDownNeuroni.Location = new System.Drawing.Point(277, 19);
            this.numericUpDownNeuroni.Name = "numericUpDownNeuroni";
            this.numericUpDownNeuroni.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownNeuroni.TabIndex = 13;
            this.numericUpDownNeuroni.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Nr neuroni hidden layer";
            // 
            // START
            // 
            this.START.Location = new System.Drawing.Point(24, 18);
            this.START.Name = "START";
            this.START.Size = new System.Drawing.Size(75, 23);
            this.START.TabIndex = 11;
            this.START.Text = "START";
            this.START.UseVisualStyleBackColor = true;
            this.START.Click += new System.EventHandler(this.START_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.textBox3);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(183, 171);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1160, 226);
            this.panel2.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Procent date corecte";
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(166, 106);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(403, 68);
            this.textBox3.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(652, 102);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Start";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(18, 57);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1139, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1891, 846);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnTrain);
            this.Controls.Add(this.btnNormalization);
            this.Controls.Add(this.btnInputData);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEroare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDowninvatare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNeuroni)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnInputData;
        private System.Windows.Forms.Button btnNormalization;
        private System.Windows.Forms.Button btnTrain;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button button1;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button STOP;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button START;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownEroare;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDowninvatare;
        private System.Windows.Forms.Label labellearning;
        private System.Windows.Forms.NumericUpDown numericUpDownNeuroni;
        private System.Windows.Forms.ComboBox comboBoxHidden;
        private System.Windows.Forms.ComboBox comboBoxOutput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

