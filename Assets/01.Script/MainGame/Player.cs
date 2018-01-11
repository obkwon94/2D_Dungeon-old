using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MapObject
{
    public GameObject _characterView;

	void Start ()
    {
        
	}
	
	void Update ()
    {
		
	}

    public void Init()
    {
        TileMap map = GameManager.Instance.GetMap();

        int x = Random.Range(1, map.GetWidth() - 2);
        int y = Random.Range(1, map.GetHeight() - 2);

        TileCell tileCell = map.GetTileCell(x, y);
        tileCell.AddObject(eTileLayer.MIDDLE, this);
    }

    override public void SetSortingOrder(int sortingID, int sortingOrder)
    {
        _characterView.GetComponent<SpriteRenderer>().sortingLayerID = sortingID;
        _characterView.GetComponent<SpriteRenderer>().sortingOrder = sortingOrder;
    }
}
