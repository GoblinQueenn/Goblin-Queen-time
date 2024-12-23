using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressToOptions : MonoBehaviour
{
    public void ChangeToOptionsScreen()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ActivateOptionsScreen();
        }
    }
}
