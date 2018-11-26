using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NUglify;

namespace MvcJqGrid.Tests.JavascriptCompiler
{
    public class JavascriptCompilerResult
    {
        public JavascriptCompilerResult()
        {
            Errors = new Collection<UglifyError>();
        }

        public bool IsValid 
        { 
            get { return !HasErrors; }
        }

        public bool HasErrors
        {
            get { return Errors.Count > 0; }
        }

        public ICollection<UglifyError> Errors { get; set; } 
    }
}
