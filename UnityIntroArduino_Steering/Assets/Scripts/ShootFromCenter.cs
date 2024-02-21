using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFromCenter : MonoBehaviour
{
    public GameObject explosionEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   //check for mouseshot
        if(Input.GetMouseButtonDown(0) && GameManager.currentGameState == GameState.RUNNING)
        {
            Shoot();           
        }
        //check for arduino shot
        if(GameManager.Instance.shotFromArduinoReceived && GameManager.currentGameState == GameState.RUNNING)
        {
            Shoot();
            GameManager.Instance.shotFromArduinoReceived = false;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameManager.ReloadWeapon();
        }

    }

    public void Shoot()
    {
        if (GameManager.bulletsInMagazine > 0)
        {
            GameManager.bulletsInMagazine--;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 100))
            {
                if (hit.transform.name.Contains("Enemy"))
                {
                    Destroy(hit.transform.gameObject);
                    GameObject explosion = GameObject.Instantiate(explosionEffect, hit.transform.position, hit.transform.rotation);
                    Destroy(explosion, 3);
                    AudioManager.Instance.PlayClipOnce(AudioManager.AudioID.EXPLOSION);

                    //turn led on
                    StartCoroutine(LedOnForOneSecond());
                }
            }
        }
    }

    private IEnumerator LedOnForOneSecond()
    {
        GameManager.Instance.SetArduinoLed(true);
        float elapsedTime = 0f;
        while (elapsedTime < 1)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        GameManager.Instance.SetArduinoLed(false);
    }
}
