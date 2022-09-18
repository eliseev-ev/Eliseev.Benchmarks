// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

var summary = BenchmarkRunner.Run(typeof(Program).Assembly);

public class AsIs
{
    private readonly A a = new A();
    private readonly B<A> b = new B<A>();
    private readonly Type aType = typeof(A);
    private readonly Type bType = typeof(B<>);


    [Benchmark]
    public void As()
    {
        ////GetTypeAs(a);
        ////GetTypeAs(b);
        GetTypeAs(aType);
        GetTypeAs(bType);
    }

    [Benchmark]
    public void Is()
    {
        ////GetTypeIs(a);
        ////GetTypeIs(b);
        GetTypeIs(aType);
        GetTypeIs(bType);
    }

    private Type GetTypeAs<T>(T source)
    {
        return source as Type ?? source.GetType();
    }

    private Type GetTypeIs<T>(T source)
    {
        return source is Type type ? type : source.GetType();
    }
}

public class A { }
public class B<T> { }

