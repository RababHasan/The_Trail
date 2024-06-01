using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FillStatusBar : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Image fillImage;
    private Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        float fillValue = playerHealth.currentHealth / (float)playerHealth.maxHealth;
        slider.value = fillValue;

        if (fillValue <= 0)
        {
            fillImage.enabled = false;
        }
        else
        {
            fillImage.enabled = true;

            if (fillValue <= 0.33f)
            {
                fillImage.color = Color.yellow;
            }
            else
            {
                fillImage.color = Color.green;
            }
        }
    }


}