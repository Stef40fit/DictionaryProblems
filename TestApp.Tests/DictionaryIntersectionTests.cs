using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class DictionaryIntersectionTests
{
    [Test]
    public void Test_Intersect_TwoEmptyDictionaries_ReturnsEmptyDictionary()
    {
        //Arrange
        Dictionary<string, int> firstDictionary = new Dictionary<string, int>();
        Dictionary<string, int> secondDictionary = new Dictionary<string, int>();

        //Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(firstDictionary, secondDictionary);

        //Assert
        Assert.AreEqual(0,result.Count);
    }
    [Test]
    public void Test_Intersect_OneEmptyDictionaryAndOneNonEmptyDictionary_ReturnsEmptyDictionary()
    {
        Dictionary<string, int> firstDictionary = new()
        {
            { "one", 1 },
            { "two",2 },
        };
        Dictionary<string, int> secondDictionary = new();

        //Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(firstDictionary, secondDictionary);

        //Assert
        Assert.AreEqual(0, result.Count);
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithNoCommonKeys_ReturnsEmptyDictionary()
    {

        Dictionary<string, int> firstDictionary = new()
        {
            { "one", 1 },
            { "two",2 },
        };
        Dictionary<string, int> secondDictionary = new()
             {
            { "tree", 3 },
            { "four",4 },
        }; 

        //Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(firstDictionary, secondDictionary);

        //Assert
        Assert.AreEqual(0, result.Count);
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithCommonKeysAndValues_ReturnsIntersectionDictionary()
    {
        Dictionary<string, int> firstDictionary = new()
        {
            { "one", 1 },
            { "two", 2 },
        };
        Dictionary<string, int> secondDictionary = new()
             {
             { "one", 1 },
            { "two", 2 },
            { "four", 4},
        };

        //Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(firstDictionary, secondDictionary);

        //Assert
        Assert.AreEqual(2, result.Count);
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithCommonKeysAndDifferentValues_ReturnsEmptyDictionary()
    {
        Dictionary<string, int> firstDictionary = new()
        {
            { "one", 4 },
            { "two", 5 },
        };
        Dictionary<string, int> secondDictionary = new()
             {
             { "one", 6},
            { "two", 7},
            { "four", 8},
        };

        //Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(firstDictionary, secondDictionary);

        //Assert
        Assert.AreEqual(0, result.Count);
    }
}
