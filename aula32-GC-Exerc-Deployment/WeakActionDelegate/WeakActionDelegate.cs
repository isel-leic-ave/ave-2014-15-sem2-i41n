using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WeakActionDelegateExample
{
    sealed class WeakActionDelegate<T>
    {
        WeakReference weakDel;
        WeakReference weakTarget;
        MethodInfo mi;

        public WeakActionDelegate(Action<T> action)
        {
            weakDel = new WeakReference(action);
            weakTarget = new WeakReference(action.Target);
            mi = action.Method;
        }

        public void Invoke(T value)
        {
            Object target = weakTarget.Target;
            // if target was GCed, return
            if (target == null)
            {
                return;
            }
            Action<T> del = weakDel.Target as Action<T>;
            if (weakDel.Target == null)
            {
                del = (Action<T>) Delegate.CreateDelegate(typeof(Action<T>), target, mi);
                weakDel.Target = del;
            }
            del(value);
        }

        public override bool Equals(Object obj)
        {
            if (obj.GetType() != typeof(WeakActionDelegate<T>))
            {
                return false;
            }

            WeakActionDelegate<T> other = (WeakActionDelegate<T>)obj;
            if (mi != other.mi)
            {
                return false;
            }
            if (weakTarget == other.weakTarget && weakDel == other.weakDel)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return mi.GetHashCode() |
                (weakTarget.Target != null ? weakTarget.Target.GetHashCode() : 0) |
                (weakDel.Target != null ? weakDel.Target.GetHashCode() : 0);
        } 

        internal void Debug()
        {
            Console.WriteLine("Delegate for method({0}) is alive={1}, Target is alive {2}", 
                mi, 
                weakDel.IsAlive, 
                weakTarget.IsAlive);
        }
    }

}
