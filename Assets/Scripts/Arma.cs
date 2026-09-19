using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Arma : MonoBehaviour
{
    [SerializeField]
    GameObject Proyectil;
    [SerializeField]
    Transform SpawnPoint;
    [SerializeField]
    float Fuerza = 100f;
    [SerializeField]
    Slider SliderAnguloY;
    [SerializeField]
    Slider SliderAnguloX;
    [SerializeField]
    TextMeshProUGUI AnguloYTexto;
    [SerializeField]
    TextMeshProUGUI AnguloXTexto;
    [SerializeField]
    Slider SliderFuerza;
    [SerializeField]
    TextMeshProUGUI FuerzaTexto;
    [SerializeField]
    Slider SliderPeso;
    [SerializeField]
    TextMeshProUGUI PesoTexto;
    [SerializeField]
    TextMeshProUGUI TiempoVueloTexto;
    [SerializeField]
    TextMeshProUGUI NumeroDisparoTexto;
    [SerializeField]
    TextMeshProUGUI PuntoImpactoTexto;
    [SerializeField]
    TextMeshProUGUI VelocidadRelativaTexto;
    [SerializeField]
    TextMeshProUGUI ImpulsoTexto;
    [SerializeField]
    TextMeshProUGUI ObjetivosDerribadosTexto;

    float anguloVertical = 0f;
    float anguloHorizontal = 0f;
    int numeroDisparo = 0;
    Dictionary<int, int> derribosPorDisparo = new Dictionary<int, int>();
    BallisticData tiroGuardado = new BallisticData();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            numeroDisparo++;

            derribosPorDisparo[numeroDisparo] = 0;
            ObjetivosDerribadosTexto.text = "Objetivos derribados: 0";

            NumeroDisparoTexto.text = "Numero de disparo: " + numeroDisparo + "#";

            GameObject newProyectil = Instantiate(Proyectil, SpawnPoint.position, SpawnPoint.rotation);
            newProyectil.GetComponent<Rigidbody>().mass = SliderPeso.value;
            newProyectil.GetComponent<Rigidbody>().AddForce(SpawnPoint.up * Fuerza, ForceMode.Impulse);

            TrackingProyectil tracking = newProyectil.GetComponent<TrackingProyectil>();
            tracking.Arma = this;
            tracking.TiempoDisparo = Time.time;
            tracking.NumeroDisparo = numeroDisparo;

            Destroy(newProyectil, 5f);
        }
    }

    public void CambiaAnguloY()
    {
        anguloVertical = SliderAnguloY.value;
        transform.rotation = Quaternion.Euler(anguloVertical, anguloHorizontal, 0);
        AnguloYTexto.text = "Angulo Y: " + SliderAnguloY.value.ToString("F1") + "°";
    }

    public void CambiaAnguloX()
    {
        anguloHorizontal = SliderAnguloX.value;
        transform.rotation = Quaternion.Euler(anguloVertical, anguloHorizontal, 0);
        AnguloXTexto.text = "Angulo X: " + SliderAnguloX.value.ToString("F1") + "°";
    }

    public void CambiaFuerza()
    {
        Fuerza = SliderFuerza.value;
        FuerzaTexto.text = "Fuerza: " + SliderFuerza.value.ToString("F1");
    }

    public void CambiaPeso()
    {
        PesoTexto.text = "Peso: " + SliderPeso.value.ToString("F1") + " kg";
    }

    public void RegistrarImpacto(Collision collision, float tiempoVuelo)
    {
        TiempoVueloTexto.text = "Tiempo de vuelo: " + tiempoVuelo.ToString("F2") + " s";

        Vector3 puntoImpacto = collision.contacts[0].point;
        PuntoImpactoTexto.text = "Punto de impacto: " + puntoImpacto.ToString("F2");

        float velocidadRelativa = collision.relativeVelocity.magnitude;
        VelocidadRelativaTexto.text = "Velocidad relativa: " + velocidadRelativa.ToString("F2") + " m/s";

        float impulso = collision.impulse.magnitude;
        ImpulsoTexto.text = "Impulso de colisión: " + impulso.ToString("F2") + " N·s";
    }

    public void RegistrarDerribo(int numeroDisparo)
    {
        if (!derribosPorDisparo.ContainsKey(numeroDisparo))
            derribosPorDisparo[numeroDisparo] = 0;

        derribosPorDisparo[numeroDisparo]++;

        ObjetivosDerribadosTexto.text = "Objetivos derribados: " + derribosPorDisparo[numeroDisparo];
    }

    public void GuardarTiro()
    {
        tiroGuardado.anguloVertical = anguloVertical;
        tiroGuardado.anguloHorizontal = anguloHorizontal;
        tiroGuardado.fuerza = Fuerza;
        tiroGuardado.peso = SliderPeso.value;

        PlayerPrefs.SetFloat("Tiro_AnguloVertical", tiroGuardado.anguloVertical);
        PlayerPrefs.SetFloat("Tiro_AnguloHorizontal", tiroGuardado.anguloHorizontal);
        PlayerPrefs.SetFloat("Tiro_Fuerza", tiroGuardado.fuerza);
        PlayerPrefs.SetFloat("Tiro_Peso", tiroGuardado.peso);
        PlayerPrefs.SetInt("Tiro_Guardado", 1);
        PlayerPrefs.Save();
    }

    public void CargarTiro()
    {
        if (!PlayerPrefs.HasKey("Tiro_Guardado"))
            return;

        tiroGuardado.anguloVertical = PlayerPrefs.GetFloat("Tiro_AnguloVertical");
        tiroGuardado.anguloHorizontal = PlayerPrefs.GetFloat("Tiro_AnguloHorizontal");
        tiroGuardado.fuerza = PlayerPrefs.GetFloat("Tiro_Fuerza");
        tiroGuardado.peso = PlayerPrefs.GetFloat("Tiro_Peso");

        anguloVertical = tiroGuardado.anguloVertical;
        anguloHorizontal = tiroGuardado.anguloHorizontal;
        Fuerza = tiroGuardado.fuerza;

        SliderAnguloY.value = anguloVertical;
        SliderAnguloX.value = anguloHorizontal;
        SliderFuerza.value = Fuerza;
        SliderPeso.value = tiroGuardado.peso;

        transform.rotation = Quaternion.Euler(anguloVertical, anguloHorizontal, 0);

        AnguloYTexto.text = "Angulo Y: " + anguloVertical.ToString("F1") + "°";
        AnguloXTexto.text = "Angulo X: " + anguloHorizontal.ToString("F1") + "°";
        FuerzaTexto.text = "Fuerza: " + Fuerza.ToString("F1");
        PesoTexto.text = "Peso: " + tiroGuardado.peso.ToString("F1") + " kg";
    }
}