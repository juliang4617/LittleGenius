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
    public float velocidadCaminando = 5f;
    public float velocidadCorriendo = 15f;
    public float velocidadVertical = 10f;
    public float velocidadVolando = 15f;
    public float sensibilidadAlGirar = 700f;

    // OBJETOS EXTERNOS
    public Camera camara;

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
        float x = (Input.GetAxis("Horizontal") != 0) ? Input.GetAxis("Horizontal") : Input.GetAxis("Joystick Left X");
        float z = (Input.GetAxis("Vertical") != 0) ? Input.GetAxis("Vertical") : Input.GetAxis("Joystick Left Y");
        movimientoHorizontal = transform.right * x + transform.forward * z;
        characterController.Move(movimientoHorizontal * velocidadCaminando * Time.deltaTime);

    }

    internal void Correr()
    {
        animator.SetInteger("Accion", 2);
        float x = (Input.GetAxis("Horizontal") != 0) ? Input.GetAxis("Horizontal") : Input.GetAxis("Joystick Left X");
        float z = (Input.GetAxis("Vertical") != 0) ? Input.GetAxis("Vertical") : Input.GetAxis("Joystick Left Y");
        movimientoHorizontal = transform.right * x + transform.forward * z;
        characterController.Move(movimientoHorizontal * velocidadCorriendo * Time.deltaTime);
    }

    internal void Flotar()
    {
        animator.SetInteger("Accion", 3);

        if (camara.transform.localPosition.z < -1.56f)
        {
            camara.transform.localPosition = new Vector3(camara.transform.localPosition.x, camara.transform.localPosition.y, camara.transform.localPosition.z + Time.deltaTime);
        }
        else
        {
            camara.transform.localPosition = new Vector3(camara.transform.localPosition.x, camara.transform.localPosition.y, -1.56f);
        }
    }

    internal void Subir()
    {
        animator.SetInteger("Accion", 3);
        transform.Translate(0, velocidadVertical * Time.deltaTime, 0);
    }

    internal void Bajar()
    {
        animator.SetInteger("Accion", 3);
        transform.Translate(0, -velocidadVertical * Time.deltaTime, 0);
    }

    internal void Volar()
    {
        animator.SetInteger("Accion", 4);
        float x = (Input.GetAxis("Horizontal") != 0) ? Input.GetAxis("Horizontal") : Input.GetAxis("Joystick Left X");
        float z = (Input.GetAxis("Vertical") != 0) ? Input.GetAxis("Vertical") : Input.GetAxis("Joystick Left Y");
        movimientoHorizontal = transform.right * x + transform.forward * z;
        characterController.Move(movimientoHorizontal * velocidadVolando * Time.deltaTime);

        if (camara.transform.localPosition.z > -2.56f)
        {
            camara.transform.localPosition = new Vector3(camara.transform.localPosition.x, camara.transform.localPosition.y, camara.transform.localPosition.z - Time.deltaTime);
        }
        else
        {
            camara.transform.localPosition = new Vector3(camara.transform.localPosition.x, camara.transform.localPosition.y, -2.56f);
        }

    }

    internal void Girar()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadAlGirar * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);
    }
}
