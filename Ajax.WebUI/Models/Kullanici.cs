using Ajax.WebUI.Models;

namespace Ajax.WebUI.Models
{
    public class Kullanici
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public static class KullaniciIslem
        {
            private static  List<Kullanici> kullanicilar = GetKullanicilar();

            public static Kullanici GetKullanici(int id)
            {
                return kullanicilar.FirstOrDefault(x => x.Id == id);
            }
            public static void Insert(Kullanici entity)
            {
                 kullanicilar.Add(entity);
            }

            public static List<Kullanici> GetKullanicilar()
            {
                List<Kullanici> list = new List<Kullanici>();

                for (int i = 0; i < 20; i++)
                {
                    Kullanici kullanici = new Kullanici();
                    kullanici.Name = FakeData.NameData.GetFullName();
                    kullanici.Id = i + 1;
                    list.Add(kullanici);
                }

                return list;
            }

        }



      

    }

}
