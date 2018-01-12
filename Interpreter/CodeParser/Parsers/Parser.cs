using System.Text.RegularExpressions;

namespace Interpreter.CodeParser.Parsers
{
	public abstract class Parser
	{
		private string loopRegexTemplate = @"{%@((.|\n)*?)%}((.|\n)*){%@%}";
		private string conditionRegexTemplate = @"{%\?((.|\n)*?)%}((.|\n)*){%\?%}";
		private string arithmeticalRegexTemplate = @"{%=((.|\n)*?)%}";
		private string simpleCodeRegexTemplate = @"{%((.|\n)*?)%}";
		private string refactorCodeRegexTemplate = @"({%((.|\n)*?)%})(.[^{%]*)";
		public virtual string Parse(string code, Variable[] variables, string[] values)
		{
			return string.Empty;
		}

		protected string ConvertToDateTime(string dateTime)
		{
			string[] splittedDate = dateTime.Split('.');
			return $"{splittedDate[2]}, {splittedDate[1]}, {splittedDate[0]}";
		}
		protected string ReplaceConditionExpression(string code, string conditionRuntimeReplacement)
		{
			return ReplaceAll(conditionRegexTemplate, code, conditionRuntimeReplacement);
		}
		protected string ReplaceLoopExpression(string code, string loopRuntimeReplacement)
		{
			return ReplaceAll(loopRegexTemplate, code, loopRuntimeReplacement);
		}
		protected string ReplaceArithmeticalExpression(string code, string arithmeticalRuntimeReplacement)
		{
			return ReplaceAll(arithmeticalRegexTemplate, code, arithmeticalRuntimeReplacement);
		}
		protected string ReplaceSimpleExpression(string code, string refactorRuntimeReplacement, string simpleRuntimeReplacement)
		{
			var result = ClearSimple(refactorCodeRegexTemplate, code, refactorRuntimeReplacement);
			return ReplaceAll(simpleCodeRegexTemplate, code, simpleRuntimeReplacement);
		}
		protected string ClearSimple(string regex, string code, string resultTemplate)
		{
			Regex pattern = new Regex(regex);
			string result = code;
			while (pattern.Match(result).Success)
			{
				result = pattern.Replace(result, resultTemplate);
				break;
			}
			return result;
		}
		protected string ReplaceAll(string regex, string code, string resultTemplate)
		{
			Regex pattern = new Regex(regex);
			string result = code;
			while (pattern.Match(result).Success)
			{
				result = pattern.Replace(result, resultTemplate);
			}
			return result;
		}
	}	
}