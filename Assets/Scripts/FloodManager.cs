using UnityEngine;
using System.Collections;

public class FloodManager : MonoBehaviour
{
    public Transform waterSurface;
    public float endYPosition = 60f;
    public float floodDuration = 15f;

    public void StartFlood()
    {
        StartCoroutine(FloodCoroutine());
    }

    private IEnumerator FloodCoroutine()
    {
        float elapsed = 0f;
        Vector3 startPos = waterSurface.position;
        Vector3 endPos = new Vector3(startPos.x, endYPosition, startPos.z);

        while (elapsed < floodDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / floodDuration;
            waterSurface.position = Vector3.Lerp(startPos, endPos, t);
            yield return null;
        }
    }
}