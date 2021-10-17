using System;

namespace temaConvertBases
{
    class Program
    {
        static void Main()
        {
            string baza1, baza2, input;
            Console.WriteLine("Va rog sa-mi dati prima baza");
            baza1 = Console.ReadLine();
            Console.WriteLine("Va rog sa-mi dati a doua baza");
            baza2 = Console.ReadLine();

            uint b1, b2;

            bool OK1 = uint.TryParse(baza1, out b1);
            bool OK2 = uint.TryParse(baza2, out b2);

            if(OK2 == false || OK1 == false || b2>16)
            {
                Console.WriteLine("date incorecte");
                System.Environment.Exit(0);
            }

            Console.WriteLine($"Va rog sa-mi dati numarul in baza de {baza1}");
            input = Console.ReadLine();

            if (Test(input, b1) == false)
            {
                
                Console.WriteLine("date incorecte");
                System.Environment.Exit(1);
            }

            string output = Konvert(b1, b2, input);
            Console.WriteLine("Rezultatea este " + output);

        }
        static string Konvert(uint b1, uint b2, string input)
        {
            string tenBased="", rez="";
            int poz = punctPoz(input);
            if (b1 >= 2 && b2 <= 10)
            {
                if (poz == 0)
                {
                    tenBased = konvTen(b1, input);
                    if (b2 == 10)
                        rez = tenBased;
                    else
                    {
                        rez = KonvBaseTwo(b2, tenBased);
                    }
                }
            }
            return rez;
        }
        static string KonvBaseTwo(uint b2, string tenBased)
        {
            UInt64  nr = (ulong)Convert.ToInt64(tenBased), rez=0, mirror = 0;
            int i = 1;
            while (nr!=0)
            {
                rez = rez * 10 + nr % b2 ;
                nr /= b2;
                
            }
            while(rez!=0)
            {
                mirror = mirror * 10 + rez % 10; 
                rez /= 10;
                
            }
            return Convert.ToString(mirror);
        }
        static string konvTen(uint b1, string input)
        {
            UInt64 nr = 0;
            ulong p = 1; int i = input.Length -1;
            while (i>=0)
            {
                nr += (ulong)(input[i] - '0') * p;
                p *= b1;
                i--;
            }
          

            return Convert.ToString(nr);
        }

        static int punctPoz(string str)
        {
            int i=0;
            while( i < str.Length)
            {
                if (str[i] == '.')
                    return i;
                ++i;
            }
            return 0;
        }
        static bool Test(string input, uint b1)
        {
            if (b1 >= 2 && b1 <= 9)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if ('1' < input[i] && input[i] >= ((char)(b1+48)) && input[i]!='.')
                        return false;
                }
            }
            else
            {
                if(b1>=10 && b1<=16)
                for (int i = 0; i < input.Length; i++)
                {
                    if (('0' <= input[i] && input[i] > '9') || (input[i] < 'A' && input[i] > 'F')) 
                        return false;
                }
            }
            int index = 0;
            byte punct = 0;
            while (index < input.Length && punct <= 2)
            {
                if (input[index] == '.')
                    punct++;
                ++index;
            }
            if (punct < 2 && !input.StartsWith('.') && !input.EndsWith('.'))
                return true;
            else
                return false;
        }
    }
}
