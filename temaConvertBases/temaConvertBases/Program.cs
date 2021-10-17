using System;

namespace temaConvertBases
{
    class Program
    {
        static void Main(string[] args)
        {
            string baza1, baza2;
            Console.WriteLine("Va rog sa-mi dati prima baza");
            baza1 = Console.ReadLine();
            Console.WriteLine("Va rog sa-mi dati a doua baza");
            baza2 = Console.ReadLine();

            int b1=0, b2=0;

            bool OK1 = int.TryParse(baza1, out b1);
            bool OK2 = int.TryParse(baza2, out b2);
            if(OK2 == false || OK1 == false)
            {
                Console.WriteLine("date incorecte");
                System.Environment.Exit(0);
            }
            Console.WriteLine("totul e ok");

            //if()
            //Console.WriteLine("{0}, {1}", b1, b2);
            //TestInput(input);

        }
        static void TestInput(string input)
        {

        }
    }
}
