using System;
using System.Collections.Generic;

namespace events {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");
            DelegateTest dt = new DelegateTest ();
            dt.AddNum +=  AddNumHandler;                        
            dt.RaiseEvent ();
            Derived d = new Derived();
            d.DerivedMethod();
            d.ImplAbsMethod();
            d.RealAbsMethod();
        }

        static void AddNumHandler(Object sender, int e) => Console.WriteLine(e);

    }

    public class DelegateTest {

        public delegate void Del1();
        public event Del1 Del;
        public event EventHandler<int> AddNum = delegate { };

        public void RaiseEvent () {
            AddNum?.Invoke (this, 10);
            Del1 d = () => Console.WriteLine("");
            d();
        }

        public void RaiseEventDel1() => Del?.Invoke();

        public void DoNothing() => Console.WriteLine("");

    }

    public class Args : EventArgs{
        public int Num { get; set; }

        public Args(int x) => this.Num = x;
    }

    public abstract class Abstract{

        protected Abstract() => Console.WriteLine("In abs ctr");
        protected void AbstractMethod() => Console.WriteLine("In abs method");   

        public abstract void RealAbsMethod();     
        public virtual void ImplAbsMethod() => Console.WriteLine("In ImplAbsMethod");
    }

    public class Derived : Abstract{

        public Derived() => Console.WriteLine("In derived ctr");
        public void DerivedMethod() => base.AbstractMethod();

        public override void ImplAbsMethod() 
        {
            base.ImplAbsMethod();
            Console.WriteLine("In derived method");
        }

        public override void RealAbsMethod()
        {
            throw new NotImplementedException();
        }
    }
}