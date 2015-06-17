using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DelegateMaxCalls
{

    public class NotifyArgs { }

    public delegate void NotifyHandler(NotifyArgs arg);

    [AttributeUsage(AttributeTargets.Method)]
    public class MaxCallsAttribute : Attribute
    {
        private int maxCalls = Int32.MaxValue;
        public MaxCallsAttribute(int max) { maxCalls = max; }
        public int MaxCalls
        {
            get { return maxCalls; }
            set { maxCalls = value; }
        }
    }


    public class Aula38
    {
        private class Pair<T, W>
        {
            public T Item1 { get; set; }
            public W Item2 { get; set; }
        }
        public static NotifyHandler MakeNotifier(Type klass)
        {
            Object _this = null;
            List<Pair<int, NotifyHandler>> maxCallsRecord = new List<Pair<int, NotifyHandler>>();
            foreach (MethodInfo mi in klass.GetMethods())
            {
                MaxCallsAttribute attr = (MaxCallsAttribute)
                    Attribute.GetCustomAttribute(mi, typeof(MaxCallsAttribute));
                if (attr != null
                    && mi.ReturnType == typeof(void)
                    && mi.GetParameters().Length == 1
                    && mi.GetParameters()[0].ParameterType == typeof(NotifyArgs))
                {
                    NotifyHandler d;
                    if (mi.IsStatic)
                    {
                        d = (NotifyHandler)Delegate.CreateDelegate(
                            typeof(NotifyHandler),
                            mi);
                    }
                    else
                    {
                        if (_this == null)
                        {
                            _this = Activator.CreateInstance(klass);
                        }
                        d = (NotifyHandler)Delegate.CreateDelegate(
                            typeof(NotifyHandler), _this, mi);
                    }
                    Pair<int, NotifyHandler> pair = new Pair<int, NotifyHandler>();
                    pair.Item1 = attr.MaxCalls;
                    pair.Item2 = d;
                    maxCallsRecord.Add(pair);
                }
            }
            return args =>
            {
                foreach (Pair<int, NotifyHandler> p in maxCallsRecord)
                {
                    if (p.Item1 > 0)
                    {
                        p.Item1--;
                        p.Item2(args);
                    }
                }
            };
        }


        static void Main(string[] args)
        {
            // Demo
            NotifyHandler h = MakeNotifier(typeof(Handlers));
            h(null); // M1, M2
            h(null); // M1
            h(null); // ()
        }
    }
}
