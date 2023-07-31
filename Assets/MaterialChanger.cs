using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    public GameObject sourceObject;
    public GameObject targetObject;

    public float blendDuration = 2.0f;
    public float blendingSpeed = 1.0f;

    private Material sourceMaterial;
    private Material targetMaterial;
    private GameObject targetObjectClone;
    private MaterialPropertyBlock materialPropertyBlock;
    private bool isBlending = false;

    private void Start()
    {
        sourceMaterial = sourceObject.GetComponent<Renderer>().material;
        targetMaterial = targetObject.GetComponent<Renderer>().material;
        materialPropertyBlock = new MaterialPropertyBlock();
        StartMaterialTransfer();
    }

    public void StartMaterialTransfer()
    {
        if (!isBlending)
        {
            isBlending = true;
            StartCoroutine(BlendMaterials());
        }
    }

    private System.Collections.IEnumerator BlendMaterials()
    {
        // Create a clone of the target object and transfer the source material to it
        targetObjectClone = Instantiate(targetObject);
        targetObjectClone.transform.position = targetObject.transform.position;
        targetObjectClone.transform.rotation = targetObject.transform.rotation;
        targetObjectClone.GetComponent<Renderer>().material = sourceMaterial;

        float elapsedTime = 0.0f;
        while (elapsedTime < blendDuration)
        {
            yield return null;
            elapsedTime += Time.deltaTime * blendingSpeed;
            float t = Mathf.Clamp01(elapsedTime / blendDuration);

            // Interpolate material properties from source to target using MaterialPropertyBlock
            Color blendedColor = Color.Lerp(sourceMaterial.color, targetMaterial.color, t);

            // Apply the blended color to the clone using MaterialPropertyBlock
            targetObjectClone.GetComponent<Renderer>().GetPropertyBlock(materialPropertyBlock);
            materialPropertyBlock.SetColor("_Color", blendedColor);
            targetObjectClone.GetComponent<Renderer>().SetPropertyBlock(materialPropertyBlock);
        }

        // If the blending is complete, destroy the clone
        Destroy(targetObjectClone);
        isBlending = false;
    }
}
