using Microsoft.VisualStudio.TestTools.UnitTesting;
using Interpreter.CodeParser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interpreter.CodeParser.Languages;
using System.Text.RegularExpressions;

namespace Interpreter.CodeParser.Tests
{
	[TestClass()]
	public class TemplateTests
	{
		[TestMethod()]
		public void CSharpSimplePatternTest()
		{
			string input = "abcd";
			string result = "abcd";
			var template = new Template(new CSharp(), input, new string[0]);
			{
				using (var output = new StringWriter())
				{
					template.Render(output);
					Assert.AreEqual(result, output.ToString());
				}
			}
		}

		[TestMethod()]
		public void JavaSimplePatternTest()
		{
			string input = "abcd";
			string result = "abcd";
			var template = new Template(new Java(), input, new string[0]);
			{
				using (var output = new StringWriter())
				{
					template.Render(output);
					Assert.AreEqual(result, output.ToString());
				}
			}
		}

		[TestMethod()]
		public void RubySimplePatternTest()
		{
			string input = "abcd";
			string result = "abcd";
			var template = new Template(new Ruby(), input, new string[0]);
			{
				using (var output = new StringWriter())
				{
					template.Render(output);
					Assert.AreEqual(result, output.ToString());
				}
			}
		}

		[TestMethod()]
		public void PythonSimplePatternTest()
		{
			string input = "abcd";
			string result = "abcd";
			var template = new Template(new Python(), input, new string[0]);
			{
				using (var output = new StringWriter())
				{
					template.Render(output);
					Assert.AreEqual(result, output.ToString());
				}
			}
		}

		[TestMethod()]
		public void CSharpLoopPatternTest()
		{
			string input = "{%@3%}*{%@%}";
			string result = "***";
			var template = new Template(new CSharp(), input, new string[0]);
			{
				using (var output = new StringWriter())
				{
					template.Render(output);
					Assert.AreEqual(result, output.ToString());
				}
			}
		}

		[TestMethod()]
		public void JavaLoopPatternTest()
		{
			string input = "{%@3%}*{%@%}";
			string result = "***";
			var template = new Template(new Java(), input, new string[0]);
			{
				using (var output = new StringWriter())
				{
					template.Render(output);
					Assert.AreEqual(result, output.ToString());
				}
			}
		}

		[TestMethod()]
		public void RubyLoopPatternTest()
		{
			string input = "{%@3%}*{%@%}";
			string result = "***";
			var template = new Template(new Ruby(), input, new string[0]);
			{
				using (var output = new StringWriter())
				{
					template.Render(output);
					Assert.AreEqual(result, output.ToString());
				}
			}
		}

		[TestMethod()]
		public void PythonLoopPatternTest()
		{
			string input = "{%@3%}*{%@%}";
			string result = "***";
			var template = new Template(new Python(), input, new string[0]);
			{
				using (var output = new StringWriter())
				{
					template.Render(output);
					Assert.AreEqual(result, output.ToString());
				}
			}
		}

		[TestMethod()]
		public void CharpConditionPatternTest()
		{
			string input = "{%?5 > 3%}true{%?%}";
			string result = "true";
			var template = new Template(new CSharp(), input, new string[0]);
			{
				using (var output = new StringWriter())
				{
					template.Render(output);
					Assert.AreEqual(result, output.ToString());
				}
			}
		}

		[TestMethod()]
		public void JavaConditionPatternTest()
		{
			string input = "{%?5 > 3%}true{%?%}";
			string result = "true";
			var template = new Template(new Java(), input, new string[0]);
			{
				using (var output = new StringWriter())
				{
					template.Render(output);
					Assert.AreEqual(result, output.ToString());
				}
			}
		}

		[TestMethod()]
		public void RubyConditionPatternTest()
		{
			string input = "{%?5 > 3%}true{%?%}";
			string result = "true";
			var template = new Template(new Ruby(), input, new string[0]);
			{
				using (var output = new StringWriter())
				{
					template.Render(output);
					Assert.AreEqual(result, output.ToString());
				}
			}
		}

		[TestMethod()]
		public void PythonConditionPatternTest()
		{
			string input = "{%?5 > 3%}true{%?%}";
			string result = "true";
			var template = new Template(new Python(), input, new string[0]);
			{
				using (var output = new StringWriter())
				{
					template.Render(output);
					Assert.AreEqual(result, output.ToString());
				}
			}
		}

		[TestMethod()]
		public void CSharpArithmeticalPatternTest()
		{
			string input = "{%=7*10%}";
			string result = "70";
			var template = new Template(new CSharp(), input, new string[0]);
			{
				using (var output = new StringWriter())
				{
					template.Render(output);
					Assert.AreEqual(result, output.ToString());
				}
			}
		}

		[TestMethod()]
		public void JavaArithmeticalPatternTest()
		{
			string input = "{%=7*10%}";
			string result = "70";
			var template = new Template(new Java(), input, new string[0]);
			{
				using (var output = new StringWriter())
				{
					template.Render(output);
					Assert.AreEqual(result, output.ToString());
				}
			}
		}

		[TestMethod()]
		public void RubyArithmeticalPatternTest()
		{
			string input = "{%=7*10%}";
			string result = "70";
			var template = new Template(new Ruby(), input, new string[0]);
			{
				using (var output = new StringWriter())
				{
					template.Render(output);
					Assert.AreEqual(result, output.ToString());
				}
			}
		}

		[TestMethod()]
		public void PythonArithmeticalPatternTest()
		{
			string input = "{%=7*10%}";
			string result = "70";
			var template = new Template(new Python(), input, new string[0]);
			{
				using (var output = new StringWriter())
				{
					template.Render(output);
					Assert.AreEqual(result, output.ToString());
				}
			}
		}

		[TestMethod()]
		public void CSharpNamespacePatternTest()
		{
			string input = "{%System.Text.StringBuilder sb = new System.Text.StringBuilder(); sb.Append(\"Some text\"); output += sb.ToString();%}";
			string result = "Some text";
			var template = new Template(new CSharp(), input, new string[0]);
			{
				using (var output = new StringWriter())
				{
					template.Render(output);
					Assert.AreEqual(result, output.ToString());
				}
			}
		}

		[TestMethod()]
		public void JavaNamespacePatternTest()
		{
			string input = "{%=new Random(System.currentTimeMillis()).nextInt(15)%}";
			string result = "16";
			var template = new Template(new Java(), input, new string[]{"java.util.Random"});
			{
				using (var output = new StringWriter())
				{
					template.Render(output);
					Assert.AreNotEqual(result, output.ToString());
				}
			}
		}

		[TestMethod()]
		public void PythonNamespacePatternTest()
		{
			string input = "{%=random.randint(0, 9)%}";
			string result = "10";
			var template = new Template(new Python(), input, new string[] { "random" });
			{
				using (var output = new StringWriter())
				{
					template.Render(output);
					Assert.AreNotEqual(result, output.ToString());
				}
			}
		}

		[TestMethod()]
		public void CSharpComplexPatternTest()
		{
			string input = "first{% for(int i = 0; i < 2; i++){%}second{%}%}{%@2%}third{%? 5 < 2 %}fourth{%?%}fiveth{%@%}sixth";
			string result = "firstsecondsecondthirdfiveththirdfivethsixth";
			var template = new Template(new CSharp(), input, new string[0]);
			{
				using (var output = new StringWriter())
				{
					template.Render(output);
					Assert.AreEqual(result, output.ToString());
				}
			}
		}

		[TestMethod()]
		public void JavaComplexPatternTest()
		{
			string input = "first{% for(int i = 0; i < 2; i++){%}second{%}%}{%@2%}third{%? 5 < 2 %}fourth{%?%}fiveth{%@%}sixth";
			string result = "firstsecondsecondthirdfiveththirdfivethsixth";
			var template = new Template(new Java(), input, new string[0]);
			{
				using (var output = new StringWriter())
				{
					template.Render(output);
					Assert.AreEqual(result, output.ToString());
				}
			}
		}

		[TestMethod()]
		public void RubyComplexPatternTest()
		{
			string input = "first{% 2.times{%}second{%};%}{%@2%}third{%? 5 < 2 %}fourth{%?%}fiveth{%@%}sixth";
			string result = "firstsecondsecondthirdfiveththirdfivethsixth";
			var template = new Template(new Ruby(), input, new string[0]);
			{
				using (var output = new StringWriter())
				{
					template.Render(output);
					Assert.AreEqual(result, output.ToString());
				}
			}
		}

		[TestMethod()]
		public void PythonComplexPatternTest()
		{
			string input = "first{%for i in range(2):\n\t%}second{%@2%}third{%? 5 < 2 %}fourth{%?%}fiveth{%@%}sixth";
			string result = "firstsecondthirdfiveththirdfivethsixthsecondthirdfiveththirdfivethsixth";
			var template = new Template(new Python(), input, new string[0]);
			{
				using (var output = new StringWriter())
				{
					template.Render(output);
					Assert.AreEqual(result, output.ToString());
				}
			}
		}

		[TestMethod()]
		public void CSharpVariablesPatternTest()
		{
			string input = "{%@m%}{%=n%}{%@%}";
			string result = "***";
			Variable varM = new Variable("m", ArgumentType.Int);
			Variable varN = new Variable("n", ArgumentType.String);
			var template = new Template(new CSharp(), input, new string[0], varM, varN);
			{
				using (var output = new StringWriter())
				{
					template.Render(output, "3", "\"*\"");
					Assert.AreEqual(result, output.ToString());
				}
			}
		}

		[TestMethod()]
		public void JavaVariablesPatternTest()
		{
			string input = "{%@m%}{%=n%}{%@%}";
			string result = "***";
			Variable varM = new Variable("m", ArgumentType.Int);
			Variable varN = new Variable("n", ArgumentType.String);
			var template = new Template(new Java(), input, new string[0], varM, varN);
			{
				using (var output = new StringWriter())
				{
					template.Render(output, "3", "\"*\"");
					Assert.AreEqual(result, output.ToString());
				}
			}
		}

		[TestMethod()]
		public void RubyVariablesPatternTest()
		{
			string input = "{%@m%}{%=n%}{%@%}";
			string result = "***";
			Variable varM = new Variable("m", ArgumentType.Int);
			Variable varN = new Variable("n", ArgumentType.String);
			var template = new Template(new Ruby(), input, new string[0], varM, varN);
			{
				using (var output = new StringWriter())
				{
					template.Render(output, "3", "\"*\"");
					Assert.AreEqual(result, output.ToString());
				}
			}
		}

		[TestMethod()]
		public void PythonVariablesPatternTest()
		{
			string input = "{%@m%}{%=n%}{%@%}";
			string result = "***";
			Variable varM = new Variable("m", ArgumentType.Int);
			Variable varN = new Variable("n", ArgumentType.String);
			var template = new Template(new Python(), input, new string[0], varM, varN);
			{
				using (var output = new StringWriter())
				{
					template.Render(output, "3", "\"*\"");
					Assert.AreEqual(result, output.ToString());
				}
			}
		}
	}
}