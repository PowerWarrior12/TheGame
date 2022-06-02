using Assets.GameObjects.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.GameObjects.Interfaces
{
    [Serializable]
    abstract class IController: MonoBehaviour
    {
        public abstract bool Click(RaycastHit hit);
        public abstract bool ObserveMousePosition(Vector3 position);
        public abstract void PrepareToWork();
        public abstract void StopWork();
        public abstract bool UpdateTargetGameObject(IGameObject gameObject);

    }
}
