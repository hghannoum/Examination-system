using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static db_2024.enseignant;
namespace db_2024
{
    public partial class etudiant : Form
    {
        public etudiant(Form main)
        {
            InitializeComponent();
            m = main;

        }


        DataTable dt, DT2; MYCLASS c = MYCLASS.Instance;
        private void etudiant_Load(object sender, EventArgs e)
        {

            dl = new DataLayer("QSC-PC\\SQLEXPRESS01", "LAST");
            dt = dl.GetData($"select * FROM Personne where numero={c.id}", "info");
            DT2 = dl.GetData($"SELECT CLASSE.NAME, CLASSE.CLASS_ID AS ClassName\r\nFROM ETUDIANT\r\nJOIN PERSONNE " +
                $"ON ETUDIANT.NUMERO = PERSONNE.NUMERO\r\nJOIN CLASSE ON eTUDIANT.CLASSE_ID = CLASSE.CLASS_ID " +
                $"WHERE ETUDIANT.NUMERO = {c.id};\r\n", "info2");
            label2.Text = dt.Rows[0][0].ToString() + " " + dt.Rows[0][1].ToString();
            label4.Text = DT2.Rows[0][0].ToString();
        }

        private void mETTREUNTESTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.BringToFront();
            panel4.Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        DataLayer dl;
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string query = @$"SELECT
    CONCAT(P.[NOM], ' ', P.[PRENOM]) AS NomEnseignant,
    T.[NUMT] AS TestID,
    T.[matiere] AS Matiere,
    SUM(Q.[NBPOINTS]) AS SommeNbPoints,
    SUM(Q.[temps]) AS SommeTemps
FROM
    [dbo].[TEST] T
FULL OUTER JOIN
    [dbo].[ENSEIGNANT] EN ON T.[NUMERO] = EN.[NUMERO]
FULL OUTER JOIN
    [dbo].[PERSONNE] P ON EN.[NUMERO] = P.[NUMERO]
FULL OUTER JOIN
    [dbo].[QUESTION] Q ON T.[NUMT] = Q.[NUMT_TEST]
FULL OUTER JOIN
    [dbo].[TEST_CLASS] TC ON T.[NUMT] = TC.[numt]
WHERE
    TC.[CLASS_ID] = {DT2.Rows[0][1].ToString()}
    AND NOT EXISTS (
        SELECT 1
        FROM [dbo].[EVALUATION] E
        WHERE E.[NUMT] = T.[NUMT]
        AND E.[NUMERO] = {c.id}
    )
GROUP BY
    P.[NOM], P.[PRENOM], T.[NUMT], T.[matiere];

";
            DataTable dt = dl.GetData(query, "");
            dataGridView1.DataSource = dt;
            dataGridView1.Visible = true;


        }
        Form m;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            m.Show();
        }

        private void nd4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (remainingTimeInSeconds > 0)
            {
                remainingTimeInSeconds--;
                UpdateTimerLabel();
            }
            else
            {
                timer1.Stop();
                button2.PerformClick();
            }
        }

        private void UpdateTimerLabel()
        {
            int minutes = remainingTimeInSeconds / 60;
            int seconds = remainingTimeInSeconds % 60;
            timer.Text = $"{minutes:00}:{seconds:00}";
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        DataTable dt3; int COUNTER = 0; int reponsee; private int remainingTimeInSeconds = 0; int[] results, temps;
        private void button1_Click(object sender, EventArgs e)
        {
            COUNTER = 0;
            try
            {
                dt3 = dl.GetData($"SELECT IDQ,QUESTION,OPTION1, OPTION2, OPTION3,OPTION4,REPONSE,NUMT_TEST,TEMPS,DEADLINE,MATIERE,DATE,NBPOINTS,NIVEAU, Numero  FROM QUESTION INNER JOIN TEST ON NUMT_TEST=NUMT WHERE numt=({dataGridView1.SelectedRows[0].Cells[1].Value})", "q");
            }
            catch
            {
                MessageBox.Show("Selectionner une ligne"); return;            }
            menuStrip1.Enabled = false;
            panel3.Visible = true;
            panel1.Visible = false;
            panel2.Visible = true;
            panel2.BringToFront();
            
            question.Text = dt3.Rows[COUNTER][1].ToString();
            o1.Text = dt3.Rows[COUNTER][2].ToString();
            o2.Text = dt3.Rows[COUNTER][3].ToString();
            o3.Text = dt3.Rows[COUNTER][4].ToString();
            o4.Text = dt3.Rows[COUNTER][5].ToString();
            points.Text = dt3.Rows[COUNTER][12].ToString();
            niveau.Text = dt3.Rows[COUNTER][13].ToString();
            reponsee = (int)dt3.Rows[COUNTER][6];
            remainingTimeInSeconds = (int)dt3.Rows[COUNTER][8] * 60;
            timer1.Interval = 1000;
            timer1.Start();
            results = new int[dt3.Rows.Count];
            temps = new int[dt3.Rows.Count];
            if (dt3.Rows.Count > 1)
            {
                button2.Text = "Suivant";
            }
            else button2.Text = "Fini";
            UpdateTimerLabel();

        }
        int countt = 0;
        private void button2_Click(object sender, EventArgs e)
        {

            results[COUNTER] = (int)reponse.Value;
            temps[COUNTER] = remainingTimeInSeconds / 60;
            if (button2.Text == "Fini")
            {
                panel2.Visible = false;
                string query = @$"SELECT
    CONCAT(P.[NOM], ' ', P.[PRENOM]) AS NomEnseignant,
    T.[NUMT] AS TestID,
    T.[matiere] AS Matiere,
    SUM(Q.[NBPOINTS]) AS SommeNbPoints,
    SUM(Q.[temps]) AS SommeTemps
FROM
    [dbo].[TEST] T
FULL OUTER JOIN
    [dbo].[ENSEIGNANT] EN ON T.[NUMERO] = EN.[NUMERO]
FULL OUTER JOIN
    [dbo].[PERSONNE] P ON EN.[NUMERO] = P.[NUMERO]
FULL OUTER JOIN
    [dbo].[QUESTION] Q ON T.[NUMT] = Q.[NUMT_TEST]
FULL OUTER JOIN
    [dbo].[TEST_CLASS] TC ON T.[NUMT] = TC.[numt]
WHERE
    TC.[CLASS_ID] = {c.id}
    AND NOT EXISTS (
        SELECT 1
        FROM [dbo].[EVALUATION] E
        WHERE E.[NUMT] = T.[NUMT]
        AND E.[NUMERO] = {c.id}
    )
GROUP BY
    P.[NOM], P.[PRENOM], T.[NUMT], T.[matiere];

";
                DataTable dt4 = dl.GetData(query, "");
                dataGridView1.DataSource = dt4;
                dataGridView1.Visible = true;
                int totalSum = 0, total = 0;

                foreach (int result in results)
                { // Replace with the actual property of your Question class

                    // Iterate through the DataTable rows to find a match
                    foreach (DataRow row in dt3.Rows)
                    {
                        // Assuming the column name in the DataTable is "results"
                        int dtResult = (int)row[6]; // Replace with the actual column name
                        int nbpoints = Convert.ToInt32(row[12]);
                        total += nbpoints;
                        // Compare the question result with the DataTable result
                        if (result == dtResult)
                        {
                            // Assuming there is a column named "nbpoints" in the DataTable
                            // Replace with the actual column name

                            // Add nbpoints to totalSum
                            totalSum += nbpoints;

                        }
                    }

                }
                menuStrip1.Enabled = true;
                int totaltime = 0;
                foreach (int temp in temps)
                { // Replace with the actual property of your Question class

                    // Iterate through the DataTable rows to find a match
                    // Assuming there is a column named "nbpoints" in the DataTable
                    // Replace with the actual column name

                    // Add nbpoints to totalSum
                    totaltime += temp;


                }
                MessageBox.Show($"Le test a fini et tu pris {totalSum}/{total} en {totaltime} minutes");


                // Assuming currentDate is a DateTime variable
                DateTime currentDate = DateTime.Today;
                panel2.Visible = false; panel1.Visible = true; panel1.BringToFront();
                dl.ExecuteActionCommand($"insert into evaluation values ({c.id},{dt3.Rows[0][14]},{dt3.Rows[0][7]},{totalSum},{total},'{currentDate.ToString("yyyy-MM-dd")}')");

            }
            else
            {
                COUNTER++;
                if (COUNTER == dt3.Rows.Count-1)
                {
                    button2.Text = "Fini";
                }
                question.Text = dt3.Rows[COUNTER][1].ToString();
                o1.Text = dt3.Rows[COUNTER][2].ToString();
                o2.Text = dt3.Rows[COUNTER][3].ToString();
                o3.Text = dt3.Rows[COUNTER][4].ToString();
                o4.Text = dt3.Rows[COUNTER][5].ToString();
                points.Text = dt3.Rows[COUNTER][12].ToString();
                niveau.Text = dt3.Rows[COUNTER][13].ToString();
                reponsee = (int)dt3.Rows[COUNTER][6];
                remainingTimeInSeconds = (int)dt3.Rows[COUNTER][8] * 60;


            }
        }

        private void vOIRNOTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"SELECT\r\n    E.NUMERO AS EvaluationID,\r\n    E.RESULTAT,\r\n    E.DATEFAITE,\r\n    CONCAT(P.NOM, ' ', P.PRENOM) AS EnseignantNom\r\nFROM\r\n    EVALUATION E\r\nJOIN\r\n    ENSEIGNANT EN ON E.NUMERO_ENSEIGNANT = EN.NUMERO\r\nJOIN\r\n    PERSONNE P ON EN.NUMERO = P.NUMERO\r\nWHERE\r\n    E.NUMERO = ({c.id});\r\n");
           DataTable dt5= dl.GetData($"SELECT\r\n    E.NUMERO AS EvaluationID,\r\n    E.RESULTAT,\r\n    E.DATEFAITE,\r\n    CONCAT(P.NOM, ' ', P.PRENOM) AS EnseignantNom\r\nFROM\r\n    EVALUATION E\r\nJOIN\r\n    ENSEIGNANT EN ON E.NUMERO_ENSEIGNANT = EN.NUMERO\r\nJOIN\r\n    PERSONNE P ON EN.NUMERO = P.NUMERO\r\nWHERE\r\n    E.NUMERO = ({c.id});\r\n", "");
            dataGridView2.DataSource= dt5;
            panel4.Visible = true;
            panel1.Visible = false;
            panel4.BringToFront();
        
        }
    }
}
