using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace uzayc
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> brandArr = new List<string>();

            bool lop = true; // While döngüsünün bitmesi veya devamı için sonda bunun içine atama yapıyoruz
            List<string> allId = new List<string>(); // ID'lerin tutulduğu liste
            List<customers> allCust = new List<customers>(); // Müşteri objelerinin tutulduğu liste
            while (lop == true)
            {
                Console.WriteLine();
                // En fazla sipariş verilen ürünü ekrana yazdır
                customers custData = new customers();
                Console.Write("Yani kayıt oluşturmak için Tc giriniz: ");
                string recentId = Console.ReadLine();

                // ID girişinin int olup olmadığını kontrol ederek sadece sayılardan oluşan input alınıyor.
                bool inputControl = !Int32.TryParse(recentId, out int number);
                while (inputControl)
                {
                    Console.Write("Lütfen Geçerli bir TC giriniz: ");
                    recentId = Console.ReadLine();
                    inputControl = !Int32.TryParse(recentId, out number);
                }

                // Yeni girilen ID'nin objesini liste içerisinde bularak ismini konsola yazdırıyor.
                void findId()
                {
                    foreach (var customerIndex in allCust)
                    {
                        if (customerIndex.idNo == recentId)
                        {
                            Console.WriteLine("Existing Customer => Name: {0}", customerIndex.firstName);
                        }
                    }
                }

                // Yeni girilen ID liste içerisinde mevcutsa burası çalışıyor.
                if (allId.Contains(recentId))
                {
                    Console.WriteLine("Müşteri Bilgisi mevcut..");
                    findId(); // X. Satır Metot
                    Console.WriteLine("Çıkmak istiyorsanız false, devam etmek için true yazın: ");
                    lop = Convert.ToBoolean(Console.ReadLine());
                }
                else
                {
                    // Yeni müşteri bilgilerinin obje proplarına atanması.
                    allId.Add(recentId);
                    custData.idNo = recentId;
                    Console.Write("İsim giriniz: ");
                    custData.firstName = Console.ReadLine().ToUpper();
                    Console.Write("Soyisim giriniz: ");
                    custData.secondName = Console.ReadLine().ToUpper();
                    Console.Write("Cinsiyet giriniz: ");
                    custData.gender = Console.ReadLine().ToUpper();

                    //Siparişin Seçilmesi. X. satırdaki customers metotu(Mainmenu).
                    custData.orderType = customers.MainMenu();
                    custData.orderService = customers.altMenu();
                    //Markaları topladığım dizi
                    brandArr.Add(custData.orderType);


                    //Listeye yeni objeyi atama
                    allCust.Add(new customers(custData.idNo, custData.firstName, custData.secondName, custData.gender, custData.orderType, custData.orderService));

                    // Son girilen verileri konsola yazdırır
                    customers.customerData(custData);
                    Console.WriteLine();
                    Console.WriteLine("---Tüm Müşteri Bilgileri---");
                    int res = 1; // Toplam müşteri sayısını görebilmek için
                    //Liste içerisindeki objeleri for ile yazdırma
                    foreach (var customerIndex in allCust.OrderBy(o => Convert.ToInt64(o.idNo)))
                    {
                        Console.WriteLine("Customer Data {4} => İd: {0} / Name: {1} / SecName: {2} / Gender: {3} / Order: {5} / Service: {6}", customerIndex.idNo, customerIndex.firstName, customerIndex.secondName, customerIndex.gender, res, customerIndex.orderType, customerIndex.orderService);
                        res++;
                    }

                    Console.WriteLine("Kayıt alındı..");
                    //En çok tercih edilen markayı bulan x. satırdaki method
                    customers.brandCounter(brandArr);
                    Console.WriteLine("Çıkmak istiyorsanız false, devam etmek için true yazın: ");
                    lop = Convert.ToBoolean(Console.ReadLine());
                }
            }
        }
    }

    class customers
    {
        public string idNo;
        public string firstName;
        public string secondName;
        public string gender;
        public string orderType;
        public string orderService;

        public customers()
        {
            //Boş create edip userdan bilgi almak için
        }

        public customers(string id, string name, string secname, string gender, string orderType, string orderService)
        {
            //Listeye atarken kullandığımız const.
            this.idNo = id;
            this.firstName = name;
            this.secondName = secname;
            this.gender = gender;
            this.orderType = orderType;
            this.orderService = orderService;
        }

        public static object takeData(int recId)//Bilgi alımı için
        {
            customers custData = new customers();
            custData.idNo = Convert.ToString(recId);
            Console.Write("İsim giriniz: ");
            custData.firstName = Console.ReadLine();
            Console.Write("Soyisim giriniz: ");
            custData.secondName = Console.ReadLine();
            Console.Write("Cinsiyet giriniz: ");
            custData.gender = Console.ReadLine();
            return custData.idNo;
        }

        public static void customerData(customers cust1)
        {
            Console.WriteLine();
            Console.WriteLine("---Son Müşteri Bilgileri---");
            Console.WriteLine("Müşterinin tc'si: {0}", cust1.idNo);
            Console.WriteLine("Müşterinin adı: {0}", cust1.firstName);
            Console.WriteLine("Müşterinin soyismi: {0}", cust1.secondName);
            Console.WriteLine("Müşterinin cinsiyeti: {0}", cust1.gender);
            Console.WriteLine("Müşterinin seçtiği marka: {0}", cust1.orderType);
            Console.WriteLine("Müşterinin seçtiği hizmet: {0}", cust1.orderService);
        }
        public static string MainMenu()
        {   // Marka seçilen sepet
            Console.WriteLine();
            Console.WriteLine("Markalar:");
            Console.WriteLine("1.) Microsoft");
            Console.WriteLine("2.) IBM");
            Console.WriteLine("3.) Google");
            Console.Write("\r\nSayı ile marka seçiniz: ");

            switch (Console.ReadLine())
            {
                case "1":
                    return "Microsoft";
                case "2":
                    return "IBM";
                case "3":
                    return "Google";
                default:
                    return "Boş";
            }
        }
        public static string altMenu()
        {   // Hizmet Seçilen Sepet
            Console.WriteLine();
            Console.WriteLine("Hizmetler:");
            Console.WriteLine("1.) Virtual Machine");
            Console.WriteLine("2.) DevOps");
            Console.WriteLine("3.) Database Solution");
            Console.Write("\r\nSayı ile hizmet seçiniz: ");

            switch (Console.ReadLine())
            {
                case "1":
                    return "Virtual Machine";
                case "2":
                    return "DevOps";
                case "3":
                    return "Database Solution";
                default:
                    return "Boş";
            }
        }
        public static void brandCounter(List<string> brandArr)
        {   // Başlangıç harflerine göre tekrar eden marka sayısı kaydediliyor
            int brand1 = brandArr.Where(s => s != null && s.StartsWith("M")).Count();
            int brand2 = brandArr.Where(s => s != null && s.StartsWith("I")).Count();
            int brand3 = brandArr.Where(s => s != null && s.StartsWith("G")).Count();
            // Sayı büyüklüklerinin kontrolü
            if (brand1 > brand2 && brand1 > brand3)
            {
                Console.WriteLine("En Çok Tercih Edilen Marka: Microsoft");
            }
            else if (brand2 > brand1 && brand2 > brand3)
            {
                Console.WriteLine("En Çok Tercih Edilen Marka: IBM");
            }
            else if (brand3 > brand2 && brand3 > brand1)
            {
                Console.WriteLine("En Çok Tercih Edilen Marka: Google");
            }
            else
            {
                Console.WriteLine("En Çok Tercih Edilen Marka: Eşitlik Söz konusu");
            }
        }
    }
}
