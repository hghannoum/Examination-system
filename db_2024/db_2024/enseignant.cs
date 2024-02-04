using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Syncfusion.Maui.Core.Converters;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.Design.AxImporter;
namespace db_2024
{
    public partial class enseignant : Form
    {
        Form m;
        MYCLASS C = MYCLASS.Instance; DataLayer dl; DataTable dt;
        private DateTimePicker dateTimePicker1;
        public enseignant(Form main)
        {
            InitializeComponent();

            dl = new DataLayer("QSC-PC\\SQLEXPRESS01", "LAST");
            dt = dl.GetData($"select * FROM Personne where numero={C.id}", "info");
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker1.Format = DateTimePickerFormat.Long; // You can choose different formats
            dateTimePicker1.Location = new System.Drawing.Point(440, 146);
            panel3.Controls.Add(dateTimePicker1);
            InitializeCheckedListBox();
            makebutton(button1);
            makebutton(button2);

            m = main;
        }
        private void makebutton(Button button)
        {

        }
        private void enseignant_Load(object sender, EventArgs e)
        {

        }
        DataTable dt2;
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

            label4.Text = dt.Rows[0][0].ToString() + " " + dt.Rows[0][1].ToString();
            panel4.Visible = true;
            dt2 = dl.GetData($" SELECT [matiere] FROM [dbo].[TEST] WHERE [NUMERO] = {C.id}", "");

            if (dt2.Rows.Count > 0)
            {
                foreach (DataRow row in dt2.Rows)
                {
                    comboBox2.Items.Add(row["matiere"]);
                }
                comboBox2.SelectedIndex = 0;  // You can set the default selection if needed
            }
        }

        private void mETTREUNTESTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip1.Enabled = false;
            panel4.Visible = false;
            panel1.Visible = true;
            panel5.Visible = false;
            DateTime currentDate = DateTime.Today;
            label5.Text = currentDate.ToString("yyyy-MM-dd");
            label4.Text = dt.Rows[0][0].ToString() + " " + dt.Rows[0][1].ToString();

        }

        private void vOIRNOTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel1.Visible = false;
            panel5.Visible = false;
            label20.Text = dt.Rows[0][0].ToString() + " " + dt.Rows[0][1].ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            m.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            List<string> checkedItems = checkedListBox1.CheckedItems
                                                .OfType<string>()
                                                .ToList();

            // If the item is being checked, add it to the list
            if (e.NewValue == CheckState.Checked)
            {
                checkedItems.Add(checkedListBox1.Items[e.Index].ToString());
            }
            // If the item is being unchecked, remove it from the list
            else
            {
                checkedItems.Remove(checkedListBox1.Items[e.Index].ToString());
            }
            optionsAsString = string.Join(",", checkedItems);
        }
        string optionsAsString;
        private void InitializeCheckedListBox()
        {
            DataTable result =
                result = dl.GetData($"SELECT * FROM GET_CLASS ({C.id})", "classes");
            // Create a list of options
            List<string> options = result.AsEnumerable()
                              .Select(row => row.Field<string>("NAME"))
                              .ToList();
            // Set the CheckedListBox properties
            checkedListBox1.Items.AddRange(options.ToArray());

            // Set the event handler for item check change
            checkedListBox1.ItemCheck += checkedListBox1_ItemCheck;

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }
        int counter = 0;
        public class Question
        {
            public string Niveau { get; set; }
            public int Temps { get; set; }
            public int NbPoints { get; set; }
            public int NumtTest { get; set; }
            public string Option1 { get; set; }
            public string Option2 { get; set; }
            public string Option3 { get; set; }
            public string Option4 { get; set; }
            public int Reponse { get; set; }
            public string QuestionText { get; set; }
        }
        Question[] questions;
        private void button2_Click(object sender, EventArgs e)
        {
            nd1.Enabled = false;
            if (button2.Text == "Suivant")
            // Increment the counter
            {
                questions[counter] = new Question
                {
                    Niveau = comboBox1.Text,
                    Temps = (int)nd2.Value,
                    NbPoints = (int)nd3.Value,
                    NumtTest = NUMINSERTED,
                    Option1 = textBox2.Text,
                    Option2 = textBox3.Text,
                    Option3 = textBox4.Text,
                    Option4 = textBox5.Text,
                    Reponse = (int)nd4.Value,
                    QuestionText = textBox7.Text
                };
                counter++;
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox7.Text = "";
                nd2.Value = nd3.Value = nd4.Value = 1;
                comboBox1.Text = "facile";
                // Check if the counter reaches the limit
                if (counter >= nd1.Value - 1)
                {
                    button2.Text = "Terminer";

                }
            }
            else
            {
                panel1.Visible = false;
                questions[counter] = new Question
                {
                    Niveau = comboBox1.Text,
                    Temps = (int)nd2.Value,
                    NbPoints = (int)nd3.Value,
                    NumtTest = NUMINSERTED,
                    Option1 = textBox2.Text,
                    Option2 = textBox3.Text,
                    Option3 = textBox4.Text,
                    Option4 = textBox5.Text,
                    Reponse = (int)nd4.Value,
                    QuestionText = textBox7.Text
                };
                // Convert Question array to DataTable
                DataTable questionTable = new DataTable();
                questionTable.Columns.Add("Niveau", typeof(string));
                questionTable.Columns.Add("Temps", typeof(int));
                questionTable.Columns.Add("NbPoints", typeof(int));
                questionTable.Columns.Add("NumtTest", typeof(int));
                questionTable.Columns.Add("Option1", typeof(string));
                questionTable.Columns.Add("Option2", typeof(string));
                questionTable.Columns.Add("Option3", typeof(string));
                questionTable.Columns.Add("Option4", typeof(string));
                questionTable.Columns.Add("Reponse", typeof(int));
                questionTable.Columns.Add("QuestionText", typeof(string));

                foreach (var q in questions)
                {
                    questionTable.Rows.Add(q.Niveau, q.Temps, q.NbPoints, q.NumtTest, q.Option1, q.Option2, q.Option3, q.Option4, q.Reponse, q.QuestionText);
                }

                // Call the stored procedure with the DataTable parameter
                object[,] parameters = new object[,]
                {
    { "@Questions", questionTable, false }
                };

                dl.ExecuteActionCommand("InsertQuestions", parameters);

                MessageBox.Show("le Test est ajouté");
                menuStrip1.Enabled = true;

            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void nd1_ValueChanged(object sender, EventArgs e)
        {
            if (nd1.Value > 1)
            {
                button2.Text = "Suivant";
            }
            else
                button2.Text = "Terminer";
        }
        int NUMINSERTED = 3;
        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel3.Enabled = false;
            questions = new Question[(int)nd1.Value];
            DateTime currentDate = DateTime.Today;
            SqlParameter outputParam = new SqlParameter("@NUMINSERTED", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            object[,] parameters = new object[,]
{
                    { "@Deadline", dateTimePicker1.Value ,false},  // Replace with your value
                    { "@Numero", C.id ,false},                       // Replace with your value
                    { "@Matiere", textBox1.Text , false},           // Replace with your value
                    { "@Date", currentDate  ,false },                 // Replace with your value
                    { outputParam , NUMINSERTED , true}// Initialize with 0 and specify as output
            };

            dl.ExecuteActionCommand("InsertTES", parameters);

            // Retrieve the output parameter value after the stored procedure call
            NUMINSERTED = Convert.ToInt32(parameters[4, 1]);

            object[,] parameters2 = new object[,]
{
                    { "@NUMT", NUMINSERTED ,false},  // Replace with your value
                    { "@ClassNames", optionsAsString ,false},         // Initialize with 0 and specify as output
            };

            dl.ExecuteActionCommand("InsertTESTCLASS", parameters2);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            object[,] parameters = new object[,]
{
                    { "@matiere", comboBox2.Text ,false},  // Replace with your value
                    { "@NUMERO_ENSEIGNANT", C.id ,false}, };
            DataTable dtt = dl.GetData("GetEvaluationsByTeacher ", parameters, "");
            dataGridView1.DataSource = dtt;
            dataGridView1.Visible = true;
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
        DataTable dt3;
        private void cORRIGELESTESTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
            panel4.Visible = false;
            panel1.Visible = false;

            dt3 = dl.GetData($"SELECT IDQ,QUESTION,OPTION1, OPTION2, OPTION3,OPTION4,REPONSE,NUMT_TEST,TEMPS,DEADLINE,MATIERE,DATE,NBPOINTS,NIVEAU  FROM QUESTION INNER JOIN TEST ON NUMT_TEST=NUMT WHERE NUMERO={C.id}", "q");
            dataGridView2.DataSource = dt3;

            dataGridView2.Columns[0].ReadOnly = true;
            dataGridView2.Columns[7].ReadOnly = true;
            dataGridView2.Columns[8].ReadOnly = true;
            dataGridView2.Columns[9].ReadOnly = true;
            dataGridView2.Columns[10].ReadOnly = true;
            dataGridView2.Columns[11].ReadOnly = true;
            dataGridView2.Columns[13].ReadOnly = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Check if there is a selected row
            if (dataGridView2.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];

                MessageBox.Show($"Question avec id = {selectedRow.Cells[0].Value} a ete supprime");
                dl.ExecuteActionCommand("Delete from question where IDQ=" + selectedRow.Cells[0].Value);

                // Remove the row from the DataGridView
                dataGridView2.Rows.Remove(selectedRow);
            }

        }

        private void dataGridView2_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 12 || e.ColumnIndex == 6) // Check if the column is 1 or 2
            {
                // Validate if the entered value is a valid number
                if (!int.TryParse(e.FormattedValue.ToString(), out int result))
                {
                    // Display an error message
                    MessageBox.Show("saisir un numero svp", "Entree invalide", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Cancel the editing
                    e.Cancel = true;
                }
                else
                {

                    if (e.ColumnIndex == 6 && (int.Parse(e.FormattedValue.ToString()) > 4 || int.Parse(e.FormattedValue.ToString()) < 1))
                    {
                        MessageBox.Show("saisir un numero entre 1 et 4", "Entree invalide", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                    }
                }
            }
            if (e.ColumnIndex == 9) // Vérifiez si la colonne est la colonne 3
            {
                // Essayez de convertir la valeur entrée en une date
                if (!DateTime.TryParse(e.FormattedValue.ToString(), out DateTime result))
                {
                    // Affichez un message d'erreur
                    MessageBox.Show("Veuillez entrer une date valide.", "Entrée non valide", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Annulez l'édition
                    e.Cancel = true;
                }
            }
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            dt3 = (DataTable)dataGridView2.DataSource;
            DataRow row = dt3.Rows[e.RowIndex];
            dl.ExecuteActionCommand($@"UPDATE question 
                          SET reponse=({row[6]}),
                              QUESTION='{row[1]}',
                              OPTION1='{row[2]}',
                              OPTION2='{row[3]}',
                              OPTION3='{row[4]}',
                              OPTION4='{row[5]}',
                              NBPOINTS={row[12]} Where idq=({row[0]})");


        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
