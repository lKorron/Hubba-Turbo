using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButtonStars : MonoBehaviour
{
    [SerializeField] private LevelButtonStar _firstStar;
    [SerializeField] private LevelButtonStar _secondStar;
    [SerializeField] private LevelButtonStar _thirdStar;

    public void SetStars(int count)
    {
        if (count == 0)
        {
            _firstStar.SetBlackStar();
            _secondStar.SetBlackStar();
            _thirdStar.SetBlackStar();
        }
        if (count == 1)
        {
            _firstStar.SetFillStar();
            _secondStar.SetBlackStar();
            _thirdStar.SetBlackStar();
        }
        if (count == 2)
        {
            _firstStar.SetFillStar();
            _secondStar.SetFillStar();
            _thirdStar.SetBlackStar();
        }
        if (count == 3)
        {
            _firstStar.SetFillStar();
            _secondStar.SetFillStar();
            _thirdStar.SetFillStar();
        }
    }
}
