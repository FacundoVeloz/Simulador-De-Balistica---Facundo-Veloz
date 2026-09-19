using UnityEngine;

public class TrackingProyectil : MonoBehaviour
{
    public Arma Arma;
    public float TiempoDisparo;
    public int NumeroDisparo;
    bool impactoRegistrado = false;

    void OnCollisionEnter(Collision collision)
    {
        if (impactoRegistrado)
            return;

        impactoRegistrado = true;

        float TiempoVuelo = Time.time - TiempoDisparo;
        Arma.RegistrarImpacto(collision, TiempoVuelo);

        DetectorDerribo detector = collision.collider.GetComponentInChildren<DetectorDerribo>();

        if (detector != null)
        {
            detector.AsignarArma(Arma);
            detector.RegistrarImpacto(NumeroDisparo);
        }
    }
}