using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BasketMovementScript : MonoBehaviour
{
    public float speed;
    public float maxX;

    public Text scoreText;
    private int scoreNumber;
   
    // Start is called before the first frame update
    void Start()
    {
        //Score system
        scoreNumber = 0;
        scoreText.text = "Score : " + scoreNumber;
    }

    // Update is called once per frame
    void Update()
    {
      
      //Player Movement
      float horizontalInput = Input.GetAxis("Horizontal");
      transform.position = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime, 0, 0);

      //Restrict player from moving out of the screen
      Vector2 pos = transform.position;
      pos.x = Mathf.Clamp(pos.x, -maxX, maxX);
      transform.position = pos;

      //Win Scene  
      if (scoreNumber == 20)
        {
            SceneManager.LoadScene("WinScene");
        }
    }


    //Collision for Healthy and Unhealthy items
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Healthy"))
        {

            //Score system
            scoreNumber += 10;
            Destroy(collision.gameObject);
            scoreText.text = "Score : " + scoreNumber;
        }
        else if(collision.gameObject.CompareTag("Unhealthy"))
        {
            SceneManager.LoadScene("LoseScene");
            //Destroy(collision.gameObject);
        }
    }

}
