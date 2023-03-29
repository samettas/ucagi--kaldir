using System;

namespace ATC_1
{
    internal class Program
    {
        static int  Random_Sayi = 0;
        public static int Hesapla(int dakika,int pist,int [] pistler)
        {
            int kucuk=pistler[0];
            int j = 1;
            int random_sayi = 1;
            Random random = new Random();
            for (int i = 0; i < pist; i++)
            {
                random_sayi=random.Next(1,5);
                if (kucuk + j + dakika > pistler[i] + random_sayi + dakika)
                {
                    kucuk = pistler[i];
                    j = random_sayi;
                }
            }
            Random_Sayi = j;
            return kucuk; 
        }
        public static int Döndür(int time,int pist_sayisi,int [] pistler)
        {
            int j=0;
            for (int i = 0; i < pist_sayisi; i++)
            {
                if (pistler[i] == time)
                {
                    j= i;
                    break;
                }
            }           
            return j;
        }
        public static void Yazdır(int saat , int dakika , int dizi_no,int i)
        {
            if (dakika < 10)
            {
                if (saat < 10)
                {
                    Console.WriteLine("ATC-1 = TK-" + i + " push-back için izin verildi pist numaranız = " + (dizi_no + 1) + " tahmini kalkma saatiniz = 0" + saat + ":0" + dakika + " iyi uçuşlar , piste ulaşma süresi yani sezgisel = " + Random_Sayi);
                }
                else
                {
                    Console.WriteLine("ATC-1 = TK-" + i + " push-back için izin verildi pist numaranız = " + (dizi_no + 1) + " tahmini kalkma saatiniz = " + saat + ":0" + dakika + " iyi uçuşlar , piste ulaşma süresi yani sezgisel = " + Random_Sayi);
                }
            }
            else
            {
                if (saat < 10)
                {
                    Console.WriteLine("ATC-1 = TK-" + i + " push-back için izin verildi pist numaranız = " + (dizi_no + 1) + " tahmini kalkma saatiniz = 0" + saat + ":" + dakika + " iyi uçuşlar , piste ulaşma süresi yani sezgisel = " + Random_Sayi);
                }
                else
                {
                    Console.WriteLine("ATC-1 = TK-" + i + " push-back için izin verildi pist numaranız = " + (dizi_no + 1) + " tahmini kalkma saatiniz = " + saat + ":" + dakika + " iyi uçuşlar , piste ulaşma süresi yani sezgisel = " + Random_Sayi);
                }
            }
        }
        static void Main(string[] args)
        {
            
            Console.Write("Merhaba ATC-1 kulesine hoşgeldiniz. Oluşturacağınız her pist diğer pistten uçakların havalanmasını 1dk geciktirmektedir.\nÖrneğin 1.pist uçağı 1 dakikada kaldırıyorsa 2. pist 2 dakikada kaldırmaktadır.\nHavalimanında kaç pist olmasını istersiniz = ");
            int pist_sayisi= Convert.ToInt32(Console.ReadLine());
            int[] pistler = new int[pist_sayisi];
            int i = 1;
            int dakika = 0;
            int saat = 0;
            int geçici = 0;
            while (true)
            {
                Console.WriteLine("TK-" + i + " = ATC-1 push-back için izin istiyoruz");
                Console.Write("ATC-1 = TK-"+i+" uçak tipinizi belirtiniz (Büyük uçak için = 1 / Küçük uçak için = 2) = ");
                int choice = Convert.ToInt32(Console.ReadLine());
                int süre;
                int dizi_no;
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("TK-"+i+" = Uçak tipimiz Boeing 787-9");
                        süre = Hesapla(5, pist_sayisi, pistler);
                        dizi_no = Döndür(süre,pist_sayisi,pistler);                        
                        pistler[dizi_no] += 5+Random_Sayi;
                        geçici=pistler[dizi_no];
                        dakika=geçici % 60;
                        saat = geçici / 60;
                        Yazdır(saat, dakika, dizi_no, i);                        
                        Console.WriteLine("TK-"+i+" = Anlaşıldı ATC-1\n");
                        break;
                    case 2:
                        Console.WriteLine("TK-" + i + " = Uçak tipimiz Boeing 737-800");
                        süre = Hesapla(3, pist_sayisi, pistler);
                        dizi_no = Döndür(süre,pist_sayisi,pistler);
                        pistler[dizi_no] +=3+Random_Sayi ;
                        geçici = pistler[dizi_no];
                        dakika = geçici % 60;
                        saat = geçici / 60;
                        Yazdır(saat, dakika, dizi_no, i);
                        Console.WriteLine("TK-" + i + " = Anlaşıldı ATC-1\n");
                        break;
                    default:
                        Console.WriteLine("Hatalı bildirim yaptınız. Size geri döneceğim");
                        i--;
                        break;
                }
                i++;
            }            
        }
    }
}
