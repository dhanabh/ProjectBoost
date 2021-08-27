using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float respawnDelay = 2.0f;
    [SerializeField] AudioClip  crash;
    [SerializeField] AudioClip  success;
    AudioSource audioSource;

    bool isTransitioning = false;

    bool movEnabled ;
     void Start() {
         audioSource = GetComponent<AudioSource>();
        movEnabled =    GetComponent<Movement>().enabled;
        
    }
    private void OnCollisionEnter(Collision other) {

       
        
        switch(other.gameObject.tag){

        

            case "Friendly":
                                Debug.Log("Rocket is on the launchpad!");
                                break;
            case "Finish":      
                                OnRestartOrLevelChange("NextLevel",success);
                               
                                
                                break;
            case "Base":
                                Debug.Log("Rocket has landed on the base!");
                                OnRestartOrLevelChange("Respawn",crash);
                                //Respawn();
                                break;
            case "Obstacle":
                                Debug.Log("Rocket hit the obstacle!");
                                //audioSource.Stop();
                                //audioSource.PlayOneShot(success);
                                OnRestartOrLevelChange("Respawn",crash);
                                break;

        }

    }

    
    
    void OnRestartOrLevelChange(string functionName,AudioClip clip){


     
        movEnabled = false;
        
        if(!isTransitioning){
            audioSource.PlayOneShot(clip);
            isTransitioning = true;
        }
        Invoke(functionName,respawnDelay);
    
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
