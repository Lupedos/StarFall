using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PontuacaoScript : MonoBehaviour
{
    public CanvasScript _CanvasScript;
    public GameObject painelMorte;
    public static bool pause = true ;

    void Awake()
    {
        painelMorte = GameObject.Find("Panel");
        
    }
    void Start()
    {
       pause = false;
       GameObject cn = GameObject.Find("Canvas");
       _CanvasScript = cn.GetComponent<CanvasScript>();
       painelMorte = GameObject.Find("Panel");
       _CanvasScript.pontos = 0;
       _CanvasScript.segundos = 0;
       _CanvasScript.minutos = 0;


    }

    
    void Update()
    {
        //Debug.Log(GameObject.Find("Panel"));

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
            
        }
        if(pause == true)
        {
            Time.timeScale = 0;
            painelMorte.gameObject.SetActive(true);
        }
        else if(pause == false)
        {
            Time.timeScale = 1;
            
            painelMorte.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("coin"))
		{
         _CanvasScript.pontos = _CanvasScript.pontos + 50;
         Destroy(other.gameObject);   
			
		}

        if (other.gameObject.CompareTag("Estrela"))
		{
            painelMorte.gameObject.SetActive(true);
            SceneManager.LoadScene(0); 
		}

	}
}
