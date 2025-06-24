using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance
    public GameObject[] items; // Array de ítems
    public int itemsALanzar = 3;

    // para generar las combinadas
    public bool generarCombinada = false;
    public Vector3 generarPosicion;
    public GameObject generarItem;


    void Awake()
    {
        // Configurar el singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    


}