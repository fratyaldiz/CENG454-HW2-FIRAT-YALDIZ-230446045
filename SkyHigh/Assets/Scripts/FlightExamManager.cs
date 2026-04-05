// FlightExamManager.cs
using UnityEngine;
using TMPro;

public class FlightExamManager : MonoBehaviour
{
    [SerializeField] private TMP_Text statusText;
    [SerializeField] private TMP_Text missionText;
    
    private bool hasTakenOff = false;
    private bool threatCleared = false;
    private bool missionComplete = false;

    private void Start()
    {
        // game start, we hide warning text
        if (statusText != null)
        {
            statusText.gameObject.SetActive(false);
        }
    }

    public void EnterDangerZone()
    {
        // TODO: update the mission state and HUD
        // player go inside danger place. we show red text
        if (statusText != null)
        {
            statusText.gameObject.SetActive(true);
            statusText.text = "Entered a Dangerous Zone!";  //text for screen
        }
        
        // danger is start
        threatCleared = false;
    }

    public void ExitDangerZone()    //when the player leave the dangerous area
    {
        // TODO: mark the threat as cleared and refresh the HUD
        // player escape from danger. we hide text again.
        if (statusText != null)
        {
            statusText.gameObject.SetActive(false);
        }
        
        threatCleared = true;
    }
}