using UnityEngine;

public class MovimientoPJ : MonoBehaviour
{
    public float velocidad = 3f;

    private Rigidbody2D rb;
    private Animator ani;
    private Vector2 direccion;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        float movimientoX = Input.GetAxisRaw("Horizontal");
        float movimientoY = Input.GetAxisRaw("Vertical");

        direccion = new Vector2(movimientoX, movimientoY).normalized;

        ani.SetFloat("Horizontal", direccion.x);
        ani.SetFloat("Vertical", direccion.y);
    }

    void FixedUpdate()
    {
        // Mover al personaje físicamente
        rb.MovePosition(rb.position + direccion * velocidad * Time.fixedDeltaTime);
    }
}
