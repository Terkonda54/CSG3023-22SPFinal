/**** 
 * Created by: Bob Baloney
 * Date Created: April 20, 2022
 * 
 * Last Edited by: 
 * Last Edited:
 * 
 * Description: Controls the ball and sets up the intial game behaviors. 
****/

/*** Using Namespaces ***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //import this for UI


public class Ball : MonoBehaviour
{

    //VARIABLES//

    [Header("General Settings")]
    public UnityEngine.UI.Text txtBalls;
    public UnityEngine.UI.Text txtScore;
    public int score;
    public GameObject paddle;
    public bool isInPlay;
    public Rigidbody rb;
    public AudioSource audioSource;


    [Header("Ball Settings")]
    public int numBalls = 10;
    public Vector3 initialForce;
    public int speed;

   


 


    //Awake is called when the game loads (before Start).  Awake only once during the lifetime of the script instance.
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }//end Awake()


        // Start is called before the first frame update
        void Start()
    {
        SetStartingPos(); //set the starting position

    }//end Start()


    // Update is called once per frame
    void Update()
    {
        //Converts ints to strings
        string stringBalls = "Balls: " + numBalls.ToString();
        string stringScore = "Score: " + score.ToString();
        //Set the text property on the HUD
        txtBalls.text = stringBalls;
        txtScore.text = stringScore;

        if (!isInPlay)
        {
            Vector3 pos = new Vector3();
            pos.x = paddle.transform.position.x; //x position of paddel
            pos.y = paddle.transform.position.y + paddle.transform.localScale.y; //Y position of paddle plus it's height

            transform.position = pos;//set current position of the ball 
        }
        if (Input.GetKeyDown(KeyCode.Space) && !isInPlay)
        {
            isInPlay = true;
            Move();
        }

    }//end Update()


    private void LateUpdate()
    {
        if (isInPlay)
        {
            rb.velocity = speed * rb.velocity.normalized;
        }

    }//end LateUpdate()


    private void Move()
    {
        Debug.Log("MOVE FUNCTION CALLED");
        rb.AddForce(initialForce);
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Hit " + other.gameObject.tag);
        //I tried so hard to figure this out, needed to get the clip OF the audio source, so close.... yet so far
        //audioSource.PlayOneShot(audioSource);
        if(other.gameObject.tag == "Brick")
        {
            score += 100;
            Destroy(other.gameObject);
        }
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "OutBounds")
        {
            numBalls--;
            if (numBalls > 0)
            {
                Invoke("SetStartingPos", 2);
            }
        }
    }


    void SetStartingPos()
    {
        
        isInPlay = false;//ball is not in play
        rb.velocity = Vector3.zero;//set velocity to keep ball stationary

        Vector3 pos = new Vector3();
        pos.x = paddle.transform.position.x; //x position of paddel
        pos.y = paddle.transform.position.y + paddle.transform.localScale.y; //Y position of paddle plus it's height

        transform.position = pos;//set starting position of the ball 
        
    }//end SetStartingPos()






}
