using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsPanel : MonoBehaviour
{
    
    [SerializeField] private AnimalsPanelCell _animalsPanelCellTemplate;
    [SerializeField] private Transform _container;

    private IEnumerable<IAnimalItem> _animalItems;
    private InstantiateSettings _instantiateSettings;

    private void OnEnable()
    {
        _instantiateSettings = InstantiateSettings.Instance;
        _animalItems = _instantiateSettings.AnimalItems;

        Render(_animalItems);
        
    }

    private void Render(IEnumerable<IAnimalItem> animalItems)
    {
        foreach (var item in animalItems)
        {
            var cell = Instantiate(_animalsPanelCellTemplate, _container);
            cell.Render(item);
        }
    }
}
