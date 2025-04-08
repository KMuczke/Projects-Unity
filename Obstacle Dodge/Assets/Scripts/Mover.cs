using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    float moveSpeed = 10f;
    void Start(){}

    void Update()
    {
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float yValue = 0f;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        transform.Translate(xValue,yValue,zValue);
    }
}
