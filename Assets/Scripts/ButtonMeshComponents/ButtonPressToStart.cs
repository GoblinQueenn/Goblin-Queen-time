using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressToStart : MonoBehaviour
{
    public void ChangeToMainMenu()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ActivateMainMenu();
        }
    }
}
