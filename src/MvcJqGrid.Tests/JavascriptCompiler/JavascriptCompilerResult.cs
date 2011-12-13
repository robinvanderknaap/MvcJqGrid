using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MvcJqGrid.Tests.JavascriptCompiler
{
    public class JavascriptCompilerResult
    {
        public JavascriptCompilerResult()
        {
            Errors = new Collection<CompilerError>();
        }

        public bool IsValid 
        { 
            get { return !HasErrors; }
        }

        public bool HasErrors
        {
            get { return Errors.Count > 0; }
        }

        public ICollection<CompilerError> Errors { get; set; } 
    }
}
