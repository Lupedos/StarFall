using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoScript : MonoBehaviour
{
    
    private Rigidbody2D rb2d;
    [HideInInspector] private bool jump;
    public float ForcaPulo = 1000f;
    public Transform posPe;
    [HideInInspector] public bool tocaChao = false;
    public float Velocidade;
    [HideInInspector] public bool viradoDireita = true;
    void Start()
    {
        //anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        


        tocaChao = Physics2D.Linecast(transform.position, posPe.position, 1 << LayerMask.NameToLayer("chao"));
		if (Input.GetKeyDown("space") && tocaChao)
		{
			jump = true;
		}


        if (jump)
		{
			//anim.SetTrigger("pula");
			rb2d.AddForce(new Vector2(0f, ForcaPulo));
			jump = false;
		}
    }

    void FixedUpdate()
    {
        float translationY = 0;
		float translationX = Input.GetAxis("Horizontal") * Velocidade;
		transform.Translate(translationX, translationY, 0);
		transform.Rotate(0, 0, 0);

        if (translationX > 0 && !viradoDireita)
        {
            Flip();
        }
        else if (translationX < 0 && viradoDireita)
        {
            Flip();
        }
    }

    void Flip()
	{
		viradoDireita = !viradoDireita;
		Vector3 escala = transform.localScale;
		escala.x *= -1;
		transform.localScale = escala;
	}
}
