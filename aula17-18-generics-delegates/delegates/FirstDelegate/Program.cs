using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Aula17
{
    // definição de um novo tipo de delegate designado Display
    delegate void Display(int value);

    class PrefixDisplay
    {
        private String prefix;
        public PrefixDisplay(String prefix)
        {
            this.prefix = prefix;
        }

        public void Print(int value)
        {
            Console.WriteLine("{0} {1}", this.prefix, value);
        }
    }


    class FirstDelegate
    {
        public static void ToConsole(int value)
        {
            Console.WriteLine("Item=" + value);
        }

        public static void ToMsgBox(int value)
        {
            MessageBox.Show("Item=" + value);
        }

        public static void ShowAll(int[] values, Display display)
        {
            foreach (int v in values)
            {
                display(v);  // display.Invoke(v);
            }
                
        }


        static void Main(string[] args)
        {
            ShowAll(
                new int[] { 1, 2, 3 },
                // cria uma instancia do delegate 'Display' que refere
                // o método 'FirstDelegate.ToMsgBox'
                new Display(FirstDelegate.ToMsgBox));

            ShowAll(
                new int[] { 3, 4, 5, 6, 7, 8 },
                new Display(ToConsole));

            //
            // 3 outras formas de fazer a mesma coisa ("syntatic sugar" da linguagem)
            //
            ShowAll(
                new int[] { 1, 2, 3 },
                ToConsole);

            ShowAll(
                new int[] { 1, 2, 3 },
                delegate(int x) { Console.WriteLine(x); }
                );

            ShowAll(
                new int[] {1, 2, 3},
                x => Console.WriteLine(x)
                );

            //
            // delegate para um método de instancia
            //
            PrefixDisplay pd = new PrefixDisplay("***");
            ShowAll(
                new int[] { 1, 2, 3 },
                new Display(pd.Print)
                );


            //
            // - as instancia de delegates são imutáveis
            // - uma instância de delegate pode referir várias outras instâncias
            //
            Display d1 = new Display(ToConsole);
            Display d2 = new Display(ToMsgBox);

            // cria um novo delegate que refere d1 e d2
            Display d3 = (Display) Delegate.Combine(d1, d2);
            d3.Invoke(100);

            // outra forma ...
            // cria um novo delegate que refere os 
            // delegates referidos por d1 e d2
            Display d4 = d1 + d2;
            d4.Invoke(75);

            // outra forma ...
            // cria um novo delegate que refere os 
            // delegates referidos por d1 e d2 
            // e guarda a referência em d1
            d1 += d2;
            d1.Invoke(50);

            // tenta remover o delegate referido por d1
            // mas sem sucesso porque não faz parte da lista de 
            // delegates de d3
            Delegate.Remove(d3, d1);
            d3.Invoke(200);

        }
    }
}
