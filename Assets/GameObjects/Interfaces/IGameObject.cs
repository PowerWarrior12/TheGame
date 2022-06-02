using UnityEngine;

namespace Assets.GameObjects.Interfaces
{
    public interface IGameObject
    {
        public void Destroy();
        public bool IsSelected();
        public void Select();
        public void Deselect();
    }
}
