using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerOld : MonoBehaviour
{
    public static GameManagerOld Instance;

    public List<PlayerInfo> AllPlayerInfos;
    public List<BotManager> AllBots;

    public List<GameObject> Lamps;

    public PlayerInfo Killer;

    public TextMeshProUGUI TimerText;
    public int Timer = 0;
    public TextMeshProUGUI GlobalHapinessText;
    public float GlobalHapinessAmount;
    public TextMeshProUGUI GlobalSadnessText;
    public float GlobalSadnessAmount;

    public int ElectricShutDownTimer = 30;

    public delegate void ElectricShutDown();
    public ElectricShutDown electricShutDown;

    //public delegate void HapinnessBonnus();
    //public HapinnessBonnus hapinnessBonnus;

    public GameObject PlayerCharacter { get; set; }

    public void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        //GenerateRole();//9a larche c'est cool mais j'ai besoi nde test wsh
        //Tps Random Pour Le ElectricShutDown ?
        StartCoroutine(TimerLampe());
        //foreach (var botManager in AllBots)
        //{
        //    var Rand = Random.Range(0, 100);
        //    botManager.Happiness = Rand;
        //}
    }

    public void Update()
    {
        if (Timer == ElectricShutDownTimer)
        {
            //ElectricShutdown Gestion
            //Aprés X Temps
            electricShutDown?.Invoke();
            GlobalSadnessAmount += Timer / 100f;
            Timer = 0;
            StartCoroutine(KillerTime());

            //foreach (var botManager in AllBots)
            //{
            //    var Rand = Random.Range(0, 100);
            //    botManager.Happiness = Rand;
            //}

        }

        CheckGlobalMood();
    }


    private void CheckGlobalMood()
    {
        //float totalHappiness = 0;
        //foreach (var bot in AllBots)
        //{
        //    totalHappiness += bot.Happiness;
        //}

        float hapinessAmount = GlobalHapinessAmount/1000f*100f;
        GlobalHapinessText.text = hapinessAmount.ToString("0.0000");

        float sadnessAmount = (GlobalSadnessAmount/ 100) * 100;
        GlobalSadnessText.text = sadnessAmount.ToString("0.0000");
    }

    private void GenerateRole()
    {
        var randomList = new List<PlayerInfo>(AllPlayerInfos);
        randomList.Shuffle();
        for (int i = 0; i < randomList.Count; i++)
        {
            if (i == 0)
            {
                randomList[i].Role = RoleEnum.Tueur;
                Killer = randomList[i];
            }

            randomList[i].Role = (RoleEnum)i;
        }
    }

    IEnumerator TimerLampe()
    {
        TimerText.color = Color.white;
        while (Timer < ElectricShutDownTimer)
        {
            yield return new WaitForSeconds(1);
            Timer++;
            TimerText.text = Timer.ToString();
        }
    }

    IEnumerator KillerTime()
    {
        TimerText.color = Color.red;
        while (Timer < ElectricShutDownTimer)
        {
            yield return new WaitForSeconds(1);
            Timer++;
            TimerText.text = Timer.ToString();
        }
    }

    public void HapinnessBonnus(float bonus)
    {
        GlobalHapinessAmount += bonus;
    }

}