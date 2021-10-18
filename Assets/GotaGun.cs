using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotaGun : MonoBehaviour
{
    public int distance = 10;
    public Transform gunPosition;
    GameObject currentWeapon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    void OnTriggerEnter(Collider collid)
    {
        CheckGrab();

        if(collid.name == "Player")
        {
            PickUp();
        }
    }


    private void CheckGrab()
    {
        RaycastHit hit;
        //Physics.Raycast(raycastPoint.position, shootRay, out hit, 100)
        if (Physics.Raycast(gunPosition.position,transform.rotation,out hit,distance))
        {
            Debug.Log("Got it!");
            currentWeapon = hit.transform.gameObject;
            Gun = true;
        }
        else
        {
            Gun = false;
        }
    }
    private void PickUp()
    {
        currentWeapon.transform.position = gunPosition.position;
        currentWeapon.transform.parent = gunPosition;
        currentWeapon.transform.localEulerAngles = new Vector3(0, 180, 180);
        currentWeapon.GetComponent<Rigidbody>().isKinematic = true;
    }
}
