using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Shooter : MonoBehaviour {

    [SerializeField]
    public GameObject m_bullet; // Use a prefab so it doesn't have to be in the scene
    public float m_cooldown = .5f;

    private float m_lastShot;

    // Use this for initialization
    private void Start ()
    {
        m_lastShot = Time.time;
    }
	
	// Update is called once per frame
	private void FixedUpdate ()
    {
        // if (Input.GetButtonDown(("Fire1")))
        if (Input.GetButton("Fire1") && Time.time - m_lastShot > m_cooldown)
        {
            m_lastShot = Time.time;

            // Instantiate(bullet, transform.position, Quaternion.identity);
            Instantiate(m_bullet, transform.position, transform.rotation);

            // FirstPersonController fpc = GetComponent<FirstPersonController>();

            // fpc.m_MoveDir.z -= 15;

            /*tmpRigid.AddForce(transform.forward * 600);

            Vector3 V = new Vector3(0f, 0f, -1f);
            tmpRigid.AddForce(Camera.main.transform.TransformDirection(V) * 6000);*/
        }
    }
}
