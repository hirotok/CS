using System;

//XORによる簡易的な暗号化と複合化
class password
{
	static void Main() {

		string str = "abcdefghijklmnopqrstuvwxyzABC!#$%&'()=~|";
		char[] c = str.ToCharArray();
		Console.WriteLine(str);

		//暗号化
		for (int i = 0; i < str.Length; i++ )
		{
			c[i]=(char)((int)c[i] ^ 1);
		}

		string str2= new string(c);
		Console.WriteLine(str2);

		c = str2.ToCharArray();
		//複合化
		for (int i = 0; i < str2.Length; i++)
		{
			c[i] = (char)((int)c[i] ^ 1);
		}

		string str3 = new string(c);
		Console.WriteLine(str3);

	}
}