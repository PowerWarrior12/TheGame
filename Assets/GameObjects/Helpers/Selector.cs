using Assets.GameObjects.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.GameObjects.Helpers
{
    internal class Selector: MonoBehaviour
    {
        [SerializeField]
        private Collider _collider;
        private GameObjectsManager gameObjectsManager;
        private Vector2 startPosition;
        private Vector2 endPosition;
        private bool selected = false;
        private ArrayList selectedGameObjects = new ArrayList();
        private ArrayList spaceSelectedGameObjects = new ArrayList();
        public void Initializing(GameObjectsManager gameObjectsManager)
        {
            this.gameObjectsManager = gameObjectsManager;
        }
        public void StartSelect(Vector2 position)
        {
            selected = true;
            startPosition = position;
        }
        public void UpdateSelection(Vector2 position)
        {
            if (selected)
            {
                endPosition = position;
                CheckSelected();
            }
        }
        public void EndSelected()
        {
            selectedGameObjects.AddRange(spaceSelectedGameObjects);
            spaceSelectedGameObjects.Clear();
            endPosition = Vector2.zero;
            startPosition = Vector2.zero;
            selected = false;
        }
        public void ClickOnGameObject(IGameObject gameObject)
        {
            if (gameObject.IsSelected())
            {
                gameObject.Deselect();
                selectedGameObjects.Remove(gameObject);
            }
            else
            {
                gameObject.Select();
                selectedGameObjects.Add(gameObject);
            }
        }
        public void ClickNearGameObjects()
        {
            foreach (IGameObject gameObject in selectedGameObjects)
            {
                gameObject.Deselect();
            }
            selectedGameObjects.Clear();
        }
        private void CheckSelected()
        {
            var camera = Camera.main;
            var viewportsBouns = SelectorUtils.GetViewportBounds(camera, startPosition, Input.mousePosition);
            foreach (GameObject gameObject in gameObjectsManager.GetGameObjects())
            {
                var gameObjectC = gameObject.GetComponentInChildren<IGameObject>();
                if (viewportsBouns.Contains(camera.WorldToViewportPoint(gameObject.transform.position)))
                {
                    gameObjectC.Select();
                    spaceSelectedGameObjects.Add(gameObjectC);
                }
                else if (spaceSelectedGameObjects.Contains(gameObjectC))
                {
                    gameObjectC.Deselect();
                    spaceSelectedGameObjects.Remove(gameObject);
                }
            }
        }
        void OnGUI()
        {
            if (selected)
            {
                Rect rect = SelectorUtils.GetScreenRect(startPosition, endPosition);
                SelectorUtils.DrawScreenRect(rect, new Color(0.8f, 0.8f, 0.95f, 0.3f));
                SelectorUtils.DrawScreenBorder(rect, 2, new Color(0.8f, 0.8f, 0.95f));
            }
        }
    }
}
