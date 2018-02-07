using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Bot
    {
        private string _dataBase;
        private string _defaultMessage = "Przykro mi, nie rozumiem :(";
        private string _message;
        private string _path;
        private string _addToDataBase;


        public Bot()
        {
            //_path = @"C:\Users\Maciej\Desktop\bazaDanych.txt";
            _path = Environment.CurrentDirectory; //In case of trouble change it to your path

            if (!File.Exists(_path))
            {
                File.Create(_path);
            }

            ReadDataBase();
        }

        private void ReadDataBase()
        {
            int i = 0;
            try
            {
                using (StreamReader sr = new StreamReader(_path))
                {
                    String line = sr.ReadToEnd();
                    _dataBase = line;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public string Response(string message)
        {
            _message = message;

            return MatchData();
        }

        private string MatchData()
        {
            int points = 0;
            string match = _defaultMessage;
            string[] strArr = _dataBase.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            foreach(string x in strArr)
            {
                if (x != null)
                {
                    int pointsX = Rank(x.Split(' '));
                    if (pointsX > points)
                    {
                        points = pointsX;
                        match = x;
                    }
                }
                else
                {
                    continue;
                }
            }

            if(points < 1)
            {
                _addToDataBase += _message + "\r\n";
            }

            return match;
        }

        private int Rank(string[] template)
        {
            string[] messageArr = _message.Split(' ');
            int p = 0;

            for(int i = 0; i < template.Length; i++)
            {
                for(int j = 0; j < messageArr.Length; j++)
                {
                    if((template[i] == messageArr[j]) & (template[i] != "a") & (template[i] != "tak") & (template[i] != "nie") & (template[i] != "w") & (template[i] != "z"))
                    {
                        p++;
                    }
                }
            }

            return p;
        }

        public void SaveData()
        {
            using (var tw = new StreamWriter(_path, true))
            {
                tw.WriteLine(_addToDataBase);
                tw.Close();
            }
        }
    }
}
