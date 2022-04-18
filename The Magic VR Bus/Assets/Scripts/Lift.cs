using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
 
    Animator _liftAdmin;
    Animator _doorAdmin;
    public GameObject LiftAutomationGroup;
    public GameObject Door;

    private void OnTriggerEnter(Collider other) {

         if (other.tag==("Player")){
            //_atliftRamp = true;
            //_doorAdmin.SetBool ("isOpening", true);
            _liftAdmin.SetBool ("IsLoading",true);
                //StartCoroutine (OpenLift ());
            Debug.Log("OnTrigger Lift rising");

        }   
        
    }

    private void OnTriggerExit(Collider other) {
        

    }
        
    
 
    // Start is called before the first frame update
    void Start()
    {
        _liftAdmin = LiftAutomationGroup.GetComponent<Animator>(); 
        _doorAdmin = Door.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
