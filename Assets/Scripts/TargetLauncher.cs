using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLauncher : MonoBehaviour
{
    public GameObject LauncherBase;
    public GameObject Launcher;
    public Transform targetLaunchPoint;
    public Rigidbody[] piegons;

    public bool gameIsPlaying;

    void Start()
    {
        StartCoroutine(RandomRotation());
    }

    IEnumerator RandomRotation()
    {
        while (gameIsPlaying)
        {
            yield return new WaitForSeconds(1f);

            float randomBaseRotation;
            randomBaseRotation = Random.Range(-30f, 30f);
            iTween.RotateTo(LauncherBase, iTween.Hash(
                "y", randomBaseRotation,
                "time", 1f,
                "isLocal", true,
                "easeType", "spring"
            ));

            float randomLauncherRotation;
            randomLauncherRotation = Random.Range(0f, -25f);
            iTween.RotateTo(Launcher, iTween.Hash(
                "x", randomLauncherRotation,
                "time", 1f,
                "isLocal", true,
                "easeType", "spring"
            ));
            yield return new WaitForSeconds(1f);

            int randomPiegonNumber = Random.Range(0, piegons.Length);
            Rigidbody clonePigeon;
            clonePigeon = Instantiate(piegons[randomPiegonNumber], targetLaunchPoint.position, targetLaunchPoint.rotation);
            clonePigeon.linearVelocity = targetLaunchPoint.TransformDirection(Vector3.forward * clonePigeon.gameObject.GetComponent<PiegonScript>().speed);

            yield return new WaitForSeconds(1f);
        }
       
    }
}