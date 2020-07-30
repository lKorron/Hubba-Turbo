using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsPanel : MonoBehaviour
{
    
    [SerializeField] private List<Star> stars = new List<Star>();

    private void Start()
    {
        SetTwoStars();
    }

    private void SetOneStar()
    {
        SetCurrentStar(0);
    }

    private void SetTwoStars()
    {
        SetOneStar();
        SetCurrentStar(1);
    }

   
    private void SetCurrentStar(int index)
    {
        Star star = stars[index];
        foreach (var item in stars)
        {
            if (item.GetIndex() == index)
            {
                star = item;
            }
        }
        star.SetStar();
    }
}
