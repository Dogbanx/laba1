using laba1.Models;

namespace laba1
{
    public partial class Form1 : Form
    {
        private List<TelevisionVm> _televisions;
        void TelevisionCollection()
        {
            _televisions = new List<TelevisionVm>();
        }

        public Form1()
        {
            _televisions = new List<TelevisionVm>();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fileName = "INFO.TXT";
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    TelevisionVm tv = new TelevisionVm
                    {
                        Brand = parts[0].Trim(),
                        Price = decimal.Parse(parts[1].Trim().Replace("₴", "")),
                        Manufacturer = parts[3].Trim()

                    };
                    _televisions.Add(tv);
                }
            }
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Введіть дані!");
            }
            else
            {
                _televisions.Add(new TelevisionVm { Brand = textBox1.Text, Price = decimal.Parse(textBox2.Text), Manufacturer = textBox3.Text });
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    foreach (TelevisionVm tv in _televisions)
                    {
                        writer.WriteLine($"{tv.Brand}, {tv.Price:C}, {tv.Manufacturer}");
                    }
                }
            }
            textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string fileName = "INFO.TXT";
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    TelevisionVm tv = new TelevisionVm
                    {
                        Brand = parts[0].Trim(),
                        Price = decimal.Parse(parts[1].Trim().Replace("₴", "")),
                        Manufacturer = parts[3].Trim()

                    };
                    _televisions.Add(tv);
                }
            }
            TelevisionVm mostExpensiveTv = null;

            decimal maxPrice = 0;

            foreach(TelevisionVm tv in _televisions)
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
