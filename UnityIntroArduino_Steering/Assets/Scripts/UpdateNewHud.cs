using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateNewHud : MonoBehaviour
{
    public Slider healthSlider;
    public Text scoreField;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreField.text = "Score: " + GameManager.Instance.points;
        healthSlider.value = GameManager.Instance.health;

     /*   foreach (GameObject item in bulletImages)
        {
            item.SetActive(false);
        }
        for (int i = 0; i < GameManager.bulletsInMagazine; i++)
        {

            bulletImages[i].SetActive(true);
        }*/
    }
}
