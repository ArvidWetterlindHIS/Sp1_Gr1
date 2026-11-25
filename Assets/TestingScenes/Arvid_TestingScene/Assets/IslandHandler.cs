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
        islandNames = AssetGetter.GetAssetsNames("Island t:Sprite");
        islandSprites = AssetGetter.GetAssets<Sprite>("Island t:Sprite");
        
        CreateIslands(10, 3, -11, 11, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // Creates Islands HAS NOT TESTED NIEED TEST!!!!!!!!!!!11!!!!!!1!11!!1!!1!1!!!!!11111!!!!1!!!1!!
    public void CreateIslands(int height, int width, float minPosX, float maxPosX, float posY)
    {
        int startIndex = Random.Range(0, islandNames.Count);
        Island startIsland = Island.CreateIsland("Island00", islandNames[startIndex], islandSprites[startIndex], 
            new Vector3(0, 0, posY));
        
        islands.Add(new List<Island>());
        islands[0].Add(startIsland);
        
        for (int y = 1; y < height; y++)
        {
            islands.Add(new List<Island>());
            int islandCount = Random.Range(2, width + 1);
            for (int x = 0; x < islandCount; x++)
            {
                int islandIndex = Random.Range(0, islandNames.Count);
                Island island = Island.CreateIsland("Island" + y + x,  islandNames[islandIndex], islandSprites[islandIndex], 
                    new Vector3(CreateIslandXPos(x, islandCount, minPosX, maxPosX), y * 5f, posY));
                
                islands[y].Add(island);
            }
        }
        
        int endIndex = Random.Range(0, islandNames.Count);
        Island endIsland = Island.CreateIsland("Island" + height + "0", islandNames[endIndex], islandSprites[endIndex], 
            new Vector3(0, height * 5f, posY));
        
        islands.Add(new List<Island>());
        islands[height].Add(endIsland);
    }

    private float CreateIslandXPos(int islandIndex, int islandCount, float minPos, float maxPos)
    {
        float posDiff = maxPos - minPos;
        float absulutXpos = ((islandIndex + 1) * posDiff) / (islandCount + 1);
        
        float truePosX = absulutXpos + minPos;
        return truePosX;
    }
    
    public void SetConections(List<List<Island>> islands, int islandIndex)
    {
        List<Island> currentIslandSet = islands[islandIndex];
        List<Island> nextIslandSet = islands[islandIndex + 1];

        foreach (Island island in currentIslandSet)
        {
            foreach (Island nextIsland in nextIslandSet)
            {
                island.conections.Add(nextIsland);
            }
        }
        
        
    }
}
