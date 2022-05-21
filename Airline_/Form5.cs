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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-QIFF4L4;Initial Catalog=airline_database_proje;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        SqlDataAdapter adapter;

        
        private void Şifretext_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Şifretext.PasswordChar = '\0';
            }
            else
            {
                Şifretext.PasswordChar = '*';
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Şifretext.PasswordChar = '\0';
            }
            else
            {
                Şifretext.PasswordChar = '*';
            }
        }

        private void Girisbtn_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM yonetici where tc_no='" + Kullanıcıtext.Text + "' AND yonetici_sifre='" + Şifretext.Text + "'";
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Yoneticipanel.Enabled = true;
                Yoneticipanel.Visible = true;
            }
            else
            {
                MessageBox.Show("Kullanıcı adı ya da şifre yanlış!!");
            }
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void Menubtn_Click(object sender, EventArgs e)
        {
            Cıkıspanel.Visible = true;
            Cıkıspanel.Enabled = true;
        }

        private void Cıkısbtn_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }
        void Yoneticipilotgriddoldur()
        {
            adapter = new SqlDataAdapter("SELECT * FROM pilotlar", conn);
            DataSet ds = new DataSet();
            conn.Open();
            adapter.Fill(ds, "pilotlar");
            Yoneticipilotgrid.DataSource = ds.Tables["pilotlar"];
            conn.Close();
        }
        void Yoneticifilogriddoldur()
        {
            adapter = new SqlDataAdapter("SELECT * FROM ucakturu INNER JOIN adet ON ucakturu.ucaktur_id=adet.ucaktur_id", conn);
            DataSet ds = new DataSet();
            conn.Open();
            adapter.Fill(ds, "ucakturu");
            Yoneticifilogrid.DataSource = ds.Tables["ucakturu"];
            conn.Close();

        }
        void Yoneticisirketgriddoldur()
        {
            adapter = new SqlDataAdapter("SELECT * FROM havayolusirketler", conn);
            DataSet ds = new DataSet();
            conn.Open();
            adapter.Fill(ds, "havayolusirketler");
            Yoneticisirketgrid.DataSource = ds.Tables["havayolusirketler"];
            conn.Close();
        }
        void Yoneticiucusgriddoldur()
        {
            adapter = new SqlDataAdapter("SELECT * FROM ucuslar", conn);
            DataSet ds = new DataSet();
            conn.Open();
            adapter.Fill(ds, "ucuslar");
            Yoneticiucusgrid.DataSource = ds.Tables["ucuslar"];
            conn.Close();
        }
        void gridtasarım(DataGridView grid)
        {
            
            grid.DefaultCellStyle.Font = new Font("Times New Roman", 9, FontStyle.Bold);
            grid.DefaultCellStyle.BackColor = Color.SteelBlue;
            grid.DefaultCellStyle.SelectionBackColor = Color.White;
            grid.DefaultCellStyle.SelectionForeColor = Color.DimGray;
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            gridtasarım(Yoneticifilogrid);
            gridtasarım(Yoneticipilotgrid);
            gridtasarım(Yoneticisirketgrid);
            gridtasarım(Yoneticiucusgrid);
            Yoneticiucusgriddoldur();
            Yoneticifilogriddoldur();
            Yoneticipilotgriddoldur();
            Yoneticisirketgriddoldur();

        }

        private void Ucuseklebtn_Click(object sender, EventArgs e)
        {

            string kayit = "INSERT INTO ucuslar(ucus_kodu,varis_yeri,kalkis_saati,varis_saati,ucus_durum,ucus_suresi,ucus_tipi,kapı_no,karusel,havayolu_id) VALUES  (@ucus_kodu,@varis_yeri,@kalkis_saati,@varis_saati,@ucus_durum,@ucus_suresi,@ucus_tipi,@kapı_no,@karusel,@havayolu_id)";
                cmd = new SqlCommand(kayit, conn);
               
                cmd.Parameters.AddWithValue("@ucus_kodu", ucuskoduext.Text);
                cmd.Parameters.AddWithValue("@varis_yeri", varisyeritext.Text);
                cmd.Parameters.AddWithValue("@kalkis_saati", kalkissaatitext.Text);
                cmd.Parameters.AddWithValue("@varis_saati", varissaatitext.Text);
                cmd.Parameters.AddWithValue("@ucus_durum", ucusdurumutext.Text);
                cmd.Parameters.AddWithValue("@ucus_suresi", ucusüresitext.Text);
                cmd.Parameters.AddWithValue("@ucus_tipi", ucustipitext.Text);
                cmd.Parameters.AddWithValue("@kapı_no", kapınotext.Text);
                cmd.Parameters.AddWithValue("@karusel", karuseltext.Text);
            cmd.Parameters.AddWithValue("@havayolu_id", havayoluidtext.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
                
                conn.Close();
                MessageBox.Show("Uçuş bilgileri kaydedildi.");
            panel1.Enabled = false;
            panel1.Visible = false;
            ucuskoduext.Clear();
            varisyeritext.Clear();
            kalkissaatitext.Clear();
            varissaatitext.Clear();
            ucusdurumutext.Clear();
            ucusüresitext.Clear();
            ucustipitext.Clear();
            kapınotext.Clear();
            karuseltext.Clear();
            havayoluidtext.Clear();
        }

        private void sirketeklebtn_Click(object sender, EventArgs e)
        {

                string kayit = "INSERT INTO havayolusirketler VALUES (@havayolu_id,@havayolu_ad,@vergi_no)";
                
                SqlCommand cmd = new SqlCommand(kayit, conn);
                
                cmd.Parameters.AddWithValue("@havayolu_id", sirketidtext.Text);
                cmd.Parameters.AddWithValue("@havayolu_ad", sirketadtext.Text);
                cmd.Parameters.AddWithValue("@vergi_no", sirketvergitext.Text);
            conn.Open();
            
            cmd.ExecuteNonQuery();
                
                conn.Close();
                MessageBox.Show("Havayolu şirketi kaydedildi.");
            sirketeklepanel.Visible = false;
            sirketidtext.Clear();
            sirketadtext.Clear();   
            sirketvergitext.Clear();
            
        }

        private void KAYITEKRANI_Click(object sender, EventArgs e)
        {
            if(sirketeklepanel.Visible)
                sirketeklepanel.Visible=false;
            else
            sirketeklepanel.Visible = true;
            sirketeklepanel.Enabled = true;
        }

        private void güncellebtn_Click(object sender, EventArgs e)
        {
            Yoneticisirketgriddoldur();
        }

        private void sirketsilbtn_Click(object sender, EventArgs e)
        {

            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "delete from havayolusirketler where havayolu_id=" + sirketidtext.Text + "";
            cmd.CommandText = "delete from havayolusirketler where havayolu_ad=" + sirketadtext.Text + "";
            cmd.CommandText = "delete from havayolusirketler where vergi_no=" + sirketvergitext.Text + "";
            cmd.ExecuteNonQuery();
            conn.Close();
            sirketeklepanel.Enabled=false;
            sirketeklepanel.Visible=false;
            sirketidtext.Clear();
            sirketadtext.Clear();
            sirketvergitext.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(panel1.Visible)
                panel1.Visible = false;
            else
                panel1.Visible = true;
            panel1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Yoneticiucusgriddoldur();
        }
        void UcusKayıtSil(string ucus_kodu)
        {
            string sil = "DELETE FROM ucuslar WHERE ucus_kodu=@ucus_kodu";
            cmd = new SqlCommand(sil, conn);
            cmd.Parameters.AddWithValue("@ucus_kodu", ucus_kodu);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void Ucusilbtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in Yoneticiucusgrid.SelectedRows)  
            {
                string ucus_kodu = Convert.ToString(drow.Cells[0].Value);
                UcusKayıtSil(ucus_kodu);
            }
            Yoneticiucusgriddoldur();

            // kaynak: https://www.yazilimkodlama.com/programlama/datagridview-de-secili-satirlari-veritabanindan-silme/ 


        }


    }
}
