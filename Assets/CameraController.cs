using UnityEngine;

namespace Assets
{
    class CameraController: MonoBehaviour
    {
        public float panSpeed = 20f;
        public float panBorderThickness = 20f;

        public Vector2 panLimit;
        public float maxYLimit;
        public float minYLimit;

        public float scrollSpeed = 2000f;

        void Update()
        {
            Vector3 position = transform.position;

            if (Input.mousePosition.y >= Screen.height - panBorderThickness)
            {
                position.z += panSpeed * Time.deltaTime;
            }
            if (Input.mousePosition.y <= panBorderThickness)
            {
                position.z -= panSpeed * Time.deltaTime;
            }
            if (Input.mousePosition.x >= Screen.width - panBorderThickness)
            {
                position.x += panSpeed * Time.deltaTime;
            }
            if (Input.mousePosition.x <= panBorderThickness)
            {
                position.x -= panSpeed * Time.deltaTime;
            }

            float scroll = Input.GetAxis("Mouse ScrollWheel");
            position.y -= scroll * scrollSpeed * Time.deltaTime;

            position.y = Mathf.Clamp(position.y, minYLimit, maxYLimit);
            position.z = Mathf.Clamp(position.z, -panLimit.y, panLimit.y);
            position.x = Mathf.Clamp(position.x, -panLimit.x, panLimit.x);

            transform.position = position;
        }
    }
}