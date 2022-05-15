using UnityEngine;

public class Train : MonoBehaviour
{
    private bool punto1;
    private bool punto2;
    private bool punto3;
    private bool punto4;
    public float velocidadMovimiento = 7f;
    public float velocidadRotacion = 80f;

    // Start is called before the first frame update
    void Start()
    {
        punto1 = true;
        punto2 = false;
        punto3 = false;
        punto4 = false;
    }

    // Update is called once per frame
    void Update()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;

        if (punto1)
        {
            if (z > 19f)
                transform.Translate(0f, 0f, -velocidadMovimiento * Time.deltaTime);

            if (z < 19f)
                transform.position = new Vector3(x, y, 19f);

            if (transform.rotation.x > -0.7071068f && z == 19f)
                transform.Rotate(-velocidadRotacion * Time.deltaTime, 0f, 0f);

            if (transform.rotation.x < -0.7071068f)
                transform.localRotation = Quaternion.Euler(-90f, 0f, 0f);

            if (z == 19f && transform.rotation.x == -0.7071068f)
            {
                punto1 = false;
                punto2 = true;
            }
        }

        if (punto2)
        {
            if (y > -10f)
                transform.Translate(0f, 0f, -velocidadMovimiento * Time.deltaTime);

            if (y < -10f)
                transform.position = new Vector3(x, -10f, z);

            if (transform.rotation.x > -0.9961947f && y == -10f)
                transform.Rotate(-velocidadRotacion * Time.deltaTime, 0f, 0f);

            if (transform.rotation.x < -0.9961947f)
                transform.localRotation = Quaternion.Euler(-170f, 0f, 0f);

            if (y == -10f && transform.rotation.x == -0.9961947f)
            {
                punto2 = false;
                punto3 = true;
            }
        }

        if (punto3)
        {
            if (z < 89f)
                transform.Translate(0f, 0f, -velocidadMovimiento * Time.deltaTime);

            if (z > 89f)
                transform.position = new Vector3(x, y, 89f);


            if (transform.rotation.x < -0.7071068f && z == 89f)
                transform.Rotate(-velocidadRotacion * Time.deltaTime, 0f, 0f);

            if (transform.rotation.x > -0.7071068f)
                transform.localRotation = Quaternion.Euler(-270f, 0f, 0f);

            if (z == 89f && transform.rotation.x == -0.7071068f)
            {
                punto3 = false;
                punto4 = true;
            }
        }

        if (punto4)
        {
            if (y < 26.92f)
                transform.Translate(0f, 0f, -velocidadMovimiento * Time.deltaTime);

            if (y > 26.92f)
                transform.position = new Vector3(x, 26.92f, z);

            if (transform.rotation.x < 0f && y == 26.92f)
                transform.Rotate(-velocidadRotacion * Time.deltaTime, 0f, 0f);

            if (transform.rotation.x > 0)
                transform.localRotation = Quaternion.Euler(0f, 0f, 0f);

            if (y == 26.92f && transform.rotation.x == 0)
            {
                punto4 = false;
                punto1 = true;
            }
        }
    }
}
