using UnityEngine;

public class CheckConditions : MonoBehaviour
{
    public ACCIONESPERSONAJE accionesPersonaje;
    public ACCIONESCAMARA accionesCamara;
    private bool estaCaminando;
    private bool estaCorriendo;

    // Start is called before the first frame update
    void Start()
    {
        accionesPersonaje = ACCIONESPERSONAJE.REPOSAR;
        accionesCamara = ACCIONESCAMARA.REPOSAR;
        estaCaminando = false;
        estaCorriendo = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.B))
        {
            accionesPersonaje = ACCIONESPERSONAJE.SUBIR;
            return;
        }
        
        if (Input.GetKey(KeyCode.V))
        {
            accionesPersonaje = ACCIONESPERSONAJE.BAJAR;
            return;
        }

        if (transform.position.y > 1)
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") > 0)
            {
                accionesPersonaje = ACCIONESPERSONAJE.VOLAR;
            }
            else
            {
                accionesPersonaje = ACCIONESPERSONAJE.FLOTAR;
            }
        }
        else
        {
            estaCaminando = (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) ? true : false;
            estaCorriendo = (Input.GetKey(KeyCode.LeftShift)) ? true : false;

            if (estaCaminando && !estaCorriendo)
            {
                accionesPersonaje = ACCIONESPERSONAJE.CAMINAR;
            }
            else if (estaCorriendo && estaCaminando)
            {
                accionesPersonaje = ACCIONESPERSONAJE.CORRER;
            }
            else
            {
                accionesPersonaje = ACCIONESPERSONAJE.REPOSAR;
            }
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
