using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketMovementScript : MonoBehaviour
{
    public float speed;
    public float maxX;
   
    // Start is called before the first frame update
    void Start()
    {

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
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.CompareTag("Unhealthy"))
        {
            Destroy(collision.gameObject);
        }
    }

}
