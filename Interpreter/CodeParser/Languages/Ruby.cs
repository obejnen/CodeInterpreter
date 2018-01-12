using System;
using Interpreter.CodeParser.Compilers;
using Interpreter.CodeParser.Parsers;

namespace Interpreter.CodeParser.Languages
{
	public class Ruby : Language
	{
		private RubyCompiler compiler;
		private string executableCode;
		public Ruby()
		{
			compiler = new RubyCompiler();
			parser = new RubyParser();
			executableCode = String.Empty;
		}

		public override string Render()
		{
			executableCode += ((RubyParser)parser).Parse(codeTemplate, variables, values);
			using (compiler = new RubyCompiler())
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
