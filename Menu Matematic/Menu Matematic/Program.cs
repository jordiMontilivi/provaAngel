using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Menu_Matematic
{
    class Program
    {
        static ConsoleColor colorMenu = ConsoleColor.Red;
        static int IntroduirValor()
        {
            string valor;
            do
            {
                Console.Clear();
                Capçalera();
                //Console.Write("Introdueix un valor: ");
                Console.Write(CentrarTextMenu("Introdueix un valor: "));
                valor = Console.ReadLine();
            } while (!ValidarValor(valor));
            return (Convert.ToInt32(valor));
        }
        static void Return()
        {
            int i = 5;
            while (i != 0)
            {
                //Console.Write("\rTornant al menu: {0}s", i);
                Console.Write("\r");
                Console.Write(CentrarTextMenu($"Tornant al menu: {i}s"));
                Thread.Sleep(1000);
                i--;
            }
            Menu();
        }
        static bool ValidarValor(string valor)
        {
            bool validacio = true;
            int i = 0;
            while (validacio && i != valor.Length)
            {
                if (!(valor[i] >= '0' && valor[i] <= '9')) validacio = false;
                i++;
            }
            if (!validacio)
            {
                Console.WriteLine(CentrarTextMenu("Valor introduit incorrecte."));
                Thread.Sleep(2000);
            }
            return validacio;
        }
        static bool ValidarOpcio(char c)
        {
            return ((c >= '0' && c <= '9') || c == 'q' || c == 'Q');
        }
        static void Opcio()
        {
            int posicio = 0;
            char opcio;
            ConsoleKey key;
            Console.Write(CentrarTextMenu("Introdueix una opció: "));
            //opcio = Console.ReadKey().KeyChar;
            key = Console.ReadKey().Key;
            while (key == ConsoleKey.LeftArrow || key == ConsoleKey.RightArrow || key == ConsoleKey.DownArrow || key == ConsoleKey.UpArrow)
            {
                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.UpArrow:
                        Console.Clear();
                        Capçalera();
                        posicio--;
                        if (posicio == -1)
                            posicio = 3;
                        else if (posicio == 11)
                            posicio = 10;
                        else if (posicio < 3)
                            posicio = 12;
                        PintarMenuSeleccio(posicio);
                        break;

                    case ConsoleKey.RightArrow:
                    case ConsoleKey.DownArrow:
                        Console.Clear();
                        Capçalera();
                        posicio++;
                        if (posicio == 1)
                            posicio = 3;
                        else if (posicio == 11)
                            posicio = 12;
                        else if (posicio > 12)
                            posicio = 3;
                        PintarMenuSeleccio(posicio);
                        break;
                }
                key = Console.ReadKey().Key;

                //Menu();
            }
            if (key == ConsoleKey.Enter)
            {
                opcio = (char)('0' + posicio - 2);
                if (posicio == 12)
                    opcio = '0';
            }
            else
                opcio = (char)key;

            if (!ValidarOpcio(opcio))
            {
                Console.Clear();
                Capçalera();
                Console.WriteLine(CentrarTextMenu("El valor introduït no és correcte!"));
                Return();
            }
            else
            {
                int a, b, i;
                switch (opcio)
                {

                    case '1':
                        a = IntroduirValor();
                        b = IntroduirValor();
                        Console.Clear();
                        Capçalera();
                        Maxim(ref a, ref b);
                        Console.WriteLine(CentrarTextMenu("{0} és major que {1}."), a, b);
                        Return();
                        break;
                    case '2':
                        a = IntroduirValor();
                        b = IntroduirValor();
                        Console.Clear();
                        Capçalera();
                        Maxim(ref a, ref b);
                        i = MCD(a, b);
                        Console.WriteLine(CentrarTextMenu($"El MCD de {a} i {b} és : {i}"));
                        Return();
                        break;
                    case '3':
                        a = IntroduirValor();
                        b = IntroduirValor();
                        Console.Clear();
                        Capçalera();
                        Maxim(ref a, ref b);
                        i = MCM(a, b);
                        Console.WriteLine(CentrarTextMenu($"El MCM de {a} i {b} és: {i}"));
                        Return();
                        break;
                    case '4':
                        a = IntroduirValor();
                        Console.Clear();
                        Capçalera();
                        Console.WriteLine(CentrarTextMenu($"El factorial de {a} és: {Factorial(a)}"));
                        Return();
                        break;
                    case '5':
                        a = IntroduirValor();
                        b = IntroduirValor();
                        Console.Clear();
                        Capçalera();
                        Maxim(ref a, ref b);
                        double res = Combinatori(a, b);
                        if (res != -1)
                            Console.WriteLine(CentrarTextMenu($"El combinatori de {a} i {b} és: {res}"));
                        else
                            Console.WriteLine(CentrarTextMenu($"No es pot calcular el combinatori ja que {a} > {b}"));
                        Return();
                        break;
                    case '6':
                        a = IntroduirValor();
                        Console.Clear();
                        Capçalera();
                        i = DivisorMajor(a);
                        Console.WriteLine(CentrarTextMenu($"El major divisor de {a} és: {i}"));
                        Return();
                        break;
                    case '7':
                        a = IntroduirValor();
                        Console.Clear();
                        Capçalera();
                        if (Primer(a)) Console.WriteLine(CentrarTextMenu($"El numero {a} és primer."));
                        else Console.WriteLine(CentrarTextMenu($"El numero {a} no és primer."));
                        Return();
                        break;
                    case '8':
                        a = IntroduirValor();
                        Console.Clear();
                        Capçalera();
                        NPrimers(a);
                        Return();
                        break;
                    case 'Q':
                        break;
                    case 'q':
                        break;
                    default:
                        break;
                }
            }
        }
        static void PintarMenuSeleccio(int seleccio)
        {
            Console.Clear();
            Capçalera();
            int i = 0;
            string menu = MenuText();
            string linea = "";
            string text = menu;
            while (text.Contains("\n"))
            {
                linea = text.Substring(0, text.IndexOf("\n"));
                if (i == seleccio && i != 11)
                {
                    int index = linea.IndexOf((char)(i - 2 + '0')) - 1;
                    if (index == -2)
                        index = linea.IndexOf('0') - 1;

                    //Console.WriteLine(index);
                    Console.Write(String.Format("{0," + ((Console.WindowWidth / 2) - (linea.Length / 2) - 1) + "}", ""));
                    Console.BackgroundColor = colorMenu;
                    string text1 = linea.Substring(0, index);
                    //Console.Write(String.Format("{0," + ((Console.WindowWidth / 2) + (linea.Length / 2) - (linea.Length - text1.Length)) + "}", text1));
                    Console.Write(text1);
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    text1 = linea.Substring(index, linea.Length - 2 * index);
                    Console.Write(text1);
                    //Console.Write(String.Format("{0," + ((Console.WindowWidth / 2) + (linea.Length / 2)) + "}", text1));
                    linea = linea.Substring(index + linea.Length - 2 * index);

                    Console.BackgroundColor = colorMenu;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(linea);
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Centrar2(linea);
                }
                text = text.Substring(text.IndexOf("\n") + 1);
                i++;
            }
            Centrar2(text);
            Console.Write(CentrarTextMenu("Introdueix una opció: "));
        }
        static void Capçalera()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Centrar("MENU MATEMATIC DE MERDA");
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void Menu()
        {
            Console.Clear();
            Capçalera();
            string menu = MenuText();

            PintarMenu(menu);
            Opcio();
        }

        static string MenuText()
        {
            string menu =
                "╔═══════════════════════════════════╗\n" +
                "║               MENU                ║\n" +
                "╠═══════════════════════════════════╣\n" +
                "║      1. Maxim                     ║\n" +
                "║      2. MCD                       ║\n" +
                "║      3. MCM                       ║\n" +
                "║      4. Factorial                 ║\n" +
                "║      5. Combinatori               ║\n" +
                "║      6. Major Divisor             ║\n" +
                "║      7. Comprovar Primer          ║\n" +
                "║      8. N Primers                 ║\n" +
                "║                                   ║\n" +
                "║      0. Sortir                    ║\n" +
                "╚═══════════════════════════════════╝";
            return menu;
        }

        static void PintarMenu(string menu)
        {
            string linea = "";
            string text = menu;
            while (text.Contains("\n"))
            {
                linea = text.Substring(0, text.IndexOf("\n"));
                Centrar2(linea);
                text = text.Substring(text.IndexOf("\n") + 1);
            }
            Centrar2(text);
        }


        static void Maxim(ref int a, ref int b)
        {
            if (a < b)
            {
                int aux = a;
                a = b;
                b = aux;
            }
        }
        static int MCD(int a, int b)
        {
            int i = a % b;
            while (a % i != 0 || b % i != 0) i--;
            return i;
        }
        static int MCM(int a, int b)
        {
            int i = a;
            while (i % a != 0 || i % b != 0) i++;
            return i;
        }
        static int Factorial(int a)
        {
            int factorial = 1;
            for (int i = 1; i <= a; i++) factorial = factorial * i;
            return factorial;
        }
        static int DivisorMajor(int a)
        {
            int i = a - 1;
            while (a % i != 0) i--;
            return i;
        }
        static double Combinatori(int a, int b)
        {
            double combinatori;
            if (a >= b)
            {
                combinatori = Factorial(a) / (Factorial(b) * Factorial(a - b));
            }
            else
                combinatori = -1;
            return combinatori;
        }
        static bool Primer(int a)
        {
            int j = 0;
            for (int i = 2; i <= a/2 && j < 1; i++)
            {
                if (a % i == 0) j++;
            }
            return j == 0;
        }
        static void NPrimers(int a)
        {
            int i = 2, j = 1;
            while (j <= a)
            {
                if (Primer(i))
                {
                    Console.WriteLine(CentrarTextMenu($"Primer Nº {j}: {i}"));
                    j++;
                }
                i++;
            }
        }

        //Mostra qualsevol text centrat per pantalla Console.WriteLine(CentrarTextMenu
        static void Centrar(string text)
        {
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text));
        }
        static void Centrar2(string text)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(String.Format("{0," + ((Console.WindowWidth / 2) - (text.Length / 2) - 1) + "}", ""));
            Console.BackgroundColor = colorMenu;
            Console.Write(String.Format($"{text}"));
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
        }

        //Retorna les mides perfectes per centrar el text respecte del nostre Menu
        static string CentrarTextMenu(string text)
        {
            string menu = MenuText();
            //independentment de la mida sempre ens centrara tot el text segons la primera linea del menu
            menu = menu.Substring(0, menu.IndexOf("\n")); //agafem primera linea del menu
            string ordre = String.Format("{0," + ((Console.WindowWidth / 2) - (menu.Length / 2) + text.Length) + "}", text);
            //string ordre = String.Format("{0,33}", text);
            return ordre;
        }
        static string CentrarTextMenu(string text, string color)
        {
            string menu = MenuText();
            //independentment de la mida sempre ens centrara tot el text segons la primera linea del menu
            menu = menu.Substring(0, menu.IndexOf("\n")); //agafem primera linea del menu
            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color);
            string ordre = String.Format("{0," + ((Console.WindowWidth / 2) - (menu.Length / 2) + text.Length) + "}", text);
            //string ordre = String.Format("{0,33}", text);
            Console.ForegroundColor = ConsoleColor.Black;
            return ordre;
        }

        //Retorna la l'string per a centrar un text i ja el mostraràs tu com vulguis
        static string CentrarText(string text)
        {
            string ordre = String.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text);
            return ordre;
        }

        //Estableix les mides de la consola  i crida al Menu
        static void Inici()
        {
            //string text = "MENU";
            Console.WindowHeight = 15;
            Console.WindowWidth = 82;
            Menu();
        }
        static void Main(string[] args)
        {
            //Programa
            Inici();
            //Console.WindowHeight = 20;
            //Console.WindowWidth = 60;
            //string menu = "*************************************\n";
            //Console.WriteLine(CentrarTextMenu("{0," + ((Console.WindowWidth / 2) + (menu.Length / 2) + ("hola".Length/2)) + "}");
        }
    }
}

