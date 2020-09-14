using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsPanel : MonoBehaviour
{
    [SerializeField] private List<AnimalItem> _animalItems;
    [SerializeField] private AnimalsPanelCell _animalsPanelCellTemplate;
    [SerializeField] private Transform _container;

    private void OnEnable()
    {
        Render(_animalItems);
    }

    private void Render(List<AnimalItem> animalItems)
    {
        animalItems.ForEach(item =>
        {
            var cell = Instantiate(_animalsPanelCellTemplate, _container);
            cell.Render(item);
        });
    }
}
