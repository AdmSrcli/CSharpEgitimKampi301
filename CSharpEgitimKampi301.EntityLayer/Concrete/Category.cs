using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.EntityLayer.Concrete
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }
        public List<Product>Products { get; set; }

    }
}
/*
 Field-variable-propert

int x; -----> Field

public int CategoryId { get; set; } -----> Property

vod hesapla()
{
  int x;        --------> Metot İçerisinde Variable 
}
 
 */