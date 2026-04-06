// MissileHoming.cs
using UnityEngine;

public class MissileHoming : MonoBehaviour
{
    [SerializeField] private float moveSpeed =20f;
    [SerializeField] private float turnSpeed =5f;
    private Transform target;

    public void SetTarget( Transform newTarget)
    {
        // TODO (Task 3-E): cache the aircraft transform
        // we save player target
        target =newTarget;
    }

    void Update()
    {
        // TODO (Task 3-F): rotate toward the target and move forward
        
        // if target exist, look at target slowly
        if (target != null)
        {
            Vector3 direction = target.position- transform.position;
            Quaternion lookRot =Quaternion.LookRotation(direction);
            // turning logic
            transform.rotation = Quaternion.Slerp(transform.rotation,lookRot, turnSpeed*Time.deltaTime );
        }

        // fly forward always fast
        transform.Translate(Vector3.forward* moveSpeed *Time.deltaTime );
    }

    // misile will explode when player is touch 
    private void OnTriggerEnter( Collider other)
    {

        if (other.CompareTag("Player "))
        {
            Debug.Log("BOOM! Player hit by missile!");
            // destroy this missile
            Destroy( gameObject);
        }
    }
}