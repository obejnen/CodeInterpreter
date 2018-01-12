using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter.CodeParser
{
	public enum ArgumentType
	{
		Int, Long, String, Double, Bool, DateTime, Calendar, Integer, Boolean
	}
	public class Variable
	{
		private readonly string name;
		private readonly ArgumentType type;
		public ArgumentType Type => type;
		public string Name => name;

		public Variable(string name, ArgumentType variableType)
		{
			this.name = name;
			type = variableType;
		}
	}
}
