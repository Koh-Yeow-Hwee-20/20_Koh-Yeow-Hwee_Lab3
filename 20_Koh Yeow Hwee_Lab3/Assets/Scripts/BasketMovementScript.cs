using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasketMovementScript : MonoBehaviour
{
    public float speed;
    public float maxX;

    public Text scoreText;
    private int scoreNumber;
   
    // Start is called before the first frame update
    void Start()
    {
        scoreNumber = 0;
        scoreText.text = "Score : " + scoreNumber;
    }

    // Update is called once per frame
    void Update()
    {

      float horizontalInput = Input.GetAxis("Horizontal");
      transform.position = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime, 0, 0);

      //Restrict player from moving out of the screen
      Vector2 pos = transform.position;
      pos.x = Mathf.Clamp(pos.x, -maxX, maxX);
      transform.position = pos;
    }


    //Collision for Healthy and Unhealthy items
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Healthy"))
        {
            scoreNumber += 10;
            Destroy(collision.gameObject);
            scoreText.text = "Score : " + scoreNumber;
        }
        else if(collision.gameObject.CompareTag("Unhealthy"))
        {
            Destroy(collision.gameObject);
        }
    }

}
