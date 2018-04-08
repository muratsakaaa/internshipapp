using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CustomEntity
    {
    }

    public class SatisEntity : Sati
    {
        public string SatisMusteriAdi { get; set; }
        public string SatisPersonelAdi { get; set; }
        public string SatisUrunAdi { get; set; } 
    }

    public class UrunKategoriEntity : Urun
    {
        public string KategoriAdi { get; set; }
        public int KategoriId { get; set; }

    }

    public class PersonelEntity : Personel
    {
        public string PersonelRol { get; set; }
        public int PersonelRolId { get; set; }

    }

    public class SepetEntity : Urun
    {
        public int urunAdet { get; set; }
        public int urunToplamFiyat { get; set; }
    }

}
