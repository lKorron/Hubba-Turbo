using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsPanel : MonoBehaviour
{
    
    [SerializeField] private List<Star> stars = new List<Star>();

    private void Start()
    {
        SetOneStar();
    }

    private void SetOneStar()
    {
        Star star = stars[0];
        star.SetStar();
    }
}
