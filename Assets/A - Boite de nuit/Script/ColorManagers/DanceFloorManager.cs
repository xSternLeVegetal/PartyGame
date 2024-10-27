using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceFloorManager : MonoBehaviour
{
    public List<Material> materials;
    public List<GameObject> AllTiles;
    public List<Material> AllTilesMaterials;

    public bool ChangeColor;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var tile in AllTiles)
        {
            AllTilesMaterials.Add(tile.GetComponent<MeshRenderer>().material);
        }

        ChangeColor = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (ChangeColor)
        {
            ChangeColor = false;
            StartCoroutine(ChangeTileColorRandomly());
        }
    }

    IEnumerator ChangeTileColorRandomly()
    {
        foreach (var tilesMaterial in AllTilesMaterials)
        {
            var rand = Random.Range(0, materials.Count);
            tilesMaterial.color = materials[rand].color;
        }
        yield return new WaitForSeconds(2);
        ChangeColor = true;
    }
}
