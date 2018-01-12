using System.IO;
using Interpreter.CodeParser.Compilers;
using Interpreter.CodeParser.Parsers;

namespace Interpreter.CodeParser.Languages
{
	public class Java : Language
	{
		private JavaCompiler compiler;
		private string executableCode;
		public Java()
		{
			parser = new JavaParser();
			executableCode = string.Empty;
		}

		public override string Render()
		{
			executableCode += ((JavaParser)parser).Parse(codeTemplate, variables, values);
			using (compiler = new JavaCompiler())
			{
				compiler.Compile(executableCode);
			}
			return compiler.Result;
		}

		public override void SetCompilerParameters(string parameters)
		{
			executableCode += parameters;
		}
	}
}
