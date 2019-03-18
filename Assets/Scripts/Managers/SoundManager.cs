using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public List<AudioClip> AudioClips = new List<AudioClip>();

    private AudioSource CreateAudioSourceWithAudioClip(string name, float volume, bool loop)
    {
        var audioClip = AudioClips.FirstOrDefault(x => x.name == name);
        if (audioClip == null)
        {
            Debug.LogError("No audioClip was found with specified name :" + name);
            return null;
        }

        var gameObject = new GameObject();
        var audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.loop = loop;

        return audioSource;
    }

    public void PlaySound2D(string name, float volume, bool loop)
    {
        CreateAudioSourceWithAudioClip(name, volume, loop);
    }

    public void PlaySound3D(string name, float volume, bool loop, GameObject bindGameObject, bool fallowGameObject)
    {
        var audioSource = CreateAudioSourceWithAudioClip(name, volume, loop);

        audioSource.gameObject.transform.position = bindGameObject.transform.position;
        if (fallowGameObject)
        {
            audioSource.gameObject.transform.SetParent(bindGameObject.transform);
        }
    }
}
