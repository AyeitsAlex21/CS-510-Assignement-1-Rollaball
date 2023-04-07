using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        // Use delta time so actions happen smoothly regardless of frame rate
    }
    // add rigidbody to collectables because you want it to be dynamic object 
    // so it takes less long to calculate physics

    // need to disable gravity and enable kinematic (if kin off then still responds to phys forces)


    // static colliders dont move like walls floors

    // dynamic colliders can move and have rigid body
    // standard rigid bodys are moved by physics forces
    // kinematic rigid bodies are moved by the transform
}
