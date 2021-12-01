using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDisenio
{
	public class Interpreter
	{

		// "Context" 
		public class Context
		{
		}

		// "AbstractExpression" 
		public abstract class AbstractExpression
		{
			public abstract void Interpret(Context context);
		}

		// "TerminalExpression" 
		public class TerminalExpression : AbstractExpression
		{
			public override void Interpret(Context context)
			{
				Console.WriteLine("Called Terminal.Interpret()");
			}
		}

		// "NonterminalExpression" 
		public class NonterminalExpression : AbstractExpression
		{
			public override void Interpret(Context context)
			{
				Console.WriteLine("Called Nonterminal.Interpret()");
			}
		}



	}
}
