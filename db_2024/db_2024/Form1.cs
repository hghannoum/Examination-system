using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace db_2024
{
    public partial class Form1 : Form
    {
        Form main; DataLayer dl; DataTable dt, dt2;
        public Form1(Form f)
        {
            InitializeComponent();
            main = f;

            dl = new DataLayer("QSC-PC\\SQLEXPRESS01", "LAST");
            dt = dl.GetData("select p.Numero,Nom,Prenom, Name FROM Personne p inner join etudiant e on p.numero=e.numero inner join classe c on e.classe_id = c.class_id ", "IDS");
            dt2 = dl.GetData("select Name from classe", "");
            dataGridView1.DataSource = dt;

            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Show();

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            dt = (DataTable)dataGridView1.DataSource;
            DataRow row = dt.Rows[e.RowIndex];
            dl.ExecuteActionCommand($@"declare @cl int;
                                      set @cl= (select class_id from classe where name='{row[3]}');
                                            UPDATE etudiant 
                          SET classe_id=(@cl)  where NUmero=({row[0]})

                            ");

        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            
        }
    }
}
