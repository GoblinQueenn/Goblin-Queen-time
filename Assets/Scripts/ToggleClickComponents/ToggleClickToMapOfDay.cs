using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleClickToMapOfDay : MonoBehaviour
{
    public void ActivateMapOfDay()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ActivateMapOfTheDay();
        }
    }
}
