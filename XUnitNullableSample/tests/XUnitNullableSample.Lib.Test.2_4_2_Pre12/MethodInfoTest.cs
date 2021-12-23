using Xunit;

namespace XUnitNullableSample.Lib.Test._2_4_2_Pre12;

public class MethodInfoTest
{
    [Fact]
    public void Test1()
    {
        var type = typeof(SampleClass);
        var methodInfo = type.GetMethod("SampleMethod");

        Assert.NotNull(methodInfo);
        Assert.Equal("SampleMethod", methodInfo.Name);
    }
}
