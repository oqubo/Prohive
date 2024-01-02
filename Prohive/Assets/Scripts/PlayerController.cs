using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Transform limiteIzquierdo;
    public Transform limiteDerecho;
    public float margen = 0.1f;


    public GameObject objetoPrefab; // Prefab del objeto a lanzar
    public Transform puntoLanzamiento; // Punto de lanzamiento del objeto

    private GameObject objetoAsociado; // Objeto asociado al jugador





    // Start is called before the first frame update
    void Start()
    {
        GenerarItemALanzar();
    }

    // Update is called once per frame
    void Update()
    {

        // Obtener la posición del ratón en coordenadas de pantalla
        Vector3 posicionRaton = Input.mousePosition;

        // Convertir la posición del ratón a coordenadas del mundo
        Vector3 posicionEnElMundo = Camera.main.ScreenToWorldPoint(posicionRaton);

        // Limitar la posición en el eje X entre los dos límites
        float xPos = Mathf.Clamp(posicionEnElMundo.x, limiteIzquierdo.position.x + margen, limiteDerecho.position.x - margen);

        // Ajustar la posición del objeto para que siga al ratón, pero dentro de los límites
        transform.position = new Vector3(xPos, transform.position.y, 0f);



        if (Input.GetMouseButtonDown(0))
        {
            LanzarObjeto();
        }


        if (GameManager.instance.generarCombinada)
        {
            GameManager.instance.generarCombinada = false;
            Instantiate(GameManager.instance.generarItem, GameManager.instance.generarPosicion, Quaternion.identity);
        }


    }

    void GenerarItemALanzar()
    {
        // Seleccionar un índice aleatorio del array
        int indiceAleatorio = Random.Range(0, GameManager.instance.itemsALanzar);

        // Instanciar el objeto asociado al jugador y establecerlo como hijo del jugador
        objetoAsociado = Instantiate(GameManager.instance.items[indiceAleatorio], this.transform.position, Quaternion.identity, transform);
        // Desactivar la simulación de física para que no se lance automáticamente
        objetoAsociado.GetComponent<Rigidbody2D>().simulated = false;
    }


    void LanzarObjeto()
    {
        // Desactivar la relación de padre-hijo para que el objeto pueda moverse libremente
        objetoAsociado.transform.parent = null;

        // Lanzar el objeto
        objetoAsociado.GetComponent<Rigidbody2D>().simulated = true;

        GenerarItemALanzar();

    }





}





