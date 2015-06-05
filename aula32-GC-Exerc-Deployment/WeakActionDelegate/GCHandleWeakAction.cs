using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace WeakActionDelegate
{
    sealed class GCHandleWeakAction<T> : IDisposable
    {
        GCHandle weakDel;
        GCHandle weakTarget;
        MethodInfo mi;
        private bool disposed;

        public GCHandleWeakAction(Action<T> action)
        {
            weakDel = GCHandle.Alloc(action, GCHandleType.Weak);
            weakTarget = GCHandle.Alloc(action.Target, GCHandleType.Weak);
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
            if (obj.GetType() != typeof(GCHandleWeakAction<T>))
            {
                return false;
            }

            GCHandleWeakAction<T> other = (GCHandleWeakAction<T>)obj;
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

        public void Dispose()
        {
            if (!disposed)
            {
                InternalDispose();
                GC.SuppressFinalize(this);
                disposed = true;
            }
        }

        private void InternalDispose()
        {
            weakDel.Free();
            weakTarget.Free();
        }

        ~GCHandleWeakAction()
        {
            InternalDispose();
        }
    }
}
