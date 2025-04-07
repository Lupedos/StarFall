using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveXML
{
    public int moedaNum;
    public float segundosNum;
    public int minutosNum;

    public float playerPositionX;
    public float playerPositionY;

    public List<float> estrelaPositionX = new List<float>();
    public List<float> estrelaPositionY = new List<float>();

    public List<float> moedaPositionX = new List<float>();
    public List<float> moedaPositionY = new List<float>();

}
