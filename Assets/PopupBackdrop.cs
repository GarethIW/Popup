using UnityEngine;
using System.Collections;

public class PopupBackdrop : MonoBehaviour
{
    public bool Popped = false;

    private float popDelay;
    private float poppedAmout;
    private Transform hero;
    private Transform mesh;

	// Use this for initialization
	void Start ()
	{
	    hero = GameObject.Find("Hero").transform;
	    mesh = transform.FindChild("Mesh");
	    Popped = false;
	    poppedAmout = 0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    Popped = Vector3.Distance(transform.position, hero.position) < 5f;
	    if (Popped)
	    {
	        popDelay -= Time.deltaTime;
	        if (popDelay <= 0f)
	        {
                mesh.gameObject.SetActive(true);
                poppedAmout = Mathf.Lerp(poppedAmout, 1f, Time.deltaTime*10f);
	        }
	    }
	    else
	    {
            poppedAmout = Mathf.Lerp(poppedAmout, 0f, Time.deltaTime * 10f);
	        popDelay = Random.Range(0f, 0.5f);
            if(poppedAmout<0.1f) mesh.gameObject.SetActive(false);
	    }

	    transform.localRotation = Quaternion.Euler(90f*(1f - poppedAmout), transform.localEulerAngles.y, transform.localEulerAngles.z);
	}
}
