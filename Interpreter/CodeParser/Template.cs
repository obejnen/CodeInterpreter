using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Interpreter.CodeParser.Languages;
using Interpreter.CodeParser.Parsers;

namespace Interpreter.CodeParser
{
	public class Template
	{
		private readonly string codeTemplate;
		private readonly Variable[] variables;
		private string executableCode;
		private CompilerParameters parameters;
		private List<string> namespaces;
		private readonly IRenderable language;

		public Template(IRenderable language, string codeTemplate, string[] libraries, params Variable[] variables)
		{
			this.codeTemplate = codeTemplate;
			this.variables = variables;
			AppendLibraries(libraries);
			executableCode = string.Empty;
			this.language = language;
			AppendLibraries(libraries);
		}

		public void Render(System.IO.TextWriter output, params string[] values)
		{
			language.SetRenderParameters(codeTemplate, variables, values);
			language.SetCompilerParameters(namespaces);
			language.SetCompilerParameters(executableCode);
			output.Write(language.Render());
		}

		private void AppendLibraries(string[] libraries)
		{
			namespaces = new List<string>();
			foreach (string library in libraries)
			{
				AppendNameSpace(library);
				AppendPackage(library);
			}
		}

		private void AppendNameSpace(string library)
		{
			//parameters.ReferencedAssemblies.Add(library);
			namespaces.Add(library);
		}

		private void AppendPackage(string library)
		{
			executableCode += $"import {library};";
		}
	}
}
