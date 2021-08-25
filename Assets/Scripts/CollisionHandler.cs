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
                                NextLevel();
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
    void NextLevel(){
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        if(!(currentLevel == SceneManager.sceneCount)){

            SceneManager.LoadScene(currentLevel+1);

        }else{

            SceneManager.LoadScene(0);
        }





    }
    void Respawn(){


        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(sceneIndex);

    }
}
