using UnityEngine;

public class NetworkManager : MonoBehaviour
{
    public static NetworkManager Instance;

    public void Awake()
    {
        if (Instance == null)
            Instance = this;
    }


    public void UpdateLocalPlayerProperties()
    {

        //PhotonNetwork.LocalPlayer.SetCustomProperties();
    }
    //Ici on vas mettre tout les méthodes d'envoie aux autres client

}
