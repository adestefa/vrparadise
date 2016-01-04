using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class boat : MonoBehaviour {
    public float turnSpeed = 5000f;
    public float accellerateSpeed = 5000f;
    public int timerMax = 5000;
    public TextMesh score;
    public TextMesh timer_;

    private int points;
    private Rigidbody rbody;
    private string hitobject;



    // Use this for initialization
    void Start () {
        rbody = GetComponent<Rigidbody>();
        points = 0;
        timer_.text = timerMax.ToString();
   }
	
	// Update is called once per frame
	void Update () {
        
        // update boat velocity using controls directly   
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        rbody.AddTorque(0f, h * turnSpeed * Time.deltaTime, 0f);
        rbody.AddForce(transform.forward * v * accellerateSpeed * Time.deltaTime);

        // Boost button pressed
        float boost = Input.GetAxis("Fire1");
        if(boost > 0)
        {
            rbody.AddForce(transform.forward * v * 10000 * Time.deltaTime);
        }

        // brake button pressed
        float brake = Input.GetAxis("Fire2");
        if (brake > 0)
        {
            rbody.velocity = new Vector3(0f, 0f, 0f);
        }

        
        // manage the game timer
        if (timerMax > 0)
        {
            timerMax = timerMax - 1;
            timer_.text = timerMax.ToString();
        }
        else
        {
            timer_.text = "GAME OVER!";
        }  
    }

    // detect collisions with boat   
    void OnCollisionEnter(UnityEngine.Collision hit)
    {

        hitobject = hit.gameObject.tag;

        // did player hit actual cube?
        if (hitobject == "RedCube")
        {
            Destroy(hit.gameObject);
            Debug.Log("HIT:" + hitobject);
            points = points + 1;
            // rbody.AddForce(transform.forward*2000*Time.deltaTime);
            score.text = points.ToString();
        }
         
    }
}
