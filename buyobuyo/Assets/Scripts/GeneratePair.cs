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
     * -Establish the four "positions" that a puyo pair can be in (DONE), and rotate accordingly to input
     * -Animate rotations
     * -Feed values into PuyoGrid accurately
     * 
     * **/
    
    //Offset defines how far the second puyo is from the first
    public float offset = 1.0f;
    //Holds the puyo gameobject to be instatiated on start
    public GameObject puyoPrefab;
    //The transform of the pair
    private Transform thisPos;

    //Array that holds the two child puyos
    private GameObject[] puyos = new GameObject[2];
    //Strings for handling rotations
    private string[] potentialRotations = { "down", "left", "up", "right"};
    private string rotation = "down";

    //Angle which the second puyo is placed at
    private float angle = Mathf.Deg2Rad*270;
    
	// Use this for initialization
	void Start () {

        //Destroys the placeholder sprite
        Destroy(gameObject.GetComponent<SpriteRenderer>());

        //Generates the puyo pair
        thisPos = gameObject.GetComponent<Transform>();
        Vector3 pos = new Vector3(thisPos.position.x, thisPos.position.y, thisPos.position.z);
        Instantiate(puyoPrefab, pos, Quaternion.identity, thisPos);
        Vector3 pos2 = new Vector3(thisPos.position.x + Mathf.Cos(angle) * offset, thisPos.position.y + Mathf.Sin(angle) * offset, thisPos.position.z);
        Instantiate(puyoPrefab, pos2, Quaternion.identity, thisPos);

        puyos[0] = gameObject.transform.GetChild(0).gameObject;
        puyos[1] = gameObject.transform.GetChild(1).gameObject;
    }
	
	// Update is called once per frame
	void Update () {

        //Runs every 40 frames
        if (Time.frameCount%40 == 0)
        {

            //Loops through the potential rotation and changes the current rotation using those values
            /*for (int i = 0; i < potentialRotations.Length; i++)
            {
                if (rotation == potentialRotations[i])
                {
                    rotation = potentialRotations[(i+1 > 3) ? 0:i+1];
                    angle -= Mathf.PI / 2;
                    break;
                }
            }*/

            RotatePair("counter-clockwise");

            //Calculates the position of the second puyo using trig
            Vector3 puyoPosition = new Vector3(thisPos.position.x + Mathf.Cos(angle)*offset, thisPos.position.y + Mathf.Sin(angle)*offset, thisPos.position.z);

            Debug.Log(rotation);

            //Sets the position to the calculated one
            puyos[1].GetComponent<Transform>().position = puyoPosition;

        }

	}

    //Rotates the puyo pair, potential inputs are "clockwise" and "counter-clockwise"
    void RotatePair(string direction)
    {
        if (direction != "clockwise" && direction != "counter-clockwise")
        {
            Debug.Log("Rotate direction has to be clockwise or counter-clockwise!");
            return;
        }

        bool isClockwise = (direction == "clockwise"?true:false);

        if (isClockwise)
        {
            for (int i = 0; i < potentialRotations.Length; i++)
            {
                if (rotation == potentialRotations[i])
                {
                    rotation = potentialRotations[(i + 1 > 3) ? 0 : i + 1];
                    angle -= Mathf.PI / 2;
                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < potentialRotations.Length; i++)
            {
                if (rotation == potentialRotations[i])
                {
                    rotation = potentialRotations[(i - 1 < 0) ? 3 : i - 1];
                    angle += Mathf.PI / 2;
                    break;
                }
            }
        }

    }

}
