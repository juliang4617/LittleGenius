using System;
using UnityEngine;

public class Mechanics : MonoBehaviour
{
    // COMPONENTES
    public Animator animator;
    public CharacterController characterController;

    // VARIABLES PRIVADAS
    private Vector3 movimientoHorizontal;

    // VARIABLES DE CONFIGURACION
    public float velocidadCaminando = 7f;
    public float velocidadCorriendo = 17f;
    public float velocidadVertical = 5f;
    public float velocidadVolando = 15f;
    public float sensibilidadAlGirar = 700f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    internal void Reposar()
    {
        animator.SetInteger("Accion", 0);
    }

    internal void Caminar()
    {
        animator.SetInteger("Accion", 1);
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        movimientoHorizontal = transform.right * x + transform.forward * z;
        characterController.Move(movimientoHorizontal * velocidadCaminando * Time.deltaTime);

    }

    internal void Correr()
    {
        animator.SetInteger("Accion", 2);
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        movimientoHorizontal = transform.right * x + transform.forward * z;
        characterController.Move(movimientoHorizontal * velocidadCorriendo * Time.deltaTime);
    }

    internal void Flotar()
    {
        animator.SetInteger("Accion", 3);
    }

    internal void Subir()
    {
        animator.SetInteger("Accion", 3);
        transform.Translate(0, velocidadVertical * Time.deltaTime, 0);
    }

    internal void Bajar()
    {
        if (transform.position.y > 1)
        {
            animator.SetInteger("Accion", 3);
            transform.Translate(0, -velocidadVertical * Time.deltaTime, 0);
        }

        if (transform.position.y < 1)
        {
            animator.SetInteger("Accion", 0);
            transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        }
    }

    internal void Volar()
    {
        animator.SetInteger("Accion", 4);
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        movimientoHorizontal = transform.right * x + transform.forward * z;
        characterController.Move(movimientoHorizontal * velocidadVolando * Time.deltaTime);
    }

    internal void Girar()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadAlGirar * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);
    }
}
