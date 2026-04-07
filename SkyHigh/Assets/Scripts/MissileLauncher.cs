// CENG 454 - HW2 Midterm: Sky-High Prototype II
// Author: FIRAT YALDIZ | Student ID: 230446045
using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private Transform launchPoint;
    [SerializeField] private AudioSource launchAudioSource;
    
    private GameObject activeMissile;
    
    public GameObject Launch(Transform target)
    {
        // TODO (Task 3-A): instantiate the missile at launchPoint
        // i make new missile
        activeMissile = Instantiate(missilePrefab, launchPoint.position, launchPoint.rotation);
        
        // TODO (Task 3-B): give the missile its target
        // i find brain of missile and give player target
        MissileHoming missileScript =activeMissile.GetComponent<MissileHoming>();
        if (missileScript !=null)
        {
            missileScript.SetTarget(target);
        }
        
        // TODO (Task 3-C): play launch audio and return the spawned missile
        if (launchAudioSource!= null)
        {
            launchAudioSource.Play();
        }
        
        return activeMissile;
    }

    public void DestroyActiveMissile()
    {
        // TODO (Task 3-D): destroy the current missile safely if one exists
        // if missile is not dead, we kill it
        if (activeMissile!= null)
        {
            Destroy(activeMissile);
            activeMissile = null;
        }
    }
}