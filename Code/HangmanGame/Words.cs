using System;

public class Class1
{
	public Class1()
	{
		public string getRandomWord()
		{
            StreamReader sr = new StreamReader("C:\\Sample.txt");

            while (line != null)
            {
                Console.WriteLine(line);
                //Read the next line
                line = sr.ReadLine();
            }
        }
    }
}
