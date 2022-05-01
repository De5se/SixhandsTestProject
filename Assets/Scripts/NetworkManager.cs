using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private Animator menuAnimator;

    [SerializeField] private TMP_InputField roomNameField;
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(roomNameField.text);
    }

    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions(){BroadcastPropsChangeToAll = true};
        roomOptions.MaxPlayers = 10;
        PhotonNetwork.CreateRoom(roomNameField.text, roomOptions);
    }

    public override void OnJoinedRoom()
    {
        menuAnimator.Play("Close");
        PhotonNetwork.LoadLevel("Game");
    }
}
