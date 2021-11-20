using System;

namespace TemaASC
{
    class Program
    {

        static void Main(string[] args)
        {

            Automat();

        }

        private static void Automat()
        {
            char s = 'D';
            long valGlobal = 0;
            int nr1 = 0, nr5 = 0, nr25 = 0;
            while (s != 'N')
            {
                Console.WriteLine("Doriti sa intrati bani? (D / N)");
                s = char.Parse(Console.ReadLine());
                switch (s)
                {
                    case 'D': IntraBani(ref nr1, ref nr5, ref nr25, ref valGlobal); Console.WriteLine(); break;
                    case 'N': break;
                    default: Console.WriteLine("Numai literele 'D' si 'N' sunt acceptate"); break;

                }
            }



        }

        private static void IntraBani(ref int nr1, ref int nr5, ref int nr25, ref long valGlobal)
        {
            Console.WriteLine("Ce fel de bani doriti sa intrati: 1 5 25");
            string felBan = Console.ReadLine();
            Console.Write($"Cate bucati de {felBan} centi doriti sa intrati? Cantitate: ");
            int nrBan = int.Parse(Console.ReadLine());

            if (felBan == "1")
            {
                nr1 += nrBan;
                valGlobal = valGlobal + 1 * nrBan;
            }
            else
                if (felBan == "5")
            {
                nr5 += nrBan;
                valGlobal = valGlobal + 5 * nrBan;
            }
            else
            {
                if (felBan == "25")
                {
                    nr25 += nrBan;
                    valGlobal = valGlobal + 25 * nrBan;
                }
                else
                {
                    Console.WriteLine("Date gresite!");
                    return;
                }
            }
            Marfa(ref nr1, ref nr5, ref nr25, ref valGlobal);
        }

        private static void Marfa(ref int nr1, ref int nr5, ref int nr25, ref long valGlobal)
        {
            int eliberatProdus = Convert.ToInt32(valGlobal / 20);
            valGlobal %= 20;
            if (eliberatProdus == 0)
            {
                Console.WriteLine($"Nu au fost puse destule bani pentru o marfa! Mai aveti nevoie de {20 - valGlobal} centi.");
            }
            else
            {
                Console.WriteLine($"Au fost eliberate {eliberatProdus} bucati de produs.");
                if (valGlobal != 0)
                    Rest(ref nr1, ref nr5, ref nr25, ref valGlobal);
            }

        }

        private static void Rest(ref int nr1, ref int nr5, ref int nr25, ref long valGlobal)
        {
            int rest = Convert.ToInt32(valGlobal);
            generareRest(ref nr1, ref nr5, ref nr25, rest, 0, 0, valGlobal);
        }

        private static void generareRest(ref int nr1, ref int nr5, ref int nr25, int rest, int g1, int g5, long valGlobal)
        {
            if (g1 * 1 + g5 * 5 == rest)
            {
                Console.WriteLine($"Restul: {g1} buc. de 1 centi, {g5} buc. de 5 centi. In total {rest}.");
                nr1 -= g1;
                nr5 -= g5;
            }
            else if (nr1 > g1 && nr5 > g5)
            {
                if (nr1 > g1)
                    generareRest(ref nr1, ref nr5, ref nr25, rest, g1 + 1, g5, valGlobal);
                if (nr5 > g5)
                    generareRest(ref nr1, ref nr5, ref nr25, rest, g1, g5 + 1, valGlobal);

            }
            else
                Console.WriteLine($"Nu am putut da restul inapoi. Intrati {20 - valGlobal} pentru o noua marfa.");
        }
    }
}
