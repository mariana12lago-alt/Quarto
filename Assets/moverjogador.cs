using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Instrucoes : MonoBehaviour
{
    [Header("Referências")]
    public Rigidbody jogador;
    public TextMeshProUGUI textoUI; // TextMeshPro que mostra mensagens

    [Header("Velocidades")]
    public float velocidadeFrente = 50f;
    public float velocidadeLado = 25f;

    void Awake()
    {
        if (jogador == null)
            jogador = GetComponent<Rigidbody>();

        // Configura Rigidbody
        jogador.useGravity = false;
        jogador.constraints = RigidbodyConstraints.FreezeRotation;
        jogador.drag = 2f;
        jogador.collisionDetectionMode = CollisionDetectionMode.Continuous;

        // UI inicial
        if (textoUI != null)
            textoUI.text = "Mexa nas setas para que o jogador avance";
    }

    void FixedUpdate()
    {
        Vector3 movimento = Vector3.forward * velocidadeFrente;

        if (Keyboard.current.leftArrowKey.isPressed)
            movimento += Vector3.left * velocidadeLado;
        if (Keyboard.current.rightArrowKey.isPressed)
            movimento += Vector3.right * velocidadeLado;

        jogador.MovePosition(jogador.position + movimento * Time.fixedDeltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        string tagObjeto = collision.gameObject.tag;

        // Atualiza o UI
        if (textoUI != null)
            textoUI.text = "Colidiu com objeto de TAG: " + tagObjeto;

        // Para o jogador
        jogador.velocity = Vector3.zero;
        jogador.angularVelocity = Vector3.zero;
    }
}
