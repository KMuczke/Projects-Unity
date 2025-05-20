using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
float moveSpeed = 10f;
    void Start() 
    {PrintInstruction();}

    void Update()
    {MovePlayer();}



    void PrintInstruction()
    {
    Debug.Log("Welcome to the Game !");
    Debug.Log("WASD / Arrow keys to move your player");
    Debug.Log("Don't touch the obstacles!");
    }

    void MovePlayer()
    {
    float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
    float yValue = 0f;
    float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
    transform.Translate(xValue, yValue, zValue);
    }



}
