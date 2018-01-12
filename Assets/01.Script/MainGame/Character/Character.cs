﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MapObject
{
    GameObject _characterView;

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    public void Init(string viewName)
    {
        // View를 붙인다
        //GameObject characterViewPrefabs = Resources.Load<GameObject>("Prefabs/CharacterView/character01");
        string filePath = "Prefabs/CharacterView/" + viewName;

        GameObject characterViewPrefabs = Resources.Load<GameObject>(filePath);
        _characterView = GameObject.Instantiate(characterViewPrefabs);

        _characterView.transform.SetParent(transform);
        _characterView.transform.localPosition = Vector3.zero;
        _characterView.transform.localScale = Vector3.one;

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
