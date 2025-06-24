using UnityEngine;
using UnityEngine.InputSystem;

public class QuickExit : MonoBehaviour
{
    void Update()
    {
        if (Keyboard.current.escapeKey.isPressed)
        {
            Debug.Log("Game has been Quit");
            Application.Quit();
        }  
    }
}
