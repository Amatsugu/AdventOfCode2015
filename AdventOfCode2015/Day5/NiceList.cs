namespace AdventOfCode2015.Day5;

public class NiceList
{
	private string[] _inputData;

	public NiceList(string? inputFile = null)
	{
		_inputData = File.ReadAllLines(inputFile ?? "Day5/input.txt");
	}

	public void RunPart1()
	{
		var niceCount = 0;

		for (int i = 0; i < _inputData.Length; i++)
		{
			if (IsNice(_inputData[i]))
				niceCount++;
		}

		Console.WriteLine($"Nice Count {niceCount}");
	}

	public void RunPart2()
	{
		var niceCount = 0;

		for (int i = 0; i < _inputData.Length; i++)
		{
			if (IsNice2(_inputData[i]))
			{
				niceCount++;
			}
		}
		Console.WriteLine($"Nice Count {niceCount}");
	}

	private bool IsNice2(string value)
	{
		var pairs = new Dictionary<string, List<int>>();
		var separatedPair = false;

		for (int i = 1; i < value.Length; i++)
		{
			var c = value[i];
			var curIndex = i - 1;
			var pair = value[curIndex..(i + 1)];
			if (pairs.ContainsKey(pair))
			{
				if (pairs[pair].Contains(curIndex - 1))
					continue;
				pairs[pair].Add(curIndex);
			}
			else
			{
				pairs.Add(pair, new List<int>() { curIndex });
			}

			if (i == 1)
				continue;
			if (value[i - 2] == c)
				separatedPair = true;
		}

		return separatedPair && pairs.Any(p => p.Value.Count >= 2);
	}

	private bool IsNice(string value)
	{
		var vowelCount = 0;
		var doubleLetters = false;
		for (int i = 0; i < value.Length; i++)
		{
			char c = value[i];
			if (IsVowel(c))
				vowelCount++;
			if (i == 0)
				continue;
			var lastChar = value[i - 1];
			if (IsIllegal(c, lastChar))
				return false;
			if (IsDouble(c, lastChar))
				doubleLetters = true;
		}
		return (doubleLetters && vowelCount >= 3);
	}

	private static bool IsVowel(char c)
	{
		return c switch
		{
			'a' or 'e' or 'i' or 'o' or 'u' => true,
			_ => false
		};
	}

	private static bool IsDouble(char c, char lastChar)
	{
		return c == lastChar;
	}

	private static bool IsIllegal(char c, char lastChar)
	{
		return (lastChar, c) switch
		{
			('a', 'b') => true,
			('c', 'd') => true,
			('p', 'q') => true,
			('x', 'y') => true,
			_ => false
		};
	}
}