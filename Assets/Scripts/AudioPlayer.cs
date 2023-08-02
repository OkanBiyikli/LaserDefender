using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] float shootingVolume = 1f;

    [Header("DamageTaken")]
    [SerializeField] AudioClip damageClip;
    [SerializeField] float damageVolume = 1f;

    static AudioPlayer instance; 

    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        //int instanceCount = FindObjectsOfType(GetType()).Length;
        //if(instanceCount > 1)
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);  
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void PlayShootingClip()
    {
        if(shootingClip != null)
        {
            PlayClip(shootingClip, shootingVolume);
        }
    }

    public void PlayDamageClip()
    {
        if(damageClip != null)
        {
            PlayClip(damageClip, damageVolume);
        }
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if(clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }
}
