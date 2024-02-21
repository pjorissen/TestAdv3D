using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateFields : MonoBehaviour
{
    public Text scoreField;
    public Slider healthSlider;

    public GameObject[] bulletImages;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreField.text = "Score: " + GameManager.Instance.points;
        healthSlider.value = GameManager.Instance.health;

        int i;
        for ( i = 0; i < GameManager.bulletsInMagazine; i++)
        {    
            bulletImages[i].SetActive(true);
        }
        for (int j = i; j < GameManager.MAXBULLETS; j++)
        {
            bulletImages[j].SetActive(false);
        }
    }
}
