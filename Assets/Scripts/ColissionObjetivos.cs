using UnityEngine;

public class ColisionObjetivo : MonoBehaviour
{
    DetectorDerribo Detector;

    void Awake()
    {
        Detector = GetComponentInChildren<DetectorDerribo>();
    }

    void OnCollisionEnter(Collision collision)
    {
        TransferirDisparo(collision);
    }

    void OnCollisionStay(Collision collision)
    {
        TransferirDisparo(collision);
    }

    void TransferirDisparo(Collision collision)
    {
        DetectorDerribo otroDetector = collision.collider.transform.root.GetComponentInChildren<DetectorDerribo>();

        if (otroDetector == null || otroDetector == Detector)
            return;

        if (Detector.TieneDisparo())
        {
            otroDetector.RecibirDerribo(Detector);
            return;
        }

        if (otroDetector.TieneDisparo())
        {
            Detector.RecibirDerribo(otroDetector);
        }
    }
}