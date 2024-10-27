using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampManager : MonoBehaviour
{
    public List<Material> materials;
    public List<GameObject> AllLamps;
    public List<Light> AllLampsLigth;

    public bool ChangeColor;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var tile in AllLamps)
        {
            AllLampsLigth.Add(tile.GetComponent<Light>());
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
        foreach (var lampLigth in AllLampsLigth)
        {
            var rand = Random.Range(0, materials.Count);
            lampLigth.color = materials[rand].color;
        }
        yield return new WaitForSeconds(2);
        ChangeColor = true;
    }
}
