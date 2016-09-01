using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace BODYMASSINDEX
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            string strprovider = " Data Source = Localhost ;Database= test1; User ID=root; Password= mysql ;";

            MySqlConnection mysqlCon = new MySqlConnection(strprovider);
               mysqlCon.Open();
            

            double weight;
            double height;
            double bmi;
            string str;
            weight = double.Parse(textBox1.Text);
            height = double.Parse(textBox2.Text);
            
      
            
            if (weight <  0 || height <  0)
            {
                MessageBox.Show("invalid values");

            }
            else
            {
                
                bmi = weight * 10000 / (height * height);

                MySqlCommand command = mysqlCon.CreateCommand();
                
                command.CommandText = "select weight,height,status from bmi where rollno  ="+comboBox1.Text+" ";
                

               
                
                    command.CommandText = "Update bmi set weight=" + textBox1.Text + ",height=" + textBox2.Text + ",status= " + textBox3.Text + "  ";
               
                
                    command.CommandText = " insert into bmi (weight,height,bmi,rollno,status) values (" + textBox1.Text + "," + textBox2.Text + "," + bmi.ToString("#.00") + "," + comboBox1.Text + ",\" "+ textBox3.Text+"\");";



                Console.WriteLine(command.CommandText);

               MySqlDataReader result = command.ExecuteReader();


                if (bmi < 18.5)
                {
                    label4.Text = bmi.ToString("#.00");
                    label4.ForeColor = System.Drawing.Color.Brown;
                    label3.Text = "underweight";
                    label3.ForeColor = System.Drawing.Color.Brown;
                }
                else if (bmi > 18.5 && bmi < 24.9)
                {
                    label4.Text = bmi.ToString("#.00");
                    label4.ForeColor = System.Drawing.Color.Green;
                    label3.Text = "normal";

                    label3.ForeColor = System.Drawing.Color.Green;
                }
                else if (bmi > 25 && bmi < 29.9)
                {
                    label4.Text = bmi.ToString("#.00");
                    label4.ForeColor = System.Drawing.Color.Red;
                    label3.Text = "overweight";

                    label3.ForeColor = System.Drawing.Color.Red;

                }


                else
                {
                    label4.Text = bmi.ToString("#.00");

                    label4.ForeColor = System.Drawing.Color.Brown;
                    label3.Text = "obese";

                    label3.ForeColor = System.Drawing.Color.Brown;
                }



            }
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
