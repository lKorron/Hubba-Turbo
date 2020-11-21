using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Mine : MonoBehaviour
{
    [SerializeField] private Sprite _pressedMineSprite;
    [SerializeField] private Explosion _explosionTemplate;
    [SerializeField] private float _delayBeforeExplode;
    [SerializeField] private float _explosionTime = 0.1f;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Item>())
        {
            StartCoroutine(Explode(_delayBeforeExplode, _explosionTime));
        }
    }

    private IEnumerator Explode(float delayBeforeExplode, float explosionTime)
    {
        _spriteRenderer.sprite = _pressedMineSprite;
        yield return new WaitForSeconds(delayBeforeExplode);
        _explosionTemplate.gameObject.SetActive(true);
        _spriteRenderer.sprite = null;
        Destroy(gameObject, explosionTime);
    }
}
