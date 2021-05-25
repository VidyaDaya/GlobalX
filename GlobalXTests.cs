using Xunit;
using System;
using GlobalX;
using System.IO;
using System.Collections.Generic;
using FluentAssertions;


public class GlobalXTests
{

public static string GetMD5Checksum(string filename)
{
	using (var md5 = System.Security.Cryptography.MD5.Create())
	{
		using (var stream = System.IO.File.OpenRead(filename))
		{
			var hash = md5.ComputeHash(stream);
			return BitConverter.ToString(hash).Replace("-", "");
		}
	}
}

[Fact]
public void IncorrectFileNameTest()
{
    NameSorter nameSorter= new NameSorter();
    nameSorter.FileName="xtx.txt";
    Assert.Throws<FileNotFoundException>(()=>nameSorter.NameSorterProcessor());
    
}

[Fact]
public void ReadFile_StoresNames_Test()
{
    List<PersonDetail> testList=new List<PersonDetail>();
    testList.Add(new PersonDetail{GivenName="Jeff",LastName="Bezos"});
    testList.Add(new PersonDetail{GivenName="Bill",LastName="Gates"});
    testList.Add(new PersonDetail{GivenName="Elon",LastName="Musk"});
    NameSorter nameSorter= new NameSorter();
    nameSorter.FileName=@"D:\CSharpPractice\GlobalX\unsorted-names-test.txt";
    
    nameSorter.ReadFile();

    testList.Should().BeEquivalentTo(nameSorter.GetNames());
}

[Fact]
public void SortNamesTest()
{
    List<PersonDetail> sortedTestList=new List<PersonDetail>();
    sortedTestList.Add(new PersonDetail{GivenName="Jeff",LastName="Bezos"});
    sortedTestList.Add(new PersonDetail{GivenName="Bill",LastName="Gates"});
    sortedTestList.Add(new PersonDetail{GivenName="Elon",LastName="Musk"});
    NameSorter nameSorter= new NameSorter();
    nameSorter._nameList.Add(new PersonDetail{GivenName="Elon",LastName="Musk"});
    nameSorter._nameList.Add(new PersonDetail{GivenName="Bill",LastName="Gates"});
    nameSorter._nameList.Add(new PersonDetail{GivenName="Jeff",LastName="Bezos"});
    
    nameSorter.SortNames();
    sortedTestList.Should().BeEquivalentTo(nameSorter.GetNames());
}

[Fact]
public void WriteFileTest()
{
    NameSorter nameSorter= new NameSorter();
    nameSorter._nameList.Add(new PersonDetail{GivenName="Elon",LastName="Musk"});
    nameSorter._nameList.Add(new PersonDetail{GivenName="Jeff",LastName="Bezos"});
    nameSorter._nameList.Add(new PersonDetail{GivenName="Bill",LastName="Gates"});
    
    nameSorter.WriteFile("write-test.txt");
    var outputMD5=GetMD5Checksum("write-test.txt");
    var baseMD5=GetMD5Checksum(@"D:\CSharpPractice\GlobalX\unsorted-names-test.txt");

    Assert.Equal(baseMD5,outputMD5);
    
}

}