using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorImagenFondo : MonoBehaviour
{
    public SpriteRenderer[] spritesFondos;

    public Sprite[] imagenesPosibles;

    public int imagenElegida = 0;

    // Update is called once per frame
    void Update()
    {
        foreach (SpriteRenderer unRenderer in spritesFondos) {
            unRenderer.sprite = imagenesPosibles[imagenElegida];
        }
    }
}
