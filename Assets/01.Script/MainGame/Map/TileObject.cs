using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileObject : MapObject
{

	// Unity functions

	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    // Init
    public void Init(Sprite sprite)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
