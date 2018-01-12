using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodTest
{
	class Program
	{
		public enum Type
		{
			First, Second
		}
		static void Main(string[] args)
		{
			Console.WriteLine(Type.First.ToString());
		}

	}
}
