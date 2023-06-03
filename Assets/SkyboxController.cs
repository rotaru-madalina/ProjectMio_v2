using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class SkyboxController : MonoBehaviour
{
    public float rotationSpeed = 0.1f; // Rotation speed for the skybox
    public float cycleTime = 1f; // Total time for exposure cycle in minutes
    public float maxExposure = 1f; // Max exposure
    public float minExposure = 0f; // Min exposure

    private Material skyboxMaterial;
    private float currentExposure;
    private bool isIncreasingExposure = true;
    private float exposureSpeed;

    void Start()
    {
        skyboxMaterial = RenderSettings.skybox; // Get the current skybox material
        currentExposure = skyboxMaterial.GetFloat("_Exposure");

        // Calculate the speed of exposure change based on cycleTime
        exposureSpeed = (maxExposure - minExposure) / (cycleTime * 60f / 2f); // Divided by 2 because cycleTime includes both increasing and decreasing exposure
    }

    void Update()
    {
        // Slowly rotate the skybox
        skyboxMaterial.SetFloat("_Rotation", Time.time * rotationSpeed);

        // Slowly change exposure
        if (isIncreasingExposure)
        {
            currentExposure += Time.deltaTime * exposureSpeed;
            if (currentExposure >= maxExposure)
            {
                isIncreasingExposure = false;
            }
        }
        else
        {
            currentExposure -= Time.deltaTime * exposureSpeed;
            if (currentExposure <= minExposure)
            {
                isIncreasingExposure = true;
            }
        }

        skyboxMaterial.SetFloat("_Exposure", currentExposure);

        // Update the Skybox material
        RenderSettings.skybox = skyboxMaterial;
    }
}
