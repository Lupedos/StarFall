using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoCaindo : MonoBehaviour
{
    public Rigidbody2D rb;
    public float objetoPositionX, objetoPositionY;
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
       rb.AddForce(new Vector2(0,-200)); 
    }

    void Update()
    {
        objetoPositionX = transform.position.x;
        objetoPositionY = transform.position.y;
    }

     void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("chao"))
		{
        
         Destroy(this.gameObject);   
			
		}

	}
}
