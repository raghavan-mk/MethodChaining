using System;

class Foo
{
    public Foo(string s)
    {
        Console.WriteLine("Foo constructor: {0}", s);
    }
    public void Bar() { }
} 
class Base
{
    readonly Foo baseFoo = new Foo("Base initializer");
    public Base()
    {
        Console.WriteLine("Base constructor");
    }
} 
class Derived : Base
{
    readonly Foo derivedFoo = new Foo("Derived initializer");
    public Derived()
    {
        Console.WriteLine("Derived constructor");
    }
} 
static class Program
{
    delegate int Add(int a, int b);
    static void Main1()
    {
        //new Derived();   

        Add a = new Add(Add_1);
        Console.WriteLine(a.Invoke(1,2));
        Console.WriteLine(a(1,2));

        Add add1  = delegate (int aa,int b){
            return aa+b;
        };

        Add addlambda = (a2,b2) => a2+b2;

        Func<int,int,int> addFunc = (a3, b3) => a3+b3;

        Add addFunc_ = new Add(addFunc);
        Console.WriteLine(addFunc_(100,100));
        
        Console.WriteLine(add1(10,10));
    }

    static int Add_1(int a, int b){
        return a+b;
    }

    static int Add_Func(int i, Func<int,int> fn){
        return fn(i);
    }

    static TResult Add_func<TSource, TResult>
    (TSource src, Func<TSource,TResult> fn)
    {
        return fn(src);
    }
}