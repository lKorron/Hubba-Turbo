using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parser
{ 
    public static string UppercaseFirst(string word)
    {
        if (string.IsNullOrEmpty(word))
            return string.Empty;

        return char.ToUpper(word[0]) + word.Substring(1);
    }
}
