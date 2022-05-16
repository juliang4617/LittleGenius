using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public CheckConditions checkConditions;
    public Mechanics mechanics;

    // Start is called before the first frame update
    void Start()
    {
        checkConditions = GetComponent<CheckConditions>();
        mechanics = GetComponent<Mechanics>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (checkConditions.accionesPersonajeEnEspacio)
        {
            case ACCIONESPERSONAJE.REPOSAR:
                mechanics.Reposar();
                break;
            case ACCIONESPERSONAJE.CAMINAR:
                mechanics.Caminar();
                break;
            case ACCIONESPERSONAJE.CORRER:
                mechanics.Correr();
                break;
            case ACCIONESPERSONAJE.FLOTAR:
                mechanics.Flotar();
                break;
            case ACCIONESPERSONAJE.SUBIR:
                mechanics.Subir();
                break;
            case ACCIONESPERSONAJE.BAJAR:
                mechanics.Bajar();
                break;
            case ACCIONESPERSONAJE.VOLAR:
                mechanics.Volar();
                break;
        }

        switch (checkConditions.accionesCamara)
        {
            case ACCIONESCAMARA.REPOSAR:
                break;
            case ACCIONESCAMARA.GIRAR:
                mechanics.Girar();
                break;
        }
    }
}
