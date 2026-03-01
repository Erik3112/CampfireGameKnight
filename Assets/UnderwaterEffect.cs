using UnityEngine;

public class UnderwaterEffect : MonoBehaviour
{
    public Transform waterSurface;
    public Color underwaterFogColor = new Color(0.1f, 0.3f, 0.5f, 1f);
    public float underwaterFogDensity = 0.05f;

    private bool isUnderwater = false;
    private Color defaultFogColor;
    private float defaultFogDensity;
    private bool defaultFog;

    void Start()
    {
        defaultFogColor = RenderSettings.fogColor;
        defaultFogDensity = RenderSettings.fogDensity;
        defaultFog = RenderSettings.fog;
    }

    void Update()
    {
        if (waterSurface == null) return;

        bool underwater = transform.position.y < waterSurface.position.y + 48f;

        if (underwater && !isUnderwater)
        {
            isUnderwater = true;
            RenderSettings.fog = true;
            RenderSettings.fogColor = underwaterFogColor;
            RenderSettings.fogDensity = underwaterFogDensity;
            RenderSettings.fogMode = FogMode.Exponential;
        }
        else if (!underwater && isUnderwater)
        {
            isUnderwater = false;
            RenderSettings.fog = defaultFog;
            RenderSettings.fogColor = defaultFogColor;
            RenderSettings.fogDensity = defaultFogDensity;
        }
    }
}
