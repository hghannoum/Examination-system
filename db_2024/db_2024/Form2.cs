using System.Data;
using System.Text.RegularExpressions;
namespace db_2024
{
    public partial class Form2 : Form
    {
        MYCLASS C = MYCLASS.Instance;


        DataLayer dl; DataTable dt, dt2; Form F;
        public Form2()
        {
            InitializeComponent();
            F = this;
            this.AutoScaleMode = AutoScaleMode.None;
            this.Size = new System.Drawing.Size(800, 800);
            // Set your desired width and height
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;


        }
        private void Form2_Load(object sender, EventArgs e)
        {
            dl = new DataLayer("QSC-PC\\SQLEXPRESS01", "LAST");
            dt = dl.GetData("select Numero,TYPE FROM IDS", "IDS");
            DataTable result =
                result = dl.GetData($"SELECT nAME FROM CLASSE", "classes");
            // Create a list of options
            List<string> options = result.AsEnumerable()
                              .Select(row => row.Field<string>("NAME"))
                              .ToList();
            // Set the CheckedListBox properties
            checkedListBox1.Items.AddRange(options.ToArray());
            dt2 = dl.GetData("select username from personne", "usernames");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox6.Text != textBox8.Text)
            {
                label12.Visible = true;
            }
            else
            {
                label12.Visible = false;
            }
        }

        private void textBox6_KeyUp(object sender, KeyEventArgs e)
        {

            string pattern = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";

            // Create a Regex object
            Regex regex = new Regex(pattern);

            // Use the IsMatch method to test the password
            if (!regex.IsMatch(textBox6.Text))
            {
                label11.Visible = true;
            }
            else label11.Visible = false;
        }

        private void textBox7_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox7.Text != "")
            {

                if (!dt.AsEnumerable()
                                               .Any(row => row.Field<int>("NUMERO") == (int.Parse(textBox7.Text))))
                    label1.Visible = true;
                else
                    label1.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (label1.Visible || label11.Visible || label12.Visible || label14.Visible)
                return;
            else
            {
                id = int.Parse(textBox7.Text);
                object[,] parametersArray = {
                        { "@IDENTITE", int.Parse(textBox7.Text) ,false},
                        { "@NOM", textBox3.Text,false },
                        { "@PRENOM", textBox4.Text,false },
                        { "@NU", textBox5.Text ,false},
                        { "@MOTCLE", textBox6.Text,false },
                    };

                int result2 = dl.ExecuteActionCommand("sign_up", parametersArray);

                panel2.Visible = false;
                panel1.Visible = true;

            }
            DataTable result = dl.GetData($"select * from dbo.LOG_IN ('{textBox5.Text}','{textBox6.Text}')", "log_in");

            C.id = (int)result.Rows[0][0];
            if (!string.IsNullOrEmpty(optionsAsString))
            {
                string[] optionsArray = optionsAsString.Split(',');

                if (optionsArray.Length > 0)
                {
                    int firstOptionValue = int.Parse(optionsArray[0]);

                    if (dt.AsEnumerable()
                           .Where(row => row.Field<int>("NUMERO") == (int)result.Rows[0][0])
                           .Select(row => row.Field<int>("TYPE"))
                           .FirstOrDefault() == 1)
                    {
                        dl.ExecuteActionCommand($"Insert into enseignant values ({C.id})");
                       
                        dl.ExecuteActionCommand("InsertEnseignantT", new object[,] {
                { "@OptionsAsString", optionsAsString.Trim(','), false },
                { "@Numero", C.id, false }
            });
                    }
                    else
                    {
                        dl.ExecuteActionCommand($"Insert into etudiant values ({C.id},{firstOptionValue + 1})");
                    }
                }
            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }
        private void textBox5_KeyUp(object sender, KeyEventArgs e)
        {
            if (dt2.AsEnumerable()
                                           .Any(row => row.Field<string>("username") == textBox5.Text))
                label14.Visible = true;
            else
                label14.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {


            DataTable result = dl.GetData($"select * from dbo.LOG_IN ('{textBox1.Text}','{textBox2.Text}')", "log_in");

            if (result.Rows.Count == 0) MessageBox.Show("Nom utilisateur ou mot cle faux");
            else
            {
                C.id = (int)result.Rows[0][0];
                this.Hide();
                MessageBox.Show(dt.AsEnumerable()
                   .Where(row => row.Field<int>("NUMERO") == (int)result.Rows[0][0])
                   .Select(row => row.Field<bool>("TYPE"))
                   .FirstOrDefault().ToString());
                if (dt.AsEnumerable()
                   .Where(row => row.Field<int>("NUMERO") == (int)result.Rows[0][0])
                   .Select(row => row.Field<bool>("TYPE"))
                   .FirstOrDefault() == true)
                {
                    etudiant et = new etudiant(this);
                    et.ShowDialog();

                }
                else
                {
                    enseignant es = new enseignant(this);
                    es.ShowDialog();
                }
            }


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only numbers and backspace
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
                // Allow the key press for numbers and backspace
                e.Handled = false;
            }
            else
            {
                // Suppress the key press for other characters
                e.Handled = true;
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {


        }
        string optionsAsString = "";
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
                checkedItems.Add(e.Index.ToString());
                optionsAsString += e.Index.ToString() + ",";
            }
            // If the item is being unchecked, remove it from the list
            else
            {
                checkedItems.Remove(e.Index.ToString());
            }

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            int id = 0;
            if (label1.Visible || label11.Visible || label12.Visible || label14.Visible)
                return;
            else
            {
                id = int.Parse(textBox7.Text);
                object[,] parametersArray = {
                        { "@IDENTITE", int.Parse(textBox7.Text) ,false},
                        { "@NOM", textBox3.Text,false },
                        { "@PRENOM", textBox4.Text,false },
                        { "@NU", textBox5.Text ,false},
                        { "@MOTCLE", textBox6.Text,false },
                    };

                int result2 = dl.ExecuteActionCommand("sign_up", parametersArray);

                panel2.Visible = false;
                panel3.Visible = true;

            }
            DataTable result = dl.GetData($"select * from dbo.LOG_IN ('{textBox5.Text}','{textBox6.Text}')", "log_in");

            C.id = (int)result.Rows[0][0];
            if (!string.IsNullOrEmpty(optionsAsString))
            {
                string[] optionsArray = optionsAsString.Split(',');

                if (optionsArray.Length > 0)
                {
                    int firstOptionValue = int.Parse(optionsArray[0]);

                    if ((int)result.Rows[0][1] == 0)
                    {
                        dl.ExecuteActionCommand($"Insert into enseignant values ({C.id})");
                        
                        dl.ExecuteActionCommand("InsertEnseignantT", new object[,] {
                { "@OptionsAsString", optionsAsString.Trim(','), false },
                { "@Numero", C.id, false }
            });
                    }
                    else
                    {
                        dl.ExecuteActionCommand($"Insert into etudiant values ({C.id},{firstOptionValue + 1})");
                    }
                }
            }


        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            panel2.Visible = false;
            panel3.Visible = true;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            DataTable result = dl.GetData($"select * from dbo.LOG_IN ('{textBox1.Text}','{textBox2.Text}')", "log_in");
            if (result.Rows.Count == 0) MessageBox.Show("Nom utilisateur ou mot cle faux");
            else
            {
                C.id = (int)result.Rows[0][0];
                MessageBox.Show(result.Rows[0][1].ToString());
                this.Hide();
                if ((int)result.Rows[0][1] == 1)
                {
                    etudiant et = new etudiant(F);
                    et.ShowDialog();

                }
                else
                {
                    enseignant es = new enseignant(F);
                    es.ShowDialog();
                }
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel2.Visible = true;
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load_1(object sender, EventArgs e)
        {
            dl = new DataLayer("QSC-PC\\SQLEXPRESS01", "LAST");
            dt = dl.GetData("select Numero,TYPE FROM IDS", "IDS");
            DataTable result =
                result = dl.GetData($"SELECT nAME FROM CLASSE", "classes");
            // Create a list of options
            List<string> options = result.AsEnumerable()
                              .Select(row => row.Field<string>("NAME"))
                              .ToList();
            // Set the CheckedListBox properties
            checkedListBox1.Items.AddRange(options.ToArray());
            dt2 = dl.GetData("select username from personne", "usernames");
        }

        private void checkedListBox1_ItemCheck_1(object sender, ItemCheckEventArgs e)
        {
            List<string> checkedItems = checkedListBox1.CheckedItems
                                            .OfType<string>()
                                            .ToList();

            // If the item is being checked, add it to the list
            if (e.NewValue == CheckState.Checked)
            {
                checkedItems.Add(e.Index.ToString());
                optionsAsString += e.Index.ToString() + ",";
            }
            // If the item is being unchecked, remove it from the list
            else
            {
                checkedItems.Remove(e.Index.ToString());
            }
        }

        private void label15_Click_1(object sender, EventArgs e)
        {
            if (label15.Text == "Je suis admin")
            {
                label15.Text = "Retour";
                panel1.Visible = false;
                panel4.Visible = true;
            }
            else
            {
                label15.Text = "Je suis admin";
                panel4.Visible = false;
                panel1.Visible = true;

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            DataTable result = dl.GetData($"select * from dbo.CheckAdminCredential ('{textBox9.Text}','{textBox10.Text}')", "login");

            if (result.Rows.Count>0)
            {
                this.Hide();
                Form1 ad = new Form1(this);
                ad.ShowDialog();
            }
            else MessageBox.Show("Nom admin ou mot cle faux");
        }
    }
}
