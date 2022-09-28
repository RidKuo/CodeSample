using System.Text;
using RidSample.BL.Service.BL.Interfaces;

namespace RidSample.BL.Service.BL;

public class MaskService : IMaskService
{
     public string MaskNameFail(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return "*";
        }

        var nameLength = name.Length;

        if (nameLength < 2)
        {
            return "*";
        }

        if (nameLength == 2)
        {
            return $"{name[0]}*";
        }

        var maskLength = nameLength - 2;
        var maskString = new string('*', maskLength);
        return $"{name[0]}{maskString}{name[nameLength - 1]}";
    }
     
    public string MaskNameByRune(string name)
    {
        var runeArray = new List<Rune>();
        for (int i = 0; i < name.Length;)
        {
            if (Rune.TryGetRuneAt(name, i, out Rune rune) == false)
            {
                throw new Exception();
            }

            runeArray.Add(rune);
            Console.WriteLine($"Code point: {rune.Value}");
            i += rune.Utf16SequenceLength;
        }
        
        var outputString = string.Empty;
        for (int i = 0; i < runeArray.Count; i++)
        {
            if (i == 0 || i == runeArray.Count - 1)
            {
                outputString += runeArray[i];
            }
            else
            {
                outputString += "*";
            }
        }

        return outputString;
    }

    public string MaskNameByChar(string name)
    {
        var intArray = new List<int>();

        for (int i = 0; i < name.Length; i++)
        {
            if (!char.IsSurrogate(name[i]))
            {
                intArray.Add(name[i]);
            }
            else if (i + 1 < name.Length && char.IsSurrogatePair(name[i], name[i + 1]))
            {
                int codePoint = char.ConvertToUtf32(name[i], name[i + 1]);
                intArray.Add(codePoint);
                i++;
            }
            else
            {
                throw new Exception();
            }
        }

        var outputString = string.Empty;

        for (int i = 0; i < intArray.Count; i++)
        {
            if (i == 0 || i == intArray.Count - 1)
            {
                outputString += char.ConvertFromUtf32(intArray[i]);
            }
            else
            {
                outputString += "*";
            }
        }

        return outputString;
    }
}