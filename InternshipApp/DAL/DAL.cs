using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class DAL
    {
        public List<UrunKategoriEntity> GetUrunList()
        {
            List<UrunKategoriEntity> list = new List<UrunKategoriEntity>();
         

                using (SDB sdbContext = new SDB())
                {

                    var query_product_list = from u in sdbContext.Uruns
                                             join k in sdbContext.Kategoris on u.UrunKatID equals k.KategoriID
                                             select new UrunKategoriEntity()
                                             {
                                                 UrunAd = u.UrunAd,
                                                 UrunFiyat = u.UrunFiyat,
                                                 UrunKod = u.UrunKod,
                                                 UrunStok = u.UrunStok,
                                                 UrunID = u.UrunID,
                                                 UrunKatID = k.KategoriID,
                                                 KategoriAdi = k.KategoriAdi,
                                                 UrunPic = u.UrunPic,


                                             };
                    list = (query_product_list).ToList();
                }

          
           
            return list;
        }

        public void NewRecord(Urun u)
        {
           
                using (SDB sdb = new SDB())
                {
                    sdb.Uruns.Add(u);
                    sdb.SaveChanges();
                }

        }

        public void UpdateRecord(Urun u)
        {
           
                using (SDB sdb = new SDB())
                {
                    sdb.Entry(u).State = System.Data.Entity.EntityState.Modified;
                    sdb.SaveChanges();

                }
               
        }

        public void DeleteRecord(Urun u)
        {
          
                using (SDB sdb = new SDB())
                {
                    sdb.Entry(u).State = System.Data.Entity.EntityState.Deleted;
                    sdb.SaveChanges();

                }
           
        }

        //Personellerin Listelendiği Method//
        public List<PersonelEntity> GetPersoneList()
        {
            List<PersonelEntity> list = new List<PersonelEntity>();
           

                using (SDB sdb = new SDB())
                {

                    var query_personel_list = from p in sdb.Personels
                                              join r in sdb.Roles on p.PersonelRoleID equals r.RoleID
                                              select new PersonelEntity()
                                              {
                                                  PersonelAd = p.PersonelAd,
                                                  PersonelSoyad = p.PersonelSoyad,
                                                  PersonelPic = p.PersonelPic,
                                                  PersonelRoleID = r.RoleID,
                                                  PersonelRol = r.Role1,
                                                  PersonelID = p.PersonelID,
                                                  PersonelUsername = p.PersonelUsername,
                                                  PersonelPassword = p.PersonelPassword
                                              };
                    list = (query_personel_list).ToList();

                }
         

            return list;
        }

        public void NewRecordPer(Personel p)
        {
          
                using (SDB sdb = new SDB())
                {
                    sdb.Personels.Add(p);
                    sdb.SaveChanges();

                }
                  
        }

        public void UpdateRecordPer(Personel p)
        {
           
                using (SDB sdb = new SDB())
                {
                    sdb.Entry(p).State = System.Data.Entity.EntityState.Modified;
                    sdb.SaveChanges();

                }
                   
        }

        public void DeleteRecordPer(Personel p)
        {
          
                using (SDB sdb = new SDB())
                {
                    sdb.Entry(p).State = System.Data.Entity.EntityState.Deleted;
                    sdb.SaveChanges();

                }
                     
        }

        //Müşterilerin Listelendiği Method//
        public List<Musteri> GetMusteriList()
        {
            List<Musteri> list = new List<Musteri>();
            
                using (SDB sdbContext = new SDB())
                {
                    var query_musteri_list = from m in sdbContext.Musteris
                                             select m;

                    list = (query_musteri_list).ToList();
                }
                  
            return list;
        }

        public void NewRecordMus(Musteri m)
        {
          
                using (SDB sdb = new SDB())
                {
                    sdb.Musteris.Add(m);
                    sdb.SaveChanges();
                }
                    
        }

        public void UpdateRecordMus(Musteri m)
        {
        
                using (SDB sdb = new SDB())
                {
                    sdb.Entry(m).State = System.Data.Entity.EntityState.Modified;
                    sdb.SaveChanges();
                }       
        }

        public void DeleteRecordMus(Musteri m)
        {           
                using (SDB sdb = new SDB())
                {
                    sdb.Entry(m).State = System.Data.Entity.EntityState.Deleted;
                    sdb.SaveChanges();

                }        
        }

        //Siparişi database Kaydetme//
        public List<SatisEntity> SatisRaporList()
        {
            List<SatisEntity> raporlist = new List<SatisEntity>();          
                using (SDB sdb = new SDB())
                {

                    var query_rapor_list = from s in sdb.Satis
                                           join p in sdb.Personels on s.SatisPerID equals p.PersonelID
                                           join m in sdb.Musteris on s.SatisMusID equals m.MusteriID
                                           join u in sdb.Uruns on s.SatisUrunID equals u.UrunID
                                           select new SatisEntity()
                                           {
                                               SatisID = s.SatisID,
                                               SatisAdet = s.SatisAdet,
                                               SatisUrunID = u.UrunID,
                                               SatisUrunAdi = u.UrunAd,
                                               SatisFiyat = s.SatisFiyat,
                                               SatisMusID = m.MusteriID,
                                               SatisMusteriAdi = m.MusteriAdi + "  " + m.MusteriSoyadi,
                                               SatisPerID = p.PersonelID,
                                               SatisPersonelAdi = p.PersonelAd + "  " + p.PersonelSoyad,
                                               SatisTarih = s.SatisTarih,
                                           };
                    raporlist = query_rapor_list.ToList();
                }
                   
            return raporlist;
        }

        public void SatisRapor(Sati s)
        {
            
                using (SDB sdb = new SDB())
                {
                    sdb.Satis.Add(s);
                    sdb.SaveChanges();
                }              
        }
    }
}

