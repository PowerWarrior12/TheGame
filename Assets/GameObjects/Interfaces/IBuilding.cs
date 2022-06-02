using Assets.GameObjects.Interfaces;

namespace Assets.GameObjects
{
    internal interface IBuilding: IGameObject
    {
        public void UpdateBuilding(IBuildingConfig buildingConfig);
    }
}
