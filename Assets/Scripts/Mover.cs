using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mover : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Vector3 movementVector ;
    [SerializeField][Range(0,1)] float movementFactor;
    [SerializeField] float period = 6.0f;
    const float tau = 2.0f * Mathf.PI;


    Vector3 startingPosition;
    Vector3 newPosition;
    void Start()
    {
        
        startingPosition = transform.position;
        movementVector = new Vector3(0f,-90f,0f);

    }

    // Update is called once per frame
    void Update()
    {
        float alpha = Time.time / period;
        float movementFactor = (Mathf.Sin(alpha*tau) + 1.0f)/2.0f;
        Debug.Log("factor= " + movementFactor );
        
        transform.position = startingPosition + (movementVector * movementFactor);
        
    }
}
