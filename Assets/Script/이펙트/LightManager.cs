using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightManager : MonoBehaviour
{
    [SerializeField] private Light2D [] lights;
    [SerializeField] private float min_Intensity;
    [SerializeField] private float max_Intensity;
    [SerializeField] private float flicker_Speed;
    private float[] targetIntensities;

    void Start()
    {
        // 초기 목표 밝기 설정
        targetIntensities = new float[lights.Length];
        SetRandomIntensities();
    }

    void Update()
    {
        for (int i = 0; i < lights.Length; i++)
        {
            // 현재 밝기를 목표 밝기로 보간
            lights[i].intensity = Mathf.Lerp(lights[i].intensity, targetIntensities[i], flicker_Speed * Time.deltaTime);

            // 목표 밝기에 거의 도달했으면 새로운 목표 밝기 설정
            if (Mathf.Abs(lights[i].intensity - targetIntensities[i]) < 0.01f)
            {
                targetIntensities[i] = Random.Range(min_Intensity, max_Intensity);
            }
        }
    }

    // 랜덤한 목표 밝기 설정
    private void SetRandomIntensities()
    {
        for (int i = 0; i < lights.Length; i++)
        {
            targetIntensities[i] = Random.Range(min_Intensity, max_Intensity);
        }
    }
}
