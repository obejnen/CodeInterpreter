using System.CodeDom.Compiler;
using System.Collections.Generic;
using Interpreter.CodeParser.Compilers;
using Interpreter.CodeParser.Parsers;

namespace Interpreter.CodeParser.Languages
{
	public class CSharp : Language
	{
		private readonly CSharpCompiler compiler;
		public CSharp()
		{
			parser = new CSharpParser();
			compiler = new CSharpCompiler();
		}

		public override string Render()
		{
			string executableCode = ((CSharpParser)parser).Parse(codeTemplate, variables, values);
			compiler.Compile(executableCode);
			return compiler.Result;
		}

		public override void SetCompilerParameters(List<string> parameters)
		{
			compiler.ChangeParameters(parameters);
		}
	}
}
