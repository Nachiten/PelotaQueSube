using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AplicarColorObjetoCompuesto : MonoBehaviour, IAplicarColor
{
    public void aplicarColor(Color unColor) 
    {
        Transform[] hijosMios = gameObject.GetComponentsInChildren<Transform>();

        //Debug.Log("Cantidad de hijos de: " + gameObject.name + ". Hijos: " + hijosMios.Length);

        foreach (Transform unTransfromHijo in hijosMios)
        {
            SpriteRenderer unRenderer = unTransfromHijo.gameObject.GetComponent<SpriteRenderer>();

            if (unRenderer != null)
                unRenderer.color = unColor;
        }

        Debug.Log("Aplicando color a objeto compuesto: " + gameObject.name);
    }
}
