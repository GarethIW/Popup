using UnityEngine;
using System.Collections;

public class Room : MonoBehaviour
{
    public bool Active = false;
    public bool IsInside = false;

    private float floorFade = 0.25f;

    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (Active)
        {
            floorFade = Mathf.Lerp(floorFade, 1f, Time.deltaTime*2f);
        }
        else
        {
            if(IsInside == Hero.Instance.IsInside)
                floorFade = Mathf.Lerp(floorFade, 0.4f, Time.deltaTime * 2f);
            else
                floorFade = Mathf.Lerp(floorFade, 0f, Time.deltaTime * 2f);
        }

        transform.FindChild("Floor").GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(floorFade,floorFade,floorFade));
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.name == "Hero") Active = true;
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.name == "Hero") Active = false;
    }
}
