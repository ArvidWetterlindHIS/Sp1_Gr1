using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Serialization;

public class InstantiateOnEvent : MonoBehaviour
{
    public GameObject ObjectToInstantiate;

    public Transform instantiationTransform;

    [Tooltip("If we set it to 0 it will 'live' indefinitely until another script destroys it")] [SerializeField] public float instanceLifeTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        // if we havent filled in a specific position, set instantiationTransform to this GameObjects transform
        if (instantiationTransform == null)
        {
            instantiationTransform = transform;
        }
    }

    
    public void InstantiatePrefab()
    {
        GameObject instance = Instantiate(ObjectToInstantiate, instantiationTransform.position, instantiationTransform.rotation);
        if (instanceLifeTime > 0) //destroy object after set time
        {
            Destroy(instance, instanceLifeTime);
        }
    }
}
