using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineShake : MonoBehaviour
{
    [SerializeField] private float _shakeIntensity = 4f;
    [SerializeField] private float _shakeTime = 0.3f;

    private float _shakeTimer;

    private CinemachineVirtualCamera _cinemachine;
    private CinemachineBasicMultiChannelPerlin _perlin;

    private void OnEnable()
    {
        TryGetComponent(out _cinemachine);
        _perlin = _cinemachine.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void ShakeCamera()
    {
        _shakeTimer = _shakeTime;
        StartCoroutine(ShakeCameraCoroutine());
    }
    private IEnumerator ShakeCameraCoroutine()
    {
        while (_shakeTimer > 0f)
        {
            _shakeTimer -= Time.deltaTime;
            _perlin.m_AmplitudeGain = _shakeIntensity;
            yield return null;
        }
        _perlin.m_AmplitudeGain = 0f;
        _shakeTimer = 0f;
    }
}
