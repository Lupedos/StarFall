using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasScript : MonoBehaviour
{
    public static CanvasScript instance;
    [SerializeField] TextMeshProUGUI textosTempo;
    [SerializeField] public float segundos = 0;
    [SerializeField] public int minutos = 0;

    [SerializeField] TextMeshProUGUI textosPontuacao;
    
    
    public int pontos;
    public List<ObjetoCaindo> estrelas = new List<ObjetoCaindo>();
    public List<ObjetoCaindo> moedas = new List<ObjetoCaindo>();

    ObjetoCaindo ultimoE;
    ObjetoCaindo ultimoC;

    //public List<GameObject> estrelasObject = new List<GameObject>();
    //public List<GameObject> moedasObject = new List<GameObject>();
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        GameObject encontrar = GameObject.Find("Time");
        textosTempo = encontrar.GetComponent<TextMeshProUGUI>();

    }

    
    void Update()
    {
        GameObject encontrar = GameObject.Find("Time");
        textosTempo = encontrar.GetComponent<TextMeshProUGUI>();

        
        
      textosPontuacao.text = "Pontuação:" + pontos.ToString();
      
      
    }
    void FixedUpdate()
    {
        segundos += Time.deltaTime;
        if(segundos >= 60)
      {
        minutos++;
        segundos = 00 + 1;
      }
      textosTempo.text =    "Tempo:" + minutos.ToString("00")+ ":" + segundos.ToString("00");
    }

   public void atualizarEstrela()
   {
    GameObject[] estrelasObject = GameObject.FindGameObjectsWithTag("Estrela");
    //ObjetoCaindo ultimo;
      foreach (GameObject star in estrelasObject)
      {
        ObjetoCaindo objetoCaindo = star.GetComponent<ObjetoCaindo>();
        int j = 0;
        for(int i = 0; i < estrelas.Count ; i++)
        {
          if(estrelas[i] == objetoCaindo && objetoCaindo != null)
          {
            j = -20;
          }
          else
          {
            j++;
          }

          if(j == estrelas.Count)
          {
            estrelas.Add(objetoCaindo);
          }
        }
        
  
      }
   }
   public void atualizarCoin()
   {

    GameObject[] moedasObject = GameObject.FindGameObjectsWithTag("coin");

    foreach (GameObject coin in moedasObject)
      {
        ObjetoCaindo objetoCaindo = coin.GetComponent<ObjetoCaindo>();
        int j = 0;
        for(int i = 0; i < moedas.Count; i++)
        {
          if(moedas[i] == objetoCaindo && objetoCaindo != null)
          {
            j = -20;
          }
          else
          {
            j++;
          }

          if(j == moedas.Count)
          {
            moedas.Add(objetoCaindo);
          }
        }
      }
   }

}
