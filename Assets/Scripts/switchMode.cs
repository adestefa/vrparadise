using UnityEngine;
using System.Collections;

public class switchMode : MonoBehaviour {

    public GameObject boat;
    public GameObject boatCamera;
    public GameObject player;
    public GameObject playerStartPos;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        // trun boat controls on (drive boat)
        //if (Input.GetKey("1"))
        //{
        //  driveBoat();
       // }

        // turn boat controls off (FPS)
        if (Input.GetKey("2"))
        {
            walkAway();
        }
    }


    // if player walks into boat bridge, let him drive!
    void OnTriggerEnter(Collider col)
    {
        driveBoat();
    }

  

    void driveBoat()
    {
        boat.GetComponent<Rigidbody>().isKinematic = false;
        boat.GetComponent<boat>().enabled = true;
        boatCamera.SetActive(true);

        player.SetActive(false);
    }

    void walkAway()
    {
        boat.GetComponent<Rigidbody>().isKinematic = true;
        boat.GetComponent<boat>().enabled = false;
        boatCamera.SetActive(false);

        player.SetActive(true);
        player.transform.position = playerStartPos.transform.position;
    }

}
