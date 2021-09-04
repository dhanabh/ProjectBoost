using System;
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

    [SerializeField] ParticleSystem  crashParticles;
    [SerializeField] ParticleSystem  successParticles;

    AudioSource audioSource;

    bool isTransitioning = false;

    bool movEnabled ;
    bool collisionDisabled = false;
     void Start() {
         audioSource = GetComponent<AudioSource>();
        movEnabled =    GetComponent<Movement>().enabled;
        
    }

    void Update() {
        
        RespondToDebugKeys();

    }

    private void RespondToDebugKeys()
    {
        if(Input.GetKeyDown(KeyCode.C)){

            collisionDisabled = !collisionDisabled;
            Debug.Log("Collison Mode: " + collisionDisabled);
        }
        else if(Input.GetKey(KeyCode.L)){
            
            NextLevel();

        }
    }

    private void OnCollisionEnter(Collision other) {

       
        if(isTransitioning || collisionDisabled)return;
        switch(other.gameObject.tag){

        

            case "Friendly":
                                Debug.Log("Rocket is on the launchpad!");
                                break;
            case "Finish":      
                                OnRestartOrLevelChange("NextLevel",success,successParticles);
                               
                                
                                break;
            case "Base":
                                Debug.Log("Rocket has landed on the base!");
                                OnRestartOrLevelChange("Respawn",crash,crashParticles);
                                //Respawn();
                                break;
            case "Obstacle":
                                Debug.Log("Rocket hit the obstacle!");
                                //audioSource.Stop();
                                //audioSource.PlayOneShot(success);
                                OnRestartOrLevelChange("Respawn",crash,crashParticles);
                                break;

        }

    }

    
    
    void OnRestartOrLevelChange(string functionName,AudioClip clip, ParticleSystem partSys){


     
            movEnabled = false;
        
            isTransitioning = true;
            audioSource.Stop();
            audioSource.PlayOneShot(clip);
            partSys.Play();
            
        
        Invoke(functionName,respawnDelay);
    
        //movEnabled = true;



    }
   public  void NextLevel(){

        

        
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
