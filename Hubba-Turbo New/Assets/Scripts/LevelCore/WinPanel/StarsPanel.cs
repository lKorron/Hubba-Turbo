using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsPanel : MonoBehaviour
{
    [SerializeField] private List<Star> _stars = new List<Star>();

    public void SetStars(int starsCount)
    {
        if (starsCount == 1)
            SetOneStar();
        else if (starsCount == 2)
            SetTwoStars();
        else if (starsCount == 3)
            SetThreeStars();
        else Debug.LogError("Enter correct number of stars");
    }

    private void SetOneStar()
    {
        _stars[0].SetStar();
        _stars[1].SetEmptyStar();
        _stars[2].SetEmptyStar();
    }

    private void SetTwoStars()
    {
        _stars[0].SetStar();
        _stars[1].SetStar();
        _stars[2].SetEmptyStar();
    }

    private void SetThreeStars()
    {
        _stars.ForEach(star =>
        {
            star.SetStar();
        });
    }
}
