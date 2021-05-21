using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using GlobalX;

namespace TextFileHelper{

    public  class TextFileReader
    {
        //  string textFile="unsorted-names-list.txt";

        List<PersonDetail> nameList=new List<PersonDetail>();
        PersonDetail name= new PersonDetail();
        
        public void ReadFile(string fileName) {
            
            if (File.Exists(fileName)) {     
            using(StreamReader file = new StreamReader(fileName)) {
                string ln; 
                // List<string> lNames=new List<string>(); 
            
                while ((ln = file.ReadLine()) != null) {
                   name.LastName=ln.Split(' ').LastOrDefault();
                    name.GivenName=ln.Substring(0, ln.LastIndexOf(' ')).TrimEnd(); 
                    nameList.Add(new PersonDetail{GivenName=name.GivenName,LastName=name.LastName}); 
            }  
                file.Close();  
                nameList=nameList.OrderBy(x=>x.LastName).ThenBy(x=>x.GivenName).ToList();
        foreach (PersonDetail person in nameList)
        {
            Console.WriteLine(person.LastName);
        }

        using StreamWriter newFile = new StreamWriter("sorted-names-list.txt");

        foreach (PersonDetail person in nameList)
        {
           ln=person.GivenName+ " " +person.LastName;
           newFile.WriteLine(ln);
        }
        newFile.Close();
        }
        }
        else{
            Console.WriteLine("The File {fileName} does not exist.");
        }  
        }
}
}