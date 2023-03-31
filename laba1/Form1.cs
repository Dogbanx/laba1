
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
       


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TelevisionCollection tvCollection = new TelevisionCollection();
            string fileName = "INFO.TXT";
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    Television tv = new Television
                    {
                        Brand = parts[0].Trim(),
                        Price = decimal.Parse(parts[1].Trim().Replace("₴", "")),
                        Manufacturer = parts[3].Trim()

                    };
                    tvCollection.Televisions.Add(tv);
                }
            }
            if (textBox1.Text == "" || textBox2.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Введіть дані!");
            }
            else
            {
                tvCollection.Televisions.Add(new Television { Brand = textBox1.Text, Price = decimal.Parse(textBox2.Text), Manufacturer = textBox3.Text });
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
            string fileName = "INFO.TXT";
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    Television tv = new Television
                    {
                        Brand = parts[0].Trim(),
                        Price = decimal.Parse(parts[1].Trim().Replace("₴", "")),
                        Manufacturer = parts[3].Trim()

                    };
                    tvCollection.Televisions.Add(tv);
                }
            }
            Television mostExpensiveTv = null;

            decimal maxPrice = 0;


            foreach (Television tv in tvCollection.Televisions)
            {
                if (tv.Price > maxPrice)
                {
                    maxPrice = tv.Price;
                    mostExpensiveTv = tv;
                }

            }
            label7.Text = mostExpensiveTv.Brand;
            label8.Text = mostExpensiveTv.Price.ToString()+ " ₴";
            label9.Text = mostExpensiveTv.Manufacturer;
        }
    }
}