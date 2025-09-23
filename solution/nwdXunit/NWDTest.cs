using System;

namespace nwdXunit;

public class NWDTest
{
    [Fact]
    public void If_8_and_12_then_4()
    {
        int a = 8;
        int b = 12;
        int expected = 4;
        var nwd = new nwdClassLib.Nwd();
        int result = nwd.Calculate(a, b);
        Assert.Equal(expected, result);
    }
    [Fact]
    public void If_0_and_12_then_12()
    {
        int a = 0;
        int b = 12;
        int expected = 12;
        var nwd = new nwdClassLib.Nwd();
        int result = nwd.Calculate(a, b);
        Assert.Equal(expected, result);
    }
    [Fact]
    public void If_minus8_and_minus12_then_4()
    {
        int a = -8;
        int b = -12;
        int expected = 4;
        var nwd = new nwdClassLib.Nwd();
        int result = nwd.Calculate(a, b);
        Assert.Equal(expected, result);
    }
    [Fact]
    public void If_0_and_0_then_0()
    {
        int a = 0;
        int b = 0;
        
        var nwd = new nwdClassLib.Nwd();
        Assert.Throws<ArgumentException>(() => nwd.Calculate(a, b));
    }
}