using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace Interpreter.CodeParser.Compilers
{
	class RubyCompiler : ICompilable, IDisposable
	{
		private Process cmd;
		private string tempFileName = "tempCode.rb";
		private string outputFileName = "output.txt";
		private string result;

		public string Result => Regex.Unescape(result);

		public RubyCompiler()
		{
			cmd = new Process();
		}

		public void Compile(string code)
		{
			CreateSourceFile(code);
			ConfigureCmd();
			DoCommands();
			result = TakeFromOutput();
		}

		private void CreateSourceFile(string code)
		{
			File.WriteAllText(tempFileName, code);
		}

		private string TakeFromOutput()
		{
			for (int i = 0; i < 3 && !File.Exists(outputFileName); i++)
				Thread.Sleep(300);
			return File.ReadAllText(outputFileName);
		}

		private void DoCommands()
		{
			cmd.Start();
			cmd.StandardInput.WriteLine($"ruby {tempFileName}");
		}

		private void ConfigureCmd()
		{
			cmd.StartInfo.FileName = "cmd.exe";
			cmd.StartInfo.RedirectStandardInput = true;
			cmd.StartInfo.CreateNoWindow = true;
			cmd.StartInfo.UseShellExecute = false;
			cmd.StartInfo.WorkingDirectory = Path.GetDirectoryName(tempFileName) ?? throw new InvalidOperationException();
		}

		public void Dispose()
		{
			File.Delete(tempFileName);
			File.Delete(outputFileName);
		}
	}
}
