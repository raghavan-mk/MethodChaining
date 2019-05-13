using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace events {
    class Program {
        static readonly object _lock = new object ();
        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");
            DelegateTest dt = new DelegateTest ();
            dt.AddNum += AddNumHandler;
            dt.Del += async () => await Del1_Handler();
            for (int i = 0; i < 2; i++) {
                Console.WriteLine ($"event {i} fired");
                dt.RaiseEvent ();
            }
            Derived d = new Derived ();
            d.DerivedMethod ();
            d.ImplAbsMethod ();
            d.RealAbsMethod ();
        }

        async static Task Del1_Handler(){
            await Task.Delay(100);
        }
        static void AddNumHandler (Object sender, int e) {
            Console.WriteLine ($"event {e} entered subscribed event");
            System.Threading.Thread.Sleep (1000);
            lock (_lock) {
                var x = e;
                Console.WriteLine ($"event {x} subscribed");
            }
        }

    }

    public class DelegateTest {

        public delegate Task Del1 ();
        public event Del1 Del;
        public event EventHandler<int> AddNum = delegate { };

        public void RaiseEvent () {
            AddNum?.Invoke (this, 10);
            Del1 d = async () => { await Task.Delay(10); Console.WriteLine ("");};
            d ();
        }

        public void RaiseEventDel1 () => Del?.Invoke ();

        public void DoNothing () => Console.WriteLine ("");

    }
    //     public int Num { get; set; }

    //     public Args (int x) => this.Num = x;
    // }

    public abstract class Abstract {

        protected Abstract () => Console.WriteLine ("In abs ctr");
        protected void AbstractMethod () => Console.WriteLine ("In abs method");

        public abstract void RealAbsMethod ();
        public virtual void ImplAbsMethod () => Console.WriteLine ("In ImplAbsMethod");
    }

    public class Derived : Abstract {

        public Derived () => Console.WriteLine ("In derived ctr");
        public void DerivedMethod () => base.AbstractMethod ();

        public override void ImplAbsMethod () {
            base.ImplAbsMethod ();
            Console.WriteLine ("In derived method");
        }

        public override void RealAbsMethod () {
            // throw new NotImplementedException ();
        }
    }

    public class DerivedFromDerived : Derived{

    }
}