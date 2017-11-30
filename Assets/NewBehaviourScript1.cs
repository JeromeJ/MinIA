using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log(NewBehaviourScript.imStatic);

        // You aren't supposed to do this :))
        NewBehaviourScript new_ttest = new NewBehaviourScript();

        Debug.Log(new_ttest.test);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Awake()
    {
        // Executed before Start
    }

    private void FixedUpdate()
    {
        // Same as update but only for the physic
        // As physic is pretty CPU consumming, it's triggered less often.
    }


}
