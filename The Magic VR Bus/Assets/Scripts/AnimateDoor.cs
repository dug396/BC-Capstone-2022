using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateDoor : MonoBehaviour
{
    
    #region Variables
    Animator _doorAdmin;
    public GameObject LiftAutomationGroup;
    Animator _liftAdmin;
    private Transform target;
    
    private string[] isCheckedValue ={
        "isOpening",
        "isLiftClosing",
        "IsLoading"
    };

    private bool isDebug = false;
    private bool _atliftRamp;
    private bool _isLiftTimerStarted = false;
    private int counter;
    private string isOpen;    
    private bool isOpening = false;
    private bool isClosing = false;       
    #endregion  
    // private void OnTriggerStay(Collider other) {
    //     Debug.Log ("======>  Tracking how busy this is");
    // }
    
    
    private void Validation (string Loop=null){      
        

        for (int i = 0; i < isCheckedValue.Length; i++)
        {
            
            if (_liftAdmin.GetBool (isCheckedValue[i])){
            Loop = Loop + $"===> Bool {isCheckedValue[i]} is True |";
              //Debug.Log ($"===> Bool {isCheckedValue[i]} is True");

            } else {
                //Debug.Log ($"===> Bool {isCheckedValue[i]} is False");
                Loop = Loop + $"===> Bool {isCheckedValue[i]} is False |";
            }
        }
        
        Debug.Log ($"===> Final  {Loop}");

        
    }
    
    private void OnTriggerEnter(Collider other) {
        
          //Debug.Log("OnTrigger Door Testing");
        if (isDebug) Debug.Log ($"ontrigger enter object tag ---{other.tag}");
        if (isDebug) Debug.Log($" Accessing the following---  {other.name} end");
         if (isDebug) Debug.Log($"collided with {other.gameObject.name}");
        if (other.tag==("Player")){
            _atliftRamp = true;
            _doorAdmin.SetBool ("isOpening", true);
            StartCoroutine (OpenLift ());
            Debug.Log("OnTrigger Door Opening");

        }   
        if (_doorAdmin.GetBool ("isOpening")) {
            if (isDebug) Debug.Log($" Yes, it is true!  {other.name} end");
         }

          Validation ("OnTriggerEnter"); 
    }
    
     private void OnTriggerExit(Collider other) {
        if (isDebug) Debug.Log ($"ontrigger Exit object tag ---{other.tag}");
         if (other.tag==("Player")){

            //_liftAdmin.SetBool ("isLiftClosing",true);
            _liftAdmin.SetBool ("isOpening",false);
            _liftAdmin.SetBool ("IsLoading",false);
            StartCoroutine (CloseDoor ());
            Debug.Log("OnTrigger Door CLosing");
            _atliftRamp = false;
         }
        Validation ("OnTriggerExit");  
         if (_liftAdmin.GetBool("isLiftClosing")==false) 
         {Debug.Log("====++++>>>>Exit - It is false"); 
         }
         else  {
             Debug.Log("====++++>>>>Exit - It is true");            
         
         }
        //  if (other.tag=="Lift" && _liftAdmin.GetBool("isLiftClosing")==false) {
        //      Debug.Log("====++++>>>>OnTriggerExit - setting lift to true");
        //      _liftAdmin.SetBool ("isLiftClosing",true);
        //  }
    }
    // Start is called before the first frame update
    void Start()
    {
      _doorAdmin = this.transform.parent.GetComponent<Animator>();
      _liftAdmin = LiftAutomationGroup.GetComponent<Animator>();      
       if (isDebug) Debug.Log(" Just starting");
      target = GameObject.FindWithTag("Player").transform; 
      Validation ("Start");  
    }

    IEnumerator CloseDoor (){
        Debug.Log($"CloseDoor - Started Coroutine at timestamp : {Time.time}.");       

        //yield on a new YieldInstruction that waits for 3 seconds.
        yield return new WaitForSeconds(3);

         _liftAdmin.SetBool ("isLiftClosing",true);
        yield return new WaitForSeconds(3);
      
        _doorAdmin.SetBool ("isOpening",false);
        _liftAdmin.SetBool ("isLiftClosing",false);
        //After we have waited 5 seconds print the time again.
        if (_liftAdmin.GetBool("isLiftClosing") == true) {
                isOpen="true";
            } 
        else 
            {
                isOpen="false";
                //_liftAdmin.SetBool ("isLiftClosing",true);
            } 
       Debug.Log($"CloseDoor - Finished Coroutine at timestamp : {Time.time} and ramp closing is {isOpen}" );             
        
    }
    IEnumerator OpenLift (){
        if (isDebug) Debug.Log($"OpenLift - Started Coroutine at timestamp : {Time.time}.");       

        //yield on a new YieldInstruction that waits for 3 seconds.
        yield return new WaitForSeconds(3);

            _liftAdmin.SetBool ("isOpening",true);
            _liftAdmin.SetBool ("IsLoading",false);
            _liftAdmin.SetBool ("isLiftClosing",false);

        //After we have waited 5 seconds print the time again.
       if (isDebug)  Debug.Log("OpenLift - Finished Coroutine at timestamp : " + Time.time);             
        
    }


     // Update is called once per frame
    void Update()
    {
        if (_atliftRamp == true)
        {
            
        //     if (_doorAdmin != null)
        //     {
        //         _doorAdmin.Play("Base Layer.OpenRampDoor");
        //         this.isOpening=_doorAdmin.GetBool("isOpening");
        //     }
         }
    }

    #region filter
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
    
    #endregion
    
}
