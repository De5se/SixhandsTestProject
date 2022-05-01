
using System.Collections.Generic;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class SkinController : MonoBehaviourPunCallbacks
{
    private ExitGames.Client.Photon.Hashtable _playerProperties = new ExitGames.Client.Photon.Hashtable();

    private  string _shirtsString = "shirts";
    private  string _bootsString = "boots";
    private  string _pantsString = "pants";
    private void Start()
    {
        _player = photonView.Owner;
        if (!_playerProperties.ContainsKey(_shirtsString))
        {
            _playerProperties.Add(_shirtsString, 0);
        }
        if (!_playerProperties.ContainsKey(_bootsString))
        {
            _playerProperties.Add(_bootsString, 0);
        }
        if (!_playerProperties.ContainsKey(_pantsString))
        {
            _playerProperties.Add(_pantsString, 0);
        }
        
    }


    [SerializeField] private List<GameObject> shirts = new List<GameObject>();
    public void ChangeShirt()
    {
        if ((int) _playerProperties[_shirtsString] == shirts.Count - 1)
        {
            _playerProperties[_shirtsString] = 0;
        }
        else
        {
            _playerProperties[_shirtsString] = (int) _playerProperties[_shirtsString]  + 1;
        }
        
        PhotonNetwork.SetPlayerCustomProperties(_playerProperties);
    }
    
    [SerializeField] private List<GameObject> boots = new List<GameObject>();
    public void ChangeBoots()
    {
        if ((int) _playerProperties[_bootsString] == boots.Count - 1)
        {
            _playerProperties[_bootsString] = 0;
        }
        else
        {
            _playerProperties[_bootsString] = (int) _playerProperties[_bootsString]  + 1;
        }
        PhotonNetwork.SetPlayerCustomProperties(_playerProperties);
    }
    
    [SerializeField] private List<GameObject> pants = new List<GameObject>();
    public void ChangeTrousers()
    {
        if ((int) _playerProperties[_pantsString] == pants.Count - 1)
        {
            _playerProperties[_pantsString] = 0;
        }
        else
        {
            _playerProperties[_pantsString] = (int) _playerProperties[_pantsString]  + 1;
        }
        
        PhotonNetwork.SetPlayerCustomProperties(_playerProperties);
    }
    
    private Player _player;
    
    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        if (_player == targetPlayer)
        {
            UpdatePlayerThing(targetPlayer);
        }
    }

    private void UpdatePlayerThing(Player player)
    {
        if (player.CustomProperties.ContainsKey(_shirtsString))
        {
            for (int i = 0; i < shirts.Count; i++)
            {
                shirts[i].SetActive(i == (int)player.CustomProperties[_shirtsString]);
            }
            
            _playerProperties[_shirtsString] = (int) player.CustomProperties[_shirtsString];
        }
        else
        {
            _playerProperties[_shirtsString] = 0;
        }
        
        if (player.CustomProperties.ContainsKey(_bootsString))
        {
            for (int i = 0; i < boots.Count; i++)
            {
                boots[i].SetActive(i == (int)player.CustomProperties[_bootsString]);
            }
            
            _playerProperties[_bootsString] = (int) player.CustomProperties[_bootsString];
        }
        else
        {
            _playerProperties[_bootsString] = 0;
        }
        
        if (player.CustomProperties.ContainsKey(_pantsString))
        {
            for (int i = 0; i < pants.Count; i++)
            {
                pants[i].SetActive(i == (int)player.CustomProperties[_pantsString]);
            }
            
            _playerProperties[_pantsString] = (int) player.CustomProperties[_pantsString];
        }
        else
        {
            _playerProperties[_pantsString] = 0;
        }
    }
}
