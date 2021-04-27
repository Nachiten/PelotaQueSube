using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AplicarColorObjetoSimple : MonoBehaviour, IAplicarColor
{
    public void aplicarColor(Color unColor)
    {
        gameObject.GetComponent<SpriteRenderer>().color = unColor;

        //Debug.Log("Aplicando color a objeto simple: " + gameObject.name);
    }

    public void aplicarColorRandom()
    {
        Color colorRandom = GameObject.Find("ObjectSpawner").GetComponent<ObjectSpawner>().obtenerColorRandom();

        aplicarColor(colorRandom);
    }
}
