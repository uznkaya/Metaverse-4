using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    [SerializeField] float duration;
    [SerializeField] Image coolDownImage;
    private void Start()
    {
        coolDownImage.fillAmount = 0f;
    }
    private void Update()
    {
        Timer();
    }

    void Timer()
    {
        if (Movement.dashed)
        {
            duration -= Time.deltaTime;
            coolDownImage.fillAmount = Mathf.InverseLerp(2.5f, 0, duration);
        }
        else
        {
            duration = 2.5f;
            coolDownImage.fillAmount = 0f;
        }
        
    }
}
