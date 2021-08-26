using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float respawnDelay = 10.0f;
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
                                OnCrashReset();
                                //Respawn();
                                break;
            case "Obstacle":
                                Debug.Log("Rocket hit the obstacle!");
                                OnCrashReset();
                                break;

        }

    }
    
    void OnCrashReset(){


     bool movEnabled =    GetComponent<Movement>().enabled;
        
        movEnabled = false;

        Invoke("Respawn",respawnDelay);
    
        //movEnabled = true;



    }
    void NextLevel(){
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        if(!(currentLevel == SceneManager.sceneCountInBuildSettings -1)){

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
