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
    public partial class FrmLocation : Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }
        EgitimKampiEFTravelDbEntities db=new EgitimKampiEFTravelDbEntities();

        #region LİSTELEME BUTONU
        private void btnListele_Click(object sender, EventArgs e)
        {
            try
            {
                var values = db.Location.ToList();
                dataGridView1.DataSource = values;
            }
            catch 
            {
                MessageBox.Show("HATALI VERİ GİRİŞİ MEVCUT LÜTFEN KONTROL EDİNİZ!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region FORM LOAD
        private void FrmLocation_Load(object sender, EventArgs e)
        {
            try
            {
                var values = db.Guid.Select(x => new
                {
                    fullname = x.GuidName + " " + x.GuidSurname,
                    x.GuidId,
                }).ToList();
                cmbrehber.DisplayMember = "fullname";
                cmbrehber.ValueMember = "GuidId";
                cmbrehber.DataSource = values;
            }
            catch
            {
                MessageBox.Show("HATALI VERİ GİRİŞİ MEVCUT LÜTFEN KONTROL EDİNİZ!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region EKLEME BUTONU
        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                Location location = new Location();

                location.City = txtsehir.Text;
                location.Country = txtulke.Text;
                location.Capacity = byte.Parse(nudCapasity.Value.ToString());
                location.Price = int.Parse(txtfiyat.Text);
                location.DayNight = txtgecegunduz.Text;
                location.GuidId = int.Parse(cmbrehber.SelectedValue.ToString());
                db.Location.Add(location);
                db.SaveChanges();
                MessageBox.Show("Kayıt gerçekleştirildi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("HATALI VERİ GİRİŞİ MEVCUT LÜTFEN KONTROL EDİNİZ!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        #endregion

        #region SİL BUTONU
        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtlocationId.Text);
                var deletdvalue = db.Location.Find(id);
                db.Location.Remove(deletdvalue);
                db.SaveChanges();
                MessageBox.Show("Silme işlemi gerçekleştirildi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("HATALI VERİ GİRİŞİ MEVCUT LÜTFEN KONTROL EDİNİZ!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region GÜNCELLE BUTONU

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtlocationId.Text);
                var find = db.Location.Find(id);
                find.DayNight = txtgecegunduz.Text;
                find.Capacity = byte.Parse(nudCapasity.Value.ToString());
                find.Country = txtulke.Text;
                find.Price = int.Parse(txtfiyat.Text);
                find.GuidId = int.Parse(cmbrehber.SelectedValue.ToString());
                find.City = txtsehir.Text;
                db.SaveChanges();
                MessageBox.Show("Güncelleme  işlemi gerçekleştirildi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("HATALI VERİ GİRİŞİ MEVCUT LÜTFEN KONTROL EDİNİZ!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



        }
        #endregion

        #region ID YE GÖRE GETİR BUTONU

        private void btnidGetir_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtlocationId.Text);
                var deger = from x in db.Location
                            where x.LocationId == id
                            select x;
                dataGridView1.DataSource = deger.ToList();
            }
            catch
            {
                MessageBox.Show("HATALI VERİ GİRİŞİ MEVCUT LÜTFEN KONTROL EDİNİZ!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }             
                          
                
        #endregion
    }
}
