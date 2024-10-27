using Photon.Realtime;
using TMPro;
using UnityEngine;

public class RoomPrefabInfo : MonoBehaviour
{
    public TextMeshProUGUI RoomName;
    //public Text RoomNbPlayer;
    public string RoomId;

    public void RoomSetInfo(RoomInfo roomInfo)
    {
        RoomName.text = roomInfo.Name;
        //roomInfo.
        //RoomGame.text = roomInfo.CustomProperties["game"].ToString();
        //RoomNbPlayer.text = roomInfo.PlayerCount + "/" + roomInfo.MaxPlayers;
        RoomId = roomInfo.CustomProperties["roomId"].ToString();
    }

    public void RoomSetInfo(string name, string game, string nbplayer, string id)
    {
        RoomName.text = name;
        //RoomGame.text = game;
        //RoomNbPlayer.text = nbplayer;
        RoomId = id;
    }
}