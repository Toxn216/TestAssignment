using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private float shakeIntesity = 1f;
    private float shakeTime = 0.2f;

    private float timer;
    private CinemachineBasicMultiChannelPerlin cbmcp;
    // Start is called before the first frame update

    private void Awake()
    {
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }
    void Start()
    {
        StopShake();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            ShakeCamera();
        }
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                StopShake();
            }
        }
    }

    private void ShakeCamera()
    {
        CinemachineBasicMultiChannelPerlin cbmcp = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cbmcp.m_AmplitudeGain = shakeIntesity;

        timer = shakeTime;
    }

    private void StopShake()
    {
        CinemachineBasicMultiChannelPerlin cbmcp = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cbmcp.m_AmplitudeGain = 0;

        timer = 0;
    }
}
