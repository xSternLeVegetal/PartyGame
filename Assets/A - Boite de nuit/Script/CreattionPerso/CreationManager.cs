using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreationManager : MonoBehaviour
{
    //faire que les couleurs soit interchangeacle en fct d unombre de materiaux que posséde les obj
    //(en mode si un seul on peux shoisir qu'une couleur, sinon deux etc etc)
    public GameObject Presentoir;
    public List<Material> MaterialsList;
    public List<GameObject> AllElementModels;

    private ModelObj AllBody = new ModelObj();
    private ModelObj AllEyes = new ModelObj();
    private ModelObj AllGlasses = new ModelObj();
    private ModelObj AllHat = new ModelObj();
    private ModelObj AllFacialHair = new ModelObj();
    private ModelObj AllHair = new ModelObj();
    private ModelObj AllCoat = new ModelObj();
    private ModelObj AllBodyShirt = new ModelObj();
    private ModelObj AllPants = new ModelObj();
    private ModelObj AllGloves = new ModelObj();
    private ModelObj AllAccesories = new ModelObj();
    private ModelObj AllShoes = new ModelObj();
    private ModelObj AllSocks = new ModelObj();

    private bool changedHappened;

    // Start is called before the first frame update
    void Start()
    {
        //SetAllList();
        GetAllElementModels();
        PopulateLists();
        changedHappened = true;
    }

    private void GetAllElementModels()
    {
        int childCount = Presentoir.transform.childCount;
        int i = 0;
        while (i < childCount)
        {
            var child = Presentoir.transform.GetChild(i).gameObject;
            if (child.GetComponent<ModelInfo>())
            {
                AllElementModels.Add(child);
                child.SetActive(false);
            }

            if (child.name.Contains("body"))
            {
                AllBody.currentObj = child;
                child.SetActive(true);
            }
            else if (child.name.Contains("EmptyEyes"))
            {
                AllEyes.currentObj = child;
            }
            else if (child.name.Contains("EmptyGlasses"))
            {
                AllGlasses.currentObj = child;
            }
            else if (child.name.Contains("EmptyHat"))
            {
                AllHat.currentObj = child;
            }
            else if (child.name.Contains("EmptyFacialHair"))
            {
                AllFacialHair.currentObj = child;
            }
            else if (child.name.Contains("EmptyHair"))
            {
                AllHair.currentObj = child;
            }
            else if (child.name.Contains("EmptyCoat"))
            {
                AllCoat.currentObj = child;
            }
            else if (child.name.Contains("EmptyBodyShirt"))
            {
                AllBodyShirt.currentObj = child;
            }
            else if (child.name.Contains("EmptyPants"))
            {
                AllPants.currentObj = child;
            }
            else if (child.name.Contains("EmptyGloves"))
            {
                AllGloves.currentObj = child;
            }
            else if (child.name.Contains("EmptyAccesories"))
            {
                AllAccesories.currentObj = child;
            }
            else if (child.name.Contains("EmptyShoes"))
            {
                AllShoes.currentObj = child;
            }
            else if (child.name.Contains("EmptySocks"))
            {
                AllSocks.currentObj = child;
            }

            i++;
        }
    }

    public void SetAllList()
    {
        AllBody.AllObj.Add(null);
        AllBody.currentObj = AllBody.AllObj[0];
        AllEyes.AllObj.Add(null);
        AllEyes.currentObj = AllEyes.AllObj[0];
        AllGlasses.AllObj.Add(null);
        AllGlasses.currentObj = AllGlasses.AllObj[0];
        AllHat.AllObj.Add(null);
        AllHat.currentObj = AllHat.AllObj[0];
        AllFacialHair.AllObj.Add(null);
        AllFacialHair.currentObj = AllFacialHair.AllObj[0];
        AllHair.AllObj.Add(null);
        AllHair.currentObj = AllHair.AllObj[0];
        AllCoat.AllObj.Add(null);
        AllCoat.currentObj = AllCoat.AllObj[0];
        AllBodyShirt.AllObj.Add(null);
        AllBodyShirt.currentObj = AllBodyShirt.AllObj[0];
        AllPants.AllObj.Add(null);
        AllPants.currentObj = AllPants.AllObj[0];
        AllGloves.AllObj.Add(null);
        AllGloves.currentObj = AllGloves.AllObj[0];
        AllAccesories.AllObj.Add(null);
        AllAccesories.currentObj = AllAccesories.AllObj[0];
        AllShoes.AllObj.Add(null);
        AllShoes.currentObj = AllShoes.AllObj[0];
        AllSocks.AllObj.Add(null);
        AllSocks.currentObj = AllSocks.AllObj[0];
    }

    private void PopulateLists()
    {
        foreach (var elementModel in AllElementModels)
        {
            var ModelInfo = elementModel.GetComponent<ModelInfo>();
            switch (ModelInfo.ElementType)
            {
                case ElementTypeEnum.Body:
                    if (elementModel.name.Contains("Empty"))
                        AllBody.AllObj.Insert(0, elementModel);
                    else
                        AllBody.AllObj.Add(elementModel);
                    break;
                case ElementTypeEnum.Eyes:
                    if (elementModel.name.Contains("Empty"))
                        AllEyes.AllObj.Insert(0, elementModel);
                    else
                        AllEyes.AllObj.Add(elementModel);
                    break;
                case ElementTypeEnum.Glasses:
                    if (elementModel.name.Contains("Empty"))
                        AllGlasses.AllObj.Insert(0, elementModel);
                    else
                        AllGlasses.AllObj.Add(elementModel);
                    break;
                case ElementTypeEnum.Hat:
                    if (elementModel.name.Contains("Empty"))
                        AllHat.AllObj.Insert(0, elementModel);
                    else
                        AllHat.AllObj.Add(elementModel);
                    break;
                case ElementTypeEnum.FacialHair:
                    if (elementModel.name.Contains("Empty"))
                        AllFacialHair.AllObj.Insert(0, elementModel);
                    else
                        AllFacialHair.AllObj.Add(elementModel);
                    break;
                case ElementTypeEnum.Hair:
                    if (elementModel.name.Contains("Empty"))
                        AllHair.AllObj.Insert(0, elementModel);
                    else
                        AllHair.AllObj.Add(elementModel);
                    break;
                case ElementTypeEnum.Coat:
                    if (elementModel.name.Contains("Empty"))
                        AllCoat.AllObj.Insert(0, elementModel);
                    else
                        AllCoat.AllObj.Add(elementModel);
                    break;
                case ElementTypeEnum.BodyShirt:
                    if (elementModel.name.Contains("Empty"))
                        AllBodyShirt.AllObj.Insert(0, elementModel);
                    else
                        AllBodyShirt.AllObj.Add(elementModel);
                    break;
                case ElementTypeEnum.Pants:
                    if (elementModel.name.Contains("Empty"))
                        AllPants.AllObj.Insert(0, elementModel);
                    else
                        AllPants.AllObj.Add(elementModel);
                    break;
                case ElementTypeEnum.Gloves:
                    if (elementModel.name.Contains("Empty"))
                        AllGloves.AllObj.Insert(0, elementModel);
                    else
                        AllGloves.AllObj.Add(elementModel);
                    break;
                case ElementTypeEnum.Accesories:
                    if (elementModel.name.Contains("Empty"))
                        AllAccesories.AllObj.Insert(0, elementModel);
                    else
                        AllAccesories.AllObj.Add(elementModel);
                    break;
                case ElementTypeEnum.Shoes:
                    if (elementModel.name.Contains("Empty"))
                        AllShoes.AllObj.Insert(0, elementModel);
                    else
                        AllShoes.AllObj.Add(elementModel);
                    break;
                case ElementTypeEnum.Socks:
                    if (elementModel.name.Contains("Empty"))
                        AllSocks.AllObj.Insert(0, elementModel);
                    else
                        AllSocks.AllObj.Add(elementModel);
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (changedHappened)
        {
            DrawModels();
            changedHappened = false;
        }
    }

    private void DrawModels()
    {
        if (AllBody.currentObj != AllBody.AllObj[AllBody.currentIndexObj])
        {
            AllBody.currentObj.SetActive(false);
            if (AllBody.AllObj[AllBody.currentIndexObj])
            {
                AllBody.currentObj = AllBody.AllObj[AllBody.currentIndexObj];
                AllBody.currentObj.SetActive(true);
            }
        }

        if (AllEyes.currentObj != AllEyes.AllObj[AllEyes.currentIndexObj])
        {
            AllEyes.currentObj.SetActive(false);
            if (AllEyes.AllObj[AllEyes.currentIndexObj])
            {
                AllEyes.currentObj = AllEyes.AllObj[AllEyes.currentIndexObj];
                AllEyes.currentObj.SetActive(true);
            }
        }

        if (AllGlasses.currentObj != AllGlasses.AllObj[AllGlasses.currentIndexObj])
        {
            AllGlasses.currentObj.SetActive(false);
            if (AllGlasses.AllObj[AllGlasses.currentIndexObj])
            {
                AllGlasses.currentObj = AllGlasses.AllObj[AllGlasses.currentIndexObj];
                AllGlasses.currentObj.SetActive(true);
            }
        }

        if (AllHat.currentObj != AllHat.AllObj[AllHat.currentIndexObj])
        {
            AllHat.currentObj.SetActive(false);
            if (AllHat.AllObj[AllHat.currentIndexObj])
            {
                AllHat.currentObj = AllHat.AllObj[AllHat.currentIndexObj];
                AllHat.currentObj.SetActive(true);
            }
        }

        if (AllFacialHair.currentObj != AllFacialHair.AllObj[AllFacialHair.currentIndexObj])
        {
            AllFacialHair.currentObj.SetActive(false);
            if (AllFacialHair.AllObj[AllFacialHair.currentIndexObj])
            {
                AllFacialHair.currentObj = AllFacialHair.AllObj[AllFacialHair.currentIndexObj];
                AllFacialHair.currentObj.SetActive(true);
            }
        }

        if (AllHair.currentObj != AllHair.AllObj[AllHair.currentIndexObj])
        {
            AllHair.currentObj.SetActive(false);
            if (AllHair.AllObj[AllHair.currentIndexObj])
            {
                AllHair.currentObj = AllHair.AllObj[AllHair.currentIndexObj];
                AllHair.currentObj.SetActive(true);
            }
        }

        if (AllCoat.currentObj != AllCoat.AllObj[AllCoat.currentIndexObj])
        {
            AllCoat.currentObj.SetActive(false);
            if (AllCoat.AllObj[AllCoat.currentIndexObj])
            {
                AllCoat.currentObj = AllCoat.AllObj[AllCoat.currentIndexObj];
                AllCoat.currentObj.SetActive(true);
            }
        }

        if (AllBodyShirt.currentObj != AllBodyShirt.AllObj[AllBodyShirt.currentIndexObj])
        {
            AllBodyShirt.currentObj.SetActive(false);
            if (AllBodyShirt.AllObj[AllBodyShirt.currentIndexObj])
            {
                AllBodyShirt.currentObj = AllBodyShirt.AllObj[AllBodyShirt.currentIndexObj];
                AllBodyShirt.currentObj.SetActive(true);
            }
        }

        if (AllPants.currentObj != AllPants.AllObj[AllPants.currentIndexObj])
        {
            AllPants.currentObj.SetActive(false);
            if (AllPants.AllObj[AllPants.currentIndexObj])
            {
                AllPants.currentObj = AllPants.AllObj[AllPants.currentIndexObj];
                AllPants.currentObj.SetActive(true);
            }
        }

        if (AllGloves.currentObj != AllGloves.AllObj[AllGloves.currentIndexObj])
        {
            AllGloves.currentObj.SetActive(false);
            if (AllGloves.AllObj[AllGloves.currentIndexObj])
            {
                AllGloves.currentObj = AllGloves.AllObj[AllGloves.currentIndexObj];
                AllGloves.currentObj.SetActive(true);
            }
        }

        if (AllAccesories.currentObj != AllAccesories.AllObj[AllAccesories.currentIndexObj])
        {
            AllAccesories.currentObj.SetActive(false);
            if (AllAccesories.AllObj[AllAccesories.currentIndexObj])
            {
                AllAccesories.currentObj = AllAccesories.AllObj[AllAccesories.currentIndexObj];
                AllAccesories.currentObj.SetActive(true);
            }
        }

        if (AllShoes.currentObj != AllShoes.AllObj[AllShoes.currentIndexObj])
        {
            AllShoes.currentObj.SetActive(false);
            if (AllShoes.AllObj[AllShoes.currentIndexObj])
            {
                AllShoes.currentObj = AllShoes.AllObj[AllShoes.currentIndexObj];
                AllShoes.currentObj.SetActive(true);
            }
        }

        if (AllSocks.currentObj != AllSocks.AllObj[AllSocks.currentIndexObj])
        {
            AllSocks.currentObj.SetActive(false);
            if (AllSocks.AllObj[AllSocks.currentIndexObj])
            {
                AllSocks.currentObj = AllSocks.AllObj[AllSocks.currentIndexObj];
                AllSocks.currentObj.SetActive(true);
            }
        }
    }

    public void IncrementIndex(string elementType)
    {
        var elementTypeEnum = Enum.Parse(typeof(ElementTypeEnum), elementType);
        switch (elementTypeEnum)
        {
            case ElementTypeEnum.Body:
                AllBody.currentIndexObj++;
                AllBody.currentIndexObj = CheckSizeIndex(AllBody.currentIndexObj, AllBody.AllObj);
                break;
            case ElementTypeEnum.Eyes:
                AllEyes.currentIndexObj++;
                AllEyes.currentIndexObj = CheckSizeIndex(AllEyes.currentIndexObj, AllEyes.AllObj);
                break;
            case ElementTypeEnum.Glasses:
                AllGlasses.currentIndexObj++;
                AllGlasses.currentIndexObj = CheckSizeIndex(AllGlasses.currentIndexObj, AllGlasses.AllObj);
                break;
            case ElementTypeEnum.Hat:
                AllHat.currentIndexObj++;
                AllHat.currentIndexObj = CheckSizeIndex(AllHat.currentIndexObj, AllHat.AllObj);
                break;
            case ElementTypeEnum.FacialHair:
                AllFacialHair.currentIndexObj++;
                AllFacialHair.currentIndexObj = CheckSizeIndex(AllFacialHair.currentIndexObj, AllFacialHair.AllObj);
                break;
            case ElementTypeEnum.Hair:
                AllHair.currentIndexObj++;
                AllHair.currentIndexObj = CheckSizeIndex(AllHair.currentIndexObj, AllHair.AllObj);
                break;
            case ElementTypeEnum.Coat:
                AllCoat.currentIndexObj++;
                AllCoat.currentIndexObj = CheckSizeIndex(AllCoat.currentIndexObj, AllCoat.AllObj);
                break;
            case ElementTypeEnum.BodyShirt:
                AllBodyShirt.currentIndexObj++;
                AllBodyShirt.currentIndexObj = CheckSizeIndex(AllBodyShirt.currentIndexObj, AllBodyShirt.AllObj);
                break;
            case ElementTypeEnum.Pants:
                AllPants.currentIndexObj++;
                AllPants.currentIndexObj = CheckSizeIndex(AllPants.currentIndexObj, AllPants.AllObj);
                break;
            case ElementTypeEnum.Gloves:
                AllGloves.currentIndexObj++;
                AllGloves.currentIndexObj = CheckSizeIndex(AllGloves.currentIndexObj, AllGloves.AllObj);
                break;
            case ElementTypeEnum.Accesories:
                AllAccesories.currentIndexObj++;
                AllAccesories.currentIndexObj = CheckSizeIndex(AllAccesories.currentIndexObj, AllAccesories.AllObj);
                break;
            case ElementTypeEnum.Shoes:
                AllShoes.currentIndexObj++;
                AllShoes.currentIndexObj = CheckSizeIndex(AllShoes.currentIndexObj, AllShoes.AllObj);
                break;
            case ElementTypeEnum.Socks:
                AllSocks.currentIndexObj++;
                AllSocks.currentIndexObj = CheckSizeIndex(AllSocks.currentIndexObj, AllSocks.AllObj);
                break;
        }

        changedHappened = true;
    }

    public void DecrementIndex(string elementType)
    {
        var elementTypeEnum = Enum.Parse(typeof(ElementTypeEnum), elementType);
        switch (elementTypeEnum)
        {
            case ElementTypeEnum.Body:
                AllBody.currentIndexObj--;
                AllBody.currentIndexObj = CheckSizeIndex(AllBody.currentIndexObj, AllBody.AllObj);
                break;
            case ElementTypeEnum.Eyes:
                AllEyes.currentIndexObj--;
                AllEyes.currentIndexObj = CheckSizeIndex(AllEyes.currentIndexObj, AllEyes.AllObj);
                break;
            case ElementTypeEnum.Glasses:
                AllGlasses.currentIndexObj--;
                AllGlasses.currentIndexObj = CheckSizeIndex(AllGlasses.currentIndexObj, AllGlasses.AllObj);
                break;
            case ElementTypeEnum.Hat:
                AllHat.currentIndexObj--;
                AllHat.currentIndexObj = CheckSizeIndex(AllHat.currentIndexObj, AllHat.AllObj);
                break;
            case ElementTypeEnum.FacialHair:
                AllFacialHair.currentIndexObj--;
                AllFacialHair.currentIndexObj = CheckSizeIndex(AllFacialHair.currentIndexObj, AllFacialHair.AllObj);
                break;
            case ElementTypeEnum.Hair:
                AllHair.currentIndexObj--;
                AllHair.currentIndexObj = CheckSizeIndex(AllHair.currentIndexObj, AllHair.AllObj);
                break;
            case ElementTypeEnum.Coat:
                AllCoat.currentIndexObj--;
                AllCoat.currentIndexObj = CheckSizeIndex(AllCoat.currentIndexObj, AllCoat.AllObj);
                break;
            case ElementTypeEnum.BodyShirt:
                AllBodyShirt.currentIndexObj--;
                AllBodyShirt.currentIndexObj = CheckSizeIndex(AllBodyShirt.currentIndexObj, AllBodyShirt.AllObj);
                break;
            case ElementTypeEnum.Pants:
                AllPants.currentIndexObj--;
                AllPants.currentIndexObj = CheckSizeIndex(AllPants.currentIndexObj, AllPants.AllObj);
                break;
            case ElementTypeEnum.Gloves:
                AllGloves.currentIndexObj--;
                AllGloves.currentIndexObj = CheckSizeIndex(AllGloves.currentIndexObj, AllGloves.AllObj);
                break;
            case ElementTypeEnum.Accesories:
                AllAccesories.currentIndexObj--;
                AllAccesories.currentIndexObj = CheckSizeIndex(AllAccesories.currentIndexObj, AllAccesories.AllObj);
                break;
            case ElementTypeEnum.Shoes:
                AllShoes.currentIndexObj--;
                AllShoes.currentIndexObj = CheckSizeIndex(AllShoes.currentIndexObj, AllShoes.AllObj);
                break;
            case ElementTypeEnum.Socks:
                AllSocks.currentIndexObj--;
                AllSocks.currentIndexObj = CheckSizeIndex(AllSocks.currentIndexObj, AllSocks.AllObj);
                break;
        }

        changedHappened = true;
    }

    public void ChangeColor(string elementType)
    {
        var elementTypeEnum = Enum.Parse(typeof(ElementTypeEnum), elementType);
        switch (elementTypeEnum)
        {
            case ElementTypeEnum.Body:
                AllBody.currentMaterialIndex++;
                AllBody.currentMaterialIndex = CheckSizeIndex(AllBody.currentMaterialIndex, MaterialsList);
                AllBody.currentObj.GetComponent<SkinnedMeshRenderer>().material =
                    MaterialsList[AllBody.currentMaterialIndex];
                break;
            case ElementTypeEnum.Eyes:
                AllEyes.currentMaterialIndex++;
                AllEyes.currentMaterialIndex = CheckSizeIndex(AllEyes.currentMaterialIndex, MaterialsList);
                AllEyes.currentObj.GetComponent<SkinnedMeshRenderer>().material =
                    MaterialsList[AllEyes.currentMaterialIndex];
                break;
            case ElementTypeEnum.Glasses:
                AllGlasses.currentMaterialIndex++;
                AllGlasses.currentMaterialIndex = CheckSizeIndex(AllGlasses.currentMaterialIndex, MaterialsList);
                AllGlasses.currentObj.GetComponent<SkinnedMeshRenderer>().material =
                    MaterialsList[AllGlasses.currentMaterialIndex];
                break;
            case ElementTypeEnum.Hat:
                AllHat.currentMaterialIndex++;
                AllHat.currentMaterialIndex = CheckSizeIndex(AllHat.currentMaterialIndex, MaterialsList);
                AllHat.currentObj.GetComponent<SkinnedMeshRenderer>().material =
                    MaterialsList[AllHat.currentMaterialIndex];
                break;
            case ElementTypeEnum.FacialHair:
                AllFacialHair.currentMaterialIndex++;
                AllFacialHair.currentMaterialIndex = CheckSizeIndex(AllFacialHair.currentMaterialIndex, MaterialsList);
                AllFacialHair.currentObj.GetComponent<SkinnedMeshRenderer>().material =
                    MaterialsList[AllFacialHair.currentMaterialIndex];
                break;
            case ElementTypeEnum.Hair:
                AllHair.currentMaterialIndex++;
                AllHair.currentMaterialIndex = CheckSizeIndex(AllHair.currentMaterialIndex, MaterialsList);
                AllHair.currentObj.GetComponent<SkinnedMeshRenderer>().material =
                    MaterialsList[AllHair.currentMaterialIndex];
                break;
            case ElementTypeEnum.Coat:
                AllCoat.currentMaterialIndex++;
                AllCoat.currentMaterialIndex = CheckSizeIndex(AllCoat.currentMaterialIndex, MaterialsList);
                AllCoat.currentObj.GetComponent<SkinnedMeshRenderer>().material =
                    MaterialsList[AllCoat.currentMaterialIndex];
                break;
            case ElementTypeEnum.BodyShirt:
                AllBodyShirt.currentMaterialIndex++;
                AllBodyShirt.currentMaterialIndex = CheckSizeIndex(AllBodyShirt.currentMaterialIndex, MaterialsList);
                AllBodyShirt.currentObj.GetComponent<SkinnedMeshRenderer>().material =
                    MaterialsList[AllBodyShirt.currentMaterialIndex];
                break;
            case ElementTypeEnum.Pants:
                AllPants.currentMaterialIndex++;
                AllPants.currentMaterialIndex = CheckSizeIndex(AllPants.currentMaterialIndex, MaterialsList);
                AllPants.currentObj.GetComponent<SkinnedMeshRenderer>().material =
                    MaterialsList[AllPants.currentMaterialIndex];
                break;
            case ElementTypeEnum.Gloves:
                AllGloves.currentMaterialIndex++;
                AllGloves.currentMaterialIndex = CheckSizeIndex(AllGloves.currentMaterialIndex, MaterialsList);
                AllGloves.currentObj.GetComponent<SkinnedMeshRenderer>().material =
                    MaterialsList[AllGloves.currentMaterialIndex];
                break;
            case ElementTypeEnum.Accesories:
                AllAccesories.currentMaterialIndex++;
                AllAccesories.currentMaterialIndex = CheckSizeIndex(AllAccesories.currentMaterialIndex, MaterialsList);
                AllAccesories.currentObj.GetComponent<SkinnedMeshRenderer>().material =
                    MaterialsList[AllAccesories.currentMaterialIndex];
                break;
            case ElementTypeEnum.Shoes:
                AllShoes.currentMaterialIndex++;
                AllShoes.currentMaterialIndex = CheckSizeIndex(AllShoes.currentMaterialIndex, MaterialsList);
                AllShoes.currentObj.GetComponent<SkinnedMeshRenderer>().material =
                    MaterialsList[AllShoes.currentMaterialIndex];
                break;
            case ElementTypeEnum.Socks:
                AllSocks.currentMaterialIndex++;
                AllSocks.currentMaterialIndex = CheckSizeIndex(AllSocks.currentMaterialIndex, MaterialsList);
                AllSocks.currentObj.GetComponent<SkinnedMeshRenderer>().material =
                    MaterialsList[AllSocks.currentMaterialIndex];
                break;
        }

        changedHappened = true;
    }

    private int CheckSizeIndex(int index, IList list)
    {
        if (index >= list.Count)
            index = 0;
        if (index < 0)
            index = list.Count - 1;
        return index;
    }

    public void ValidateCharacter()
    {
        var mainBody = Instantiate(Presentoir);
        int nbChild = mainBody.transform.childCount;
        int i = 0;
        while (i < nbChild)
        {
            if (!mainBody.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                Destroy(mainBody.transform.GetChild(i).gameObject);
            }
            i++;
        }

        //GameManagerOld.Instance.PlayerCharacter = mainBody;

        //SceneManager.LoadScene("GameScene");
    }
}