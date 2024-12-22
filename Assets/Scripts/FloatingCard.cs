using UnityEngine;


public class FloatingCard : MonoBehaviour
{
    private float destroyTime = 5.0f;
    private Transform cameraTransform;


    void Start()
    {
        Destroy(gameObject, destroyTime);


        if (Camera.main != null)
        {
            cameraTransform = Camera.main.transform;
        }
    }


    void Update()
    {
        if (cameraTransform != null)
        {
            Vector3 direction = cameraTransform.position - transform.position;
            direction.y = 0;
            transform.rotation = Quaternion.LookRotation(-direction);
        }
    }
}
