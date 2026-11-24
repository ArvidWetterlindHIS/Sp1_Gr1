using System.Collections.Generic;
using System.IO;
using UnityEditor;

/// <summary>
/// 
/// </summary>
public static class AssetGetter
{
    /// <summary>
    /// Gets a list of assets with the given filters.
    /// </summary>
    /// <typeparam name="T">The type of assets to return.</typeparam>
    /// <param name="filters">
    ///Filters for getting assets.
    ///Information about filters are explained <see href="https://docs.unity.com/en-us/engine/6000.3/script-reference/unityeditor/assetdatabase/findassets">HERE</see>.
    /// </param>
    /// <returns>A list of the found assets.</returns>
    public static List<T> GetAssets<T>(string filters) where T : UnityEngine.Object
    {
        List<T> objects = new List<T>();
        
        string[] guids = AssetDatabase.FindAssets(filters);

        foreach (string guid in guids)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);
            var asset = AssetDatabase.LoadAssetAtPath<T>(assetPath);
            
            if (asset != null)  
                objects.Add(asset);
        }
        
        return objects;
    }

    /// <summary>
    /// Gets a list of assets names with the given filters.
    /// </summary>
    /// <param name="filters">
    ///Filters for getting assets.
    ///Information about filters are explained <see href="https://docs.unity.com/en-us/engine/6000.3/script-reference/unityeditor/assetdatabase/findassets">HERE</see>.
    /// </param>
    /// <returns>A list of the found assets names.</returns>
    public static List<string> GetAssetsNames(string filters)
    {
        List<string> objects = new List<string>();
        
        string[] guids = AssetDatabase.FindAssets(filters);

        foreach (string guid in guids)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);
            var asset = Path.GetFileNameWithoutExtension(assetPath);
            
            if (asset != null)  
                objects.Add(asset);
        }
        
        return objects;
    }
}
