using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Island : MonoBehaviour
{
    [SerializeField] private string islandName;
    [SerializeField] private Sprite mapSprite;

    public void Initialize(string islandName, Sprite mapSprite, Vector3 islandPosition)
    {
        this.islandName = islandName;
        this.mapSprite = mapSprite;
        transform.position = islandPosition;
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
