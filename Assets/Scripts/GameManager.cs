using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool perdio = false;

    List<GameObject> obstaculos;

    float timePassed = 0f;
        
    public float speedY = 5f;

    int contador = 1;

    public TMP_Text textoReloj, textoSpeed;

    void Start() 
    {
        obstaculos = new List<GameObject>();

        textoSpeed.text = speedY.ToString();
    }

    void Update()
    {
        if (perdio)
            return;

        timePassed += Time.deltaTime;

        string minutes = Mathf.Floor((timePassed % 3600) / 60).ToString("00");
        string seconds = Mathf.Floor(timePassed % 60).ToString("00");
        string miliseconds = Mathf.Floor(timePassed % 6 * 10 % 10).ToString("0");

        textoReloj.text = minutes + ":" + seconds + ":" + miliseconds;

        float incrementoVelocidad = 1.5f;
        int periodoIncremento = 6;

        if (int.Parse(seconds) == periodoIncremento * contador) 
        {
            contador++;

            speedY += incrementoVelocidad;
            textoSpeed.text = speedY.ToString();

            // Aumento la velocidad del fondo
            GameObject.Find("Fondo").GetComponent<MovimientoVertical>().fijarVelocidadA(speedY);

            GameObject.Find("ObjectSpawner").GetComponent<ObjectSpawner>().fijarVelocidadA(speedY);

            // Aumento la velocidad de todos los obstaculos
            foreach (GameObject unObstaculo in obstaculos)
            {
                unObstaculo.GetComponent<MovimientoVertical>().fijarVelocidadA(speedY);
            }
        }
    }

    public void agregarObstaculo(GameObject unObstaculo) { obstaculos.Add(unObstaculo); }

    public void quitarObstaculo(GameObject unObstaculo) { obstaculos.Remove(unObstaculo); }

    public void perderJuego() 
    {
        perdio = true;

        // Decirle al fondo que perdiste
        GameObject.Find("Fondo").GetComponent<MovimientoVertical>().perderJuego();

        // Decirle al object spawner q perdiste
        GameObject.Find("ObjectSpawner").GetComponent<ObjectSpawner>().perderJuego();

        // Recorro todos los obstaculos para decirles q perdi
        foreach (GameObject unObstaculo in obstaculos)
        {
            unObstaculo.GetComponent<MovimientoVertical>().perderJuego();
            unObstaculo.GetComponent<MovimientoHorizontalObstaculo>().perderJuego();

            RotacionObstaculo rotacion;

            if (( rotacion = unObstaculo.GetComponent<RotacionObstaculo>() ) != null) 
                rotacion.perderJuego();
            
            TamañoObstaculo tamaño;

            if ((tamaño = unObstaculo.GetComponent<TamañoObstaculo>()) != null)
                tamaño.perderJuego();
            
        }
    }

    public void recargarJuego() 
    {
        // Recargar la escena
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
