using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace MvcJqGrid.Tests.JavascriptCompiler
{
    public static class JavascriptAssert
    {
        private static readonly JavaScriptCompiler JavascriptCompiler = new JavaScriptCompiler();
        
        public static void IsValid(string javascript, List<string> ignoreRuleCodes)
        {
            JavascriptCompiler.AddIgnoreRules(ignoreRuleCodes);

            var result = JavascriptCompiler.Compile(javascript);

            JavascriptCompiler.RemoveIgnoreRules(ignoreRuleCodes);

            Assert.IsTrue(result.IsValid, "Error(s) while compiling: {0}",
                string.Join(", ", result.Errors.Select(x =>
                        string.Format("line: {0}, column: {1}, error: {2}", x.Line, x.Column, x.ErrorText)
                        ).ToList()));          
        }

        public static void IsValid(string javascript)
        {
            IsValid(javascript, new List<string>());    
        }

        public static void IsInvalid(string javascript)
        {
            var result = JavascriptCompiler.Compile(javascript);

            Assert.IsFalse(result.IsValid);   
        }
    }
}
