using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;  // Postgres Dataenprovider

using CustomExtensions;             // enthält Klasse Logging

namespace Zeiterfassungs_Client
{
    public partial class FrmMain : Form
    {
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        private string s;
        private Logging lo = new Logging();      // Logging Klasse einbinden

        public FrmMain()
        {
            InitializeComponent();
            lo.l("MDAE0100;Programmstart mit Initialisierung");
        }
        


        private void frmMain_Load(object sender, EventArgs e)
        {
            lo.l("main0100;FormLoad");
            /*
                Label Ladeprozedur
            */
            lblProgInfo.Text = "Bitte zunächst einen Namen aus der Listbox auswählen. Einfach anklicken.";
            lo.l("MAIN0200;Label belegt");
            /*
                Listbox Handling: https://www.c-sharpcorner.com/uploadfile/mahesh/listbox-in-C-Sharp/
            */
            listBoxNamen.Items.Add("Dina");
            listBoxNamen.Items.Add("Kautamie");
            listBoxNamen.Items.Add("Nergiz");
            listBoxNamen.Items.Add("Dzeny");
            listBoxNamen.Items.Add("Natalie");
            lo.bWriteLogLineToFile("MAIN0300;Namen eigenelsen");
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listBoxNamen_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
                Es wurde ein Listboxeleement selektiert. Auswerten, welches es ist
            */
            for (int x = 0; x < listBoxNamen.Items.Count; x++)
            {
                // Determine if the item is selected.
                if (listBoxNamen.GetSelected(x) == true)
                {
                    // Deselect all items that are selected.
                    lblPasswordInfo.Visible = true;
                    txtPasswordBox.Visible = true;
                }
            }
            
            
        }

        private void txtPasswordBox_TextChanged(object sender, EventArgs e)
        {
            /*
                Das Kennwort wurde eingegben. Die Buttons für Kommen und Gehen sowie das Kommentarfeld frei geben
            */
            cmdArrive.Visible = true;
            cmdLeave.Visible = true;
            txtInfoToSelection.Visible = true;
            txtInfoToSelection.Enabled = true;
            lblInfo.Visible = true;
        }

        private void cmdArrive_Click(object sender, EventArgs e)
        {
            /*
                Button gedrückt. Anzeigen der Selektion
            */
            cmdArrive.BackColor = Color.Red;
            cmdLeave.BackColor = Color.Empty;

        }

        private void cmdLeave_Click(object sender, EventArgs e)
        {
            /*
                Button gedrückt. Anzeigen der Selektion
            */
            cmdArrive.BackColor= Color.Empty;
            cmdLeave.BackColor = Color.Red;
        }

        private void cmdReadData_Click(object sender, EventArgs e)
        {
            try
            {
                string connstring = string.Format("Server=127.0.0.1;Port=5432;User Id=postgres;Password=L1nis1dmin;Database=myTest_db;");
                NpgsqlConnection conn = new NpgsqlConnection(connstring);
                conn.Open();
                // Console.Write("OK")
                string sql = "SELECT * FROM kennwort";  // Vorsicht: Tabellenname ist casesensitiv
                Console.Write(sql);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                ds.Reset();
                da.Fill(ds);
                dt = ds.Tables[0];

                Console.Write (ds.Tables[0]);

                dataGridView1.DataSource = dt;
                conn.Close();
                // eine neue Kommentarzeite eingefügt
                // noch ne Ändderung
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString());
                throw;
            }

        }

        private void cmdRaedSeq_Click(object sender, EventArgs e)
        {
            // Lesen der Daten in einer While schleife
            // siehe: http://embeddedsystemengineering.blogspot.com/2015/04/c-and-postgresql-using-npgsql-tutorial_81.html

            try
            {
                string connstring = string.Format("Server=127.0.0.1;Port=5432;User Id=postgres;Password=L1nis1dmin;Database=myTest_db;");
                NpgsqlConnection conn = new NpgsqlConnection(connstring);
                conn.Open();

                // Create select command
                NpgsqlCommand command = new NpgsqlCommand("Select * from kennwort",conn);
                command.Prepare();
                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    s = s + dr.GetString(0) + " - " + dr.GetString(1);
                }
                MessageBox.Show(s);
                conn.Close();
            }
            catch (NpgsqlException ex)
            {
                showError(ex);
            }

        }
        
        private void cmdInsertRecord_Click(object sender, EventArgs e)
        {
            // fügt ein Record mit den in den Textfeldern 'txtUsername' und 'txtPassWord' liegenden Daten ein
            try
            {
                if (txtUsername.Text != "" && txtPassWord.Text != "")
                {
                    // es gibt was zu speichern
                    string connstring = string.Format("Server=127.0.0.1;Port=5432;User Id=postgres;Password=L1nis1dmin;Database=myTest_db;");
                    NpgsqlConnection conn = new NpgsqlConnection(connstring);
                    conn.Open();

                    // SQL Statement definieren
                    NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO kennwort(Username,Passwort) VALUES('" + txtUsername.Text.ToString() + "','" + txtPassWord.Text.ToString() + "')",conn);
                    
                    // Execute SQL command.
                    int recordAffected = cmd.ExecuteNonQuery();
                    if (Convert.ToBoolean(recordAffected))
                    {
                        MessageBox.Show("Data successfully saved!");
                    }
                }
                else
                {
                    // Nix tun
                }
            }
            catch (NpgsqlException ex)
            {
                showError(ex);
            }
        }
        /*
         * Error Handlingsfunktion
         */
        private void showError(NpgsqlException ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cmdWriteTable_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Baustelle");
        }
    }
}
