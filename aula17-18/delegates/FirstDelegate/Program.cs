using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Aula17
{
    // definição de um novo tipo de delegate designado Display
    delegate void Display(int value);
    
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

            /* 3 outras formas de fazer a mesma coisa */
            ShowAll(
                new int[] { 1, 2, 3 },
                ToConsole);

            ShowAll(
                new int[] { 1, 2, 3 },
                delegate(int x) { Console.WriteLine(x); });

            ShowAll(
                new int[] { 1, 2, 3 },
                x => Console.WriteLine(x));
            /* ------------------------------------ */


            //
            // other example with a 'print decorator'
            //

        }
    }
}
