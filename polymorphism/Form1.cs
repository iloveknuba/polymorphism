using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace polymorphism
{
    // working with override methods
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(textBox1.Text);
            NasPunkt[] a = new NasPunkt[n * 3];
            for (int i = 0; i < 3 * n; i = i + 3)
            {
                a[i] = new NasPunkt();
                a[i + 1] = new Village();
                a[i + 2] = new City();
            }
            dataGridView1.Rows.Clear();
            foreach (NasPunkt el in a)
                el.Show(dataGridView1);

        }
        class NasPunkt
        {
            public string naz;
            public double pl;
            public NasPunkt()
            {
                Random ran = new Random();
                int r = ran.Next(1, 2);
                switch (r)
                {
                    case 1: { naz = "Village";  break; }
                    case 2: { naz = "City";  break; }
                }


            }
            public NasPunkt(string n)
            {
                naz = n;
            }
            public virtual void Show(DataGridView dg)
            {
                dg.Rows.Add("Name", naz);
                dg.Rows.Add("Square", pl.ToString());
            }
            public virtual double S()
            {
                return 0;
            }

        }


        class Village : NasPunkt
        {
            private int AmountOfHouses;
            private int AmountOfPeopleInHouses;
            public Village()
            {
                Random ran = new Random();
                AmountOfHouses = ran.Next(10, 120);
                AmountOfPeopleInHouses = ran.Next(1, 5);
                pl = ran.Next(5, 10);
                naz = "Village";
            }
            public override double S()
            {
                double sch;
                sch = AmountOfHouses * AmountOfPeopleInHouses / pl;
                return sch;
            }
            public override void Show(DataGridView dg)
            {

                base.Show(dg);
                dg.Rows.Add("Amount of houses ", AmountOfHouses);
                dg.Rows.Add("Amount of people in houses", AmountOfPeopleInHouses);
                dg.Rows.Add("population density", S());
            }
        }

        class City : NasPunkt
        {
            private int AmountOfPeople;
            Random ran = new Random();
            public City()
            {
                AmountOfPeople = ran.Next(100000, 300000);
                pl = ran.Next(30, 60);
                naz = "City";
            }
            public override double S()
            {
                double s;
                s = AmountOfPeople / pl;
                return s;
            }
            public override void Show(DataGridView dg)
            {

                base.Show(dg);
                dg.Rows.Add("Amount of people", AmountOfPeople.ToString());
                dg.Rows.Add("population density", S());
            }

        }
    }
}
