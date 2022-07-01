using System;
using System.Collections;
using System.Collections.Generic;

namespace Beltek66.GenericApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Deneme a=new Deneme();
            // a.sayi = 5;
            // a.Yazdir();

            // Deneme<string> d = new Deneme<string>(); struct yaptığımız için kısıtlanma var hata verir string class int-byte.. struct
           Deneme<int> d=new Deneme<int>();//string yapabilirsin mantık hatası
          //  var d = new Deneme<int,string>();
            d.sayi = 5;

           // string[] isimler = new string[3];
           //ArrayList al=new ArrayList();
           // al.Add(1); int heap atıyor sıkıntı bellek stack tte olması gerekir değer gezmesi performans olayı boxing unboxing olayı

            List<string> list=new List<string>(); //Generic Koleksiyonlar
            list.Add("a");
            list.Add("b");
            list.Add("c");
            list.Add("c");
            list.Capacity=list.Count;//listenin kapasitesini listenin boyutuna eşitleme
            Console.WriteLine(list.Capacity);
            List<byte> list1 = new List<byte>();
            list1.Add(5);

        }
    }

    class Deneme<T>where T: struct//Veri type değişkenliği Deneme<T,U>where T:struct
    {
       public T sayi;
      // public U veri;

        public void Yazdir()
        {
            Console.WriteLine(this.sayi);
        }
        


    }





}
