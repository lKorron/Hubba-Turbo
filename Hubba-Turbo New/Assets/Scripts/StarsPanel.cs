using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsPanel : MonoBehaviour
{
    
    [SerializeField] private List<Star> stars = new List<Star>();

    private void SetOneStar()
    {
        SetCurrentStar(0, true);
        SetCurrentStar(1, false);
        SetCurrentStar(2, false);
    }

    private void SetTwoStars()
    {
        SetOneStar();
        SetCurrentStar(1, true);
        SetCurrentStar(2, false);
    }

    private void SetThreeStars()
    {
        SetTwoStars();
        SetCurrentStar(2, true);
    }

   
    private void SetCurrentStar(int index, bool active)
    {
        Star star = stars[index];
        foreach (var item in stars)
        {
            if (item.GetIndex() == index)
            {
                star = item;
            }
        }
        if (active)
        {
            star.SetStar();
        }
        else star.SetEmptyStar();
        
    }
}
