using System;
using System.Collections;
using System.Text;
using System.Linq;

namespace TestCoverageReportSample.Lib1
{
    public static class CollectionExtension
    {
        public static string TextJoin(this IEnumerable enumerable, string separator)
        {
            if (enumerable == null)
            {
                throw new ArgumentNullException(nameof(enumerable));
            }

            StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach (var item in enumerable)
            {
                if (i++ != 0)
                {
                    sb.Append(separator);
                }

                sb.Append(item?.ToString());
            }

            return sb.ToString();
        }
    }
}
