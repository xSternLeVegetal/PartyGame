using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

//On le met à partir de la scene de lobby/selection de Classe
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<GameObject> ClassPrefabs;
    public MapInfo MapInfo;
    public Player LocalPlayer;
    public ClassData myClassSelected;
    public GameObject MyCharacterGameObject;

    public GameObject SelectionClassPanel;

    public string MissionSelected;

    public BattleManager BattleManager;
    public QuestManager QuestManager = new QuestManager();

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    void Start()
    {
        //ChoperDepuis la Room Info, quellq classe je joue 
        LocalPlayer = PhotonNetwork.LocalPlayer;

        //TEST
        MissionSelected = ConstantStringManager.SceneName.MapScene;
    }

    public void InstantiateMyCharacter()
    { 
        SelectionClassPanel.SetActive(false);
    //myClassSelected = FindClassSelected(LocalPlayer.CustomProperties["selectedClass"].ToString());
    //Debug.Log(myClassSelected.ClassName);
        InstantiateMyCharacterPrefab();
    }


    private void InstantiateMyCharacterPrefab()
    {
        foreach (var classPrefab in ClassPrefabs)
        {
            if (classPrefab.GetComponent<PlayerManager>().MyClassData.ClassName == myClassSelected.ClassName)
            {
                MyCharacterGameObject = classPrefab;
                PhotonNetwork.Instantiate(classPrefab.name, new Vector3(0, 0, 0), Quaternion.identity);
                return;
                //Instantiate(classPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            }
        }
    }

    public ClassData FindClassSelected(string classSelected)
    {
        if (classSelected == ConstantStringManager.PlayerClassName.Mage)
            return new MageData();
        if (classSelected == ConstantStringManager.PlayerClassName.Archer)
            return new ArcherData();
        if (classSelected == ConstantStringManager.PlayerClassName.Epeiste)
            return new EpeisteData();
        return null;
    }
    public ClassData FindMonster(string classSelected)
    {
        if (classSelected == ConstantStringManager.MonsterName.Skeleton)
            return new Skeleton();
        if (classSelected == ConstantStringManager.MonsterName.OrcWolfRider)
            return new OrcWolfRiderData();
        return null;
    }

    public void StartMap()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            //Instancier, préparer la map, et envoyer les infos aux autres
            MapInfo.GenerateElement();
        }
        else
        {
            //Y auras bien des trucs ici
        }
        GeneratePlayerCharacter();
    }

    private void GeneratePlayerCharacter()
    {
        //MapInfo.PlayerSpawnPoint
    }

    public void GoToMissionMap()
    {
        PhotonNetwork.LoadLevel(MissionSelected);
    }

    private void FindBattleManager()
    {
        BattleManager = GameObject.Find(ConstantStringManager.GameObjectName.BattleManager).GetComponent<BattleManager>();
    }

}