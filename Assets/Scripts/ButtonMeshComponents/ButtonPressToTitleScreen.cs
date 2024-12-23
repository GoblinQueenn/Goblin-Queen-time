using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressToTitleScreen : MonoBehaviour
{
    public void ChangeToTitleScreen()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ActivateTitleScreen();
        }
    }
}
