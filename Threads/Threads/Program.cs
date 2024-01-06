
using System.Collections;
using System.Security.Cryptography.X509Certificates;

ArrayList birinci = new ArrayList();
ArrayList ciftarray = new ArrayList();
ArrayList tekarray = new ArrayList();
ArrayList asalarray = new ArrayList();
object ciftLock = new object();
object tekLock = new object();
object asalLock = new object();

for (int i = 1; i < 1000001; i++)
        {
            birinci.Add(i);
        }

        Thread thread1 = new Thread(() => ALekleme(1, 250000));
        Thread thread2 = new Thread(() => ALekleme(250001, 500000));
        Thread thread3 = new Thread(() => ALekleme(500001, 750000));
        Thread thread4 = new Thread(() => ALekleme(750001, 1000000));

        thread1.Start();
        thread2.Start();
        thread3.Start();
        thread4.Start();

        thread1.Join();
        thread2.Join();
        thread3.Join();
        thread4.Join();
  
foreach (int i in ciftarray)
{
    Console.WriteLine(i);
}
Console.WriteLine("ÇİFTLER BİTTİ");
foreach (int i in tekarray)
{
    Console.WriteLine(i);
}
Console.WriteLine("TEKLER BİTTİ");
foreach (int i in asalarray)
{
    Console.WriteLine(i);
}
Console.WriteLine("ASALLAR BİTTİ");


void ALekleme(int başla, int bitir)
    {
        for (int i = başla; i <= bitir; i++)
        {
            if (i % 2 == 0)
            {
            lock (ciftLock)
            {
                ciftarray.Add(i);
            }
                
            }

            else
            {
            lock (tekLock) {
                tekarray.Add(i);
            }
               
            }

            if (AsalMi(i))
            {
               lock(asalLock)
            {
                asalarray.Add(i);
            }
                
            }
        }
    }

    static Boolean AsalMi(int sayi)
    {
        if (sayi < 2)
        {
            return false;
        }

        for (int i = 2; i < sayi / 2; i++)
        {
            if (sayi % i == 0)
            {
                return false;
            }

        }
        return true;
    }
