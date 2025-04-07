using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawStarScript : MonoBehaviour
{
    public CanvasScript cs;
    public float posicao;
    public GameObject moeda;
    public GameObject estrela;

    public float tempo = 0;
    private int escalonamento = 3;
    private int num = 2;
    private int limit=1;

    
    void Start()
    {
        GameObject g = GameObject.Find("Canvas");
        cs = g.GetComponent<CanvasScript>();
    }

    void FixedUpdate()
    {
       tempo += Time.deltaTime;
       if(tempo >= escalonamento)
       {
        int rand = Random.Range(1,5);
        if(rand >= 3)
        {
            Instantiate(moeda, this.transform.position, this.transform.rotation);
            cs.atualizarCoin();
        }
        else if(rand <= 2)
        {
            Instantiate(estrela, this.transform.position, this.transform.rotation);
            cs.atualizarEstrela();
        }
        posicao = Random.Range(-8f,8f);
        transform.position = new Vector2(posicao,6);
        tempo = 0;
        escalonamento = Random.Range(0,num);
         
       } 

       if(cs.minutos >= limit)
       {
        num--;
        if(num<= 0)
        num = 1;
        limit++;
       }
    }

    void Update()
    {
        
    }
}
