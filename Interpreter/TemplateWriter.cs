using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Interpreter
{
	class TemplateWriter
	{
		private string templateHeader = @"<#@ template debug=""false"" hostspecific=""false"" language=""C#"" #>
<#@ assembly name=""System.Core"" #>
<#@ import namespace=""System.Text"" #>
<#@ output extension="".cs"" #>";

		private string templateFuncs = @"<#+
 string RenderLoop(int count, string text) {
  string x = string.Empty;
  for (var i=0; i<count; i++){
   x += text;
  }
  return x;
 }
 
 string RenderIf(bool clause, string text){
  if (clause) {
   return text;
  }
  return string.Empty;
 }
 
 string RenderCSharp(
#>";

		private readonly string _filePath;
		public TemplateWriter(string fileName)
		{
			_filePath = $"{AppDomain.CurrentDomain.BaseDirectory}{fileName}.tt";
			File.WriteAllText(_filePath, templateHeader + "\n");
			File.AppendAllText(_filePath, templateFuncs + "\n");
		}

		public void AddToTemplate(string text)
		{
			string result = ConvertToTFour(text);
			File.AppendAllText(_filePath, Regex.Unescape(result));
		}

		private string ConvertToTFour(string text)
		{
			return $"<#=\"{text}\"#>";
		}
	}
}
