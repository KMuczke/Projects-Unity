using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField ]float valX = 0f;
    [SerializeField ]float valY = 0f;
    [SerializeField ]float valZ = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(valX,valY,valZ);
    }
}
