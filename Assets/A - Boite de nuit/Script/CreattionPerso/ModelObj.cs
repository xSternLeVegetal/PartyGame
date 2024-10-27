using System.Collections.Generic;
using UnityEngine;

public class ModelObj
{
    public ModelObj()
    {
        AllObj = new List<GameObject>();
        currentIndexObj = 0;
        currentMaterialIndex = 0;
    }

    public List<GameObject> AllObj;
    public GameObject currentObj;
    public int currentIndexObj;
    public Material currentMaterial;
    public int currentMaterialIndex;
}