using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsWorld
{

    interface Subscriber
    {
        void occurrence(String title, String desc, DateTime when);
    }

    class Newsworld {
        public void AddSubscriber(Subscriber sub) {}
        public void RemoveSubscriber(Subscriber sub) {}

        /* .... */
        private List<Subscriber> subscribers = new List<Subscriber>();
        public void PublishNews(string title, string news, DateTime date)
        {
            // percorre lista de 'Subscriber' e chama 'occurrence'
        }
    }


    /*******************************/

    delegate void NewsHandler(String title, String desc, DateTime when);

    sealed class SubscriberWrapper : Subscriber
    {
        NewsHandler handler;
        public SubscriberWrapper(NewsHandler handler)
        {
            this.handler = handler;
        }
        public void occurrence(string title, string desc, DateTime when)
        {
            handler(title, desc, when);
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;
            SubscriberWrapper wrapper = (SubscriberWrapper)obj;
            return handler.Equals(wrapper.handler);
        }
        public override int GetHashCode()
        {
            return handler.GetHashCode();
        }
    }

    class NewsworldWrapper
    {
        Newsworld newsworld = new Newsworld();

        public event NewsHandler NewsworldEvent
        {
            add
            {
                newsworld.AddSubscriber(new SubscriberWrapper(value));
            }
            remove
            {
                newsworld.RemoveSubscriber(new SubscriberWrapper(value));
            }
        }

        /*---*/
        public void PublishEvent(String title, String news, DateTime date)
        {
            if (newsworld != null)
            {
                newsworld.PublishNews(title, news, date);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            NewsworldWrapper newsworld = new NewsworldWrapper();
            newsworld.NewsworldEvent += (t, desc, dt) => Console.WriteLine("{0} ({1}): {2}", t, desc, dt);

        }
    }
}
