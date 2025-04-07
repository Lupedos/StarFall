using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotaoSandL : MonoBehaviour
{
    public Button save;
    public Button load;
    public GameManegerSave gms;

    void Start()
    {
        GameObject g = GameObject.Find("Canvas");
        gms = g.GetComponent<GameManegerSave>();
        save.onClick.AddListener(gms.SaveButton);
        load.onClick.AddListener(gms.LoadButton);
    }

    void Update()
    {
        
    }
}
