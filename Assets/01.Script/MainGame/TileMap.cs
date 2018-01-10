using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour
{
    // Unity Functions
	
	void Start ()
    {
        InitSpriteList();
	}
	
	
	void Update ()
    {
		
	}

    // Sprite List
    Sprite[] _spriteArray;

    void InitSpriteList()
    {
        _spriteArray = Resources.LoadAll<Sprite>("Sprites/MapSprite");
        CreateTiles();
    }

    // Tile
    public GameObject TileObjectPrefabs;

    int _width;
    int _height;

    List<TileCell> _tileCellList = new List<TileCell>();

    void CreateTiles()
    {
        float tileSize = 32.0f;

        TextAsset scriptAsset = Resources.Load<TextAsset>("Data/Map1Data_layer01");
        string[] records = scriptAsset.text.Split('\n');

        {
            string[] token = records[0].Split(',');
            _width = int.Parse(token[1]);
            _height = int.Parse(token[2]);
        }

        // 1st floor
        for(int y=0; y<_height; y++)
        {
            int line = y + 2;
            string[] token = records[line].Split(',');
            Debug.Log(token);
            for(int x = 0; x < _width; x++)
            {
                int spriteIndex = int.Parse(token[x]);
                
                GameObject tileGameObject = GameObject.Instantiate(TileObjectPrefabs);
                tileGameObject.transform.SetParent(transform);
                tileGameObject.transform.localScale = Vector3.one;
                tileGameObject.transform.localPosition = Vector3.zero;

                TileObject tileObject = tileGameObject.GetComponent<TileObject>();
                tileObject.Init(_spriteArray[spriteIndex]);
                
                TileCell tileCell = new TileCell();
                tileCell.Init();
                tileCell.SetPosition(x * tileSize / 100.0f, y * tileSize / 100.0f);
                tileCell.AddObject(eTileLayer.GROUND, tileObject);
                _tileCellList.Add(tileCell);
            }
        }

        // 2nd floor
        scriptAsset = Resources.Load<TextAsset>("Data/Map1Data_layer02");
        records = scriptAsset.text.Split('\n');

        for (int y = 0; y < _height; y++)
        {
            int line = y + 2;
            string[] token = records[line].Split(',');
            Debug.Log(token);
            for (int x = 0; x < _width; x++)
            {
                int spriteIndex = int.Parse(token[x]);

                if (0 <= spriteIndex)
                {
                    GameObject tileGameObject = GameObject.Instantiate(TileObjectPrefabs);
                    tileGameObject.transform.SetParent(transform);
                    tileGameObject.transform.localScale = Vector3.one;
                    tileGameObject.transform.localPosition = Vector3.zero;

                    TileObject tileObject = tileGameObject.GetComponent<TileObject>();
                    tileObject.Init(_spriteArray[spriteIndex]);
                    
                    int cellIndex = (y * _width) + x;
                    _tileCellList[cellIndex].AddObject(eTileLayer.GROUND, tileObject);
                }
            }
        }
        /*
        for (int i = 0; i < _spriteArray.Length; i++)
        {
            float x = (i % 16) * tileSize / 100.0f;
            float y = -(i / 16) * tileSize / 100.0f;

            GameObject tileGameObject = GameObject.Instantiate(TileObjectPrefabs);
            tileGameObject.transform.SetParent(transform);
            tileGameObject.transform.localScale = Vector3.one;
            tileGameObject.transform.localPosition = Vector3.zero;

            TileObject tileObject = tileGameObject.GetComponent<TileObject>();
            tileObject.Init(_spriteArray[i]);
            tileObject.SetPosition(x, y);
        }
        */
    }
}
