using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiegonScript : MonoBehaviour
{
    public AudioSource audioSource;

    public int pointValue;
    public int speed;
    private float zlimit = -50f;

    public GameObject explosion;
    public AudioClip explodeSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (transform.position.z < zlimit)
        {
            Destroy(gameObject);
        }
    }

    void onCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    public void Destroy()
    {
        PlayExplosionSound();
        GameObject.Find("ScoreKeeper").GetComponent<ScoreController>().ChangeScore(pointValue);
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject, explodeSound.length);
    }

    public void PlayExplosionSound()
    {
        if (explodeSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(explodeSound);
        }
    }
}
