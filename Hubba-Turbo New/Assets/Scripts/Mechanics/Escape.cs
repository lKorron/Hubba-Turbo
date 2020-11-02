using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Item))]
[RequireComponent(typeof(ItemCollision))]
[RequireComponent(typeof(Collider2D))]

public class Escape : MonoBehaviour
{
    [SerializeField] private Animal _selfAnimal;
    [SerializeField] private Animal _fearAnimal;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float _flyingForce; // How fast unit will fly
    [SerializeField] private bool _isAnimalNeedToRotate;
    [SerializeField] private float _animationTime = 2f;

    private float _delayBeforeRotation = 1f;
    private float _rotationSpeed = 70f;
    private WeightComparing _weightComparing;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private Item _itemSelf;
    private ItemCollision _selfItemCollision;
    private ItemCollision[] _itemCollisions;
    private Collider2D[] _colliders;
    private bool _isEscaping;
    private bool _canRotate;

    #region OnValidate
    private void OnValidate()
    {
        if (_animationTime < 0)
            _animationTime = 0;
    }
    #endregion

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _itemSelf = GetComponent<Item>();
        _selfItemCollision = GetComponent<ItemCollision>();
        _colliders = GetComponents<Collider2D>();

        _weightComparing = FindObjectOfType<WeightComparing>();
        _itemCollisions = FindObjectsOfType<ItemCollision>();

        foreach (var item in _itemCollisions)
        {
            item.OnCollision.AddListener(CheckAndEscape);
        }
        

    }

    private void Update()
    {
        if (_canRotate && _isAnimalNeedToRotate)
            Rotate();
    }

    private void OnDisable()
    {
        foreach (var item in _itemCollisions)
        {
            item.OnCollision.RemoveListener(CheckAndEscape);
        }
    }

    public void CheckAndEscape()
    {
        if (_weightComparing.IsAnimalsOnBoard(_fearAnimal, _selfAnimal) && _isEscaping == false)
        {
            StartCoroutine(StartEscape());
            Side side = _selfItemCollision.Side;
            _weightComparing.RemoveItem(_itemSelf, side);
            
        }
    }

    // Flying method
    private IEnumerator StartEscape()
    {
        if (TryGetComponent(out ItemAnimation itemAnimation))
            itemAnimation.StopAnimation();

        _rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        string clipName = _selfAnimal.ToString() + "Escape";
        _animator.Play(clipName);
        _isEscaping = true;
        yield return new WaitForSeconds(_animationTime);
        // Multiple for comfortable
        _rigidbody.gravityScale = _flyingForce * -1;
        yield return new WaitForSeconds(_delayBeforeRotation);
        DisableColliders();
        _canRotate = true;
        _isEscaping = false;
    }

    private void DisableColliders()
    {
        foreach (var collider in _colliders)
        {
            collider.isTrigger = true;
        }
    }

    private void Rotate()
    {
        var targetRotation = Quaternion.Euler(Vector3.zero);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

    }
    

}

