using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateDoor : MonoBehaviour
{
    
    Animator _doorAdmin;
    public GameObject LiftAutomationGroup;
    Animator _liftAdmin;
    private Transform target;

    private bool isOpen = false;    
    private bool isOpening = false;
    private bool isClosing = false;
    
    private void OnTriggerEnter(Collider other) {
        //Debug.Log("OnTrigger Door Testing");
        Debug.Log ($"ontrigger enter object tag ---{other.tag}");
        if (other.tag==("Player")){
            _doorAdmin.SetBool ("isOpening", true);
            _liftAdmin.SetBool ("isOpening",true);
            //_liftAdmin.SetBool ("IsLoading",false);
            Debug.Log("OnTrigger Door Opening");

        }   
        if (_doorAdmin.GetBool ("isOpening")) {
             Debug.Log($" Yes, it is true!  {other.name} end");
         }
    }
    
     private void OnTriggerExit(Collider other) {
        Debug.Log ($"ontrigger Exit object tag ---{other.tag}");
         if (other.tag==("Player")){
        _doorAdmin.SetBool ("isOpening",false);
        _liftAdmin.SetBool ("isOpening",false);
        _liftAdmin.SetBool ("IsLoading",false);
        Debug.Log("OnTrigger Door CLosing");
         }
    }
    // Start is called before the first frame update
    void Start()
    {
      _doorAdmin = this.transform.parent.GetComponent<Animator>();
      _liftAdmin = LiftAutomationGroup.GetComponent<Animator>();      
       Debug.Log(" Just starting");
      target = GameObject.FindWithTag("Player").transform;
 
      

    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     if (_doorAdmin != null)
        //     {
        //         _doorAdmin.Play("Base Layer.OpenRampDoor");
        //         this.isOpening=_doorAdmin.GetBool("isOpening");
        //     }
        // }
    }

    
    //     public void ToggleDoor()
    // {
    //     if (isOpen)
    //         CloseDoor();
    //     else
    //         OpenDoor();
    // }


    //     public void OpenDoor()
    // {
    //     StopDoorAnims();
    //     isOpening = true;
    //     // _doorAdmin.SetBool("isOpening", true);

    //     // _doorAdmin.Play ("");

    //     // if (!isBackwards)
    //     //     StartCoroutine("ForwardDoor2");
    //     // else
    //     //     StartCoroutine("ReverseDoor2");

    //     // if (openSound != null)
    //     //     audioSource.PlayOneShot(openSound);
    //     isOpen = true;
    // }


    //     public void CloseDoor()
    // {
    //     // StopDoorAnims();
    //     // playedCloseSound = false;
    //     // isClosing = true;

    //     // if (!isBackwards)
    //     //     StartCoroutine("ReverseDoor2");
    //     // else
    //     //     StartCoroutine("ForwardDoor2");

    //     isOpen = false;
    // }

    // public void StopDoorAnims()
    // {
    //     // StopCoroutine("ForwardDoor2");
    //     // StopCoroutine("ReverseDoor2");
    // }

}
