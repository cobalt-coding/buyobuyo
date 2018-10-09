using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePair : MonoBehaviour {

    /**
     * 
     * Basic code for generating a pair of puyos
     * Code is not yet complete
     * 
     * TODO:
     * -Establish the four "positions" that a puyo pair can be in, and rotate accordingly to input
     * 
     * **/
    
    //Offset defines how far the second puyo is from the first
    public float offset = 1.0f;
    //Holds the puyo gameobject to be instatiated on start
    public GameObject puyo;
    //The transform of the pair
    private Transform thisPos;

	// Use this for initialization
	void Start () {

        //Destroys the placeholder sprite
        Destroy(gameObject.GetComponent<SpriteRenderer>());

        //Generates the puyo pair
        thisPos = gameObject.GetComponent<Transform>();
        Vector3 pos = new Vector3(thisPos.position.x, thisPos.position.y, thisPos.position.z);
        Instantiate(puyo, pos, Quaternion.identity, thisPos);
        Vector3 pos2 = new Vector3(thisPos.position.x+offset, thisPos.position.y, thisPos.position.z);
        Instantiate(puyo, pos2, Quaternion.identity, thisPos);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
