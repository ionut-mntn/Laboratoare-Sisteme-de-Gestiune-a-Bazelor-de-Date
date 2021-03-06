using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Configuration;

namespace TemaLab1_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            insertButton.Enabled = false;
            updateButton.Enabled = false;
            deleteButton.Enabled = false;
            this.KeyPreview = true;
        }

        private void label1_Click(object sender, EventArgs e)   // CNP
        {

        }

        private void label8_Click(object sender, EventArgs e)   // nume
        {

        }

        private void label2_Click(object sender, EventArgs e)   // prenume
        {

        }

        private void Form1_Load(object sender, EventArgs e) 
        {

        }

        private void label3_Click(object sender, EventArgs e)   //inaltime
        {

        }

        private void label4_Click(object sender, EventArgs e)   // greutate
        {

        }

        private void label5_Click(object sender, EventArgs e)   // masa musculara
        {

        }

        private void label6_Click(object sender, EventArgs e)   // densitate osoasa
        {

        }

        private void label7_Click(object sender, EventArgs e)   // id sublcub
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void connectionButton_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-2SFQL7E\\SQLEXPRESS;Initial Catalog=lab1;Integrated Security=true";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter;

            string sportivQueryString = "select * from Sportiv";
            string subclubQueryString = "select * from Subclub";
            DataSet ds1 = new DataSet();

            try
            {
                connection.Open();
                adapter = new SqlDataAdapter(subclubQueryString, connection);
                adapter.Fill(ds1, "Subclub");
                adapter = new SqlDataAdapter(sportivQueryString, connection);
                adapter.Fill(ds1, "Sportiv");

                ds1.Relations.Add("Subclub Sportiv", ds1.Tables["Subclub"].Columns["id_subclub"],
                    ds1.Tables["Sportiv"].Columns["id_subclub"]);

                connection.Close();

                // dataGridView1.DataSource = ds1.Tables["Sportiv"];
                dataGridView1.DataSource = ds1.Tables["Subclub"];
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                connection.Close();
            }

            /*
            using ()
            {
                try
                {
                    
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        
                        //Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}",
                          //  reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6], reader[7], reader[8])
                        
                        dataGridView1.

                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            */
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) // posibil ca asta sa trebuiasca sa fie CellClick, fara content !!
        {

        }

        //private void getPrimaryKeyColumnName(string tableName, ) // DAR ATENTIE! IT REQUIRES AN OPEN CONNECTION
        //{
        //    string primaryKeyColumnNameQuery = "SELECT ColumnName = col.column_name" +
        //    " FROM information_schema.table_constraints tc" +
        //    " INNER JOIN information_schema.key_column_usage col" +
        //    " ON col.Constraint_Name = tc.Constraint_Name" +
        //    " AND col.Constraint_schema = tc.Constraint_schema" +
        //    " WHERE tc.Constraint_Type = 'Primary Key'" +
        //    " AND col.Table_name = '" + tableName + "'";

        //    SqlCommand auxCommand = new SqlCommand(primaryKeyColumnNameQuery, connection);
        //}

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRowNum = this.dataGridView1.CurrentCell.RowIndex;
            object cellValue1 = this.dataGridView1[0, selectedRowNum].Value;

            // string str2 = dataGridView1.Columns;

            //DataTable parentTable = 
            foreach(DataGridViewColumn col in this.dataGridView1.Columns)
            {
                //if(col.HeaderText=="")
            }
            //this.dataGridView1.

//            DataTable childTable = null;

//            foreach()

            // string stringSelectedSubclubId = cellValue1.ToString(); // cred ca am facut niste pasi in plus pe aicea !!
            int selectedSubclubId = (int) cellValue1;

            

            //string connectionString = "Data Source=DESKTOP-2SFQL7E\\SQLEXPRESS;Initial Catalog=lab1;Integrated Security=true";
            string connectionString = ConfigurationManager.AppSettings.Get("connectionString");
            //connectionButton.Text = connectionString;
//            label9.Text = connectionString;
//            string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);





            string parentTableName = ConfigurationManager.AppSettings.Get("parentTable");
            string primaryKeyColumnNameQuery = "SELECT ColumnName = col.column_name" +
             " FROM information_schema.table_constraints tc" +
             " INNER JOIN information_schema.key_column_usage col" +
             " ON col.Constraint_Name = tc.Constraint_Name" +
                     " AND col.Constraint_schema = tc.Constraint_schema" +
             " WHERE tc.Constraint_Type = 'Primary Key'" +
                     " AND col.Table_name = '" + parentTableName + "'";

            //SqlCommand auxCommand = new SqlCommand(primaryKeyColumnNameQuery, connection);
            //SqlDataReader auxReader = auxCommand.ExecuteReader();0

           




            string childTableName = ConfigurationManager.AppSettings.Get("childTable");
            //label9.Text = childTableName;
            //string childQuery = "select * from Sportiv where id_subclub = @IdSubclub";
            string childQuery = "select * from " + childTableName + " where id_subclub = @IdSubclub";
            SqlCommand command = new SqlCommand(childQuery, connection);
            command.Parameters.Add("@IdSubclub", SqlDbType.Int);
            command.Parameters["@IdSubclub"].Value = selectedSubclubId;

            try
            {
                connection.Open();

                SqlCommand auxCommand = new SqlCommand(primaryKeyColumnNameQuery, connection);
                string primaryKeyColumnName = (string)auxCommand.ExecuteScalar(); // de schimbat aici sa mearg si pt tabele cu PK compus!!
                label9.Text = primaryKeyColumnName;

                SqlDataReader reader = command.ExecuteReader();
                //connectionButton.Text += '!';
                DataTable childTable = new DataTable();
                childTable.Load(reader);
                dataGridView2.DataSource = childTable;
                reader.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.KeyDown += new KeyEventHandler(dataGridView2_KeyDown);
            // this.KeyPress += new KeyEventHandler(dataGridView2_KeyPress);
            // this.KeyPress += new KeyEventHandler(Form1_KeyDown);

        }

        private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine("key down");
        }

        private void dataGridView2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine("Key Pressed");
        }

        private void insertButton_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
