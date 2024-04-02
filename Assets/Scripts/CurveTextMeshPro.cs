using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ControlCurveStrength : MonoBehaviour
{
    public Material curveMaterial;
    [Range(0, 1)]
    public float curveStrength = 0.5f;

    private void Update()
    {
        if (curveMaterial)
        {
            curveMaterial.SetFloat("_CurveStrength", curveStrength);
        }
    }
}
