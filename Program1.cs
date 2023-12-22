using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Program
{
    static int ReadNumberFromFile(string fileName, int lineNumber)
    {
        
        string line = File.ReadLines(fileName).ElementAt(lineNumber - 1);
        
        return Convert.ToInt32(line);
    }
    static void Main(string[] args)
    {
        
        Directory.CreateDirectory("./messages");
        
        StreamWriter noFileWriter = new StreamWriter("./messages/no_file.txt");
        StreamWriter badDataWriter = new StreamWriter("./messages/bad_data.txt");
        StreamWriter overflowWriter = new StreamWriter("./messages/overflow.txt");
        
        int sum = 0;
        int productCount = 0;
         
        for (int i = 10; i <= 29; i++)
        {
            string fileName = i.ToString() + ".txt";   
            try
            {
                int firstNumber = ReadNumberFromFile(fileName, 1);
                int secondNumber = ReadNumberFromFile(fileName, 2);
                sum += checked(firstNumber * secondNumber);
                productCount++;
            }
            catch (FileNotFoundException)
            {
                noFileWriter.WriteLine(fileName);
            }
            catch (FormatException)
            {
                badDataWriter.WriteLine(fileName);
            }
            catch (OverflowException)
            {
                overflowWriter.WriteLine(fileName);
            }
        }
        
        noFileWriter.Close();
        badDataWriter.Close();
        overflowWriter.Close();

        Console.WriteLine("Сума добуткiв: " + sum);
        Console.WriteLine("Середнє арифметичне добуткiв: " + (sum / productCount));
        Console.ReadLine();
    }
    
}