using UnityEngine;

[RequireComponent(typeof(Transform))]
public class MoveObject : MonoBehaviour
{
    [Header("Target Object to Move")]
    [SerializeField] private GameObject targetObject;

    [Header("Movement Settings")]
    public float hoverSpeed = 2f;
    
    public float hoverHeight = 0.5f;
    public float rotationSpeed = 60f;
    

    private void Start()
    {
        if (targetObject == null)
        {
            Debug.LogError("Target Object is not assigned in MoveObject script.");
            return;
        }
    }
    private void Update()
    {
        RotateObject();
    }

    private void RotateObject()
    {
        if (targetObject != null)
        {
            targetObject.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            targetObject.transform.position = new Vector3(
                targetObject.transform.position.x,
                hoverHeight + Mathf.Sin(Time.time * hoverSpeed) * hoverHeight,
                targetObject.transform.position.z
            );
        }
    }
}