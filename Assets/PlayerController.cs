using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera cam;

    public float moveSpeed = 10f;
    public float followRadius = 1.5f;
    public float fastRadius = 5f;
    public float speedBoost = 0.5f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 finalPositionVector = hit.point;
                TransitTo(transform, finalPositionVector);
            }
        }
    }

    private void TransitTo(Transform transform, Vector3 finalPositionVector)
    {
        Vector3 position = Vector3.MoveTowards(transform.position, finalPositionVector, Time.deltaTime * moveSpeed);
        position.y = 0.5f;
        transform.position = position;
    }
}