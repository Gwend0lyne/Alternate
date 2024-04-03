using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoomItem : MonoBehaviour
{
    public Text roomName;
    CreateAndJoinRooms manager;

    private void Start() 
    {
        manager = FindObjectOfType<CreateAndJoinRooms>();
    }

    public void SetRoomName(string _roomName)
    {
        roomName.text = _roomName;
    }

    public void OnClickItem()
    {
        manager.JoinRoom(roomName.text);
    }
}
