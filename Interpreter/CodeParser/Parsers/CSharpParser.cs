namespace Interpreter.CodeParser.Parsers
{
	public class CSharpParser : Parser
	{
		private string headerCode = "public class Cl { public string Main() { string output = string.Empty;";

		private string loopCode =
			"public string RenderLoop(int count, string text){string result = string.Empty;for (int i = 0; i < count; i++)" +
			"{ result += text;}return result;}";

		private string loopRuntimeReplacement = @""" + string.Format(""{0}"", RenderLoop($1, string.Format(""{0}"", ""$3""))) + """;
		private string conditionRuntimeReplacement = @""" + string.Format(""{0}"", ($1 ? ""$3"" : """")) + """;
		private string arithmeticalRuntimeReplacement = @""" + string.Format(""{0}"", $1) + """;
		private string simpleRuntimeReplacement = @""";$1output+=""";
		private string refactorRuntimeReplacement = @"$1 output += ""$4"";";

		public override string Parse(string code, Variable[] variables, string[] values)
		{
			string executableCode = RenderExecutableCode(code, variables, values);
			return executableCode;
		}

		private string RenderExecutableCode(string code, Variable[] variables, string[] values)
		{
			string innerCode = GetHeaderCode();
			innerCode += AppendVariables(variables, values);
			innerCode += GetInnerCode(code);
			innerCode += GetOutput();
			innerCode += GetFunctions();
			return innerCode;
		}

		private string GetHeaderCode()
		{
			return headerCode;
		}

		private string GetFunctions()
		{
			return $"{loopCode}" + "}";
		}

		private string GetOutput()
		{
			return "return output;}";
		}

		private string GetInnerCode(string code)
		{
			string innerCode = @"output += """;
			innerCode += ReplaceLoopExpression(code, loopRuntimeReplacement);
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
				result += variables[i].Type == ArgumentType.DateTime
					? $"{variables[i].Type.ToString()} {variables[i].Name} = new {variables[i].Type.ToString()}({ConvertToDateTime(values[i])});"
					: $"{variables[i].Type.ToString().ToLower()} {variables[i].Name} = {values[i]};";
			}
			return result;
		}
	}
}
