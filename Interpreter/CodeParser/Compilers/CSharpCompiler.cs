using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;

namespace Interpreter.CodeParser.Compilers
{
	class CSharpCompiler : ICompilable
	{
		private string result;
		private CompilerParameters compilerParameters;
		private CodeCompileUnit compileUnit;
		private List<string> namespaces;
		public string Result => result;

		public CSharpCompiler()
		{
			compilerParameters = new CompilerParameters{ GenerateInMemory = true };
			compileUnit = new CodeCompileUnit();
		}

		public void Compile(string code)
		{
			File.WriteAllText("code.cs", code);
			object output;
			using (Microsoft.CSharp.CSharpCodeProvider foo = new Microsoft.CSharp.CSharpCodeProvider())
			{
				compilerParameters.EmbeddedResources.AddRange(namespaces.ToArray());
				compilerParameters.GenerateInMemory = true;
				var res = foo.CompileAssemblyFromSource(compilerParameters, code);

				var type = res.CompiledAssembly.GetType("Cl");

				var obj = Activator.CreateInstance(type);

				output = type.GetMethod("Main")?.Invoke(obj, new object[] { });
			}
			result = output?.ToString();
		}

		public void ChangeParameters(List<string> namespaces)
		{
			this.namespaces = namespaces;
		}
	}
}
