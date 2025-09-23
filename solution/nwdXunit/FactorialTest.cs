using System;
using nwdClassLib;

namespace nwdXunit;

public class FactorialTest
{
    [Fact]
    public void If_0_then_1()
    {
        int a = 0;
        int expected = 1;
        Factorial factorial = new Factorial();
        Assert.Equal(expected, factorial.Calculate(a));
    }
     [Fact]
    public void If_5_then_120()
    {
        int a = 5;
        int expected = 120;
        Factorial factorial = new Factorial();
        Assert.Equal(expected, factorial.Calculate(a));
    }
}
