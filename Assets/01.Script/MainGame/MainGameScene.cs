using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameScene : MonoBehaviour
{
    public TileMap _tileMap;

    void Start ()
    {
        Init();
	}
	
	void Update ()
    {
		
	}

    void Init()
    {
        _tileMap.Init();
        GameManager.Instance.SetMap(_tileMap);

        Character player = CreateCharacter("Player", "character01");
        Character monster = CreateCharacter("Monster", "character02");
        player.BecomeViewer();
    }
    
    Character CreateCharacter(string fileName, string resourceName)
    {
        string filePath = "Prefabs/CharacterFrame/Character";

        GameObject characterPrefabs = Resources.Load<GameObject>(filePath);
        GameObject characterGameObject = GameObject.Instantiate(characterPrefabs);
        characterGameObject.transform.SetParent(_tileMap.transform);
        characterGameObject.transform.localPosition = Vector3.zero;

        Character character = characterGameObject.GetComponent<Player>();
        switch(fileName)
        {
            case "Player":
                //character = characterGameObject.GetComponent<Player>();
                character = characterGameObject.AddComponent<Player>();
                break;

            case "Monster":
                //character = characterGameObject.GetComponent<Monster>();
                character = characterGameObject.AddComponent<Monster>();
                break;
        }
        character.Init(resourceName);
     
        return character;
    }
}
