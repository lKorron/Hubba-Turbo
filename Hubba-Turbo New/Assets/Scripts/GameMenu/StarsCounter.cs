using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class StarsCounter : MonoBehaviour
{
    [SerializeField] private LevelData _levelData;
    private Text _text;
    private int[] _starsArray;

    private void Start()
    {
        _text = GetComponent<Text>();
        _starsArray = _levelData.Levels;

        _text.text += " " + SumOfArrayDigits(_starsArray).ToString();
        
    }

    private int SumOfArrayDigits(int[] array)
    {
        int sum = 0;
        foreach (var digit in array)
        {
            sum += digit;
        }
        return sum;
    }
}
