using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateDoor : MonoBehaviour
{
    
    Animator _doorAdmin;
    public bool isOpen = false;
    private bool isOpening = false;
    private bool isClosing = false;
    
    // Start is called before the first frame update
    void Start()
    {
      _doorAdmin = this.transform.parent.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_doorAdmin != null)
            {
                _doorAdmin.Play("Base Layer.OpenRampDoor");
                this.isOpening=_doorAdmin.GetBool("isOpening");
            }
        }
    }

    
        public void ToggleDoor()
    {
        if (isOpen)
            CloseDoor();
        else
            OpenDoor();
    }


        public void OpenDoor()
    {
        StopDoorAnims();
        isOpening = true;
        // _doorAdmin.SetBool("isOpening", true);

        // _doorAdmin.Play ("");

        // if (!isBackwards)
        //     StartCoroutine("ForwardDoor2");
        // else
        //     StartCoroutine("ReverseDoor2");

        // if (openSound != null)
        //     audioSource.PlayOneShot(openSound);
        isOpen = true;
    }


        public void CloseDoor()
    {
        // StopDoorAnims();
        // playedCloseSound = false;
        // isClosing = true;

        // if (!isBackwards)
        //     StartCoroutine("ReverseDoor2");
        // else
        //     StartCoroutine("ForwardDoor2");

        isOpen = false;
    }

    public void StopDoorAnims()
    {
        // StopCoroutine("ForwardDoor2");
        // StopCoroutine("ReverseDoor2");
    }

}
