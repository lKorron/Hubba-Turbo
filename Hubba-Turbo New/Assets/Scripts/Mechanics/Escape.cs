using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class Escape : MonoBehaviour
{
    [SerializeField] private Animal selfAnimal;
    [SerializeField] private Animal fearAnimal;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float flyingForce; // How fast unit will fly

    private WeightComparing weightComparing;
    private Rigidbody2D m_rigidbody;
    private Animator animator;
    private ItemCollision[] itemCollisions;
    private bool isEscaping;
    private float animationTime = 2f;
    private float delayAfterAnimation = 4f;

    private void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        weightComparing = FindObjectOfType<WeightComparing>();
        itemCollisions = FindObjectsOfType<ItemCollision>();

        foreach (var item in itemCollisions)
        {
            item.OnCollision.AddListener(CheckAndEscape);
        }
        

    }

    private void OnDisable()
    {
        foreach (var item in itemCollisions)
        {
            item.OnCollision.RemoveListener(CheckAndEscape);
        }
    }

    public void CheckAndEscape()
    {
        if (weightComparing.IsAnimalsOnBoard(fearAnimal, selfAnimal) && isEscaping == false)
        {
            StartCoroutine(StartEscape());
        }
    }

    // Flying method
    private IEnumerator StartEscape()
    {
        animator.Play("ElephantEscape");
        isEscaping = true;
        yield return new WaitForSeconds(animationTime);
        // Multiple for comfortable
        m_rigidbody.gravityScale = flyingForce * -1;
        yield return new WaitForSeconds(delayAfterAnimation);
        isEscaping = false;
    }

    

}

public enum Animal
{
    Mouse,
    Snake,
    Bird,
    Dog,
    Wolf,
    Elephant,
    Sheep
}
