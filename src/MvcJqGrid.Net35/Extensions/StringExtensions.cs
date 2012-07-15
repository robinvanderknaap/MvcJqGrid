using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcJqGrid.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrWhiteSpace(this string value)
        {
            if (value == null) return true;
            return string.IsNullOrEmpty(value.Trim());
        }
    }
}
