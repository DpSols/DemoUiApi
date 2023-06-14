using System.Text;
using AngleSharp.Text;

namespace QaseTests.Utilities;

public static class RandomGenerator
{
    private static Guid Guid => Guid.NewGuid();
    
    public static string RandomUniqueString(int length)
    {
        var rnd = new Random();
        var result = new StringBuilder(length);
        while (result.Length < length)
        {
            var index = rnd.Next(Guid.ToString().Length-1);
            var character = Guid.ToString()[index];
            
            if (character.IsWhiteSpaceCharacter() || character.IsAlphanumericAscii())
            {
                result.Append(Guid.ToString()[index]);
            }
        }

        var resultString = result
            .ToString() 
            .Trim();
        
        return resultString;
    }
    
    public static T GetRandomEnumValue<T>() where T: Enum
    {
        var e = Enum.GetValues(typeof(T)) // get values from Type provided
            .OfType<T>() // casts to Enum
            .OrderBy(e => Guid.NewGuid()) // mess with order of results
            .FirstOrDefault();
        return e;            // take first item in result
    }

    public static int RandomInt(int max)
    {
        var rnd = new Random();
        var randomValue = rnd.Next(max);

        return randomValue;
    }
}