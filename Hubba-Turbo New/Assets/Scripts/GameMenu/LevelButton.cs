using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour, IComparable
{
    [SerializeField] private Sprite zeroStarSprite;
    [SerializeField] private Sprite oneStarSprite;
    [SerializeField] private Sprite twoStarSprite;
    [SerializeField] private Sprite threeStarSprite;
    
    [SerializeField] private Sprite blockSprite;

    private Button button;

    public int levelNumber; // Id for sorting
    private Image levelImage;

    private void Awake()
    {
        levelImage = GetComponent<Image>();
        button = GetComponent<Button>();
        
    }

    public void SetStars(int starsCount)
    {
        switch (starsCount)
        {
            case 0:
                SetZeroStar();
                break;
            case 1:
                SetOneStar();
                break;
            case 2:
                SetTwoStar();
                break;
            case 3:
                SetThreeStar();
                break;
            default:
                break;
        }
    }

    public void BlockLevel()
    {
        levelImage.sprite = blockSprite;
        button.interactable = false;
    }


    // For sorting
    public int CompareTo(object obj)
    {
        if (obj == null)
        {
            return 0;
        }

        LevelButton otherLevel = obj as LevelButton;
        if (otherLevel.levelNumber > levelNumber)
        {
            return -1;
        }
        if (otherLevel.levelNumber < levelNumber)
        {
            return 1;
        }
        else return 0;
    }
    private void SetZeroStar()
    {
        levelImage.sprite = zeroStarSprite;
    }
    private void SetOneStar()
    {
        levelImage.sprite = oneStarSprite;
    }

    private void SetTwoStar()
    {
        levelImage.sprite = twoStarSprite;
    }

    private void SetThreeStar()
    {
        levelImage.sprite = threeStarSprite;
    }

    
}
