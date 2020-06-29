using System;
using System.Linq;
using System.Text;

public class NameGenerator : INameGenerator
{
	private Random _random = new Random();
	const int LETTERS_COUNT = 26;
	const int MIN_LENGTH = 3;
	const int MAX_LENGTH = 10;

	public StringBuilder GenerateName()
    {
		int nameLength = _random.Next(MIN_LENGTH, MAX_LENGTH);
		var builder = new StringBuilder();
		char offset = 'A';
		char letter = (char)_random.Next(offset, offset + LETTERS_COUNT);
		builder.Append(letter);
		offset = 'a';

		for (int i = 0; i < nameLength - 1; i++)
        {
			letter = (char)_random.Next(offset, offset + LETTERS_COUNT);
			builder.Append(letter);
		}

		return builder;
    }

	public string AdjustToGender(StringBuilder builder, Gender gender)
    {
		string name = builder.ToString();

		if (gender == Gender.Male && name.Last() == 'a')
		{
			name.Remove(name.Length - 1);
		}
		else if (gender == Gender.Female && name.Last() != 'a')
		{
			builder.Append('a');
			name = builder.ToString();
		}

		return name;
	}
}
