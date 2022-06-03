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
        private ArrayList selectedGameObjects = new ArrayList();
        private void Start()
        {
            selector.SetOnSelect(SelectObject);
        }

        public override bool Click()
        {
            selector.StartSelect(Input.mousePosition);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitData;
            if (Physics.Raycast(ray, out hitData, 100, gameObjectMask))
            {
                IGameObject clickedGameObject = hitData.transform.GetComponent<IGameObject>();
                SelectObject(clickedGameObject);
            }
            else
            {
                foreach (IGameObject gameObject in selectedGameObjects)
                {
                    gameObject.Deselect();
                }
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

        private void SelectObject(IGameObject gameObject)
        {
            if (gameObject != null)
            {
                selectedGameObjects.Add(gameObject);
                gameObject.Select();
            }
        }

        public override bool UpdateTargetGameObject(IGameObject gameObject)
        {
            return false;
        }
    }
}
