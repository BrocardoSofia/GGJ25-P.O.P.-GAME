using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Bottonimage : MonoBehaviour
{
    public Sprite normalImage; // Asigna tu imagen normal desde el Inspector
    public Sprite hoverImage;  // Asigna tu imagen onHover desde el Inspector
    private Image buttonImage;

    void Start()
    {
        buttonImage = GetComponent<Image>();
        buttonImage.sprite = normalImage; // Asegúrate de iniciar con la imagen normal
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.sprite = hoverImage; // Cambia a la imagen onHover
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.sprite = normalImage; // Cambia de vuelta a la imagen normal
    }
}
