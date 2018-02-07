using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class DataBase
    {
        private string[] _dataBase = new string[10];
        public DataBase()
        {
           

        

            TestData();
        }
        

        public string[] GetDataBase()
        {
            return _dataBase;
        }

 

        public void WriteData()
        {

        }

        public void AddSentence(string sent)
        {

        }

        private void TestData()
        {
            for(int j = 0; j < _dataBase.Length; j++)
            {
                Console.WriteLine(_dataBase[j]);
            }
        }
    }
}
