using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Island : MonoBehaviour
{
    [SerializeField] private string islandName;
    [SerializeField] private Sprite islandMapSprite;
    [SerializeField] private SpriteRenderer islandRenderer;
    [SerializeField] private LineRenderer conectionRenderer;
    
    public List<Island> conections = new List<Island>();
    
    public void Initialize(string islandName, Sprite islandMapSprite, Vector3 islandPosition)
    {
        islandRenderer = gameObject.AddComponent<SpriteRenderer>();
        
        this.islandName = islandName;
        this.islandMapSprite = islandMapSprite;
        transform.position = islandPosition;
        islandRenderer.sprite = islandMapSprite;
        
        DontDestroyOnLoad(gameObject);
    }

    public static Island CreateIsland(string objectName, string islandName, Sprite islandMapSprite, Vector3 islandPosition)
    {
        GameObject islandObject = new GameObject(objectName);
        Island island = islandObject.AddComponent<Island>();
        
        island.Initialize(islandName, islandMapSprite, islandPosition);
        return island;
    }

    public void DrawConections()
    {
        conectionRenderer.positionCount = conections.Count;
    }
    
    public void LoadScene()
    {
        SceneManager.LoadScene(islandName);
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
