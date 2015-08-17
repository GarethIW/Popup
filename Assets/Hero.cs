using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour
{
    public static Hero Instance;

    public Room Room;
    public bool IsInside = false;

	// Use this for initialization
	void Start ()
	{
	    Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Room>() != null)
        {
            Room = other.GetComponent<Room>();
            IsInside = Room.IsInside;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Room>() != null)
        {
            Room = null;
        }
    }
}
