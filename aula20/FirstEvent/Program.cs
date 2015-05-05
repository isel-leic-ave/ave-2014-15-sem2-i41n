using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstEvent
{
    delegate void EventConsumer(int code);

    class EventProducer
    {
        public event EventConsumer EventA;

        /* 
         * o código gerado pelo compilador é equivalente a:
         * 
        // campo privado do tipo do delegate
        //
        private EventConsumer EventA;
        
        // método de adição de consumidores
        //
        public void add_EventA(EventConsumer c) {
            EventA = (EventConsumer) Delegate.Combine(EventA, a);
        }

        // método de remoção de consumidores
        // 
        public void remove_EventA(EventConsumer c) {
            EventA = (EventConsumer) Delegate.Remove(EventA, a);
        }
        */

        public void FireEventA(int code)
        {
            Delegate[] delegates = EventA.GetInvocationList();
            if (EventA != null)
            {
                EventA(code); /* EventA.Invoke(code) */
            }
        }
    }


    class Program
    {
        static void Observer(int code)
        {
            Console.WriteLine("Observer received code={0}", code);
        }

        static void Main(string[] args)
        {
            EventProducer observable = new EventProducer();

            observable.EventA += new EventConsumer(Observer);
            observable.EventA -= Observer;

            // simular que aconteceu o evento 'EventA'
            observable.FireEventA(10);
        }
    }
}





