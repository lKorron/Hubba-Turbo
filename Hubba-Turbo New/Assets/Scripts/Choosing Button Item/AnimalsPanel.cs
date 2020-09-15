using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsPanel : MonoBehaviour
{
    
    [SerializeField] private AnimalsPanelCell _animalsPanelCellTemplate;
    [SerializeField] private Transform _container;

    private List<AnimalItem> _animalItems;
    private InstantiateSettings _instantiateSettings;

    private void OnEnable()
    {
        _instantiateSettings = FindObjectOfType<InstantiateSettings>();
        _animalItems = _instantiateSettings.AnimalItems;

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
