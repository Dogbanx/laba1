
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace laba1
{
    
    public partial class Form1 : Form
    {
        TelevisionCollection tvCollection = new TelevisionCollection();


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
            string fileName = "INFO.TXT";
            if (textBox1.Text == "" || textBox2.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("¬вед≥ть дан≥!");
            }
            else
            {
                tvCollection.Televisions.Add(new Television { Brand = textBox1.Text, Price = double.Parse(textBox2.Text), Manufacturer = textBox3.Text });
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    foreach (Television tv in tvCollection.Televisions)
                    {
                        writer.WriteLine($"{tv.Brand}, {tv.Price:C}, {tv.Manufacturer}");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TelevisionCollection tvCollection = new TelevisionCollection();
            Television mostExpensiveTv = null;

           double maxPrice = 0;


            foreach (Television tv in tvCollection.Televisions)
            {
                if (tv.Price > maxPrice)
                {
                    maxPrice = tv.Price;
                    mostExpensiveTv = tv;
                }
            }
        }
    }
}