using UnityEngine;

public class Colider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D ob)
    {
        print("Nombre Objeto: " +  ob.collider.name);
        print("Informacion del objeto: ");
        print("Velocidad: "+ ob.relativeVelocity);
    } 
}