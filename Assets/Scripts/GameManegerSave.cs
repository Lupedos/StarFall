using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting;

public class GameManegerSave : MonoBehaviour
{
    //public Estrela estrelaGameObject;
    //public Moeda moedaGameObject;
    public MovimentacaoScript player;
    public ObjetoCaindo moedaObject;
    public ObjetoCaindo estrelaObject;
    void Start()
    {
        player = FindObjectOfType<MovimentacaoScript>();
    }

    
    void Update()
    {
        player = FindObjectOfType<MovimentacaoScript>();
    }
     public void SaveButton()
    {
        Savexml();
        //SaveJson();
    }

    public void LoadButton()
    {
        Loadxml();
        //LoadJson();
        PontuacaoScript.pause = false; 
    }
    private SaveXML CreateSaveGameObject()
    {
        
        SaveXML save = new SaveXML();

        save.moedaNum = CanvasScript.instance.pontos;
        save.segundosNum = CanvasScript.instance.segundos;
        save.minutosNum = CanvasScript.instance.minutos;

        save.playerPositionX = player.transform.position.x;
        save.playerPositionY = player.transform.position.y;

        foreach(ObjetoCaindo estrela in CanvasScript.instance.estrelas)
        {
            if(estrela != null)
            {
            save.estrelaPositionX.Add(estrela.objetoPositionX);
            save.estrelaPositionY.Add(estrela.objetoPositionY);
            }
        }

        foreach(ObjetoCaindo Moeda in CanvasScript.instance.moedas)
        {
            if(Moeda != null)
            {
                save.moedaPositionX.Add(Moeda.objetoPositionX);
                save.moedaPositionY.Add(Moeda.objetoPositionY);
            }
            
        }

        return save;
    }
   public void Savexml()
   {
    SaveXML save = CreateSaveGameObject();
    XmlDocument xmlDOcument = new XmlDocument();

    #region CreateXML elements

    XmlElement root = xmlDOcument.CreateElement("Save");
    root.SetAttribute("FileName","File_01");

    XmlElement moedaNumElement = xmlDOcument.CreateElement("MoedaNum");
    moedaNumElement.InnerText = save.moedaNum.ToString();
    root.AppendChild(moedaNumElement);

    XmlElement segundosNumElement = xmlDOcument.CreateElement("SegundosNum");
    segundosNumElement.InnerText = save.segundosNum.ToString();
    root.AppendChild(segundosNumElement);

    XmlElement minutosNumElement = xmlDOcument.CreateElement("MinutosNum");
    minutosNumElement.InnerText = save.minutosNum.ToString();
    root.AppendChild(minutosNumElement);

    XmlElement playerPosXElement = xmlDOcument.CreateElement("PlayerPositionX");
    playerPosXElement.InnerText = save.playerPositionX.ToString();
    root.AppendChild(playerPosXElement);

    XmlElement playerPosYElement = xmlDOcument.CreateElement("PlayerPositionY");
    playerPosYElement.InnerText = save.playerPositionY.ToString();
    root.AppendChild(playerPosYElement);
    
    XmlElement estrela,objetoPositionX,objetoPositionY;

    for(int i = 0; i < save.estrelaPositionX.Count; i++)
    {
        estrela = xmlDOcument.CreateElement("estrela");
        objetoPositionX = xmlDOcument.CreateElement("EstrelaPositionX");
        objetoPositionY = xmlDOcument.CreateElement("EstrelaPositionY");

        objetoPositionX.InnerText = save.estrelaPositionX[i].ToString();
        objetoPositionY.InnerText = save.estrelaPositionY[i].ToString();

        estrela.AppendChild(objetoPositionX);
        estrela.AppendChild(objetoPositionY);

        root.AppendChild(estrela);

    }

    XmlElement Moeda,moedaPositionX,moedaPositionY;
    for(int i = 0; i < save.moedaPositionX.Count; i++)
    {
        Moeda = xmlDOcument.CreateElement("Moeda");
        moedaPositionX = xmlDOcument.CreateElement("MoedaPositionX");
        moedaPositionY = xmlDOcument.CreateElement("MoedaPositionY");

        moedaPositionX.InnerText = save.moedaPositionX[i].ToString();
        moedaPositionY.InnerText = save.moedaPositionY[i].ToString();

        Moeda.AppendChild(moedaPositionX);
        Moeda.AppendChild(moedaPositionY);

        root.AppendChild(Moeda);

    }


    #endregion
    xmlDOcument.AppendChild(root);

    xmlDOcument.Save(Application.dataPath + "/DataXML.text");
    if(File.Exists(Application.dataPath + "/DataXML.text"))
    {
        Debug.Log("Xml FILE SAVED");
    }
   }
   public void Loadxml()
   {
    if(File.Exists(Application.dataPath + "/DataXML.text"))
    {
    
    
    SaveXML save = new SaveXML();

    XmlDocument xmlDocument = new XmlDocument();
    xmlDocument.Load(Application.dataPath + "/DataXML.text");

    XmlNodeList moedaNum = xmlDocument.GetElementsByTagName("MoedaNum");
    int moedaNumCount = int.Parse(moedaNum[0].InnerText);
    save.moedaNum = moedaNumCount;

    XmlNodeList segundosNum = xmlDocument.GetElementsByTagName("SegundosNum");
    float segundosNumCount = float.Parse(segundosNum[0].InnerText);
    save.segundosNum = segundosNumCount; 

    XmlNodeList minutosNum = xmlDocument.GetElementsByTagName("MinutosNum");
    int minutosNumCount = int.Parse(minutosNum[0].InnerText);
    save.minutosNum = minutosNumCount;

    XmlNodeList playerPositionX = xmlDocument.GetElementsByTagName("PlayerPositionX");
    float playerPositionXCount = float.Parse(playerPositionX[0].InnerText);
    save.playerPositionX = playerPositionXCount;

    XmlNodeList playerPositionY = xmlDocument.GetElementsByTagName("PlayerPositionY");
    float playerPositionYNumCount = float.Parse(playerPositionY[0].InnerText);
    save.playerPositionY = playerPositionYNumCount;

    XmlNodeList estrelas = xmlDocument.GetElementsByTagName("estrela");
    if(estrelas.Count != 0)
    {
        for(int i = 0; i < estrelas.Count; i++)
        {
            XmlNodeList estrelaPosX = xmlDocument.GetElementsByTagName("EstrelaPositionX");
            float objetoPositionX = float.Parse(estrelaPosX[i].InnerText);
            save.estrelaPositionX.Add(objetoPositionX);

            XmlNodeList estrelaPosY = xmlDocument.GetElementsByTagName("EstrelaPositionY");
            float objetoPositionY = float.Parse(estrelaPosY[i].InnerText);
            save.estrelaPositionY.Add(objetoPositionY);

        }
    }

    XmlNodeList moedas = xmlDocument.GetElementsByTagName("Moeda");
    if(moedas.Count != 0)
    {
        for(int i = 0; i < moedas.Count; i++)
        {
            XmlNodeList moedaPosX = xmlDocument.GetElementsByTagName("MoedaPositionX");
            float objetoPositionX = float.Parse(moedaPosX[i].InnerText);
            save.moedaPositionX.Add(objetoPositionX);

            XmlNodeList moedaPosY = xmlDocument.GetElementsByTagName("MoedaPositionY");
            float objetoPositionY = float.Parse(moedaPosY[i].InnerText);
            save.moedaPositionY.Add(objetoPositionY);

        }
    }



    //Passa Tudo que estava no Save para JOGO
    CanvasScript.instance.pontos = save.moedaNum;
    CanvasScript.instance.segundos = save.segundosNum;
    CanvasScript.instance.minutos = save.minutosNum;

    player.transform.position = new Vector2(save.playerPositionX,save.playerPositionY);

    save.playerPositionX = player.transform.position.x;
    save.playerPositionY = player.transform.position.y;
   
    //Destruir todas as Estrelas do cenario antes de instanciar
    for(int i = 0; i <CanvasScript.instance.estrelas.Count; i++)
    {
        if(CanvasScript.instance.estrelas[i] != null)
        {
        Destroy(CanvasScript.instance.estrelas[i].gameObject);
        //Debug.Log(CanvasScript.instance.estrelas.Count);
        }
        //Debug.Log("foi");
        
    } 

    for(int i = 0; i <CanvasScript.instance.moedas.Count; i++)
    {
        if(CanvasScript.instance.moedas[i] != null)
        {
        Destroy(CanvasScript.instance.moedas[i].gameObject);
        //Debug.Log(CanvasScript.instance.moedas.Count);
        }
        //Debug.Log("foi");
        
    }
    
    //Instancia todas as Estrelas que foram salvas 
    for(int i = 0; i <estrelas.Count; i++)
    {
        float starPosX = save.estrelaPositionX[i];
        float starPosY = save.estrelaPositionY[i];
        ObjetoCaindo newEstrela = Instantiate(estrelaObject,new Vector2(starPosX,starPosY),Quaternion.identity);
        if (i >= CanvasScript.instance.estrelas.Count)
        {
            CanvasScript.instance.estrelas.Add(newEstrela);
        }
        else
        {
            CanvasScript.instance.estrelas[i] = newEstrela;
        }

    }

     for(int i = 0; i <moedas.Count; i++)
    {
        float coinPosX = save.moedaPositionX[i];
        float coinPosY = save.moedaPositionY[i];
        ObjetoCaindo newMoeda = Instantiate(moedaObject,new Vector2(coinPosX,coinPosY),Quaternion.identity);
        if (i >= CanvasScript.instance.moedas.Count)
        {
            CanvasScript.instance.moedas.Add(newMoeda);
        }
        else
        {
            CanvasScript.instance.moedas[i] = newMoeda;
        }

    }



    }
    else
    {
        Debug.Log("Not FOUNDED FILE XML");
    }
    
   }

   public void SaveJson()
   {
        SaveXML save = CreateSaveGameObject();

        string JsonString = JsonUtility.ToJson(save);

        StreamWriter sw = new StreamWriter(Application.dataPath + "/JSONData.text");
        sw.Write(JsonString);

        sw.Close();

        Debug.Log("-=-=-=-SAVED-JSON-=-=-=-");
   }

   public void LoadJson()
   {
        if(File.Exists(Application.dataPath + "/JSONData.text"))
        {
            StreamReader sr = new StreamReader(Application.dataPath + "/JSONData.text");

            string JsonString = sr.ReadToEnd();
            sr.Close();

            SaveXML save = JsonUtility.FromJson<SaveXML>(JsonString);

            Debug.Log("-=-=-=-LOADED-JSON-=-=-=-=-");

            CanvasScript.instance.pontos = save.moedaNum;
            CanvasScript.instance.segundos = save.segundosNum;
            CanvasScript.instance.minutos = save.minutosNum;

            player.transform.position = new Vector2(save.playerPositionX,save.playerPositionY);

            save.playerPositionX = player.transform.position.x;
            save.playerPositionY = player.transform.position.y;
        
            //Destruir todas as Estrelas do cenario antes de instanciar
            for(int i = 0; i <CanvasScript.instance.estrelas.Count; i++)
            {
                if(CanvasScript.instance.estrelas[i] != null)
                {
                    Destroy(CanvasScript.instance.estrelas[i].gameObject);
                //Debug.Log(CanvasScript.instance.estrelas.Count);
                }
                //Debug.Log("foi");
                
            } 

            for(int i = 0; i <CanvasScript.instance.moedas.Count; i++)
            {
                if(CanvasScript.instance.moedas[i] != null)
                {
                    Destroy(CanvasScript.instance.moedas[i].gameObject);
                //Debug.Log(CanvasScript.instance.moedas.Count);
                }
                //Debug.Log("foi");
                
            }
            
            //Instancia todas as Estrelas que foram salvas 
            for(int i = 0; i <save.estrelaPositionX.Count; i++)
            {
                float starPosX = save.estrelaPositionX[i];
                float starPosY = save.estrelaPositionY[i];
                ObjetoCaindo newEstrela = Instantiate(estrelaObject, new Vector2(starPosX, starPosY), Quaternion.identity);
                if (i >= CanvasScript.instance.estrelas.Count)
                {
                    CanvasScript.instance.estrelas.Add(newEstrela);
                }
                else
                {
                    CanvasScript.instance.estrelas[i] = newEstrela;
                }
                    

            }

            for(int i = 0; i <save.moedaPositionX.Count; i++)
            {
                float coinPosX = save.moedaPositionX[i];
                float coinPosY = save.moedaPositionY[i];
                ObjetoCaindo newMoeda = Instantiate(moedaObject, new Vector2(coinPosX, coinPosY), Quaternion.identity);
                if (i >= CanvasScript.instance.moedas.Count)
                {
                    CanvasScript.instance.moedas.Add(newMoeda);
                }
                else
                {
                    CanvasScript.instance.moedas[i] = newMoeda;
                }
                    

            }
            
        }
            else
        {
            Debug.Log("Not FOUNDED FILE JSON");
        }
        
   }
}

