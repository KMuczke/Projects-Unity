using UnityEngine;

public class Dropper : MonoBehaviour
{

    [SerializeField ]float timeToWait = 2f;

    MeshRenderer myMeshRend;
    Rigidbody dropRigid;

    void Start()
    {
        myMeshRend = GetComponent<MeshRenderer>();
        dropRigid = GetComponent<Rigidbody>();

        myMeshRend.enabled = false;
        dropRigid.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeToWait)
        {
            myMeshRend.enabled = true;
            dropRigid.useGravity = true; 
        }
    }
}
