using System;
using System.Collections.Generic;

namespace uzayc
{
    class Program
    {
        static void Main(string[] args)
        {
            bool lop = true; // While döngüsünün bitmesi için sonda bunun içine atama yapıyoruz
            int[] aaaallId = new int[100]; //100'ü variable ile değiştir her işlem sonrası x'i arttır
            List<int> allId = new List<int>();
            List<customers> allCust = new List<customers>();
            // List<Author> AuthorList = new List<Author>();
            // int[] arr_sample = intermediate_list.ToArray();
            while (lop == true)
            {
                Console.WriteLine();





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
                int recentId = Convert.ToInt32(Console.ReadLine());

                if (allId.Contains(recentId))
                {
                    Console.WriteLine("Müşter Bilgisi mevcut..");
                    Console.WriteLine("Çıkmak istiyorsanız false yazın: ");
                    lop = Convert.ToBoolean(Console.ReadLine());
                }
                else
                {
                    allId.Add(recentId);
                    custData.idNo = Convert.ToString(recentId);
                    Console.Write("İsim giriniz: ");
                    custData.firstName = Console.ReadLine();
                    Console.Write("Soyisim giriniz: ");
                    custData.secondName = Console.ReadLine();
                    Console.Write("Cinsiyet giriniz: ");
                    custData.gender = Console.ReadLine();

                    //Listeye yeni objeyi atama
                    allCust.Add(new customers(custData.idNo, custData.firstName, custData.secondName, custData.gender));

                    // allCust.Add(custData);
                    // object[] arr_sample = allCust.ToArray();
                    // int[] arr_sample = allId.ToArray();

                    //Liste içerisindeki objeleri for ile yazdırma
                    // Son girilen verileri konsola yazdırır
                    customers.customerData(custData);
                    // Console.WriteLine("Last Customer Data => İd: {0} / Name: {1} / SecName: {2} / Gender: {3}", custData.idNo, custData.firstName, custData.secondName, custData.gender);
                    Console.WriteLine();
                    int res = 1;
                    foreach (var customerIndex in allCust)
                    {
                        Console.WriteLine("Customer Data {4} => İd: {0} / Name: {1} / SecName: {2} / Gender: {3}", customerIndex.idNo, customerIndex.firstName, customerIndex.secondName, customerIndex.gender, res);
                        res++;
                    }

                    // Console.WriteLine(allId);
                    // custData.customerData();
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

        public customers()
        {
            //Boş create edip userdan bilgi almak için
        }

        public customers(string id, string name, string secname, string gender)
        {
            //Listeye atarken kullandığım şablon
            this.idNo = id;
            this.firstName = name;
            this.secondName = secname;
            this.gender = gender;
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
            Console.WriteLine("---Müşteri Bilgileri---");
            Console.WriteLine("Müşterinin tc'si:{0}", cust1.idNo);
            Console.WriteLine("Müşterinin adı {0}", cust1.firstName);
            Console.WriteLine("Müşterinin soyismi:{0}", cust1.secondName);
            Console.WriteLine("Müşterinin cinsiyeti {0}", cust1.gender);
        }
    }
}
