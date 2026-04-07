using UnityEngine;
using TMPro;

public class FlightExamManager : MonoBehaviour
{
    [SerializeField] private TMP_Text statusText;
    [SerializeField] private TMP_Text missionText;

    [SerializeField] private AudioSource hitAudioSource;
    [SerializeField] private AudioClip explosionClip ;
    
    public bool hasTakenOff = false;
    public bool enteredDangerZone = false;
    // TODO (Task 3-I): store whether the threat was cleared
    public bool threatCleared = false;
    public bool missionComplete =false;

    private void Start()
    {
        // we hide warning text
        if (statusText!= null)
        {
            statusText.gameObject.SetActive(false);
        }

        // we hide mission text at start
        if (missionText != null)
        {
            missionText.gameObject.SetActive(false);
        }
    }

    public void EnterDangerZone()
    {
        // TODO: update the mission state and HUD
        // player go inside danger place and  we show red text
        if (statusText!= null)
        {
            statusText.gameObject.SetActive(true);
            statusText.text = "Entered a Dangerous Zone! ";  //text for screen
        }
        
        // danger is start
        threatCleared =false;
        enteredDangerZone = true;
    }

    public void ExitDangerZone()    //when the player leave the dangerous are
    {
        // TODO: mark the threat as cleared and refresh the HUD
        // player escape from danger. 
        if (statusText !=null)
        {
            statusText.gameObject.SetActive(false );
            
        }
        
        threatCleared= true ;
    }

    // TODO (Task 3-J): handle failure, reset, or damage state when the missile reaches the aircraft
    public void PlayerHitByMissile()
    {
        // player is bom
        threatCleared =false; 
        missionComplete = false;

        //Add void
        if (hitAudioSource !=null && explosionClip!= null) hitAudioSource.PlayOneShot(explosionClip);
        
        // TODO (Task 3-K): update the HUD so the player understands whether escape or landing is now allowed
        // update text
        if (statusText!= null)
        {
            statusText.gameObject.SetActive(true );
            statusText.text = "Missile Hit. Try Again ";
        }

        if (missionText !=null)
        {
            missionText.gameObject.SetActive(false);
        }
    }

    public bool CanCompleteMission()
    {
        return enteredDangerZone && threatCleared && !missionComplete;
    }

    public void CompleteMission()
    {
        if (!CanCompleteMission())
        {
            return;
        }

        missionComplete = true;

        if (statusText != null)
        {
            statusText.gameObject.SetActive(false);
        }

        if (missionText != null)
        {
            missionText.gameObject.SetActive(true);
            missionText.text = "MISSION COMPLETE";
        }
    }
}