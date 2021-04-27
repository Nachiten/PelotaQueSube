using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AplicarColorObjetoCompuesto : MonoBehaviour, IAplicarColor
{
    public void aplicarColor(Color unColor)
    {
        Transform[] hijosMios = gameObject.GetComponentsInChildren<Transform>();

        foreach (Transform unTransfromHijo in hijosMios)
        {
            SpriteRenderer unRenderer = unTransfromHijo.gameObject.GetComponent<SpriteRenderer>();

            if (unRenderer != null)
                unRenderer.color = unColor;
        }

        //Debug.Log("Aplicando color a objeto compuesto: " + gameObject.name);
    }

    public void aplicarColorRandom() 
    {
        Color colorRandom = GameObject.Find("ObjectSpawner").GetComponent<ObjectSpawner>().obtenerColorRandom();

        aplicarColor(colorRandom);
    }
}
