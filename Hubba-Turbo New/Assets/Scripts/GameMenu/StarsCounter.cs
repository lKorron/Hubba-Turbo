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

    public static StarsCounter Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void DisplayCollectedStars()
    {
        _text = GetComponent<Text>();
        _starsArray = _levelData.Levels;

        _text.text += " " + SumOfDigitsArray(_starsArray).ToString();
        
    }

    private int SumOfDigitsArray(int[] array)
    {
        int sum = 0;
        foreach (var digit in array)
        {
            sum += digit;
        }
        return sum;
    }
}
