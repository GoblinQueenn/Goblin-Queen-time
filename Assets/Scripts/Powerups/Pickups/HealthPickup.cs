using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public HealthPowerup powerup;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        // Veriable for our PowerupManager
        PowerupManager powerupManager = other.GetComponent<PowerupManager>();

        // If other object has it
        if (powerupManager != null )
        {
            // Add the powerup
            powerupManager.Add(powerup);

            // Destroy the pickup
            Destroy(gameObject);
        }
    }
}
