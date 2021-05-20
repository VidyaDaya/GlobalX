using System;
using System.IO;
using System.Linq;
using TextFileHelper;

namespace GlobalX
{
    class Program
    {
        static void Main(string[] args)
        {
            TextFileReader.ReadFile();
        }
    }

    public class FullName{
        public string GivenName;
        public string LastName;

        FullName[] nameList=new FullName[200];
        FullName name= new FullName();
    }

    

    

    

}
