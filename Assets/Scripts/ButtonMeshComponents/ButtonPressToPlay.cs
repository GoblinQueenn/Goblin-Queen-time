using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressToPlay : MonoBehaviour
{
    public void ChangeToGamePlay()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ActivateGamePlay();
        }
    }
}
