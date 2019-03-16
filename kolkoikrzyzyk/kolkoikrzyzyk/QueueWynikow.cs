using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace kolkoikrzyzyk
{
    public class QueueWynikow
    {
        static public Queue ostatnieWyniki = new Queue();
        static public string[,] tablica = new string[6,3];

        public static void Kolejka(Queue kolejka, string wynik)
        {         
            kolejka.Enqueue(wynik);
        }
 
        public static string[,] WypiszKolejke(Queue kolejka, string[,] tablica, string gracz)
        {
            
            while (kolejka.Count > 6)
            {
                kolejka.Dequeue();
            }
            int ktory=0;
            foreach (string x in kolejka)
            {
                tablica[ktory,0] = x;
                
                ktory++;
            }
            tablica[ktory-1, 1] = "(" + gracz + ")";           
            return tablica;
        }
    }
}
