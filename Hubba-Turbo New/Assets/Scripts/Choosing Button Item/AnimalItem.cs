using UnityEngine;

[CreateAssetMenu(menuName = "AnimalItem")]
public class AnimalItem : ScriptableObject, IAnimalItem
{
    [SerializeField] private Animal _animal;
    [SerializeField] private Sprite _iconSprite;

    public Animal Animal => _animal;
    public Sprite IconSprite => _iconSprite;
}
