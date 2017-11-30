using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    // If not specified, will be private by default
    public GameObject myVar;

    public int test = 23;

    [SerializeField] // Private but still displayed in Unity
    bool test2;
    
    [HideInInspector]
    public float dontShowMe = 125.65f;

    public static string imStatic;

	// Use this for initialization
	void Start () {
        // Needs to cast or it will be an integer division
        float casting = (float)test / 3;

        Debug.Log(casting);
        Debug.Log(Calculus(2, 3.5f)); // Will use the 2nd one as we're sending some floats
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public int Calculus(int A, int B)
    {
        int result = A + B;
        return result;
    }

    public float Calculus(float A, float B)
    {
        float result = A + B;
        return result;
    }
}
