using System;
using System.Text;

public interface INameGenerator
{
	StringBuilder GenerateName();
	string AdjustToGender(StringBuilder text, Gender gender);
}
