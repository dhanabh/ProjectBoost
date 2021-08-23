using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        
        switch(other.gameObject.tag){

            case "Friendly":
                                Debug.Log("Rocket is on the launchpad!");
                                break;
            case "Finish":
                                Debug.Log("Mission accoplished successfully!");
                                break;
            case "Base":
                                Debug.Log("Racket has landed on the base!");
                                break;
            case "Obstacle":
                                Debug.Log("Rocket hit the obstacle!");
                                break;

        }

    }
}
