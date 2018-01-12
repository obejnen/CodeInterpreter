using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace Interpreter.CodeParser.Languages
{
	public interface IRenderable
	{
		string Render();

		void SetRenderParameters(string code, Variable[] variables, string[] values);

		void SetCompilerParameters(List<string> namespaces);

		void SetCompilerParameters(string parameters);
	}
}
