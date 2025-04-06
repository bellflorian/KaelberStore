// See https://aka.ms/new-console-template for more information
using Kaelber_projekt.Class;

Console.WriteLine("Hello, World!");

Kalb kalb = new Kalb();
 

//Kalb kalb2 = new Kalb("sdefvw", 56, false, DateTime.Now);
//Kalb kalb3 = new Kalb("wad", 5, true, DateTime.Now);
//Kalb kalb4 = new Kalb("wewgfwef", 54, true, DateTime.Now);
//Kalb kalb5 = new Kalb("rigjnqd", 15, false, DateTime.Now);

Console.WriteLine();

IKalbStore computerstore = new StaticKaelberStore();
//computerstore.AddKalb(kalb2);
//computerstore.AddKalb(kalb3);
//computerstore.AddKalb(kalb4);
//computerstore.AddKalb(kalb5);