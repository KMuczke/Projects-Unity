using UnityEngine;

public class Scorer : MonoBehaviour
{
    int hits = 0;
    void OnCollisionEnter(Collision other)
    {
        hits = hits + 1;
        Debug.Log("bomboclat " + hits);
    }
}
