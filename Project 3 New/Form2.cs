using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Project_3_New
{
    public partial class Form2 : Form
    {
        BindingSource bindingSource1= new BindingSource();
        List<Students> students = new List<Students>();

        public Form2()
        {
            InitializeComponent();
            new Form1().ShowDialog(); //added for logging in
            String FilePath = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString() + @"\Students.csv";
            FileStream FileName = new FileStream(FilePath, FileMode.Open, FileAccess.ReadWrite);
            StreamReader Reader = new StreamReader(FileName);
            
            List<Students> BindingSourceList = new List<Students>();
            Students Astudent;
            string[] Values;

            while (!Reader.EndOfStream)//Reads the file 
            {
                Values = Reader.ReadLine().Split(',');
                if (Convert.ToInt16(Values[3]) < 400)
                {
                    Astudent = new Worker(Values[1], Values[0], Convert.ToInt16(Values[3]), Convert.ToInt16(Values[2]),Convert.ToDouble(Values[4]));
                    students.Add(Astudent);

                }
                else if (Convert.ToInt16(Values[3]) < 700)
                {
                    Astudent = new Athlete(Values[1], Values[0], Convert.ToInt16(Values[3]), Convert.ToInt16(Values[2]));
                    students.Add(Astudent);
                }
                else
                {
                    Astudent = new Scholarship(Values[1], Values[0], Convert.ToInt16(Values[3]), Convert.ToInt16(Values[2]));
                    students.Add(Astudent);
                }
                Astudent = new Students(Values[1], Values[0], Convert.ToInt16(Values[3]), Convert.ToInt16(Values[2]));
                BindingSourceList.Add(Astudent);
            }
            Reader.Close();
            FileName.Close();
            
            foreach (var i in BindingSourceList)//adds the list to the binding source for the table 
            {
                bindingSource1.Add(i);
            }

            dataGridView1.DataSource = bindingSource1;

        }

        private void NewResSubmit_Click(object sender, EventArgs e)//when you hit submit button to add new resident
        {
            try
            {
                List<Students> students = new List<Students>();
                List<Students> BindingSourceList = new List<Students>();
                Worker Bstudent;
                Students Astudent;
                if (checkedListBox1.GetItemChecked(0))//if you have scholarship student checked
                {
                    Astudent = new Scholarship(FirstNameTextbox.Text, LastNameTextBox.Text, Convert.ToInt16(RoomNumTextBox.Text), Convert.ToInt16(IDNumTextBox.Text));
                    Write(Astudent);
                    students.Add(Astudent);
                }
                if (checkedListBox1.GetItemChecked(1))// if you have Student Athlete checked
                {
                    Astudent = new Athlete(FirstNameTextbox.Text, LastNameTextBox.Text, Convert.ToInt16(RoomNumTextBox.Text), Convert.ToInt16(IDNumTextBox.Text));
                    Write(Astudent);
                    students.Add(Astudent);
                }
                if (checkedListBox1.GetItemChecked(2))// if you have Student Worker checked 
                {
                    Bstudent = new Worker(FirstNameTextbox.Text, LastNameTextBox.Text, Convert.ToInt16(RoomNumTextBox.Text), Convert.ToInt16(IDNumTextBox.Text), Convert.ToDouble(WorkingHoursTextBox.Text));
                    Write1(Bstudent);
                    students.Add(Bstudent);
                }
                Astudent = new Students(FirstNameTextbox.Text, LastNameTextBox.Text, Convert.ToInt16(RoomNumTextBox.Text), Convert.ToInt16(IDNumTextBox.Text));

                bindingSource1.Add(Astudent);// Adds to the binding source

                dataGridView1.DataSource = bindingSource1;
            }
            catch
            {
                MessageBox.Show("An error has occured please check your Entry boxes and try again.");
            }
        }
        private void Write(Students Astudent)//Writes new residents to file
        {
            
            String FilePath = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString() + @"\Students.csv";
            FileStream FileName = new FileStream(FilePath, FileMode.Append, FileAccess.Write);
            StreamWriter Writer = new StreamWriter(FileName);
            Writer.WriteLine(Astudent.LName + "," + Astudent.FName + "," + Astudent.IDNum.ToString() + "," + Astudent.RoomNum.ToString());
            Writer.Close();
            FileName.Close();
        }
        private void Write1(Worker Astudent)//if resident is a worker with their total number of hours added use this to write to file 
        {

            String FilePath = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString() + @"\Students.csv";
            FileStream FileName = new FileStream(FilePath, FileMode.Append, FileAccess.Write);
            StreamWriter Writer = new StreamWriter(FileName);
            Writer.WriteLine(Astudent.LName + "," + Astudent.FName + "," + Astudent.IDNum.ToString() + "," + Astudent.RoomNum.ToString()+ "," + Astudent.HoursWorked.ToString());
            Writer.Close();
            FileName.Close();
        }

        private void SearchSubmitButton_Click(object sender, EventArgs e)//This runs when you hit the search submit button 
        {
            try
            {


                foreach (var i in students)
                {
                    if (Convert.ToInt16(StudentSearchTextBox.Text) == i.IDNum)
                    {
                        bindingSource1 = new BindingSource();
                        bindingSource1.Add(i);
                        dataGridView1.DataSource = bindingSource1;
                    }


                }
            }
            catch
            {
                MessageBox.Show("An error has occured");
                StudentSearchTextBox.Clear();
            }

        }
    }
}
