using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawnee;
    private float spawntime = 1;
    private float spawndelay=1;
    private int randomInt;
    float positionx;
    private AudioSource audiosource;
   

    

    // Start is called before the first frame update
    void Start()
    {

        audiosource = GetComponent<AudioSource>();
        InvokeRepeating("spawnobject", spawntime, spawndelay);

     

    }

    // Update is called once per frame
    void Update()
    {
        
       // spawntime = Random.Range(1, 3);
    }

    void spawnobject()
    {
       
        audiosource.Play();
        randomInt = Random.Range(0, spawnee.Length);
        positionx = Random.Range(8f,-8f);
        this.transform.position = new Vector3(positionx,transform.position.y , transform.position.z);
        Instantiate(spawnee[randomInt], transform.position, transform.rotation);
   

    }
}
