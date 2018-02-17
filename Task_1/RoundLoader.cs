using System.IO;
using System;

namespace Task_1
{
    public static class RoundLoader
    {
        public static Round LoadFromFile(string path)
        {
            string[] ReadedData;
            using (StreamReader Reader = new StreamReader(path))
            {
                ReadedData = Reader.ReadLine().Split(' ');
            }

            if(ReadedData.Length!=3)
            {
                throw new InvalidDataException("Invalid input data format. More or less then 3 words in first string");
            }

            double x, y, r;
            try
            {
                x= double.Parse(ReadedData[0]);
                y = double.Parse(ReadedData[1]);
                r = double.Parse(ReadedData[2]);
            }
            catch(Exception e)
            {
                throw new InvalidDataException("Wrong input symbol");
            }

            return new Round(x, y, r);
        }
    }
}