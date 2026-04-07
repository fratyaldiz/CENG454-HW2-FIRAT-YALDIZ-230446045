using UnityEngine;

public class LandingAreaTrigger : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private AudioSource successAudioSource;
    [SerializeField] private AudioClip successClip;
    public GameObject missionText;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Landing zone touched by player!");

        bool isPlayer = other.CompareTag("Player") || other.transform.root.CompareTag("Player");
        if (!isPlayer)
        {
            return;
        }
            
        if (examManager == null)
        {
            return;
        }

        if (!examManager.enteredDangerZone)
        {
            Debug.Log("enter the danger zone first");
            return;
        }

        if (!examManager.threatCleared)
        {
            Debug.Log("cannot land, threat still active");
            return;
        }

        if (examManager.missionComplete)
        {
            return;
        }

        GameObject missile = GameObject.FindWithTag("Missile");

        if (missile == null)
        {
            examManager.CompleteMission();
            Debug.Log("landed successfully, mission complete congratulations");

            if (successAudioSource != null && successClip != null)
            {
                //Add void
                successAudioSource.PlayOneShot(successClip);
            }

            if (missionText != null)
            {
                missionText.SetActive(true);
            }
        }
        else
        {
            Debug.Log("cannot land, threat still active");
        }
    }
}