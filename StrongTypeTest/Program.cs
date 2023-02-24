// See https://aka.ms/new-console-template for more information

namespace StrongTypeTest;

public class StrongTypedef<T>
{
    protected StrongTypedef(T t)
    {
        Underlying = t;
    }

    public T Underlying { get; }

    public override string ToString()
    {
        return $"{Underlying}";
    }
}

public class StringParam : StrongTypedef<string>
{
    protected StringParam(string s) : base(s)
    {
        if (string.IsNullOrWhiteSpace(s))
            throw new ArgumentException("Parameter " + GetType() + " must be assigned");
    }
}

public class TestParam : StringParam
{
    public TestParam(string s) : base(s)
    {
    }
}

public static class StrongTypeTest
{
    public static void Main(string[] args)
    {
        try
        {
            Console.WriteLine(new TestParam("Assigned!").ToString());
            Console.WriteLine(new TestParam("").ToString());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}