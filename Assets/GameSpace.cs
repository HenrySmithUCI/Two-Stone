using System;
using System.Collections.Generic;
using UnityEngine;

public class GameSpace : MonoBehaviour {
    public static GameSpace instance { get; private set; }

    private List<Stone> stones;

    public int stoneCount = 0;

    public Stone stonePrefab;
    public GameObject toClearPrefab;
    public float TopMost { get; private set; }
    public float RightMost { get; private set; }
    public intTuple[] startingStones;
    public intTuple[] toClear;
    public Vector3 cameraPos;
    public int currentLevel;
    
    void Start()
    {
        cameraPos = Camera.main.transform.position;
        instance = this;
        stones = new List<Stone>();
        
        restart();
    }

    public void checkIfWonIncludingStoneJustRemoved(int x, int y)
    {
        foreach(intTuple pos in toClear)
        {
            if(!(pos.x == x && pos.y == y) && getStone(pos.x, pos.y) != null)
            {
                return;
            }
        }
        win();
    }

    public void win()
    {
        int maxLevel = PlayerPrefs.GetInt("MaxLevel");
        if(maxLevel < currentLevel)
        {
            PlayerPrefs.SetInt("MaxLevel", currentLevel);
        }
        GameObject.Find("Coverup Physics").GetComponent<BoxCollider2D>().enabled = true;
        FindObjectOfType<Animator>().SetTrigger("End Game");
    }

    public Stone getStone(int x, int y)
    {
        GameObject st = GameObject.Find("Stone (" + x + "," + y + ")");
        if(st != null)
            return st.GetComponent<Stone>();
        return null;
        
    }

    public void makeStone(int x, int y)
    {
        Stone s = Instantiate(stonePrefab, this.transform);
        s.init(x, y);
        stoneCount += 1;
        s.name = "Stone (" + x + "," + y + ")";
        stones.Add(s);
        if(y > TopMost)
            TopMost = y;
        if(x > RightMost)
            RightMost = x;
    }

    public void restart()
    {
        TopMost = 0;
        RightMost = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        foreach (intTuple pos in startingStones)
        {
            makeStone(pos.x, pos.y);
        }
        foreach (intTuple pos in toClear)
        {
            GameObject go = Instantiate(toClearPrefab, this.transform);
            go.transform.localPosition = new Vector2(pos.x, pos.y);
            go.name = "ToClear (" + pos.x + "," + pos.y + ")";
        }
        Camera.main.transform.position = cameraPos;
    }
}

[Serializable]
public struct intTuple
{
    public int x;
    public int y;
}
