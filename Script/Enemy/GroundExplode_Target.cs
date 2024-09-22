using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundExplode_Target : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; 
    public float Duration = 1.5f;           
    public GameObject Explode;   
    private AudioSource audiosource;
    public AudioClip TimerSound;
    public AudioClip ExplodeSound;            
     void Start()
    {
        Explode.SetActive(false);
        audiosource = GetComponent<AudioSource>();
        audiosource.clip =TimerSound;
        audiosource.Play();
        Explode.SetActive(false);
        // 确保SpriteRenderer和objectToSpawn已设置
            // 开始渐变协程
        StartCoroutine(FadeIn());
        
    }

    IEnumerator FadeIn()
    {
        // 获取初始颜色
        Color color = spriteRenderer.color;
        // 计算初始透明度
        float initialAlpha = 50 / 255f;
        // 计算目标透明度
        float targetAlpha = 255 / 255f;

        // 初始化时间
        float elapsedTime = 0f;

        // 设置初始透明度
        color.a = initialAlpha;
        spriteRenderer.color = color;

        // 开始渐变
        while (elapsedTime < Duration)
        {
            // 增加时间
            elapsedTime += Time.deltaTime;
            // 计算新的透明度
            float newAlpha = Mathf.Lerp(initialAlpha, targetAlpha, elapsedTime / Duration);
            // 设置新的透明度
            color.a = newAlpha;
            spriteRenderer.color = color;

            // 等待下一帧
            yield return null;
        }

        // 确保最后设置为目标透明度
        color.a = targetAlpha;
        spriteRenderer.color = color;

        // 渐变结束后生成A物体
        audiosource.clip =ExplodeSound;
        audiosource.Play();
        Explode.SetActive(true);
        color.a = 0f;
        spriteRenderer.color = color;
        Destroy(gameObject,2);
    }
}

