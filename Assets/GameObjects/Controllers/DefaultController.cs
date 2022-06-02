using Assets.GameObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.GameObjects.Controllers
{
    internal class DefaultController : IController
    {
        public override bool Click(RaycastHit hit)
        {
            IGameObject clickedGameObject = hit.transform.GetComponent<IGameObject>();
            if (clickedGameObject != null)
            {
                clickedGameObject.Select();
            }
            return true;
        }

        public override bool ObserveMousePosition(Vector3 position)
        {
            return false;
        }

        public override void PrepareToWork()
        {
            
        }

        public override void StopWork()
        {
        }

        public override bool UpdateTargetGameObject(IGameObject gameObject)
        {
            return false;
        }
    }
}
