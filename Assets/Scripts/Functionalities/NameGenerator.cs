using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public static class NameGenerator
{
    public static string[] prefixes;
    public static string[] suffixes;
    public static string GenerateStarName(){
        if(prefixes == null || suffixes == null){
            GetJSON();
        }

        string randPrefix = prefixes[Random.Range(0, prefixes.Length - 1)];
        string prefix = randPrefix.Substring(0, 1).ToUpper() + randPrefix.Substring(1);
        string randSuffix = suffixes[Random.Range(0, suffixes.Length - 1)];
        string suffix = randSuffix.Substring(0, 1).ToUpper() + randSuffix.Substring(1);

        return $"{prefix} {suffix}";
    }
    public static List<string> GetPlanetNames(string starName, int planetCount){
        List<string> names = new List<string>();

        for(int i = 1; i <= planetCount; i++){
            names.Add($"{starName} {ConvertToRoman(i)}");
        }

        return names;
    }
    private static string ConvertToRoman(int num)
    {
        string[] thousands = { "", "M", "MM", "MMM" };
        string[] hundreds = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
        string[] tens = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
        string[] ones = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

        return thousands[num / 1000] + hundreds[(num % 1000) / 100] + tens[(num % 100) / 10] + ones[num % 10];
    }

    private static void GetJSON(){
        string jsonFile = File.ReadAllText("Assets/Scripts/Functionalities/StarNames.json");
        NameData jsonData = JsonConvert.DeserializeObject<NameData>(jsonFile);

        Debug.Log(jsonData.prefixes);

        prefixes = jsonData.prefixes;
        suffixes = jsonData.suffixes;
    }
}
public class NameData{
    public string[] prefixes;
    public string[] suffixes;

    public NameData(string[] prefixes, string[] suffixes){
        this.prefixes = prefixes;
        this.suffixes = suffixes;
    }
}
