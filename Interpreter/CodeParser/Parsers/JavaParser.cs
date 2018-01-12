namespace Interpreter.CodeParser.Parsers
{
	public class JavaParser : Parser
	{
		private string loopCode =
				"public String renderLoop(int count, String text){String result = \"\";for (int i = 0; i < count; i++){result += text;}return result;}";

		private string javaHeaderCode = "import java.io.File;import java.util.Calendar;import java.text.MessageFormat;import java.io.FileOutputStream;import java.io.OutputStream;import java.nio.file.Files;public class tempCode{" +
										"public static void main(String[] args) throws Exception{File outputFile = new File(\"output.txt\");outputFile.createNewFile();" +
										"try {Cl cl = new Cl();String result = cl.execute();if (outputFile.exists()) {OutputStream os = new FileOutputStream(outputFile);" +
										"os.write(result.getBytes(), 0, result.length());}} catch (Exception e) {if (outputFile.exists()) {OutputStream os = new FileOutputStream(outputFile);" +
										"String ex = \"TemplateRuntimeException\";os.write(ex.getBytes(), 0, ex.length());}}}}class Cl{public String execute(){String output = \"\";";

		private string loopRuntimeReplacement = @""" + MessageFormat.format(""{0}"", renderLoop($1, MessageFormat.format(""{0}"", ""$3""))) + """;
		private string conditionRuntimeReplacement = @""" + MessageFormat.format(""{0}"", ($1 ? ""$3"" : """")) + """;
		private string arithmeticalRuntimeReplacement = @""" + MessageFormat.format(""{0}"", $1) + """;
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

		private string GetFunctions()
		{
			return $"{loopCode}" + "}";
		}

		private string GetHeaderCode()
		{
			return javaHeaderCode;
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
				var name = variables[i].Type == ArgumentType.String
					? variables[i].Type.ToString()
					: variables[i].Type.ToString().ToLower();
				result += variables[i].Type == ArgumentType.Calendar
					? $"{variables[i].Type.ToString()} {variables[i].Name} = new {variables[i].Type.ToString()}({ConvertToDateTime(values[i])});"
					: $"{name} {variables[i].Name}= {values[i]};";
			}
			return result;
		}
	}
}
