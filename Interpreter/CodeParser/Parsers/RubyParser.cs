namespace Interpreter.CodeParser.Parsers
{
	public class RubyParser : Parser
	{
		private string redirectFunction = "def redirect(text)file = File.open(\"output.txt\", \"w\");file.print(text);file.close;end\n";
		private string loopCode = "def renderLoop(count, text)result = '';count.times{ result += text };result;end\noutput = \"\";";

		private string loopRuntimeReplacement = @""" + ""#{renderLoop($1, ""#{""$3""}"")}"" + """;
		private string conditionRuntimeReplacement = @""" + ""#{$1 ? ""$3"" : """"}"" + """;
		private string arithmeticalRuntimeReplacement = @""" + ""#{$1}"" + """;
		private string simpleRuntimeReplacement = @""";$1output+=""";
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
			innerCode += "redirect(output)";

			return innerCode;
		}

		private string GetFunctions()
		{
			return $"{loopCode}{redirectFunction}";
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
