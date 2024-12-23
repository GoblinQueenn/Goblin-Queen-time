using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressToCredits : MonoBehaviour
{
    public void ChangeToCredits()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ActivateCredits();
        }
    }
}
