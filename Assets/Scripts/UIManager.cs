using UnityEngine;
using UnityEngine.UI;

public class KeyUIManager : MonoBehaviour
{
    [Header("UI Key Image")]
    public RawImage keyImage; 
    public float keyTransparentAlpha = 0.25f; 

    private bool hasKey = false;

    private void Start()
    {
        UpdateKeyUI(false); // Start with a semi-transparent key
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key") && !hasKey)
        {
            CollectKey(other.gameObject);
        }
    }

    void CollectKey(GameObject keyObject)
    {
        hasKey = true;
        UpdateKeyUI(true);
    }

    void UpdateKeyUI(bool isVisible)
    {
        if (keyImage != null)
        {
            Color keyColor = keyImage.color;
            keyColor.a = isVisible ? 1f : keyTransparentAlpha;
            keyImage.color = keyColor;

            // Debugging
            Debug.Log("Key Collected! UI Updated: " + (isVisible ? "Fully Visible" : "Transparent"));
        }
        else
        {
            Debug.LogError("Key Image is not assigned in the Inspector!");
        }
    }
}
