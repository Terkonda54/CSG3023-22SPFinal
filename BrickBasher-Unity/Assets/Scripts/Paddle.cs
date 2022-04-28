/**** 
 * Created by: Bob Baloney
 * Date Created: April 20, 2022
 * 
 * Last Edited by: 
 * Last Edited:
 * 
 * Description: Paddle controler on Horizontal Axis
****/

/*** Using Namespaces ***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 7; //speed of paddle
    float xPos;

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal"); //check if player is moving left or right
     
        h += (h * speed);
        transform.position = new Vector3(h, -9, 0);
        
    }//end Update()
}
