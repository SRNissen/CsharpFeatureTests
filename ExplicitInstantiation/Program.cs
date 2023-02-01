// See https://aka.ms/new-console-template for more information

namespace ExplicitInstantiation;

internal class StringWrapper
{
    public StringWrapper(string s)
    {
        Wrapped = s;
    }

    public string Wrapped { get; set; } = "";

    public static void PrintTheWrappedValue(StringWrapper wrapper)
    {
        Console.WriteLine(wrapper.Wrapped);
    }
}

public static class ExplicitInstantiation
{
    public static void Main(string[] args)
    {
        // StringWrapper.PrintTheWrappedValue("test");
        //                                      ^
        //                                      |
        //                                      +--- "test" is not a StringWrapper, and so cannot be passed to the function thank God: error CS1503
        //
    }
}