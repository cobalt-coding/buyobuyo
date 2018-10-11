using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuyoGrid : MonoBehaviour {

    /**
     * 
     * Virtual grid that handles most game logic
     * 
     * It needs access to all puyos and puyo pairs, and the virtual
     * grid will update accordingly to the positions of the puyos.
     * 
     * Whenever input is made that moves a puyopair, the virtual grid
     * will update.
     * 
     * Whenever a puyopair is dropped, the virtual grid is what is
     * responsible for checking if 4 same colored puyos match
     * 
     * **/

    //0 is empty, R is red, g is grey, G is green, rest is self-explanatory
    
    //The puyo puyo grid is 12 by 6
    private string[] virtualGrid = new string[12] {
           "000000",
           "000000",
           "000000",
           "000000",
           "000000",
           "000000",
           "000000",
           "000000",
           "000000",
           "000000",
           "000000",
           "000000",
    };

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
