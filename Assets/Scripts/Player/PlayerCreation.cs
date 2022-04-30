using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerCreation : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private SkinPanel skinPanel;

    private void Start()
    {
        CreatePlayer();
    }

    private void CreatePlayer()
    {
        var playerObject = PhotonNetwork.Instantiate(player.name, player.transform.position, player.transform.rotation);
        SkinController skinController = playerObject.GetComponent<SkinController>();
        skinPanel.SetButtons(skinController);
    }
}
