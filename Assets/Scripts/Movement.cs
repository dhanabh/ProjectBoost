using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody rb  ;
   [SerializeField] float mainThrust = 350f;
   [SerializeField] float rotationSpeed = 150f;
   Vector3 startingPosition ;
   Vector3 startingRotation;


    void Start()
    {
        startingPosition = new Vector3(-40f,10.5f,0f);
        startingRotation = new Vector3(0,0,0);

        rb  = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcesThrust();
        ProcessRotation();
        GameReset();
    }

    void ProcesThrust(){

        if(Input.GetKey(KeyCode.Space)){

            //Debug.Log("Move Forward");
           

            rb.AddRelativeForce(Vector3.up*Time.deltaTime* mainThrust);
        }
        

    }

    void ProcessRotation(){

        if(Input.GetKey(KeyCode.A) && !(Input.GetKey(KeyCode.D)))
        {
            Debug.Log("Rotate Left");
            ApplyRotation(rotationSpeed);
        }
        if (Input.GetKey(KeyCode.D) && !(Input.GetKey(KeyCode.A))){
            
            Debug.Log("Rotate Right");
            ApplyRotation(-rotationSpeed);
        }

    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation =true;//freezing the auto rotation on collision so we can rotate manually 
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationThisFrame);
        rb.freezeRotation = false;//unfreezing the auto rotation
    }
    void GameReset(){

        if(Input.GetKey(KeyCode.Z)|| transform.position[1]<= -45){

           transform.rotation=Quaternion.Euler(startingRotation);
           transform.position = startingPosition;

        }



    }
}
