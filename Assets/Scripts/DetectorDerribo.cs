using UnityEngine;

public class DetectorDerribo : MonoBehaviour
{
    [SerializeField]
    Arma Arma;

    bool derribado = false;
    bool impactoRegistrado = false;
    int NumeroDisparo = 0;

    public void AsignarArma(Arma arma)
    {
        Arma = arma;
    }

    public void RegistrarImpacto(int numeroDisparo)
    {
        NumeroDisparo = numeroDisparo;
        impactoRegistrado = true;
    }

    public void RecibirDerribo(DetectorDerribo otroDetector)
    {
        if (derribado)
            return;

        if (impactoRegistrado)
            return;

        if (otroDetector == null)
            return;

        if (!otroDetector.TieneDisparo())
            return;

        NumeroDisparo = otroDetector.ObtenerNumeroDisparo();
        Arma = otroDetector.ObtenerArma();
        impactoRegistrado = true;
    }

    public bool TieneDisparo()
    {
        return impactoRegistrado;
    }

    public int ObtenerNumeroDisparo()
    {
        return NumeroDisparo;
    }

    public Arma ObtenerArma()
    {
        return Arma;
    }

    void OnTriggerEnter(Collider other)
    {
        if (derribado)
            return;

        if (!impactoRegistrado)
            return;

        if (other.CompareTag("Suelo"))
        {
            derribado = true;
            Arma.RegistrarDerribo(NumeroDisparo);
        }
    }
}