//using UnityEngine;

//public class PlayerManager : MonoBehaviour
//{
//    public PlayerInfo PlayerInfo;
//    public GameObject BotInRange;

//    public delegate void ActionJoueur();
//    public ActionJoueur actionJoueur;

//    public void Start()
//    {
//        if (PlayerInfo.Role == RoleEnum.Tueur) 
//            GameManagerOld.Instance.electricShutDown += TimeToKill;
//    }

//    public void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Mouse0) && PlayerInfo.Role == RoleEnum.Tueur && BotInRange != null)
//        {
//            Debug.Log($"Coucou + {BotInRange.gameObject.name}");
//            Destroy(BotInRange.gameObject);
//            GameManagerOld.Instance.AllBots.Remove(BotInRange.gameObject.GetComponent<BotManager>());
//            //Deduire de la happiness globale/ajouter un malus a prendre un compte?
//        }

//        if (Input.GetKeyDown(KeyCode.X))
//        {
//            PlayerInfo.isInGame ^= true;
//            actionJoueur.Invoke();
//        }
//    }

//    public void OnCollisionEnter(Collision collision) // A changer par un physics ray de 3 unit je pense et choper le collider a ce moment là
//    {
//        if (collision.gameObject.tag == "Bot")
//        {
//            BotInRange = collision.gameObject;
//        }
//    }

//    public void OnCollisionExit(Collision collision)
//    {
//        BotInRange = null;
//    }

//    public void TimeToKill()
//    {
//        Debug.Log("KillerOptionEnable");
//    }

//}
