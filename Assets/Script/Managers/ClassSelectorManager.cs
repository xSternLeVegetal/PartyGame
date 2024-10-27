using Photon.Pun;
using TMPro;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class ClassSelectorManager : MonoBehaviourPunCallbacks
{
    ClassData myClassSelected = new ArcherData();
    public TextMeshProUGUI ClassName;
    public TextMeshProUGUI PointDeVie;
    public TextMeshProUGUI Mana;
    public TextMeshProUGUI Endurance;
    public TextMeshProUGUI Attaque;
    public TextMeshProUGUI Defense;

    public Image IconeCapa1;
    public TextMeshProUGUI Capa1NameText;
    public Image IconeCapa2;
    public TextMeshProUGUI Capa2NameText;
    public Image IconePassiv;
    public TextMeshProUGUI PassivNameText;

    public void Start()
    {
        ChangeInfoDisplay(myClassSelected.ClassName);
    }

    public void ChangeInfoDisplay(string classSelected)
    {
        myClassSelected = FindClassSelected(classSelected);
        ClassName.text = myClassSelected.ClassName;
        PointDeVie.text = myClassSelected.LifePointMax.ToString();
        Mana.text = myClassSelected.ManaPointMax.ToString();
        Endurance.text = myClassSelected.EnduranceMax.ToString();
        Attaque.text = myClassSelected.AttaqueOriginal.ToString();
        Defense.text = myClassSelected.DefenseOriginal.ToString();

        //IconeCapa1.sprite = classInfo.IconeCapa1;
        Capa1NameText.text = myClassSelected.AttackBasic.capacityName;
        //IconeCapa2.sprite = classInfo.IconeCapa2;
        Capa2NameText.text = myClassSelected.AttackHeavy.capacityName;
        //IconePassiv.sprite = classInfo.IconePassive;
        PassivNameText.text = myClassSelected.Passive.capacityName;
    }

    public ClassData FindClassSelected(string classSelected)
  
    {
        if (classSelected == ConstantStringManager.PlayerClassName.Mage)
            return new MageData();
        else if (classSelected == ConstantStringManager.PlayerClassName.Archer)
            return new ArcherData();
        else if (classSelected == ConstantStringManager.PlayerClassName.Epeiste)
            return new EpeisteData();
        return null;
        //GameManager.Instance.myClassSelected = myClassSelected;
        //GameManager.Instance.InstantiateMyCharacter();
        //SetUpInfoForAll(myClassSelected.ClassName);
    }

    public void ConfirmChoiceClass()
    {
        GameManager.Instance.myClassSelected = myClassSelected;
        GameManager.Instance.InstantiateMyCharacter();
        SetUpInfoForAll();
    }

    public void SetUpInfoForAll()
    {
        Hashtable playerProperties = new Hashtable();
        playerProperties["selectedClass"] = myClassSelected.ClassName;
        playerProperties["state"] = "TavernReady";
        PhotonNetwork.LocalPlayer.SetCustomProperties(playerProperties);
    }

}
