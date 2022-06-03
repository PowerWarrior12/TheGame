using Assets.GameObjects.Interfaces;
using UnityEngine;
using System.Collections;
using Assets.GameObjects.Helpers;
using System;

namespace Assets.GameObjects.Controllers
{
    internal class DefaultController : IController
    {
        [SerializeField]
        private Selector selector;
        [SerializeField]
        private LayerMask gameObjectMask;
        [SerializeField]
        private GameObjectsManager gameObjectsManager;
        private void Start()
        {
            selector.Initializing(gameObjectsManager);
        }

        public override bool Click()
        {
            selector.StartSelect(Input.mousePosition);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitData;
            if (Physics.Raycast(ray, out hitData, 100, gameObjectMask))
            {
                IGameObject clickedGameObject = hitData.transform.GetComponent<IGameObject>();
                selector.ClickOnGameObject(clickedGameObject);
            }
            else
            {
                selector.ClickNearGameObjects();
            }
            return false;
        }

        public override bool ClickUp()
        {
            selector.EndSelected();
            return false;
        }

        public override bool ObserveMousePosition()
        {
            selector.UpdateSelection(Input.mousePosition);
            return false;
        }

        public override void PrepareToWork()
        {
        }

        public override void StopWork()
        {
            selector.EndSelected();
        }

        public override bool UpdateTargetGameObject(IGameObject gameObject)
        {
            return false;
        }
    }
}
