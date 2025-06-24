using System.Collections;
using UnityEngine;

public class ManejoColisionesConSiguientePrefab : MonoBehaviour
{
 
    public GameObject siguiente;
    private Vector3 collisionPosition; // Almacena la posición de la colisión

    
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificar si la colisión es con un objeto específico y si no se ha procesado ya la colisión
        if (collision.gameObject.CompareTag(gameObject.tag))
        {
            // Obtener la posición de la colisión
            Vector3 collisionPosition = collision.contacts[0].point;

            // Destruir ambos objetos
            Destroy(collision.gameObject);
            Destroy(gameObject);


            // Establecer la variable de bandera a true para evitar que otros objetos realicen la acción
            GameManager.instance.generarItem = siguiente;
            GameManager.instance.generarPosicion = collisionPosition;
            GameManager.instance.generarCombinada = true;

            
        }
    }

}
