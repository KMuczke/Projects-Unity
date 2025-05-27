using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Chaser : MonoBehaviour
{
    [SerializeField] float mSpeed = 1.0f;
    [SerializeField] Transform player;
    Vector3 playerPosition;

    void Awake()
    {
        gameObject.SetActive(false);
    }



    void Start()
    {
        playerPosition = player.transform.position;
        
    }

    void Update()
    {
        MoveToPlayer();
        DestroyWhenReached();
    }

    void MoveToPlayer()
    {
        transform.position =
        Vector3.MoveTowards(transform.position, playerPosition, Time.deltaTime * mSpeed);
    }



    void DestroyWhenReached()
    {
        if(transform.position == playerPosition)
        {Destroy(gameObject);}
    }

}


