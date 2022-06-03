﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.GameObjects.Helpers
{
    internal static class SelectorUtils
    {
        static Texture2D _whiteTexture;
        public static Texture2D WhiteTexture
        {
            get
            {
                if (_whiteTexture == null)
                {
                    _whiteTexture = new Texture2D(1, 1);
                    _whiteTexture.SetPixel(0 , 0, Color.white);
                    _whiteTexture.Apply();
                }
                return _whiteTexture;
            }
        }
        public static void DrawScreenRect(Rect rect, Color color)
        {
            GUI.color = color;
            GUI.DrawTexture(rect, WhiteTexture);
            GUI.color = Color.white;
        }

        public static Rect GetScreenRect(Vector2 screenPosition1, Vector2 screenPosition2)
        {
            screenPosition1.y = Screen.height - screenPosition1.y;
            screenPosition2.y = Screen.height - screenPosition2.y;

            var topLeft = Vector2.Min(screenPosition1, screenPosition2);
            var bottomRight = Vector2.Max(screenPosition1, screenPosition2);

            return Rect.MinMaxRect(topLeft.x, topLeft.y, bottomRight.x, bottomRight.y);
        }

        public static void DrawScreenBorder(Rect rect, float thickness, Color color)
        {
            SelectorUtils.DrawScreenRect( new Rect(rect.xMin, rect.yMin, rect.width, thickness), color);

            SelectorUtils.DrawScreenRect(new Rect(rect.xMin, rect.yMin, thickness, rect.height), color);

            SelectorUtils.DrawScreenRect(new Rect(rect.xMax - thickness, rect.yMin, thickness, rect.height), color);

            SelectorUtils.DrawScreenRect(new Rect(rect.xMin, rect.yMax - thickness, rect.width, thickness), color);
        }

        public static Bounds GetViewportBounds(Camera camera, Vector3 screenPosition1, Vector3 screenPosition2)
        {
            var v1 = Camera.main.ScreenToViewportPoint(screenPosition1);
            var v2 = Camera.main.ScreenToViewportPoint(screenPosition2);
            var min = Vector3.Min(v1, v2);
            var max = Vector3.Max(v1, v2);
            min.z = camera.nearClipPlane;
            max.z = camera.farClipPlane;

            var bounds = new Bounds();
            bounds.SetMinMax(min, max);
            return bounds;
        }
    }
}
