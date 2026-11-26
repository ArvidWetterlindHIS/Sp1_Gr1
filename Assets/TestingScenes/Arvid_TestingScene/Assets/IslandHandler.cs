using System;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class IslandHandler : MonoBehaviour
{
    private const int height = 10, width = 3, minPosX = -11, maxPosX = 11, posY = 1;
    
    List<List<Island>> islands = new List<List<Island>>();
    List<string> islandNames;
    List<Sprite> islandSprites;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        
        islandNames = AssetGetter.GetAssetsNames("Island t:Sprite");
        islandSprites = AssetGetter.GetAssets<Sprite>("Island t:Sprite");
        
        CreateIslands(height, width, minPosX, maxPosX, posY);
        SetConections(height);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
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
    
    public void SetConections(int height)
    {
        int startCount = islands[1].Count;
        
        switch (startCount)
        {
            case 2:
                AddConnection(islands[0][0], 0, "1 0");
                AddConnection(islands[0][0], 0, "1 1");
                break;
            case 3:
                AddConnection(islands[0][0], 0, "1 0");
                AddConnection(islands[0][0], 0, "1 1");
                AddConnection(islands[0][0], 0, "1 2");
                break;
        }
        
        for (int y = 1; y < islands.Count - 1; y++)
        {
            int bottomCount = islands[y].Count;
            int topCount = islands[y + 1].Count;
            switch (bottomCount)
            {
                case 2:
                    switch (topCount)
                    {
                        case 2:
                            AddConnection(islands[y][0], y, "2 0");
                            AddConnection(islands[y][1], y, "2 1");
                            continue;
                        case 3:
                            AddConnection(islands[y][0], y, "3 01");
                            AddConnection(islands[y][1], y, "3 12");
                            continue;
                    }
                continue;
                case 3:
                    switch (topCount)
                    {
                        case 2:
                            AddConnection(islands[y][0], y, "2 0");
                            AddConnection(islands[y][1], y, "2 01");
                            AddConnection(islands[y][2], y, "2 1");
                            continue;
                        case 3:
                            AddConnection(islands[y][0], y, "3 01");
                            AddConnection(islands[y][1], y, "3 1");
                            AddConnection(islands[y][2], y, "3 12");
                            continue;
                    }
                continue;
            }
        }
    
        int count = islands[height - 1].Count;
        int index = height - 1;
        
        switch (count)
        {
            case 2:
                AddConnection(islands[index][0], index, "1 0");
                AddConnection(islands[index][1], index, "1 0");
                break;
            case 3:
                AddConnection(islands[index][0], index, "1 0");
                AddConnection(islands[index][1], index, "1 0");
                AddConnection(islands[index][2], index, "1 0");
                break;
        }
        
    }

    public Dictionary<string, List<int>> connetionTypes => CreateConectionTypes();
    
    private void AddConnection(Island island, int index, string key)
    {
        foreach (int connectionTypeIndex in connetionTypes[key])
        {
            island.conections.Add(islands[index + 1][connectionTypeIndex]);
        }
    }
    
    private Dictionary<string, List<int>> CreateConectionTypes()
    {
        Dictionary<string, List<int>> connetionTypes = new Dictionary<string, List<int>>();
        
        //1
        connetionTypes.Add("1 0", new List<int> {0});
        connetionTypes.Add("1 1", new List<int> {1});
        connetionTypes.Add("1 2", new List<int> {2});
        
        //2
        connetionTypes.Add("2 0", new List<int> {0});
        connetionTypes.Add("2 1", new List<int> {1});
        connetionTypes.Add("2 01", new List<int> {0, 1});

        //3
        connetionTypes.Add("3 0", new List<int> {0});
        connetionTypes.Add("3 1", new List<int> {1});
        connetionTypes.Add("3 2", new List<int> {2});
        connetionTypes.Add("3 01", new List<int> {0, 1});
        connetionTypes.Add("3 12", new List<int> {1, 2});

        return connetionTypes;
    }

    /* Leave alone get a basik working thing first.
    private bool IsLeagalConection(Island island1, Island island2)
    {
        for (int i = 0; i < island1.conections.Count; i++)
        {
            for (int j = i + 1; j < island2.conections.Count; j++)
            {
                //
            }
        }
    }

    public static bool CheckLineIntersection(Vector3 point1, Vector3 point2, Vector3 point3, Vector3 point4)
    {
        if (Mathf.Max(point1.x, point2.x) < Mathf.Min(point3.x, point4.x) ||
            Mathf.Min(point1.x, point2.x) > Mathf.Max(point3.x, point4.x) ||
            Mathf.Max(point1.y, point2.y) < Mathf.Min(point3.y, point4.y) ||
            Mathf.Min(point1.y, point2.y) > Mathf.Max(point3.y, point4.y))
        {
            return false;
        }

        float d1 = Cross(point1, point2, point3);
        float d2 = Cross(point1, point2, point4);
        float d3 = Cross(point3, point4, point1);
        float d4 = Cross(point3, point4, point2);

        if (((d1 > 0f && d2 < 0f) || (d1 < 0f && d2 > 0f)) && ((d3 > 0f && d4 < 0f) || (d3 < 0f && d4 > 0f)))
        {
            return true;
        }

        if (d1 == 0f && OnSegment(point1, point2, point3)) return true;
        if (d2 == 0f && OnSegment(point1, point2, point4)) return true;
        if (d3 == 0f && OnSegment(point3, point4, point1)) return true;
        if (d4 == 0f && OnSegment(point3, point4, point2)) return true;

        return false;
    }

    private static float Cross(Vector3 point1, Vector3 point2, Vector3 point3)
    {
        return (point2.x - point1.x) * (point3.y - point1.y) - (point2.y - point1.y) * (point3.x - point1.x);
    }

    private static bool OnSegment(Vector3 point1, Vector3 point2, Vector3 point3)
    {
        return point3.x <= Mathf.Max(point1.x, point2.x) && point3.x >= Mathf.Min(point1.x, point2.x) &&
               point3.y <= Mathf.Max(point1.y, point2.y) && point3.y >= Mathf.Min(point1.y, point2.x);
    }
    */
}
