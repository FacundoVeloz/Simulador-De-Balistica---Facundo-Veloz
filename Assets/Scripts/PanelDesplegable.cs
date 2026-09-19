using UnityEngine;

public class PanelDesplegable : MonoBehaviour
{
    [SerializeField]
    GameObject PanelRegistro;

    public void CambiarPanel()
    {
        PanelRegistro.SetActive(!PanelRegistro.activeSelf);
    }
}