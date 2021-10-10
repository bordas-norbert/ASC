using System;
//Bordás Norbert, tema 1, grupa 7411 subgrupa A
namespace tema_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Va rog dati valoarea n:");
            string line = Console.ReadLine();
            int n = int.Parse(line), max_n = 1, min_n = 0, max_luni = 0, min_luni = 0;
            double luni = 0.0, kul = 0.0;
            while(max_n < n)
            {
                max_n *= 2;
                max_luni += 18;
            }
            min_n = max_n / 2;
            min_luni = max_luni - 18;
            kul = (double)18 / (max_n - min_n);
            luni = min_luni;
            for(int i= 0; i<n - min_n; ++i)
            {
                luni += kul;
            }
            if(Math.Floor(luni) == luni)
            { 
                Console.WriteLine("{0} luni trebuie sa trece",luni);
            }
            else
            {
                kul = luni - Math.Floor(luni);
                double zile = 0;
                zile = Math.Ceiling(30 * kul);
                Console.WriteLine("aproximativ {0} luni si {1} de zile trebuie sa trece", Math.Floor(luni), zile);
            }
            
        }
    }
}
