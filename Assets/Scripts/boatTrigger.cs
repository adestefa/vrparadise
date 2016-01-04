using UnityEngine;
using System.Collections;

public class boatTrigger : MonoBehaviour {


    public GameObject boat;
    public GameObject boatCamera;
    public GameObject player;
    public GameObject playerStartPos;

 
   

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
