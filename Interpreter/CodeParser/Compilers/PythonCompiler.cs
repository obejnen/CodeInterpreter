using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Interpreter.CodeParser.Compilers
{
	class PythonCompiler : ICompilable, IDisposable
	{
		private Process cmd;
		private string tempFileName = "tempCode.py";
		private string outputFileName = "output.txt";
		private string result;

		public string Result => result;

		public PythonCompiler()
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
		private string TakeFromOutput()
		{
			for (int i = 0; i < 3 && !File.Exists(outputFileName); i++)
				Thread.Sleep(300);
			return File.ReadAllText(Path.GetFullPath(outputFileName));
		}

		private void CreateSourceFile(string code)
		{
			File.WriteAllText(tempFileName, code);
		}

		private void DoCommands()
		{
			cmd.Start();
			cmd.StandardInput.WriteLine($"python {tempFileName}");
		}

		private void ConfigureCmd()
		{
			cmd.StartInfo.FileName = "cmd.exe";
			cmd.StartInfo.RedirectStandardInput = true;
			cmd.StartInfo.CreateNoWindow = true;
			cmd.StartInfo.UseShellExecute = false;
			cmd.StartInfo.WorkingDirectory = Path.GetDirectoryName(Path.GetFullPath(tempFileName)) ?? throw new InvalidOperationException();
		}

		public void Dispose()
		{
			File.Delete(tempFileName);
			File.Delete(outputFileName);
		}
	}
}
