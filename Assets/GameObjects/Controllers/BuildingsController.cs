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
        private Camera _camera;
        [SerializeField]
        private GameObjectsGenerator generator;
        [SerializeField]
        private LayerMask gameObjectMask;
        [SerializeField]
        private LayerMask groundMask;
        override public bool Click(RaycastHit hit)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitData;
            if (Physics.Raycast(ray, out hitData, 100, groundMask) && !Physics.Raycast(ray, out hitData, 100, gameObjectMask))
            {
                gameObjectShadow.SetActive(false);
                generator.CreateBuildingPrefab(hit.point);
            }
            return true;
        }

        override public bool ObserveMousePosition(Vector3 position)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitData;
            if (Physics.Raycast(ray, out hitData, 100, groundMask))
            {
                gameObjectShadow.UpdatePosition(hitData.point);
            }

            return true;
        }

        override public void PrepareToWork()
        {
            Ray ray = new Ray(_camera.transform.position, _camera.transform.forward);
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
