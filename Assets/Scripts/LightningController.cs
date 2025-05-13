using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningController : MonoBehaviour
{
    [Header("Lightning Settings")]
    public Light lightningLight;
    public GameObject lightningBoltObject;
    public Transform startPoint;
    public Transform endPoint;

    public float minDelay = 5f;
    public float maxDelay = 15f;
    public float strikeRange = 20f;

    [Header("Ambient Flicker Settings")]
    public Color normalAmbientColor = new Color(0.1f, 0.1f, 0.1f);
    public Color flashAmbientColor = new Color(0.6f, 0.6f, 0.6f);

    private float timer;
    private Vector3 originalStartPos;
    private Vector3 originalEndPos;

    void Start()
    {
        timer = Random.Range(minDelay, maxDelay);

        originalStartPos = startPoint.position;
        originalEndPos = endPoint.position;

        RenderSettings.ambientLight = normalAmbientColor;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SetRandomStrikePosition();
            StartCoroutine(FlashLightning());
            timer = Random.Range(minDelay, maxDelay);
        }
    }

    void SetRandomStrikePosition()
    {
        Vector3 offset = new Vector3(
            Random.Range(-strikeRange, strikeRange),
            0f,
            Random.Range(-strikeRange, strikeRange)
        );

        startPoint.position = originalStartPos + offset;
        endPoint.position = originalEndPos + offset;
    }

    IEnumerator FlashLightning()
    {
        lightningLight.intensity = 5f;
        RenderSettings.ambientLight = flashAmbientColor;

        lightningBoltObject.SetActive(true);

        LineRenderer lr = lightningBoltObject.GetComponent<LineRenderer>();
        int segments = 5;
        lr.positionCount = segments;

        Vector3 top = startPoint.position;
        Vector3 bottom = endPoint.position;

        for (int i = 0; i < segments; i++)
        {
            float t = i / (float)(segments - 1);
            Vector3 point = Vector3.Lerp(top, bottom, t);
            point.x += Random.Range(-0.5f, 0.5f);
            point.z += Random.Range(-0.5f, 0.5f);
            lr.SetPosition(i, point);
        }

        yield return new WaitForSeconds(0.1f);

        lightningLight.intensity = 0f;
        RenderSettings.ambientLight = normalAmbientColor;

        lightningBoltObject.SetActive(false);
    }
}
