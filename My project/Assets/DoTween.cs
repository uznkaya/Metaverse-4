using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class DoTween : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelText;
    private void Start()
    {
        levelText.text = "Level " + CountManager.instance.level;
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOScale(new Vector3(2, 2, 1), 0.5f));
        mySequence.Append(transform.DOScale(new Vector3(0, 0, 1), 0.5f));
        mySequence.OnComplete(DestroyText);
    }

    void DestroyText()
    {
        Destroy(gameObject);
    }
}
