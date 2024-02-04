namespace db_2024
{
    partial class etudiant
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(etudiant));
            menuStrip1 = new MenuStrip();
            mETTREUNTESTToolStripMenuItem = new ToolStripMenuItem();
            vOIRNOTESToolStripMenuItem = new ToolStripMenuItem();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            panel2 = new Panel();
            panel3 = new Panel();
            timer = new Label();
            niveau = new Label();
            points = new Label();
            o4 = new Label();
            o3 = new Label();
            o2 = new Label();
            o1 = new Label();
            question = new Label();
            label18 = new Label();
            label16 = new Label();
            label15 = new Label();
            button2 = new Button();
            label13 = new Label();
            reponse = new NumericUpDown();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            panel4 = new Panel();
            dataGridView2 = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)reponse).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.AllowDrop = true;
            menuStrip1.AutoSize = false;
            menuStrip1.Font = new Font("Segoe UI", 9F);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { mETTREUNTESTToolStripMenuItem, vOIRNOTESToolStripMenuItem });
            menuStrip1.LayoutStyle = ToolStripLayoutStyle.Flow;
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1743, 71);
            menuStrip1.Stretch = false;
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // mETTREUNTESTToolStripMenuItem
            // 
            mETTREUNTESTToolStripMenuItem.AutoSize = false;
            mETTREUNTESTToolStripMenuItem.Name = "mETTREUNTESTToolStripMenuItem";
            mETTREUNTESTToolStripMenuItem.Size = new Size(800, 50);
            mETTREUNTESTToolStripMenuItem.Text = "TEST";
            mETTREUNTESTToolStripMenuItem.Click += mETTREUNTESTToolStripMenuItem_Click;
            // 
            // vOIRNOTESToolStripMenuItem
            // 
            vOIRNOTESToolStripMenuItem.AutoSize = false;
            vOIRNOTESToolStripMenuItem.Name = "vOIRNOTESToolStripMenuItem";
            vOIRNOTESToolStripMenuItem.Size = new Size(700, 50);
            vOIRNOTESToolStripMenuItem.Text = "VOIR NOTES";
            vOIRNOTESToolStripMenuItem.Click += vOIRNOTESToolStripMenuItem_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(1556, 34);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(66, 69);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1644, 34);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(66, 69);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(button1);
            panel1.Controls.Add(dataGridView1);
            panel1.Location = new Point(93, 123);
            panel1.Name = "panel1";
            panel1.Size = new Size(1440, 677);
            panel1.TabIndex = 6;
            panel1.Visible = false;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(0, 0, 192);
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(1081, 636);
            button1.Name = "button1";
            button1.Size = new Size(156, 41);
            button1.TabIndex = 1;
            button1.Text = "Faire";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView1.ColumnHeadersHeight = 29;
            dataGridView1.GridColor = SystemColors.HotTrack;
            dataGridView1.Location = new Point(51, 67);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1273, 580);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel3);
            panel2.Location = new Point(66, 126);
            panel2.Name = "panel2";
            panel2.Size = new Size(1382, 749);
            panel2.TabIndex = 2;
            panel2.Visible = false;
            panel2.Paint += panel2_Paint;
            // 
            // panel3
            // 
            panel3.Controls.Add(timer);
            panel3.Controls.Add(niveau);
            panel3.Controls.Add(points);
            panel3.Controls.Add(o4);
            panel3.Controls.Add(o3);
            panel3.Controls.Add(o2);
            panel3.Controls.Add(o1);
            panel3.Controls.Add(question);
            panel3.Controls.Add(label18);
            panel3.Controls.Add(label16);
            panel3.Controls.Add(label15);
            panel3.Controls.Add(button2);
            panel3.Controls.Add(label13);
            panel3.Controls.Add(reponse);
            panel3.Controls.Add(label12);
            panel3.Controls.Add(label11);
            panel3.Controls.Add(label10);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(label8);
            panel3.Location = new Point(429, 106);
            panel3.Name = "panel3";
            panel3.Size = new Size(808, 661);
            panel3.TabIndex = 13;
            // 
            // timer
            // 
            timer.AutoSize = true;
            timer.Location = new Point(479, 92);
            timer.Name = "timer";
            timer.Size = new Size(50, 20);
            timer.TabIndex = 32;
            timer.Text = "label5";
            // 
            // niveau
            // 
            niveau.AutoSize = true;
            niveau.Location = new Point(139, 414);
            niveau.Name = "niveau";
            niveau.Size = new Size(50, 20);
            niveau.TabIndex = 31;
            niveau.Text = "label5";
            // 
            // points
            // 
            points.AutoSize = true;
            points.Location = new Point(139, 359);
            points.Name = "points";
            points.Size = new Size(50, 20);
            points.TabIndex = 30;
            points.Text = "label5";
            // 
            // o4
            // 
            o4.AutoSize = true;
            o4.Location = new Point(139, 301);
            o4.Name = "o4";
            o4.Size = new Size(50, 20);
            o4.TabIndex = 29;
            o4.Text = "label5";
            // 
            // o3
            // 
            o3.AutoSize = true;
            o3.Location = new Point(139, 245);
            o3.Name = "o3";
            o3.Size = new Size(50, 20);
            o3.TabIndex = 28;
            o3.Text = "label5";
            // 
            // o2
            // 
            o2.AutoSize = true;
            o2.Location = new Point(139, 192);
            o2.Name = "o2";
            o2.Size = new Size(50, 20);
            o2.TabIndex = 27;
            o2.Text = "label5";
            // 
            // o1
            // 
            o1.AutoSize = true;
            o1.Location = new Point(139, 137);
            o1.Name = "o1";
            o1.Size = new Size(50, 20);
            o1.TabIndex = 26;
            o1.Text = "label5";
            // 
            // question
            // 
            question.AutoSize = true;
            question.Location = new Point(139, 72);
            question.Name = "question";
            question.Size = new Size(50, 20);
            question.TabIndex = 25;
            question.Text = "label5";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(27, 414);
            label18.Name = "label18";
            label18.Size = new Size(55, 20);
            label18.TabIndex = 24;
            label18.Text = "Niveau";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(23, 359);
            label16.Name = "label16";
            label16.Size = new Size(71, 20);
            label16.TabIndex = 22;
            label16.Text = "nb points";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(395, 92);
            label15.Name = "label15";
            label15.Size = new Size(50, 20);
            label15.TabIndex = 21;
            label15.Text = "temps";
            // 
            // button2
            // 
            button2.BackColor = Color.Navy;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.White;
            button2.Location = new Point(528, 481);
            button2.Name = "button2";
            button2.Size = new Size(148, 51);
            button2.TabIndex = 20;
            button2.Text = "Finish";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(27, 72);
            label13.Name = "label13";
            label13.Size = new Size(68, 20);
            label13.TabIndex = 18;
            label13.Text = "Question";
            // 
            // reponse
            // 
            reponse.Location = new Point(507, 285);
            reponse.Maximum = new decimal(new int[] { 4, 0, 0, 0 });
            reponse.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            reponse.Name = "reponse";
            reponse.Size = new Size(94, 27);
            reponse.TabIndex = 13;
            reponse.Value = new decimal(new int[] { 1, 0, 0, 0 });
            reponse.ValueChanged += nd4_ValueChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(379, 287);
            label12.Name = "label12";
            label12.Size = new Size(66, 20);
            label12.TabIndex = 17;
            label12.Text = "Reponse";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(27, 301);
            label11.Name = "label11";
            label11.Size = new Size(67, 20);
            label11.TabIndex = 16;
            label11.Text = "Option 4\r\n";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(27, 245);
            label10.Name = "label10";
            label10.Size = new Size(67, 20);
            label10.TabIndex = 15;
            label10.Text = "Option 3";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(27, 192);
            label9.Name = "label9";
            label9.Size = new Size(67, 20);
            label9.TabIndex = 14;
            label9.Text = "Option 2";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(27, 137);
            label8.Name = "label8";
            label8.Size = new Size(67, 20);
            label8.TabIndex = 13;
            label8.Text = "Option 1";
            // 
            // panel4
            // 
            panel4.Controls.Add(dataGridView2);
            panel4.Location = new Point(93, 119);
            panel4.Name = "panel4";
            panel4.Size = new Size(1376, 724);
            panel4.TabIndex = 11;
            panel4.Visible = false;
            // 
            // dataGridView2
            // 
            dataGridView2.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(89, 106);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(1118, 535);
            dataGridView2.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(175, 79);
            label1.Name = "label1";
            label1.Size = new Size(84, 41);
            label1.TabIndex = 7;
            label1.Text = "Nom";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(328, 96);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 8;
            label2.Text = "label2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(808, 79);
            label3.Name = "label3";
            label3.Size = new Size(101, 41);
            label3.TabIndex = 9;
            label3.Text = "Classe";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1005, 96);
            label4.Name = "label4";
            label4.Size = new Size(50, 20);
            label4.TabIndex = 10;
            label4.Text = "label4";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            // 
            // etudiant
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1743, 802);
            Controls.Add(panel4);
            Controls.Add(panel2);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "etudiant";
            Text = "etudiant";
            WindowState = FormWindowState.Maximized;
            Load += etudiant_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)reponse).EndInit();
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem mETTREUNTESTToolStripMenuItem;
        private ToolStripMenuItem vOIRNOTESToolStripMenuItem;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Panel panel1;
        private DataGridView dataGridView1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button1;
        private Panel panel2;
        private Panel panel3;
        private Label label18;
        private Label label16;
        private Label label15;
        private Button button2;
        private Label label13;
        private NumericUpDown reponse;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label points;
        private Label o4;
        private Label o3;
        private Label o2;
        private Label o1;
        private Label question;
        private Label niveau;
        private Label timer;
        private System.Windows.Forms.Timer timer1;
        private Panel panel4;
        private DataGridView dataGridView2;
    }
}