using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2015.Day10;
internal class LookAndSay
{
	private StringBuilder _value;
	public LookAndSay(string value = "21")
	{
		_value = new StringBuilder(value);
	}

	public void Run(int iter)
	{
		for (int i = 0; i < iter; i++)
		{
			CalculateNext();
		}

		Console.WriteLine($"Len: {_value.Length}");
	}

	private void CalculateNext()
	{
		var next = new StringBuilder();
		var len = _value.Length;
		var curCount = 1;
		var curChar = _value[0];
		for (int i = 1; i < len; i++)
		{
			var c = _value[i];
			if(c != curChar)
			{
				next.Append(curCount).Append(curChar);
				curChar = c;
				curCount = 1;
				continue;
			}
			curCount++;
		}
		next.Append(curCount).Append(curChar);

		_value = next;
	}
}
