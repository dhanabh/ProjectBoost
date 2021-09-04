using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    
    Rigidbody rb  ;
    AudioSource audioSource;
   [SerializeField] float mainThrust = 350f;
   [SerializeField] float rotationSpeed = 150f;

   [SerializeField] AudioClip sndThrust;
   [SerializeField] ParticleSystem rocketThrustParticles;
   [SerializeField] ParticleSystem rightThrustParticles;

   [SerializeField] ParticleSystem leftThrustParticles;
   Vector3 startingPosition ;
   Vector3 startingRotation;
   
    
   

    void Start()
    {
        Debug.Log("Here we go again!");
        
        startingPosition = new Vector3(-40f,10.5f,0f);
        startingRotation = new Vector3(0,0,0);

        rb  = GetComponent<Rigidbody>();
        
        audioSource = GetComponent<AudioSource>() ;
    }

    // Update is called once per frame
    void Update()
    {
        ProcesThrust();
        ProcessRotation();
        GameReset();
       
        
    }

   

    void ProcesThrust(){

        
        if(Input.GetKey(KeyCode.Space))
        {
            //Debug.Log("Move Forward");


            StartForwardThrust();

        }
        else
        {
            StopForwardThrust();

        }
       

    }

    

    private void StartForwardThrust()
    {
        rb.AddRelativeForce(Vector3.up * Time.deltaTime * mainThrust);

        if (!rocketThrustParticles.isPlaying)
        {

            rocketThrustParticles.Play();

        }



        if (!audioSource.isPlaying)
        {

            audioSource.PlayOneShot(sndThrust);

        }

    }
    private void StopForwardThrust()
    {
        rocketThrustParticles.Stop();
        audioSource.Stop();
    }
    void ProcessRotation(){

        if(Input.GetKey(KeyCode.A) && !(Input.GetKey(KeyCode.D)))
        {
            Debug.Log("Rotate Left");
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D) && !(Input.GetKey(KeyCode.A)))
        {

            Debug.Log("Rotate Right");
            RotateRight();
        }
        else
        {
            StopRotation();
        }
        

    }

        private void RotateLeft()
    {
        if (!rightThrustParticles.isPlaying)
        {
            rightThrustParticles.Play();
        }
        ApplyRotation(rotationSpeed);
    }
    private void RotateRight()
    {
        if (!leftThrustParticles.isPlaying)
        {
            leftThrustParticles.Play();

        }
        ApplyRotation(-rotationSpeed);
    }

    private void StopRotation()
    {
        leftThrustParticles.Stop();
        rightThrustParticles.Stop();
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation =true;//freezing the auto rotation on collision so we can rotate manually 
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationThisFrame);
        rb.freezeRotation = false;//unfreezing the auto rotation
    }
    void GameReset(){

        if(Input.GetKey(KeyCode.Z)|| transform.position[1]<= -45){

           //transform.rotation=Quaternion.Euler(startingRotation);
           //transform.position = startingPosition;
           int currentScene = SceneManager.GetActiveScene().buildIndex;
           SceneManager.LoadScene(currentScene);

        }



    }

    
}
