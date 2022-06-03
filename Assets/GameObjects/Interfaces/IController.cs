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
        //Флаг для обозначение окончания работы контроллером
        protected bool endWork = false;
        public abstract bool Click();
        public abstract bool ClickUp();
        public abstract bool ObserveMousePosition();
        public virtual void PrepareToWork()
        {
            endWork = false;
        }    
        public abstract void StopWork();
        public abstract bool UpdateTargetGameObject(IGameObject gameObject);

    }
}
