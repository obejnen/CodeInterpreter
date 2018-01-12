namespace Interpreter.CodeParser.Parsers
{
	public class PythonParser : Parser
	{
		private string redirectFunction = "import sys;\ndef redirect(text):\n\toriginal = sys.stdout\n\tsys.stdout = open('output.txt', 'w')\n\tprint(text, end=\"\")\n\tsys.stdout = original";
		private string loopFunction = "def renderLoop(count, text):\n\tresult = \"\"\n\tfor i in range(count):\n\t\tresult += text\n\treturn result\noutput = \"\"";

		private string loopRuntimeReplacement = @""" + ""{0}"".format(renderLoop($1, ""{0}"".format(""$3""))) + """;
		private string conditionRuntimeReplacement = @""" + ""{0}"".format(""$3"" if $1 else """") + """;
		private string arithmeticalRuntimeReplacement = @""" + ""{0}"".format($1) + """;
		private string simpleRuntimeReplacement = "\";\n$1output+=\"";
		private string refactorRuntimeReplacement = @"$1 output += ""$4"";";

		public override string Parse(string code, Variable[] variables, string[] values)
		{
			string executableCode = RenderExecutableCode(code, variables, values);
			return executableCode;
		}

		private string RenderExecutableCode(string code, Variable[] variables, string[] values)
		{
			string innerCode = GetFunctions();
			innerCode += AppendVariables(variables, values);
			innerCode += ReplaceExpressions(code);
			innerCode += GetOutput();
			return innerCode;
		}

		private string GetOutput()
		{
			return "\nredirect(output);";
		}

		private string GetFunctions()
		{
			return $"{redirectFunction}\r\n{loopFunction}\r\n";
		}

		private string ReplaceExpressions(string code)
		{
			string innerCode = ReplaceLoopExpression(code, loopRuntimeReplacement);
			innerCode = ReplaceConditionExpression(innerCode, conditionRuntimeReplacement);
			innerCode = ReplaceArithmeticalExpression(innerCode, arithmeticalRuntimeReplacement);
			innerCode = ReplaceSimpleExpression(innerCode, refactorRuntimeReplacement, simpleRuntimeReplacement);

			return innerCode + @""";";
		}

		private string AppendVariables(Variable[] variables, string[] values)
		{
			string result = string.Empty;
			for (int i = 0; i < variables.Length; i++)
			{
				result += $"{variables[i].Name} = {values[i]};";
			}
			return result + @"output += """;
		}
	}
}
