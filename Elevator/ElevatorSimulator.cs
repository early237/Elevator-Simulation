using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data; 
using System.Data.OleDb; //Imports the Database Connection package
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/**

    ------------------------------------------------------------

    Here is my C# program that allows the user to control the Elevator by making it go Up or Down.
    I have also used a MS Access database to log all activity carried out by the program. The database is located in the root of the directory.
    @Author James Early

    ------------------------------------------------------------
 */

    
namespace Elevator
{
    public partial class ElevatorSimulator : Form
    {
        // Declares a int and string variable to show what floor the elevator is on
        int firstFloor = 1;
        string groundFloor = "G";
      
        public ElevatorSimulator()
        {

            InitializeComponent();

            // Declared the connection string that points to the Access Database
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\early\Downloads\1506910AssignmentOne\1506910AssignmentOne\Elevator\JEElevator.accdb";
        }

        // Method that creates the "connection" varible used by the OleDbConnection
        public OleDbConnection connection = new OleDbConnection();


        private void button1_Click(object sender, EventArgs e)
        {
            // Opens a connection to my database
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            // Creates strings used in the database table
            string date = DateTime.Now.ToShortDateString();
            string time = DateTime.Now.ToShortTimeString();
            string process = "FLOOR BUTTON: First floor button pressed";
            // Database query that inserts the string data into table 
            command.CommandText = ("insert into table1 ([Date], [Time], [Process])" + "values('" + date + "', '" + time + "', '" + process + "')");
            // Executes the query
            command.ExecuteNonQuery();
            // Connection Closes
            connection.Close();
            
            // Runs a select query on the database
            connection.Open();
            OleDbCommand command1 = new OleDbCommand();
            command1.Connection = connection;
            string query = "select * from table1";
            command1.CommandText = query;

            // Fills and updates my database GridView
            OleDbDataAdapter da = new OleDbDataAdapter(command1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            table1DataGridView.DataSource = dt;
            connection.Close();
       
            // Inputs into the textboxes the floor the elevator is on. In this case, using the groundFloor variable
            TopFloorDisplayTB.Text = groundFloor;
            GFloorDisplayTB.Text = groundFloor;
            ControlPanelDisplayTB.Text = "Going to floor " + groundFloor;

            // Starts the timer to move the Elevator PicureBox Up
            EUp.Start();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            // Opens a connection to my database
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            OleDbCommand command3 = new OleDbCommand();
            command.Connection = connection;
            command3.Connection = connection;
            // Creates strings used in the database table
            string date = DateTime.Now.ToShortDateString();
            string time = DateTime.Now.ToShortTimeString();
            string process = "FLOOR BUTTON: Ground floor button pressed";
            string process1 = "Elevator Traveling to Ground Floor";
            // Database query that inserts the string data into table
            command.CommandText = ("insert into table1 ([Date], [Time], [Process])" + "values('" + date + "', '" + time + "', '" + process + "')");
            command3.CommandText = ("insert into table1 ([Date], [Time], [Process])" + "values('" + date + "', '" + time + "', '" + process1 + "')");
            // Executes the query
            command.ExecuteNonQuery();
            command3.ExecuteNonQuery();
            connection.Close();

            // Runs a select query on the database
            connection.Open();
            OleDbCommand command1 = new OleDbCommand();
            command1.Connection = connection;
            string query = "select * from table1";
            command1.CommandText = query;

            // Fills and updates my database GridView
            OleDbDataAdapter da = new OleDbDataAdapter(command1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            table1DataGridView.DataSource = dt;
            connection.Close();
            
            // Inputs into the textboxes the floor the elevator is on. In this case, using the groundFloor variable
            TopFloorDisplayTB.Text = groundFloor;
            TopFloorDisplayTB.Text = groundFloor;
            GFloorDisplayTB.Text = groundFloor;
            ControlPanelDisplayTB.Text = "Going to floor " + groundFloor;

            // Starts the timer to Close the Top floor doors
            TDoorClose.Start();

            // Changes the button visibility to show when the button is pressed
            BBottomFloorPanelRed.Visible = true;
            BBottomFloorPanel.Visible = false;
            BTopFloorPanel.Visible = true;
            BTopFloorPanelRed.Visible = false;
            DownArrowControlRed.Visible = true;
            UpArrowControlRed.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Opens a connection to my database
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            OleDbCommand command3 = new OleDbCommand();
            command.Connection = connection;
            command3.Connection = connection;
            // Creates strings used in the database table
            string date = DateTime.Now.ToShortDateString();
            string time = DateTime.Now.ToShortTimeString();
            string process = "CONTROL PANEL: First Floor Button Pressed";
            string process1 = "Elevator Traveling to First Floor";
            // Database query that inserts the string data into table
            command.CommandText = ("insert into table1 ([Date], [Time], [Process])" + "values('" + date + "', '" + time + "', '" + process + "')");
            command3.CommandText = ("insert into table1 ([Date], [Time], [Process])" + "values('" + date + "', '" + time + "', '" + process1 + "')");
            // Executes the querys
            command.ExecuteNonQuery();
            command3.ExecuteNonQuery();
            connection.Close();

            // Runs a select query on the database
            connection.Open();
            OleDbCommand command1 = new OleDbCommand();
            command1.Connection = connection;
            string query = "select * from table1";
            command1.CommandText = query;

            // Fills and updates my database GridView
            OleDbDataAdapter da = new OleDbDataAdapter(command1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            table1DataGridView.DataSource = dt;
            connection.Close();
            
            // Inputs into the textboxes the floor the elevator is on. In this case, using the groundFloor variable
            TopFloorDisplayTB.Text = firstFloor.ToString();
            ControlPanelDisplayTB.Text = "Going to floor " + firstFloor.ToString();
            TopFloorDisplayTB.Text = firstFloor.ToString();
            GFloorDisplayTB.Text = firstFloor.ToString();

            // Starts the timer to close the bottom floor doors
            BDoorClose.Start();
            
            // Changes the button visibility to show when the button is pressed
            UpArrowControlRed.Visible = true;
            DownArrowControlRed.Visible = false;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

            // Opens a connection to my database
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            OleDbCommand command3 = new OleDbCommand();
            command.Connection = connection;
            command3.Connection = connection;
            // Creates strings used in the database table
            string date = DateTime.Now.ToShortDateString();
            string time = DateTime.Now.ToShortTimeString();
            string process = "CONTROL PANEL: Ground Floor Button Pressed";
            string process1 = "Elevator Traveling to Ground Floor";
            // Database query that inserts the string data into table
            command.CommandText = ("insert into table1 ([Date], [Time], [Process])" + "values('" + date + "', '" + time + "', '" + process + "')");
            command3.CommandText = ("insert into table1 ([Date], [Time], [Process])" + "values('" + date + "', '" + time + "', '" + process1 + "')");
            // Executes the query
            command.ExecuteNonQuery();
            command3.ExecuteNonQuery();
            connection.Close();

            // Runs a select query on the database
            connection.Open();
            OleDbCommand command1 = new OleDbCommand();
            command1.Connection = connection;
            string query = "select * from table1";
            command1.CommandText = query;

            // Fills and updates my database GridView
            OleDbDataAdapter da = new OleDbDataAdapter(command1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            table1DataGridView.DataSource = dt;
            connection.Close();
            
            // Inputs into the textboxes the floor the elevator is on. In this case, using the groundFloor variable
            TopFloorDisplayTB.Text = groundFloor;
            ControlPanelDisplayTB.Text = "Going to floor " + groundFloor;
            TopFloorDisplayTB.Text = groundFloor;
            GFloorDisplayTB.Text = groundFloor;

            // Starts the timer to close the top floor doors
            TDoorClose.Start();
            
            // Changes the button visibility to show when the button is pressed
            DownArrowControlRed.Visible = true;
            UpArrowControlRed.Visible = false;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Starts the DataGridView as invisible
            table1DataGridView.Visible = false;
            // TODO: This line of code loads data into the 'jEElevatorDataSet.Table1' table. You can move, or remove it, as needed.
            this.table1TableAdapter.Fill(this.jEElevatorDataSet.Table1);

        }
        private void table1BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.table1BindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.jEElevatorDataSet);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Sets the DataGridView as visible
            table1DataGridView.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Opens a connection to my database
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            // Database query that deletes all data from the database
            string query = "delete * from table1";
            command.CommandText = query;

            // Fills and updates my database GridView
            OleDbDataAdapter da = new OleDbDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            table1DataGridView.DataSource = dt;
            connection.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Sets the DataGridView as invisible
            table1DataGridView.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            // IF statement that controls the movement of the PictureBox
            if (EleavtorPB.Top > 50)
            {
                EleavtorPB.Top = EleavtorPB.Top - 10;
            }
            else
            {
                EUp.Stop();

                // Opens a connection to my database
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                // Creates strings used in the database table
                string date = DateTime.Now.ToShortDateString();
                string time = DateTime.Now.ToShortTimeString();
                string process = "Elevator has arrived on First Floor";
                // Database query that inserts the string data into table
                command.CommandText = ("insert into table1 ([Date], [Time], [Process])" + "values('" + date + "', '" + time + "', '" + process + "')");
                // Executes the query
                command.ExecuteNonQuery();
                connection.Close();

                // Runs a select query on the database
                connection.Open();
                OleDbCommand command1 = new OleDbCommand();
                command1.Connection = connection;
                string query = "select * from table1";
                command1.CommandText = query;

                // Fills and updates my database GridView
                OleDbDataAdapter da = new OleDbDataAdapter(command1);
                DataTable dt = new DataTable();
                da.Fill(dt);
                table1DataGridView.DataSource = dt;
                connection.Close();

                // Starts the timer to open the top floor doors
                TDoorOpen.Start();           
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
            // IF statement that controls the movement of the PictureBox
            if (EleavtorPB.Top < 470)
            {
                EleavtorPB.Top = EleavtorPB.Top + 10;
            }
            else
            {
                EDown.Stop();

                // Opens a connection to my database
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                // Creates strings used in the database table
                string date = DateTime.Now.ToShortDateString();
                string time = DateTime.Now.ToShortTimeString();
                string process = "Elevator has arrived on Ground Floor";
                // Database query that inserts the string data into table
                command.CommandText = ("insert into table1 ([Date], [Time], [Process])" + "values('" + date + "', '" + time + "', '" + process + "')");
                // Executes the query
                command.ExecuteNonQuery();
                connection.Close();

                // Runs a select query on the database
                connection.Open();
                OleDbCommand command1 = new OleDbCommand();
                command1.Connection = connection;
                string query = "select * from table1";
                command1.CommandText = query;

                // Fills and updates my database GridView
                OleDbDataAdapter da = new OleDbDataAdapter(command1);
                DataTable dt = new DataTable();
                da.Fill(dt);
                table1DataGridView.DataSource = dt;
                connection.Close();

                // Starts the timer to open the bottom floor doors
                BDoorOpen.Start();         
            }
            
        }

        private void button8_Click(object sender, EventArgs e)
        {

            // Opens a connection to my database
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            OleDbCommand command3 = new OleDbCommand();
            command.Connection = connection;
            command3.Connection = connection;
            // Creates strings used in the database table
            string date = DateTime.Now.ToShortDateString();
            string time = DateTime.Now.ToShortTimeString();
            string process = "FLOOR BUTTON: First floor button pressed";
            string process1 = "Elevator Traveling to First Floor";
            // Database query that inserts the string data into table
            command.CommandText = ("insert into table1 ([Date], [Time], [Process])" + "values('" + date + "', '" + time + "', '" + process + "')");
            command3.CommandText = ("insert into table1 ([Date], [Time], [Process])" + "values('" + date + "', '" + time + "', '" + process1 + "')");
            // Executes the query
            command.ExecuteNonQuery();
            command3.ExecuteNonQuery();
            connection.Close();
            
            // Runs a select query on the database
            connection.Open();
            OleDbCommand command1 = new OleDbCommand();
            command1.Connection = connection;
            string query = "select * from table1";
            command1.CommandText = query;

            // Fills and updates my database GridView
            OleDbDataAdapter da = new OleDbDataAdapter(command1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            table1DataGridView.DataSource = dt;
            connection.Close();

            // Inputs into the textboxes the floor the elevator is on. In this case, using the groundFloor variable
            TopFloorDisplayTB.Text = firstFloor.ToString();
            GFloorDisplayTB.Text = firstFloor.ToString();
            ControlPanelDisplayTB.Text = "Going to floor " + firstFloor.ToString();

            // Starts the timer to close the bottom floor doors
            BDoorClose.Start();

            // Changes the button visibility to show when the button is pressed
            BTopFloorPanel.Visible = false;
            BTopFloorPanelRed.Visible = true;
            BBottomFloorPanel.Visible = true;
            BBottomFloorPanelRed.Visible = false;
            UpArrowControlRed.Visible = true;
            DownArrowControlRed.Visible = false;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            // IF statement that controls the movement of the PictureBox         
            if (BDoorLeft.Left > 170)
            {
                BDoorRight.Left = BDoorRight.Left + 5;
                BDoorLeft.Left = BDoorLeft.Left - 5;
               
            }   
            else
            {
                BDoorOpen.Stop();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // Timer that will open the top floor doors
            TDoorOpen.Start();
        }
        
        private void button11_Click(object sender, EventArgs e)
        {
            TDoorClose.Start();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            // IF statement that controls the movement of the PictureBox     
            if (BDoorLeft.Left < 230)
            {
                BDoorRight.Left = BDoorRight.Left - 5;
                BDoorLeft.Left = BDoorLeft.Left + 5;
            }
            else
            {
                BDoorClose.Stop();
                EUp.Start();
                EDown.Stop();
            }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            // IF statement that controls the movement of the PictureBox     
            if (TDoorLeft.Left > 170)
            {
                TDoorRight.Left = TDoorRight.Left + 5;
                TDoorLeft.Left = TDoorLeft.Left - 5;

            }
            else
            {
                TDoorOpen.Stop();
            }
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            // IF statement that controls the movement of the PictureBox     
            if (TDoorLeft.Left < 230)
            {
                TDoorRight.Left = TDoorRight.Left - 5;
                TDoorLeft.Left = TDoorLeft.Left + 5;
            }
            else
            {
                TDoorClose.Stop();
                EDown.Start();
                EUp.Stop();
            }
        }

       
    }
}



               