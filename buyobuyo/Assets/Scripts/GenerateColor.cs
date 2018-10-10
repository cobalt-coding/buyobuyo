using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateColor : MonoBehaviour {

    /**
     * 
     * Simple script which generates a random color for a puyo
     * It accesses all sprites from the "Resources" folder in Unity,
     * and changes the sprite based off a random sprite in there.
     * 
     * **/

    
    //The path where all the puyo sprites are
    private string path = "Sprites/BetterPuyos";

    //Access the sprite renderer in the unity object
    private SpriteRenderer spriteRenderer;
    //An array of all potential sprites (colors)
    private Sprite[] sprites;

	void Start () {
        //Loads all the sprites in the specified path and puts them in the array
        sprites = Resources.LoadAll<Sprite>(path);
        
        //Grabs the sprite renderer and randomizes a sprite
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[(int)Mathf.Floor(Random.value * sprites.Length)];
        
	}
	
	// Update is called once per frame
	void Update () {

        //Uncomment the following lines to see the sprite change in realtime

        //Debug.Log((int)Mathf.Round(Random.value * sprites.Length));
        //spriteRenderer.sprite = sprites[(int)Mathf.Floor(Random.value * sprites.Length)];
    }
}
