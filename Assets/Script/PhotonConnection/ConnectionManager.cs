using Photon.Pun;
using System.Collections.Generic;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using WebSocketSharp;
using Debug = UnityEngine.Debug;
using System.Linq;
using ExitGames.Client.Photon;

public class ConnectionManager : MonoBehaviourPunCallbacks
{
    public GameObject LoadingPanel;
    public GameObject LoginPanel;
    public GameObject RoomManagementPanel;
    public GameObject CreateRoomPanel;
    public TMP_InputField RoomNameInputField;

    public GameObject RoomPrefabGameObject;
    public GameObject RoomHolder;
    private List<GameObject> ListeAllRoomGOCreated = new List<GameObject>();
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        //    Hashtable playerProperties = new Hashtable();
        //    //playerProperties["iconeIndex"] = selectIconeManager.index;//récupérer du input field
        //    //PhotonNetwork.LocalPlayer.SetCustomProperties(playerProperties);
        //    //PhotonNetwork.NickName = UserNameInputField.text ?? "UserDebile";//récupérer du input field
        //    SceneManager.LoadScene("RoomSelectionScene");

        //SceneManager.LoadScene("SelectionClassScene");
        Debug.Log("Connected To Master");
        LoadingPanel.SetActive(false);
        LoginPanel.SetActive(true);
    }

    public void Login()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("LobbyJoined");
        LoginPanel.SetActive(false);
        RoomManagementPanel.SetActive(true);
    }

    public void SetRoomCreationPanel()
    {
        CreateRoomPanel.SetActive(true);
    }

    public void CreateRoom()
    {
        var roomName = RoomNameInputField.text;
        //PhotonNetwork.CreateRoom(roomName ?? "Room Default");
        if (roomName.IsNullOrEmpty())
            roomName = "Room Default";
        string uniqueId = System.Guid.NewGuid().ToString();

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 5;
        roomOptions.CustomRoomProperties = new Hashtable();
        roomOptions.CustomRoomProperties.Add("roomId", uniqueId);

        roomOptions.CustomRoomPropertiesForLobby = new[]
        {
            "roomId"
        };

        PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, null);
        LoadingPanel.SetActive(true);
        RoomManagementPanel.SetActive(false);

    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Create room failed : " + message);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Room Rejointe");
        SceneManager.LoadScene("LobbyTavernScene");
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Room Created");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        var tempList = ListeAllRoomGOCreated.Select(x => x.GetComponent<RoomPrefabInfo>().RoomId).Where(x => x != null);

        foreach (var roomInfo in roomList)
        {
            if (tempList.Any())
            {
                if (!tempList.Contains(roomInfo.CustomProperties["roomId"].ToString()))
                {
                    InstantiateNewRoomPrefab(roomInfo);
                }
                else
                {
                    var roomGO = ListeAllRoomGOCreated.FirstOrDefault(x => x.GetComponent<RoomPrefabInfo>().RoomId
                                                                           == roomInfo.CustomProperties["roomId"]
                                                                               .ToString());
                    //roomGO.GetComponent<RoomPrefabInfo>().RoomNbPlayer.text = roomInfo.PlayerCount.ToString();
                }
            }
            else
            {
                InstantiateNewRoomPrefab(roomInfo);
            }
        }

        if (!roomList.Any())
        {
            foreach (var roomGO in ListeAllRoomGOCreated)
            {
                Destroy(roomGO);
            }

            ListeAllRoomGOCreated.Clear();
        }
        //else
        //{
        //    JoinRoomButton.SetActive(true);
        //}
    }

    private void InstantiateNewRoomPrefab(RoomInfo roomInfo)
    {
        var roomGO = Instantiate(RoomPrefabGameObject, RoomHolder.transform);
        var roomPrefabInfo = roomGO.GetComponentInChildren<RoomPrefabInfo>();
        roomPrefabInfo.RoomSetInfo(roomInfo);
        //RoomHolder.GetComponent<ToggleGroupManager>().toggleList.Add(roomPrefabInfo.GetComponentInChildren<Toggle>());
        //RoomHolder.GetComponent<ToggleGroupManager>().TogglerSetUp();
        var boutton = roomGO.GetComponentInChildren<Button>();
        boutton.onClick.AddListener(() =>
        {
            PhotonNetwork.JoinRoom(roomInfo.Name);
            LoadingPanel.SetActive(true);
            RoomManagementPanel.SetActive(false);
        }); 
        ListeAllRoomGOCreated.Add(roomGO);
    }
}