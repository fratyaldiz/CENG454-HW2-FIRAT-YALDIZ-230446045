// AircraftThreatHandler.cs
using UnityEngine;

public class AircraftThreatHandler : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private AudioSource hitAudioSource;
    [SerializeField] private FlightExamManager examManager;
    
    private Rigidbody rb;

    void Start()
    {
        // TODO (Task 3-G): cache GetComponent() into 'rb'
        // i get rigidbody here for physıcs
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        // TODO (Task 3-H): if the missile hits the aircraft, apply the chosen penalty
        
        // we check if the thing hitting us is the misile
        if (collision.GetComponent<MissileHoming>() !=null)
        {
            Debug.Log("NOOOOOOOO! Misile hit me");
            
            // play boom sound if we have it
            if (hitAudioSource != null)
            {
                hitAudioSource.Play();
            }

            // teleport player to start point
            if (respawnPoint != null)
            {
                transform.position= respawnPoint.position;
                transform.rotation =respawnPoint.rotation;
                
                // stop player from moving after teleport
                if (rb != null)
                {
                    rb.linearVelocity =Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                }
            }

            // tell manager we fail
            if (examManager != null)
            {
                examManager.PlayerHitByMissile();
            }
        }
    }
}