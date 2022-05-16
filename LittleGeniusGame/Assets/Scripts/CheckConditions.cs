using UnityEngine;

public class CheckConditions : MonoBehaviour
{
    public ACCIONESPERSONAJE accionesPersonajeEnTierra;
    public ACCIONESPERSONAJE accionesPersonajeEnEspacio;
    public ACCIONESCAMARA accionesCamara;
    private bool estaCaminando;
    private bool estaCorriendo;

    // Start is called before the first frame update
    void Start()
    {
        accionesPersonajeEnEspacio = ACCIONESPERSONAJE.FLOTAR;
        accionesCamara = ACCIONESCAMARA.REPOSAR;
        estaCaminando = false;
        estaCorriendo = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) || (Input.GetAxis("Joystick Left X") != 0 || Input.GetAxis("Joystick Left Y") != 0))
        {
            accionesPersonajeEnEspacio = ACCIONESPERSONAJE.VOLAR;
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            accionesPersonajeEnEspacio = ACCIONESPERSONAJE.SUBIR;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            accionesPersonajeEnEspacio = ACCIONESPERSONAJE.BAJAR;
        }
        else
        {
            accionesPersonajeEnEspacio = ACCIONESPERSONAJE.FLOTAR;
        }

        if (Input.GetAxis("Mouse X") != 0)
        {
            accionesCamara = ACCIONESCAMARA.GIRAR;
        }
        else
        {
            accionesCamara = ACCIONESCAMARA.REPOSAR;
        }
    }
}
