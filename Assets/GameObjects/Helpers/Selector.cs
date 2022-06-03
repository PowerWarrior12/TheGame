using Assets.GameObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.GameObjects.Helpers
{
    internal class Selector: MonoBehaviour
    {
        private Action<IGameObject> onSelect;
        private Vector2 startPosition;
        private Vector2 endPosition;
        private bool selected = false;
        public void SetOnSelect(Action<IGameObject> action)
        {
            onSelect = action;
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
                var camera = Camera.main;
                var viewportBounds = SelectorUtils.GetViewportBounds(camera, startPosition, endPosition);
            }
        }
        public void EndSelected()
        {
            endPosition = Vector2.zero;
            startPosition = Vector2.zero;
            selected = false;
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
