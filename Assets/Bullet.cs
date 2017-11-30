using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    /*
    [SerializeField]
    GameObject bullet; // Use a prefab so it doesn't have to be in the scene
    */

    // GameObject tmpBullet;  // Instance of the bullet
    Rigidbody tmpRigid;

    [SerializeField]
    [Range(1f, 10f)]
    float speed = 7f;

    [SerializeField]
    float lifetime = 5f;
    float age;

    // Use this for initialization
    void Start () {
        age = 0f;

        // Rather CPU heavy, do it during initialization only.
        tmpRigid = GetComponent<Rigidbody>();

        Vector3 V = new Vector3(0f, 0f, 1f);

        tmpRigid.AddForce(Camera.main.transform.TransformDirection(V)*1000);
        // tmpRigid.velocity = Camera.main.transform.TransformDirection(V) * 300;

        // tmpRigid.AddForce(transform.forward * speed * 600);
    }

    private void Update()
    {
        if(age < lifetime) {
            age += Time.deltaTime;
        }
        else {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        /*if(collision.transform.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }*/

        Destroy(gameObject);
    }

    // Update is called once per frame
    void FixedUpdate () { 
        // tmpRigid.AddForce(transform.forward * speed * 60);
        // tmpRigid.AddForce(Vector3.forward * speed);
    }
}