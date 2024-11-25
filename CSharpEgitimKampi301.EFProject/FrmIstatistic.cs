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
    public partial class FrmIstatistic : Form
    {
        public FrmIstatistic()
        {
            InitializeComponent();
        }
        EgitimKampiEFTravelDbEntities db = new EgitimKampiEFTravelDbEntities();
        private void FrmIstatistic_Load(object sender, EventArgs e)
        {
            lbllocationcount.Text=db.Location.Count().ToString();
            lbltoplamkapasite.Text=db.Location.Sum(x=>x.Capacity).ToString();
            lblguidcount.Text=db.Guid.Count().ToString();
            var avgcapasiity = db.Location.Average(x => x.Capacity).ToString();
            lblavgcapasity.Text=Math.Round(decimal.Parse(avgcapasiity )).ToString("0")+"  Kişi";
            var ortturfiyat=db.Location.Average(x=>x.Price).ToString();
            lblortalamturfiyati.Text=Math.Round(decimal.Parse( ortturfiyat)).ToString("0.00")+"₺";

            int maxlocation=db.Location.Max(x=>x.LocationId);
            lbleklenensonulke.Text=db.Location.Where(y=>y.LocationId==maxlocation).Select(w=>w.Country).FirstOrDefault();

            lblkapadokialockapasity.Text=db.Location.Where(x=>x.City== "Kapadokya").Select(y=>y.Capacity).FirstOrDefault().ToString();
            lblturkiyeortkap.Text = db.Location.Where(x => x.Country == "Türkiye").Average(y => y.Capacity).ToString();

            var guidid=db.Location.Where(x=>x.City== "Roma ").Select(y=>y.GuidId).FirstOrDefault();
            lblromagezirehberi.Text=db.Guid.Where(z=>z.GuidId==guidid).Select(w=>w.GuidName+" "+w.GuidSurname).FirstOrDefault().ToString();

            var maxcapacity = db.Location.Max(x => x.Capacity);
            lblmaxkapacity.Text=db.Location.Where(z=>z.Capacity==maxcapacity).Select(w=>w.City).FirstOrDefault().ToString();

            var pahalitur=db.Location.Max(x=>x.Price);
            lblpahalitur.Text = db.Location.Where(z => z.Price == pahalitur).Select(w => w.City).FirstOrDefault().ToString();

            var ayseid = db.Guid.Where(x => x.GuidName == "Ayşegül" && x.GuidSurname == "Çınar").Select(z => z.GuidId).FirstOrDefault();
            lblaysegul.Text=db.Location.Where(w=>w.GuidId==ayseid).Count().ToString();


        }
    }
}
