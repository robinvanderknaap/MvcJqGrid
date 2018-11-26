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

            var errors = string.Join(", ", result.Errors.Select(x => $"line: {x.StartLine}:{x.EndLine}, column: {x.StartColumn}:{x.EndColumn}, error: {x.Message}"));
            Assert.IsTrue(result.IsValid, $"Error(s) while compiling: {errors}");          
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
