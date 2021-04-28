using UnityEngine;
using System.Collections.Generic;

public class ObjectSpawner : MonoBehaviour
{
    public bool started = false;

    public GameObject[] obstaculosPrefabs;
    public Color[] coloresPosibles;

    List<GameObject> obstaculosSpawneados;
    List<GameObject> obstaculosOcultos;

    /* 
     * 1 - Todos los obstaculosPrefabs se instancian en obstaculosOcultos.
     * 2 - Al spawnear un objeto se quita de obstaculosOcultos (en pos random) y se agrega en obstaculosSpawneados.
     * 3 - Al quitar un objeto se quita de obstaculosSpawneados y se pone en obstaculosOcultos.
     */

    float limiteMinimo = -10f, sumaAlResetear = 20f;

    float speedY = 5f;
    bool perdio = false;

    int copiasPrefabs = 3;

    private readonly object lockListas = new object();

    void Start()
    {
        GameObject obstaculoParent = GameObject.Find("Obstaculos");

        obstaculosSpawneados = new List<GameObject>();
        obstaculosOcultos = new List<GameObject>();

        speedY = GameObject.Find("GameManager").GetComponent<GameManager>().speedY;

        foreach (GameObject unObjeto in obstaculosPrefabs)
        {
            for (int i = 0; i < copiasPrefabs; i++)
            {
                GameObject obstaculoInstancia = Instantiate(unObjeto, new Vector3(0, 10, 0), Quaternion.identity);

                obstaculoInstancia.SetActive(false);
                obstaculoInstancia.GetComponent<MovimientoVertical>().fijarVelocidadA(speedY);
                obstaculoInstancia.transform.parent = obstaculoParent.transform;

                int indexColorRandom = Random.Range(0, coloresPosibles.Length);
                string nombrePrefab = obstaculoInstancia.name.Substring(0, obstaculoInstancia.name.Length - 7);

                obstaculoInstancia.GetComponent<IAplicarColor>().aplicarColor(coloresPosibles[indexColorRandom]);

                obstaculoInstancia.name = nombrePrefab + " " +  i;

                obstaculosOcultos.Add(obstaculoInstancia);
            }
        }
        this.GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    void Update()
    {
        if (perdio || !started)
            return;

        Vector2 posicionActual = transform.position;

        // Resetear posicion al pasar cierto limite
        if (posicionActual.y <= limiteMinimo)
        {        
            transform.position = new Vector2(posicionActual.x, posicionActual.y + sumaAlResetear);

            instanciarObstaculo();
        }

        // Configurar Velocidad
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speedY);
    }

    public void perderJuego()
    {
        perdio = true;

        // Elimino gravedad para parar de que siga cayendo
        this.GetComponent<Rigidbody2D>().gravityScale = 0;
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        // Recorro todos los obstaculos para decirles q perdi
        foreach (GameObject unObstaculo in obstaculosSpawneados)
        {
            unObstaculo.GetComponent<MovimientoVertical>().perderJuego();
            unObstaculo.GetComponent<MovimientoHorizontalObstaculo>().perderJuego();

            RotacionObstaculo rotacion;

            if ((rotacion = unObstaculo.GetComponent<RotacionObstaculo>()) != null)
                rotacion.perderJuego();

            TamañoObstaculo tamaño;

            if ((tamaño = unObstaculo.GetComponent<TamañoObstaculo>()) != null)
                tamaño.perderJuego();

        }
    }

    public void fijarVelocidadA(float velocidad)
    {
        speedY = velocidad;

        lock (lockListas)
        {
            // Aumento la velocidad de todos los obstaculos
            foreach (GameObject unObstaculo in obstaculosSpawneados)
            {
                unObstaculo.GetComponent<MovimientoVertical>().fijarVelocidadA(speedY);
            }
        }
    }

    void instanciarObstaculo() 
    {
        lock (lockListas) 
        {
            //Debug.Log("[Object Spawner] Intentando instanciar objeto...");

            if (obstaculosOcultos.Count == 0)
            {
                Debug.LogError("[Object Spawner] No pude instanciar ningun objeto");
                return;
            }

            int indexRandom = Random.Range(0, obstaculosOcultos.Count);

            // Recupero objeto
            GameObject objetoInstanciado = obstaculosOcultos[indexRandom];

            //Debug.Log("[Object Spawner] Objeto instanciado: " + gameObject.name + " | ID: " + gameObject.GetInstanceID());

            objetoInstanciado.SetActive(true);

            // Quito de lista ocultos
            obstaculosOcultos.Remove(objetoInstanciado);
            // Agrego a lista mostrados
            obstaculosSpawneados.Add(objetoInstanciado);

            // Logs para testear las listas
            //Debug.Log("ObstaculosPrefabs Size: " + obstaculosPrefabs.Length);
            //Debug.Log("obstaculosSpawneados Size: " + obstaculosSpawneados.Count);
            //Debug.Log("obstaculosOcultos Size: " + obstaculosOcultos.Count);
        }
    }

    public void ocultarObstaculo(GameObject unObstaculo) 
    {
        lock (lockListas)
        {
            unObstaculo.SetActive(false);

            // Quito de lista spawneados
            obstaculosSpawneados.Remove(unObstaculo);
            // Agrego a lista ocultos
            obstaculosOcultos.Add(unObstaculo);
        }   
    }

    public Color obtenerColorRandom() {
        int numeroRandom = Random.Range(0, coloresPosibles.Length);

        return coloresPosibles[numeroRandom];
    }
}
