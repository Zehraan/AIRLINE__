using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Airline_
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
            
        }
        SqlConnection conn =new SqlConnection("Data Source=DESKTOP-QIFF4L4;Initial Catalog=airline_database_proje;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adapter;
        void filopanelkapa()
        {
            if (ucakfilosupanel2.Visible)
                ucakfilosupanel2.Visible = false;
            
        }

        void sirketpanelkapa()
        {
            if(havayolusirketpanel2.Visible)
                havayolusirketpanel2.Visible = false;
        }
        void ucuspanelkapa()
        {
            if(Ucuspanel.Visible)
                Ucuspanel.Visible = false;
            
        }
        void Ichatgriddoldur()
        {
            adapter = new SqlDataAdapter("SELECT * FROM ucuslar where ucuslar.varis_yeri IN (SELECT (sehirler.sehir_id) FROM sehirler WHERE ulke_adi='Türkiye')", conn);
            DataSet ds = new DataSet();
            conn.Open();
            adapter.Fill(ds, "ucuslar");
            Içhatgrid.DataSource = ds.Tables["ucuslar"];
            conn.Close();
            //kaynak: https://www.youtube.com/watch?v=il2nCpZLqWw
        }

        void Dıshatgriddoldur()
        {
            adapter = new SqlDataAdapter("SELECT * FROM ucuslar where ucuslar.varis_yeri NOT IN (SELECT DISTINCT (sehirler.sehir_id) FROM sehirler WHERE ulke_adi='Türkiye')", conn);
            DataSet ds = new DataSet();
            conn.Open();
            adapter.Fill(ds, "ucuslar");
            Dıshatgrid.DataSource = ds.Tables["ucuslar"];
            conn.Close();

        }

        private void Menubtn_Click(object sender, EventArgs e)
        {
            if (Menupanel.Visible)
                Menupanel.Visible = false;

            else
                Menupanel.Visible = true;
            Menupanel.Enabled = true;
        }

        private void Ucuslarbtn_Click(object sender, EventArgs e)
        {
            filopanelkapa();
            sirketpanelkapa();

            Ucuspanel.Visible = true;
            Ucuspanel.Enabled = true;
            Ichatgriddoldur();
            Dıshatgriddoldur();
        }

        private void Anasayfabtn_Click_1(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }
        void UcakFilogriddoldur()
        {
            adapter = new SqlDataAdapter("SELECT * FROM ucakturu INNER JOIN adet ON ucakturu.ucaktur_id=adet.ucaktur_id", conn);
            DataSet ds = new DataSet();
            conn.Open();
            adapter.Fill(ds, "ucakturu");
            ucakfilosugrid2.DataSource = ds.Tables["ucakturu"];
            conn.Close();
        }
        private void Filobtn_Click(object sender, EventArgs e)
        {
            ucuspanelkapa();
            sirketpanelkapa();

            UcakFilogriddoldur();
            ucakfilosupanel2.Visible = true;
            ucakfilosupanel2.Enabled = true;
            
        }
        void HavayoluSirketgriddoldur()
        {
            adapter = new SqlDataAdapter("SELECT havayolu_id,havayolu_ad FROM havayolusirketler", conn);
            DataSet ds = new DataSet();
            conn.Open();
            adapter.Fill(ds, "havayolusirketler");
            havayolusirketgrid2.DataSource = ds.Tables["havayolusirketler"];
            conn.Close();
        }

        

        private void Yoneticibtn_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            this.Hide();
        }

        private void Sirketbuton_Click(object sender, EventArgs e)
        {
            filopanelkapa();
            ucuspanelkapa();
            HavayoluSirketgriddoldur();
            havayolusirketpanel2.Enabled=true;
            havayolusirketpanel2.Visible=true;
        }
        void Linkekle(string link)
        {
            System.Diagnostics.Process.Start(link);
        }

        private void Instagrambtn_Click(object sender, EventArgs e)
        {
            Linkekle("https://www.instagram.com/istanbulsabihagokcen/");
        }

        private void Twitterbtn_Click(object sender, EventArgs e)
        {
            Linkekle("https://twitter.com/SabihaGokcen");
        }

        private void facebookbtn_Click(object sender, EventArgs e)
        {
            Linkekle("https://www.facebook.com/SabihaGokcenAirport");
        }

        void gridkayıtizin(DataGridView grid)
        {
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
        }
        void gridOzellik(DataGridView grid)
        {
            grid.DefaultCellStyle.Font=new Font("Times New Roman",9,FontStyle.Bold);
            grid.DefaultCellStyle.BackColor = Color.SteelBlue;
            grid.DefaultCellStyle.SelectionBackColor = Color.White;
            grid.DefaultCellStyle.SelectionForeColor = Color.DimGray;
            
            
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            gridOzellik(Içhatgrid);
            gridOzellik(Dıshatgrid);
            gridOzellik(ucakfilosugrid2);
            gridOzellik(havayolusirketgrid2);
            gridkayıtizin(Içhatgrid);
            gridkayıtizin(Dıshatgrid);
            gridkayıtizin(ucakfilosugrid2);
            gridkayıtizin(havayolusirketgrid2);
            
        }
        
    }
}
