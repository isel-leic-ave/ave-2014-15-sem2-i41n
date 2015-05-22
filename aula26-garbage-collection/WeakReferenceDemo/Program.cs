using System;
using System.Collections.Generic;
using System.Text;

namespace WeakReferenceDemo
{
    class WRCache<Key>
    {
        public delegate Object FactoryMethod(Key key);
        public WRCache(FactoryMethod factory)
        {
            cache = new Dictionary<Key, WeakReference>();
            this.factory = factory;
        }
        public Object Get(Key key)
        {
            WeakReference wr=null;
            if (!cache.TryGetValue(key, out wr)) {
                cache.Add(key, null);
            }
            if ((wr == null) || (wr.Target==null))
            {
                wr = new WeakReference(factory(key));
                cache[key] =  wr;
            }
            return wr.Target;
                
        }
        private Dictionary<Key, WeakReference> cache;
        private FactoryMethod factory;
    }

    //class Program
    //{
    //    static Object MyFactory(int id)
    //    {
    //        return new byte[1024*100];
    //    }
    //    static void Main(string[] args)
    //    {
    //        //WRCache<int> wrcache = new WRCache<int>(MyFactory);
    //        //Console.WriteLine(wrcache.Get(1).GetHashCode());
    //        //Console.WriteLine(wrcache.Get(2).GetHashCode());
    //        //Console.WriteLine(wrcache.Get(1).GetHashCode());
    //        //GC.Collect();
    //        //Console.WriteLine(wrcache.Get(2).GetHashCode());
    //    }
    //}

    class Teste1
    {
        public static void m1(int a)
        {
            Console.WriteLine(a);
        }

        public static void Main()
        {
            Action<int> a = m1;
            WeakActions<int> wa = new WeakActions<int>();
            for (int i = 0; i < 5; ++i)
                wa.Actions += m1;
            // 1
            GC.Collect();
            wa.Actions += a;
            // 2
            GC.Collect();
            GC.WaitForPendingFinalizers();
            // 3      
            wa.Invoke(5);
        }
    }


    class WeakActions<T>
    {
        private WeakReference _Actions;
        public event Action<T> Actions
        {
            add
            {
                if (_Actions == null)
                {
                    _Actions = new WeakReference(value);
                }
                else
                {
                    if (_Actions.Target == null)
                        _Actions.Target = value;
                    else
                    {
                        Action<T> del =
                          (Action<T>)_Actions.Target;
                        if (del.GetInvocationList().Length < 2)
                            del += value;
                    }
                }
            }
            remove { }
        }
        public void Invoke(T a)
        {
            Action<T> action = (Action<T>)_Actions.Target;
            if (action != null)
                action(a);
        }
        ~WeakActions()
        {
            _Actions = null;
        }
    }

}
