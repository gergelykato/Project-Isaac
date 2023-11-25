using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    public int Widht;
    public int Height;
    public int X;
    public int Y;

    // Start is called before the first frame update
    void Start()
    {
        if (RoomController.instance == null)
        {
            Debug.Log("You pressed play in the wrong situation!");
            return;
        }

        RoomController.instance.RegisterRoom(this);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(Widht, Height, 0));
    }


    public Vector3 GetRoomCenter()
    {
        return new Vector3(X * Widht, Y * Height);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            RoomController.instance.OnPlayerEnterRoom(this);
        }
    }

}
