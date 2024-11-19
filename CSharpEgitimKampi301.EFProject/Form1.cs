using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        EgitimKampiEFTravelDbEntities db = new EgitimKampiEFTravelDbEntities();
        private void btnListele_Click(object sender, EventArgs e)
        {
           
            var values=(from x in db.Guid
                       select new
                       {
                           x.GuidId,
                           x.GuidName,
                           x.GuidSurname
                       }).ToList();
            dataGridView1.DataSource = values;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Guid guide = new Guid();
            guide.GuidName = txtName.Text;
            guide.GuidSurname= txtSurname.Text;
            db.Guid.Add( guide );
            db.SaveChanges();
            MessageBox.Show("Kayıt Başarılı Şekilde Eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var removeValue=db.Guid.Find(id);
            db.Guid.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Kayıt Başarılı Şekilde Silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id=int.Parse(txtId.Text);
            var bul=db.Guid.Find(id);
            bul.GuidName = txtName.Text;
            bul.GuidSurname= txtSurname.Text;
            db.SaveChanges();
            MessageBox.Show("Kayıt Başarılı Şekilde Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void btnidGetir_Click(object sender, EventArgs e)
        {
            int id= int.Parse(txtId.Text);
            var getir=db.Guid.Where(x=>x.GuidId==id).ToList();
            dataGridView1.DataSource = getir;
            
        }
    }
}
