using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IslandHandler : MonoBehaviour
{
    List<List<Island>> islands = new List<List<Island>>();
    List<string> islandNames;
    List<Sprite> islandSprites;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        islandNames = AssetGetter.GetAssetsNames("TestIsland");
        islandSprites = AssetGetter.GetAssets<Sprite>("TestIsland");
        
        LoadIsland();
        CreateIslands(5, 4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Loads a random island.
    /// </summary>
    public void LoadIsland()
    {
        int randomIslandIndex = Random.Range(0, islands.Count - 1);
        SceneManager.LoadScene(islands[randomIslandIndex].ToString());
    }

    
    // Creates Islands HAS NOT TESTED NIEED TEST!!!!!!!!!!!11!!!!!!1!11!!1!!1!1!!!!!11111!!!!1!!!1!!
    public void CreateIslands(int height, int width)
    {
        GameObject startIslandObject = new GameObject("Island00");
        Island startIsland = startIslandObject.AddComponent<Island>();
        
        int startIndex = Random.Range(0, islandNames.Count);
        startIsland.Initialize(islandNames[startIndex], islandSprites[startIndex], Vector3.zero);
        
        islands[0].Add(startIsland);
        
        for (int y = 1; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                GameObject islandObject = new GameObject("Island" + y + x);
                Island island = islandObject.AddComponent<Island>();
                
                int ilandIndex = Random.Range(0, islandNames.Count);
                island.Initialize(islandNames[ilandIndex], islandSprites[ilandIndex], new  Vector3(x * 10, y * 10, 1));
                
                islands[y].Add(island);
            }
        }
    }
}
