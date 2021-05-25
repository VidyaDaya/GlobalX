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
        public void WriteFile(string FileName);
    }

    public class NameSorter : INameSorter
    {
        public string FileName { get; set;}
        public List<PersonDetail> _nameList{get; set;}
        

        public NameSorter()
        {
            _nameList=new List<PersonDetail>();

        }

        public List<PersonDetail> GetNames()
        {
            return _nameList;
        }


        public void NameSorterProcessor()
        {
            ReadFile();
            SortNames();
            WriteFile();
        }

        public void ReadFile()
        {
 
            try
            { 
            StreamReader file = new StreamReader(FileName);
            string line; 
            while ((line = file.ReadLine()) != null) {
                   var lastName=line.Split(' ').LastOrDefault();
                    var givenName=line.Substring(0, line.LastIndexOf(' ')).TrimEnd(); 
                    _nameList.Add(new PersonDetail{GivenName=givenName,LastName=lastName}); 
            }  
                file.Close();
            }
            
        
            catch(FileNotFoundException exe)
            {
                Console.WriteLine(" The File {0} does not exist.", FileName);
               throw;    
            }
            
        }

        public void SortNames()
        {
            _nameList=_nameList.OrderBy(x=>x.LastName).ThenBy(x=>x.GivenName).ToList();
        }

        public void WriteFile(string outputFileName="sorted-names-list.txt")
        {
            using StreamWriter writeFile = new StreamWriter(outputFileName);
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
