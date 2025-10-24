using UnityEngine;

public class Seguir : MonoBehaviour
{
    public Transform jogador;
    public Vector3 distancia;

    void Update()
    {
        transform.position = jogador.position+distancia;
    }
}