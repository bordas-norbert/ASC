using System;

namespace Tema
{
    class Program
    {
        static void Main(string[] args)
        {
            OperatiiCuNumereMari();

        }
        static void BreakDown(ref int[] nr, string numar)
        {
            int j = 0;
            char[] str = new char[numar.Length];
            for (int i = 0; i < str.Length; i++)
            {
                str[i] = numar[i];
            }
            for (int i = numar.Length - 1; i >= 0; --i)
            {
                nr[j] = str[i] - '0';
                ++j;
            }

        }
        static void Print(int[] a)
        {
            Console.Write("a + b = ");
            int n = a.Length;

            if (a[n - 1] == 0 && a[n - 2] != 0)
                n--;
            for (int i = n - 1; i >= 0; i--)
                Console.Write(a[i]);
            Console.WriteLine();
        }
        static void Adunare(int[] a, int[] b)
        {
            int n = 0;
            if (a.Length >= b.Length)
                n = a.Length;
            else
                n = b.Length;

            int[] rez = new int[n + 1];
            int i = 0, j = 0, ramas = 0, index = 0;

            while (i < a.Length && j < b.Length)
            {
                rez[index] = a[i] + b[j] + ramas;
                if (rez[index] > 9)
                {
                    rez[index] %= 10;
                    ramas = 1;
                }
                else
                    ramas = 0;
                i++; j++; index++;
            }

            while (i < a.Length)
            {
                rez[index] = a[i] + ramas;
                if (rez[index] > 9)
                {
                    rez[index] %= 10;
                    ramas = 1;
                }
                else
                    ramas = 0;

                i++; index++;
            }
            while (j < b.Length)
            {
                rez[index] = b[j] + ramas;
                if (rez[index] > 9)
                {
                    rez[index] %= 10;
                    ramas = 1;
                }
                else
                    ramas = 0;

                j++; index++;
            }
            if (ramas == 1)
                rez[n] += 1;
            Print(rez);
        }

        static int GetIndex(int[] v)
        {
            for (int i = v.Length - 1; i >= 0; i--)
                if (v[i] != 0)
                    return i;
            return 0;
        }
        static void PrintScadere(int[] rez, bool pozitiv)
        {
            Console.Write("a - b = ");
            if (pozitiv == false)
                Console.Write("-");
            for (int i = GetIndex(rez); i >= 0; i--)
            {
                Console.Write(rez[i]);
            }
        }
        static int[] sameLength(int[] v, int n)
        {
            int[] aux = new int[n];
            for (int i = 0; i < v.Length; i++)
            {
                aux[i] = v[i];
            }
            return aux;
        }
        static void Scadere(int[] a, int[] b, bool pozitiv)
        {
            int i = 0, an = a.Length, bn = b.Length;
            if (an > bn)
                b = sameLength(b, an);

            an = a.Length;

            int[] rez = new int[an];

            while (i < an)
            {
                rez[i] = a[i] - b[i];

                if (rez[i] < 0)
                {

                    a[i] += 10;
                    rez[i] = a[i] - b[i];
                    a[i] -= 10;
                    a[i + 1] -= 1;
                }
                i++;
            }

            PrintScadere(rez, pozitiv);

        }
        static bool MaiMare(int[] a, int[] b)
        {
            if (a.Length > b.Length)
                return true;
            else
            if (a.Length < b.Length)
                return false;
            for (int i = a.Length - 1; i >= 0; i--)
                if (a[i] != b[i])
                {
                    if (a[i] > b[i])
                        return true;
                    else
                        return false;
                }
            return true;

        }
        static void ScadereOrdin(int[] a, int[] b)
        {

            if (MaiMare(a, b))
                Scadere(a, b, true);
            else
                Scadere(b, a, false);
            Console.WriteLine();
        }
        static int[] AdunareInmultire(int[] a, int[] b)
        {
            int n = 0;
            if (a.Length >= b.Length)
                n = a.Length;
            else
                n = b.Length;

            int[] rez = new int[n + 1];
            int i = 0, j = 0, ramas = 0, index = 0;

            while (i < a.Length && j < b.Length)
            {
                rez[index] = a[i] + b[j] + ramas;
                if (rez[index] > 9)
                {
                    rez[index] %= 10;
                    ramas = 1;
                }
                else
                    ramas = 0;
                i++; j++; index++;
            }

            while (i < a.Length)
            {
                rez[index] = a[i] + ramas;
                if (rez[index] > 9)
                {
                    rez[index] %= 10;
                    ramas = 1;
                }
                else
                    ramas = 0;

                i++; index++;
            }
            while (j < b.Length)
            {
                rez[index] = b[j] + ramas;
                if (rez[index] > 9)
                {
                    rez[index] %= 10;
                    ramas = 1;
                }
                else
                    ramas = 0;

                j++; index++;
            }

            if (ramas == 1)
                rez[n] += 1;
            return rez;
        }
        private static void Add(int[] aux, ref int[] rez)
        {
            rez = AdunareInmultire(aux, rez);
        }
        private static int[] Sterge(int[] a)
        {
            int[] b = new int[a.Length];
            return b;
        }
        private static void Inmultire(int[] a, int[] b)
        {

            int[] rez = new int[a.Length + b.Length];
            int[] aux = new int[a.Length + b.Length];

            int ramas = 0, aux_index = 0;
            for (int ib = 0; ib < b.Length; ib++)
            {
                aux_index = ib;
                ramas = 0;
                for (int ia = 0; ia < a.Length; ia++)
                {
                    aux[aux_index] += a[ia] * b[ib];

                    if (aux[aux_index] >= 10)
                    {
                        ramas = aux[aux_index] / 10;
                        aux[aux_index] %= 10;
                    }
                    aux_index++;
                    aux[aux_index] += ramas;
                    ramas = 0;
                }
                Add(aux, ref rez);

                aux = Sterge(aux);
            }
            Console.Write("a * b = ");
            for (int i = GetIndex(rez); i >= 0; i--)
            {
                Console.Write(rez[i]);
            }
            Console.WriteLine();
        }

        static void InmultireOrdin(int[] a, int[] b)
        {
            if (MaiMare(a, b))
                Inmultire(a, b);
            else
                Inmultire(b, a);
        }
        static void ScadereDiv(int[] a, int[] b, ref int k)
        {
            int i = 0, an = a.Length, bn = b.Length;
            int[] rez = new int[an];
            if (an > bn)
                b = sameLength(b, an);

            do
            {

                rez = Sterge(rez);

                while (i < an)
                {
                    rez[i] = a[i] - b[i];

                    if (rez[i] < 0)
                    {

                        a[i] += 10;
                        rez[i] = a[i] - b[i];
                        a[i] -= 10;
                        a[i + 1] -= 1;
                    }
                    i++;
                }
                k++;
                i = 0;

                for (int c = 0; c < an; c++)
                    a[c] = rez[c];

            } while (MaiMare(a, b));
        }
        static void DIV(int[] a, int[] b)
        {
            int k = 0;
            ScadereDiv(a, b, ref k);
            Console.WriteLine("a / b = " + k);
        }
        static void ImpartireOrdin(int[] a, int[] b)
        {
            if (MaiMare(a, b))
                DIV(a, b);
            else
                Console.WriteLine("a / b = 0");
        }

        private static void OperatiiCuNumereMari()
        {
            Console.Write("Introduceti un numar (a): ");
            string numar = Console.ReadLine();
            int[] a = new int[numar.Length];
            int an = numar.Length;
            BreakDown(ref a, numar);

            Console.Write("Introduceti un alt numar (b): ");
            numar = Console.ReadLine();
            int[] b = new int[numar.Length];
            int ab = numar.Length;
            BreakDown(ref b, numar);
            Console.WriteLine("A -> a + b");
            Console.WriteLine("B -> a - b");
            Console.WriteLine("C -> a * b");
            Console.WriteLine("D -> a / b");
            Console.Write("Alegeti o litera a unei operatie: ");

            char x = Convert.ToChar(Console.Read());
            switch (x)
            {
                case 'A': Adunare(a, b); break;
                case 'B': ScadereOrdin(a, b); break;
                case 'C': InmultireOrdin(a, b); break;
                case 'D': ImpartireOrdin(a, b); break;
                default: Console.WriteLine("Literele A, B, C, D sunt acceptate."); break;
            }
        }


    }
}