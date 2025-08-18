using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponController : MonoBehaviour
{
    #region imports
    public GunData gunData;
    [HideInInspector] public GameObject playerCam;
    [HideInInspector] public AudioSource audioSource;
    public GameObject bullet;
    private float currentAmmo = 0f;
    private float nextTimetoFire = 0f;

    private bool isReloading = false;

    [Header("Text Mesh Pro")]
    public TMP_Text ammoText;
    public TMP_Text reloadText;

    [Header("VFX")]
    public float bulletSpeed;
    public Transform muzzle;


    [Header("SFX")]
    public AudioClip gunshotSound;
    public AudioClip reloadSound;

    [Header("Raycasting")]
    RaycastHit hit;
    Vector3 target = Vector3.zero;
    #endregion

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentAmmo = gunData.magazineSize;
        ammoText.text= "Bullets: " + currentAmmo;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            TryShoot();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TryReload();
        }
    }

    #region shooting
    private void TryShoot()
    {
        if (currentAmmo <= 0f)
        {
            NotifyReload();
            return;
        }
        if (isReloading)
        {
            Debug.Log("The gun is reloading");
            return;
        }
        if (Time.time > nextTimetoFire) 
        {
            nextTimetoFire = Time.time + (1 / gunData.fireRate);
            HandleShoot();
        }
    }

    private void HandleShoot()
    {
        currentAmmo--;
        ammoText.text = "Bullets: "+ currentAmmo;
        Shoot();
    }
    private void Shoot()
    {
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.TransformDirection(Vector3.forward), out hit, gunData.shootingRange, gunData.targetLayerMask))
        {

            GameObject clonedBullet;
            clonedBullet = Instantiate(bullet, hit.point, Quaternion.LookRotation(hit.normal));
            clonedBullet.transform.parent = hit.collider.gameObject.transform;

            target = hit.point;

            if (hit.collider.gameObject.tag == "Target")
            {
                hit.collider.gameObject.GetComponent<PiegonScript>().Destroy();
                StartCoroutine(DestroyAfterDelay(clonedBullet, 3f));
            }
            else
            {
                StartCoroutine(DestroyAfterDelay(clonedBullet, 2f));
            }
        }
        playFireSound();
    }
    #endregion

    #region reloading

    public void TryReload()
    {
        if(!isReloading && currentAmmo < gunData.magazineSize)
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        isReloading = true;
        reloadText.gameObject.SetActive(false);
        audioSource.PlayOneShot(reloadSound);

        yield return new WaitForSeconds(gunData.reloadTime);

        currentAmmo = gunData.magazineSize;
        ammoText.text = "Bullets: " + currentAmmo;
        isReloading = false;
    }

    private void NotifyReload()
    {
        reloadText.gameObject.SetActive(true);
    }
    #endregion

    private IEnumerator DestroyAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (obj != null)
        {
            Destroy(obj);
        }
    }

    private void playFireSound()
    {
        if (gunshotSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(gunshotSound);
        }
    }
}
