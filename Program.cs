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
            //yeni
            List<string> allOrder = new List<string>();
            List<string> contolOrder = new List<string>();
            var a = allOrder.All(contolOrder.Contains);
            //yeni
            bool lop = true; // While döngüsünün bitmesi için sonda bunun içine atama yapıyoruz
            int[] aaaallId = new int[100]; //100'ü variable ile değiştir her işlem sonrası x'i arttır
            List<string> allId = new List<string>();
            List<customers> allCust = new List<customers>();
            // List<Author> AuthorList = new List<Author>();
            // int[] arr_sample = intermediate_list.ToArray();
            while (lop == true)
            {
                Console.WriteLine();

                // En fazla sipariş verilen ürünü ekrana yazdır





                // BÜtün prgramı while'a sokup a değişkeni q olana kadar döndür



                // // İlk girişte dizi boş mu kontrol et sonra direkt atayış ya da kontrole geç
                // string[] customers = {"123", "uzay"};
                // Console.Write("Yani kayıt oluşturmak için Tc giriniz");
                // string name = Console.ReadLine();
                // //bool b = customers.Contains(name);
                // bool b = Array.Exists(customers, element => element == name);
                // if(b){
                //     Console.WriteLine("Kullanıcı mevcut.");
                // }
                // else{

                // }
                // Console.WriteLine("Hoşgeldin "+ name + " bebek");

                customers custData = new customers();
                Console.Write("Yani kayıt oluşturmak için Tc giriniz: ");
                string recentId = Console.ReadLine();

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

                if (allId.Contains(recentId))
                {
                    Console.WriteLine("Müşteri Bilgisi mevcut..");
                    findId();
                    Console.WriteLine("Çıkmak istiyorsanız false yazın: ");
                    lop = Convert.ToBoolean(Console.ReadLine());
                }
                else
                {
                    allId.Add(recentId);
                    custData.idNo = recentId;
                    Console.Write("İsim giriniz: ");
                    custData.firstName = Console.ReadLine();
                    Console.Write("Soyisim giriniz: ");
                    custData.secondName = Console.ReadLine();
                    Console.Write("Cinsiyet giriniz: ");
                    custData.gender = Console.ReadLine();

                    // yeni

                    static string MainMenu()
                    {
                        Console.WriteLine();
                        Console.WriteLine("Seçenekler:");
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

                    custData.orderType = MainMenu();
                    // yeni

                    //Listeye yeni objeyi atama
                    allCust.Add(new customers(custData.idNo, custData.firstName, custData.secondName, custData.gender, custData.orderType));

                    // Son girilen verileri konsola yazdırır
                    customers.customerData(custData);
                    Console.WriteLine();
                    Console.WriteLine("---Tüm Müşteri Bilgileri---");
                    int res = 1;
                    //Liste içerisindeki objeleri for ile yazdırma
                    foreach (var customerIndex in allCust.OrderBy(o=>o.idNo))
                    {
                        Console.WriteLine("Customer Data {4} => İd: {0} / Name: {1} / SecName: {2} / Gender: {3} / Order: {5}", customerIndex.idNo, customerIndex.firstName, customerIndex.secondName, customerIndex.gender, res, customerIndex.orderType);
                        res++;
                    }

                    Console.WriteLine("Kayıt alındı..");
                    Console.WriteLine("Çıkmak istiyorsanız false yazın: ");
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

        public customers()
        {
            //Boş create edip userdan bilgi almak için
        }

        public customers(string id, string name, string secname, string gender, string orderType)
        {
            //Listeye atarken kullandığım şablon
            this.idNo = id;
            this.firstName = name;
            this.secondName = secname;
            this.gender = gender;
            this.orderType = orderType;
        }

        public static object takeData(int recId)//Daha az karmaşık görüntü için yukarıdaki işlemleri buraya
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
            Console.WriteLine("Müşterinin siparişi: {0}", cust1.orderType);
        }
    }
}
