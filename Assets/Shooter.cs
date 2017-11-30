using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Shooter : MonoBehaviour {

    [SerializeField]
    GameObject bullet; // Use a prefab so it doesn't have to be in the scene

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        // if (Input.GetButtonDown(("Fire1")))
        if (Input.GetButton(("Fire1")))
        {
            // Instantiate(bullet, transform.position, Quaternion.identity);
            Instantiate(bullet, transform.position, transform.rotation);

            FirstPersonController fpc = GetComponent<FirstPersonController>();

            // fpc.m_MoveDir.z -= 15;

            /*tmpRigid.AddForce(transform.forward * 600);

            Vector3 V = new Vector3(0f, 0f, -1f);
            tmpRigid.AddForce(Camera.main.transform.TransformDirection(V) * 6000);*/
        }
    }
}
