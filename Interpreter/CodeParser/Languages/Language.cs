using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using Interpreter.CodeParser.Parsers;

namespace Interpreter.CodeParser.Languages
{
	public abstract class Language : IRenderable
    {
	    protected string codeTemplate;
	    protected Variable[] variables;
	    protected string[] values;
	    protected Parser parser;

		public virtual string Render()
		{
		    return string.Empty;
	    }

	    public void SetRenderParameters(string code, Variable[] variables, string[] values)
	    {
		    codeTemplate = code;
		    this.variables = variables;
		    this.values = values;
		}

	    public virtual void SetCompilerParameters(List<string> namespaces)
	    {
		    
	    }

	    public virtual void SetCompilerParameters(string parameters)
	    {
		    
	    }
    }
}
