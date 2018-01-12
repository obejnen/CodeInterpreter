using System;
using System.IO;
using Interpreter.CodeParser;
using Interpreter.CodeParser.Languages;

namespace Interpreter
{
	class Program
	{
		static void Main(string[] args)
		{
			string input = "{%=5%}";
			var template = new Template(new Ruby(), input, new string[0]);
			{
				using (var output = new StringWriter())
				{
					template.Render(output);
					Console.WriteLine(output);
				}
			}
		}
	}
}
