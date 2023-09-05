using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    // Update is called once per frame
    private bool canSpawnDog = true;
 void Update()
    {
        // Check if the player presses the spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Check if you can spawn a dog (cooldown is over)
            if (canSpawnDog)
            {
                SpawnDog();
                StartCoroutine(StartCooldown());
            }
        }

    }
    private void SpawnDog()
    {
        // Instantiate a new dog at the spawner's position
        Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
    }

    private IEnumerator StartCooldown()
    {
        canSpawnDog = false;

        // Wait for 5 seconds before allowing the player to spawn another dog
        yield return new WaitForSeconds(2f);

        canSpawnDog = true;
    }
    
    
}
