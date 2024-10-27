using TMPro;
using UnityEngine;

public class MapInfo : MonoBehaviour
{
    public SpawnManager SpawnManager;

    public int GeneralScoreMax;
    public int CurrentGeneralScore;
    private int PreviousGeneralScore;
    public TextMeshProUGUI ScoreText;

    //Ici toute les infos de la map
    //aka les point de spawn, l'arrivée, les point de ressources possible, etc etc

    void Start()
    {
        GameManager.Instance.MapInfo = this;
        //Test PurposeOnly(?)
        GenerateElement();
        PreviousGeneralScore = CurrentGeneralScore = 0;
    }

    public void Update()
    {
        if (PreviousGeneralScore != CurrentGeneralScore)
        {
            ScoreText.text = "Score : " + CurrentGeneralScore;
            PreviousGeneralScore = CurrentGeneralScore;
        }

    }

    public void GenerateElement()
    {
        SpawnManager.SpawnCarts();
        //InvokeRepeating("SpawnMonsters",0f,5f);
        SpawnManager.SpawnMonsters();
        SpawnManager.SpawnResources(GeneralScoreMax);
    }


}