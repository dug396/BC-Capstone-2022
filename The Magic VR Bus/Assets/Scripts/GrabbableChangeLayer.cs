using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableChangeLayer : MonoBehaviour
{    
    public void DisablePhysicsInteractionWithPlayer()
    {
        gameObject.layer = 11;
    }

    public void EnablePhysicsInteractionWithPlayer()
    {
        gameObject.layer = 9;
    }
}
