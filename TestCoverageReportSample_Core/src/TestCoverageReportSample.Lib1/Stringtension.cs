using System.Globalization;

namespace TestCoverageReportSample.Lib1
{
    public static class StringExtension
    {
        public static int StringLength(this string value)
        {
            return new StringInfo(value).LengthInTextElements;
        }
    }
}
