using UnityEngine;

public class LeverInteraction : MonoBehaviour
{
    public Transform leverHandle;
    public float rotationAngle = 60f;
    public float animationSpeed = 2f;

    private FloodManager floodManager;
    private bool isActivated = false;
    private bool isAnimating = false;
    private Quaternion targetRotation;
    private bool initialized = false;

    void Start()
    {
        // Автоматически найдёт FloodManager на сцене
        floodManager = FindObjectOfType<FloodManager>();
        if (floodManager == null)
            Debug.LogError("FloodManager не найден на сцене!");
        else
            Debug.Log("FloodManager найден: " + floodManager.gameObject.name);
    }

    void Update()
    {
        if (!initialized && leverHandle != null)
        {
            targetRotation = Quaternion.Euler(
                leverHandle.localEulerAngles + new Vector3(rotationAngle, 0, 0)
            );
            initialized = true;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (!isActivated && !isAnimating && initialized)
            {
                isAnimating = true;
                if (floodManager != null)
                    floodManager.StartFlood();
            }
        }

        if (isAnimating && leverHandle != null)
        {
            leverHandle.localRotation = Quaternion.Lerp(
                leverHandle.localRotation,
                targetRotation,
                Time.deltaTime * animationSpeed
            );

            if (Quaternion.Angle(leverHandle.localRotation, targetRotation) < 0.5f)
            {
                isActivated = true;
                isAnimating = false;
            }
        }
    }
}