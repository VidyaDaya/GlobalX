using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace GlobalX
{ 
    public class Program
    {
        static void Main(string[] args)
        {
            NameSorter nameSorter= new NameSorter();
            Console.WriteLine("Enter File Name: ");
            nameSorter.FileName=Console.ReadLine();
            nameSorter.NameSorterProcessor();
        }
    }

    public interface INameSorter
    {
        public void ReadFile();
        public void WriteFile();
    }

    class NameSorter : INameSorter
    {
        public string FileName { get; set;}
        private List<PersonDetail> _nameList{get; set;}
        

        public NameSorter()
        {
            _nameList=new List<PersonDetail>();
        }


        public void NameSorterProcessor()
        {
            ReadFile();
            SortNames();
            WriteFile();
        }

        public void ReadFile()
        {
            if (File.Exists(FileName)) {     
            using(StreamReader file = new StreamReader(FileName)) {
            string line; 
            while ((line = file.ReadLine()) != null) {
                   var lastName=line.Split(' ').LastOrDefault();
                    var givenName=line.Substring(0, line.LastIndexOf(' ')).TrimEnd(); 
                    _nameList.Add(new PersonDetail{GivenName=givenName,LastName=lastName}); 
            }  
                file.Close();
            }
            }
            else
            {
                Console.WriteLine("File not found");
            }
        }

        public void SortNames()
        {
            _nameList=_nameList.OrderBy(x=>x.LastName).ThenBy(x=>x.GivenName).ToList();
        }

        public void WriteFile()
        {
            using StreamWriter writeFile = new StreamWriter("sorted-names-list.txt");
            foreach (PersonDetail person in _nameList)
            {
                var line=person.GivenName+ " " +person.LastName;
                writeFile.WriteLine(line);
            }
            writeFile.Close();
        }
    }

    public class PersonDetail
    {
        public string GivenName{get; set;}
        public string LastName{get; set;}
    }
}
