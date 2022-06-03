using Assets.GameObjects;
using Assets.GameObjects.Interfaces;
using UnityEngine;

public class Building : MonoBehaviour, IBuilding
{
    private Transform _transform;
    private bool isSelected = false;
    [SerializeField]
    private SelectingObject selectingObject;

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public bool IsSelected()
    {
        return isSelected;
    }

    public void Select()
    {
        isSelected = true;
        selectingObject.SetVisible(isSelected);
    }

    public void Deselect()
    {
        isSelected = false;
        selectingObject.SetVisible(false);
    }

    public void UpdateBuilding(IBuildingConfig buildingConfig)
    {
        throw new System.NotImplementedException();
    }
}
