using UnityEngine;

public class CameraMotion : MonoBehaviour
{
    [SerializeField] private Transform objectToFollowUp;
    [SerializeField] private float speed;
    
    [SerializeField] private Vector2 xRange;
    [SerializeField] private Vector2 yRange;
    
    private void Update()
    {
        Follow();
    }


    private void Follow()
    {
        Vector3 targetPosition = objectToFollowUp.position;
        targetPosition.y = transform.position.y;
        targetPosition.x = Mathf.Min(Mathf.Max(targetPosition.x, xRange.x), xRange.y);
        targetPosition.z = Mathf.Min(Mathf.Max(targetPosition.z, yRange.x), yRange.y);

        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, speed * Time.unscaledDeltaTime);
    }
}
