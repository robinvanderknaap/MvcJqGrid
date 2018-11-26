using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUglify;

namespace MvcJqGrid.Tests.JavascriptCompiler
{
	/// <summary>
	/// Orginal source from http://madskristensen.net/post/Verify-JavaScript-syntax-using-C.aspx
	/// </summary>
	public class JavaScriptCompiler
	{
		#region Private fields

		readonly StringBuilder _errorMessages = new StringBuilder();

		/// <summary>
		/// A list of error codes to ignore.
		/// </summary>
		/// <remarks>
		/// See all error codes at http://msdn.microsoft.com/en-us/library/9c5scey5(VS.71).aspx
		/// </remarks>
		private readonly List<string> _ignoredRules = new List<string>
		{
			"JS1135", "JS1028", "JS1234", "JS5040", "JS1151", "JS0438", "JS1204"
		};

		#endregion

		public void AddIgnoreRule(string ruleCode)
		{
			_ignoredRules.Add(ruleCode);
		}

		public void AddIgnoreRules(List<string> ruleCodes)
		{
			ruleCodes.ForEach(AddIgnoreRule);
		}

		public void RemoveIgnoreRules(List<string> ruleCodes)
		{
			ruleCodes.ForEach(RemoveIgnoreRule);
		}

		public void RemoveIgnoreRule(string ruleCode)
		{
			_ignoredRules.Remove(ruleCode);
		}

		/// <summary>
		/// Gets the error message from the compiler.
		/// </summary>
		/// <value>The error message.</value>
		public string ErrorMessage
		{
			get { return _errorMessages.ToString(); }
		}

		/// <summary>
		/// Gets a value indicating whether the compilation encountered errors.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if the Javascript files have errors; otherwise, <c>false</c>.
		/// </value>
		public bool HasErrors
		{
			get { return _errorMessages.Length > 0; }
		}

		/// <summary>
		/// Compiles the specified Javascript files.
		/// </summary>
		/// <param name="files">The absolute file paths to .js files.</param>
		public IDictionary<string, JavascriptCompilerResult> Compile(params string[] files)
		{
			var compilerResults = new Dictionary<string, JavascriptCompilerResult>();

			foreach (var file in files)
			{
			    var source = File.ReadAllText(file);

			    var result = NUglify.Uglify.Js(source);
			    var javascriptCompilerResult = new JavascriptCompilerResult();

                foreach (var error in result.Errors)
			    {
			        javascriptCompilerResult.Errors.Add(error);
                }

				compilerResults.Add(file, javascriptCompilerResult);
			}

			return compilerResults;
		}                          

		public JavascriptCompilerResult Compile(string source)
		{
		    var result = NUglify.Uglify.Js(source);
			var javascriptCompilerResult = new JavascriptCompilerResult();

			foreach (var error in result.Errors)
			{
				javascriptCompilerResult.Errors.Add(error);
			}

			return javascriptCompilerResult;
		}

		private void WriteError(string file, UglifyError error)
		{
			_errorMessages.AppendLine("JavaScript compilation failed");
			_errorMessages.AppendLine("\tError code: " + error.ErrorNumber);
			_errorMessages.AppendLine("\t" + error.Message);
			_errorMessages.AppendLine("\t" + file + "(" + error.StartLine + ":" + error.EndLine +", " + error.StartColumn + ":" + error.EndColumn + ")");
			_errorMessages.AppendLine();
		}
	}
}
