// LandingAreaTrigger.cs
using UnityEngine;

public class LandingAreaTrigger : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    public GameObject missionText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
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

            GameObject missile = GameObject.FindWithTag("Missile");

            if (missile == null)
            {
                examManager.missionComplete = true;
                Debug.Log("landed successfully, mission complete congratulations");

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
}