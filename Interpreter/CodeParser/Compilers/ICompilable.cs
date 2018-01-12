using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter.CodeParser.Compilers
{
	interface ICompilable
	{
		void Compile(string code);
	}
}
