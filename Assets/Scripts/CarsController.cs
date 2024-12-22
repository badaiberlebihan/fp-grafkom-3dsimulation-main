using UnityEngine;


public class CarsController : MonoBehaviour
{
    public GameObject FloatingCardPrefabs;
    private float floatingOffsetY = 1.1f;
    private BoxCollider boxCollider;
    private float triggerResetDelay = 5.0f;


    void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
    }


    void OnTriggerEnter(Collider other)
    {
        ShowFloatingCard();
    }


    void ShowFloatingCard()
    {
        float objectTopY = boxCollider.bounds.max.y;
        Vector3 spawnPosition = new Vector3(transform.position.x, objectTopY + floatingOffsetY, transform.position.z);
        Instantiate(FloatingCardPrefabs, spawnPosition, Quaternion.identity);


        boxCollider.isTrigger = false;
        StartCoroutine(ResetTriggerAfterDelay());
    }


    System.Collections.IEnumerator ResetTriggerAfterDelay()
    {
        yield return new WaitForSeconds(triggerResetDelay);
        boxCollider.isTrigger = true;
    }
}
