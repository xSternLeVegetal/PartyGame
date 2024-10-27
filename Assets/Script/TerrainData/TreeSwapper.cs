using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TreeSwapper : MonoBehaviour
{
    public GameObject[] TerrainToSwitchTree;

    //Fill this in the inspector with the prefabs to use in place of the tree prototypes defined in the Terrain object.
    public GameObject[] TreePrototypes;

    public Dictionary<Terrain, TerrainData> SaveAllTerrainData = new();

    void Awake()
    {
        if (TreePrototypes == null || TreePrototypes.Any(x => x == null))
        {
            Debug.LogError("missing trees prefab dans le tree swapper con");
            return;
        }
        if (TerrainToSwitchTree == null || TerrainToSwitchTree.Any(x => x == null))
        {
            Debug.LogError("missing terrain dans la liste tree swapper con");
            return;
        }
        foreach (var item in TerrainToSwitchTree)
        {
            var terrain = item.GetComponent<Terrain>();
            var data = terrain.terrainData;
            SaveAllTerrainData.Add(terrain,data);
            TerrainData dataToUse = TerrainDataCloner.Clone(data);
            //dataToUse = data;
            terrain.terrainData = dataToUse;
            var allPrototypes = dataToUse.treePrototypes;
            foreach (var instance in dataToUse.treeInstances)
            {
                var treeToInstanciate =
                    TreePrototypes.FirstOrDefault(x => x.gameObject.name == allPrototypes[instance.prototypeIndex].prefab.name);
                if (treeToInstanciate != null)
                {
                    float width = dataToUse.size.x;
                    float height = dataToUse.size.z;
                    float y = dataToUse.size.y;
                    Vector3 position = new Vector3(instance.position.x * width + item.transform.position.x, instance.position.y * y + item.transform.position.y,
                        instance.position.z * height + item.transform.position.z);
                    var tree = Instantiate(treeToInstanciate, position,
                        /*Quaternion.Euler(0f, Mathf.Rad2Deg * instance.rotation, 0f)*/ Quaternion.identity, item.transform);
                    tree.transform.localScale = new Vector3(instance.widthScale, instance.heightScale, instance.widthScale);
                    
                }
            }
            dataToUse.treeInstances = Array.Empty<TreeInstance>();
        }
    }

    public void OnApplicationQuit()
    {
        Debug.Log("On Application Quit Called");
        foreach (var item in TerrainToSwitchTree)
        {
            var terrain = item.GetComponent<Terrain>();
            terrain.terrainData = SaveAllTerrainData[terrain];
        }
    }
}