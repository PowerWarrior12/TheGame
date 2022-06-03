using Assets.GameObjects.Helpers;
using Assets.GameObjects.Interfaces;
using System;
using UnityEngine;

namespace Assets.GameObjects.Controllers
{
    internal class BuildingsController : IController
    {
        //Mask
        [SerializeField]
        private GameObjectShadow gameObjectShadow;
        [SerializeField]
        private GameObjectsManager gameObjectsManager;
        [SerializeField]
        private LayerMask gameObjectMask;
        [SerializeField]
        private LayerMask groundMask;
        override public bool Click()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
            RaycastHit hitData;
            if (Physics.Raycast(ray, out hitData, 100, groundMask) && gameObjectShadow.CheckErrorStatus())
            {
                gameObjectShadow.SetActive(false);
                gameObjectsManager.CreateBuilding(hitData.point);
                endWork = true;
            }
            return false;
        }

        public override bool ClickUp()
        {
            return endWork;
        }

        override public bool ObserveMousePosition()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitData;
            if (Physics.Raycast(ray, out hitData, 100, groundMask))
            {
                gameObjectShadow.UpdatePosition(hitData.point);
            }

            return false;
        }

        override public void PrepareToWork()
        {
            base.PrepareToWork();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitData;
            if (Physics.Raycast(ray, out hitData, 100, groundMask))
            {
                gameObjectShadow.gameObject.SetActive(true);
                gameObjectShadow.UpdatePosition(hitData.point);
            }
        }

        override public void StopWork()
        {
            gameObjectShadow.SetActive(false);
        }

        override public bool UpdateTargetGameObject(IGameObject gameObject)
        {
            throw new NotImplementedException();
        }
    }
}
