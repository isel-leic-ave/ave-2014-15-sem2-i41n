using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events_ExplicitImplementation
{
   public delegate void EventConsumer(int code);

    class EventProducer
    {

        public event EventConsumer EventoA;
        /*
         * private EventConsumer EventoA;
         * public add(EventConsumer c) {EventoA+=c;}
         * public remove(EventConsumer c) {EventoA-=c;}
         * */

        private EventConsumer EventoB;
        public event EventConsumer EventB
        {
            add
            {
                if (EventoB != null && EventoB.GetInvocationList().Length < 10)
                {
                    EventoB += value;
                }
            }
            remove
            {

            }
        }

        public void OnEventA(int code)
        {
            if (EventoA != null) // verifica se há algum consumidor registado
            {
                EventoA(code);
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            EventProducer producer = new EventProducer();

            producer.EventoA += (x) => { Console.WriteLine(x); };
            producer.EventoA += (x) => { Console.WriteLine("**" + x + "**"); };

            // simular o Evento A
            producer.OnEventA(100);
        }
    }
}
