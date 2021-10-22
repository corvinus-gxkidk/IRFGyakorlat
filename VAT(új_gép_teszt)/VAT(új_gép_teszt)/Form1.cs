using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VAT_új_gép_teszt_.Entities;

namespace VAT_új_gép_teszt_
{
    public partial class Form1 : Form
    {
        PortfolioEntities context = new PortfolioEntities();
        List<Tick> Ticks;
        List<PortfolioItems> Portfolio = new List<PortfolioItems>();
        public Form1()
        {
            InitializeComponent();
            Ticks = context.Ticks.ToList();
            dataGridView1.DataSource = Ticks;

            CreatePortfolio();
        }

        private void CreatePortfolio()
        {
            Portfolio.Add(new PortfolioItems() { Index = "OTP", Volume = 10 });
            Portfolio.Add(new PortfolioItems() { Index = "ZWACK", Volume = 10 });
            Portfolio.Add(new PortfolioItems() { Index = "ELMU", Volume = 10 });

            dataGridView2.DataSource = Portfolio;
        }
    }
}
