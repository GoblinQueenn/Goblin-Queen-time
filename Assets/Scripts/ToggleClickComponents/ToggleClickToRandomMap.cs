using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleClickToRandomMap : MonoBehaviour
{
    public void ActivateRandomMap()
    {
        if(GameManager.Instance != null)
        {
            GameManager.Instance.ActivateRandomMap();
        }
    }
}
