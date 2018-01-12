//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Interpreter;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Interpreter.Tests
//{
//	[TestClass()]
//	public class CodeParserTests
//	{
//		[TestMethod()]
//		public void ParseTest()
//		{
//			var input = @"{%@n%}<{%@ n + m %}*{%@%}>{%@%}";
//			var result = @"{%@n%}<{%@ n + m %}*{%@%}>{%@%}";

//			Parser cp = new Parser();
//			var output = cp.Parse(input);

//			Assert.AreEqual(output, result);
//		}

//		[TestMethod()]
//		public void ReplaceLoopExpression_NormalInput_Success()
//		{
//			var input = @"{%@2%}<{%@ 5 %}*{%@%}>{%@%}";
//			var result = @"aaafor(int i = 0; i < 2; i++) { <for(int i = 0; i <  5 ; i++) { *; }>; }";

//			Parser cp = new Parser();
//			var output = cp.ReplaceLoopExpressionTT(input);

//			Assert.AreEqual(output, result);
//		}

//		[TestMethod()]
//		public void ReplaceConditionExpressionTest()
//		{
//			var input = @"aaa{%?2 > 3%}dsadasdsa{%?%}";
//			var result = @"aaaif(2 > 3){ dsadasdsa; }";

//			Parser cp = new Parser();
//			var output = cp.ReplaceConditionExpressionTT(input);

//			Assert.AreEqual(output, result);
//		}

//		[TestMethod()]
//		public void ReplaceArithmeticalExpressionTest()
//		{
//			var input = @"aaa{%=2+2%}";
//			var result = @"aaa2+2";

//			Parser cp = new Parser();
//			var output = cp.ReplaceArithmeticalExpressionTT(input);

//			Assert.AreEqual(output, result);
//		}

//		[TestMethod()]
//		public void ReplaceSimpleCodeExpressionTest()
//		{
//			var input = @"aaa{% for(int i = 0; i < 5; i++)%}";
//			var result = @"aaafor(int i = 0; i < 5; i++)";

//			Parser cp = new Parser();
//			var output = cp.ReplaceSimpleCodeExpressionTT(input);

//			Assert.AreEqual(output, result);
//		}
//	}
//}