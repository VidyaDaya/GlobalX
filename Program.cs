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
            TextFileReader fileObject=new TextFileReader();

            fileObject.ReadFile("unsorted-names-list.txt");
        }
    }


    public class PersonDetail
    {
        public string GivenName{get; set;}
        public string LastName{get; set;}

        
    }

    

    

    

}
