using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SnailType")]
public class SnailType: AbstractSnailType
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Side _activationSide;
    [SerializeField] private float _timeScale;

    public override Sprite Sprite => _sprite;
    public override Side ActivationSide => _activationSide;
    public override float TimeScale => _timeScale;

    #region OnValidate
    private void OnValidate()
    {
        if (_timeScale < 0)
            _timeScale = 0;
    }
    #endregion

    public override void ChangeTime()
    {
        Time.timeScale = _timeScale;
    }

}
