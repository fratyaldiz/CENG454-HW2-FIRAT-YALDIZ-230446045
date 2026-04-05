// DangerZoneController.cs
using UnityEngine;
using System.Collections; // i add this because timer need this

public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    //[SerializeField] private MissileLauncher missileLauncher;
    [SerializeField] private float missileDelay = 5f;   //delay of missile
    
    private Coroutine activeCountdown;

    private void OnTriggerEnter(Collider collision)
    {
        // TODO: confirm the Player tag
        // we check if it is player ship
        if (collision.CompareTag("Player"))
        {
            // TODO: push the warning message "Entered a Dangerous Zone!" to the HUD
            // manager show red text in screen
            if (examManager != null)
            {
                examManager.EnterDangerZone();
            }

            // TODO: start the delayed missile launch countdown
            // we start 5 second timer for missile
            activeCountdown = StartCoroutine(MissileTimer(collision.transform));    //countdown begin
        }
    }

    private void OnTriggerExit(Collider collision)  //Starts when the aircraft enter of area
    {
        // TODO: confirm the Player tag
        
        if (collision.CompareTag("Player")) // we check player escape?
        {
            // TODO: cancel any pending launch countdown
            // timer stop
            if (activeCountdown != null)
            {
                StopCoroutine(activeCountdown);
                activeCountdown = null;
            }

            // TODO: destroy the active missile and clear the HUD warning
            // manager hide red text
            if (examManager != null)
            {
                examManager.ExitDangerZone();
            }

            // TODO: missile is destroy now
           
        }
    }

    // this is timer routine. it wait then shoot.
    private IEnumerator MissileTimer(Transform playerTransform)
    {
        // wait 5 second
        yield return new WaitForSeconds(missileDelay);
        
        // time is finish, shoot missile to player!
    }
}