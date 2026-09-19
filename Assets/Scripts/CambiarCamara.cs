using UnityEngine;

public class CambiarCamara : MonoBehaviour
{
    [SerializeField]
    GameObject PlaneCamara;

    [SerializeField]
    Texture TexturaCamara1;

    [SerializeField]
    Texture TexturaCamara2;

    bool camaraActual = false;

    public void CambiarVista()
    {
        if (camaraActual)
        {
            PlaneCamara.GetComponent<Renderer>().material.mainTexture = TexturaCamara1;
            camaraActual = false;
        }
        else
        {
            PlaneCamara.GetComponent<Renderer>().material.mainTexture = TexturaCamara2;
            camaraActual = true;
        }
    }
}