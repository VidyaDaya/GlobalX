using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace TextFileHelper{

    public static class TextFileReader{
        static string textFile="unsorted-names-list.txt";
        
        public static void ReadFile() {
            
            if (File.Exists(textFile)) {     
            using(StreamReader file = new StreamReader(textFile)) {
                string ln,lastName,givenName; 
                List<string> lNames=new List<string>(); 
            
                while ((ln = file.ReadLine()) != null) {
                   lastName=ln.Split(' ').LastOrDefault();
                    givenName=ln.Substring(0, ln.LastIndexOf(' ')).TrimEnd(); 
                    lNames.Add(lastName); 
            }  
                file.Close();  
            lNames=lNames.OrderBy(x=>x).ToList();
        foreach (string name in lNames)
        {
            Console.WriteLine(name);
        }
        }
        }
        else{
            Console.WriteLine("The File does not exist.");
        }  
        }
}
}