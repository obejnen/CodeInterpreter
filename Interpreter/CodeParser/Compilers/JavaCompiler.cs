using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Interpreter.CodeParser.Compilers
{
	class JavaCompiler : ICompilable, IDisposable
	{
		private readonly Process cmd;
		private string tempFileName = "tempCode.java";
		private string outputFileName = "output.txt";
		private string result;

		public string Result => result;

		public JavaCompiler()
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
				Thread.Sleep(500);
			return File.ReadAllText(Path.GetFullPath(outputFileName));
		}

		private void CreateSourceFile(string code)
		{
			File.WriteAllText(tempFileName, code);
		}

		private void DoCommands()
		{
			cmd.Start();
			cmd.StandardInput.WriteLine($"javac {Path.GetFileName(Path.GetFullPath(tempFileName))}");
			cmd.StandardInput.WriteLine($"java {Path.GetFileNameWithoutExtension(tempFileName)}");
		}

		private void ConfigureCmd()
		{
			cmd.StartInfo.FileName = "cmd.exe";
			cmd.StartInfo.RedirectStandardInput = true;
			cmd.StartInfo.RedirectStandardOutput = false;
			cmd.StartInfo.CreateNoWindow = true;
			cmd.StartInfo.UseShellExecute = false;
			cmd.StartInfo.WorkingDirectory = Path.GetDirectoryName(Path.GetFullPath(tempFileName)) ?? throw new InvalidOperationException();
		}

		public void Dispose()
		{
			File.Delete(tempFileName);
			File.Delete($"{Path.GetFileNameWithoutExtension(tempFileName)}.class");
			File.Delete(outputFileName);
		}
	}
}
