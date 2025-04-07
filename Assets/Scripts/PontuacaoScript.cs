using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

public class PontuacaoScript : MonoBehaviour
{
    public CanvasScript _CanvasScript;
    public GameObject painelMorte;
    public static bool pause = true;
    [SerializeField] Animator anim;
    public float timer;
    public bool invencivel;

    void Awake()
    {
        painelMorte = GameObject.Find("Panel");
        anim = GetComponent<Animator>();
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
    private void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if (timer > 0)
        {
            invencivel = true;
            this.anim.SetBool("PowerUP", true);
        }
        else
        {
            this.anim.SetBool("PowerUP", false);
            invencivel = false;
        }
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

        if (other.gameObject.CompareTag("Estrela") && invencivel == false)
        {
            painelMorte.gameObject.SetActive(true);
            SceneManager.LoadScene(0);
        }
        else if (other.gameObject.CompareTag("Estrela") && invencivel == true)
        {
            _CanvasScript.pontos = _CanvasScript.pontos + 25;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Power"))
        {
            timer = 10;
            Destroy(other.gameObject);
        }

    }
}
