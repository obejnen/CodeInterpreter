using Interpreter.CodeParser.Compilers;
using Interpreter.CodeParser.Parsers;

namespace Interpreter.CodeParser.Languages
{
	public class Python : Language
	{
		private PythonCompiler compiler;
		private string executableCode;
		public Python()
		{
			parser = new PythonParser();
			executableCode = string.Empty;
		}

		public override string Render()
		{
			executableCode += ((PythonParser)parser).Parse(codeTemplate, variables, values);
			using (compiler = new PythonCompiler())
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
