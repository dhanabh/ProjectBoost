using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        
        switch(other.gameObject.tag){

        

            case "Friendly":
                                Debug.Log("Rocket is on the launchpad!");
                                break;
            case "Finish":
                                Debug.Log("Mission accomplished successfully!");
                                break;
            case "Base":
                                Debug.Log("Rocket has landed on the base!");
                                Respawn();
                                break;
            case "Obstacle":
                                Debug.Log("Rocket hit the obstacle!");
                                break;

        }

    }

    void Respawn(){


        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(sceneIndex);

    }
}
