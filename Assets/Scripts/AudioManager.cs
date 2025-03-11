using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private List<AudioSource> sounds; // allActiveSounds

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        sounds = new List<AudioSource>();
    }

    public AudioSource PlayAudio(AudioClip clip, string gameObjectName, bool isLoop = false, float volume = 1.0f)
    {
        // 1- crear empty
        GameObject nObject = new GameObject();
        // 2- ponerle nombre
        nObject.name = gameObjectName;
        // 3- anyadir el audiosource
        AudioSource audioSourceComponent = nObject.AddComponent<AudioSource>();
        // 4- arrastrar audioclip
        audioSourceComponent.clip = clip;
        // 5- seteamos el loop
        audioSourceComponent.loop = isLoop;
        // 6- regular propiedades...
        audioSourceComponent.volume = volume;
        // 7- anyadimos el objeto a la lista
        sounds.Add(audioSourceComponent);
        // 8- que suene!
        audioSourceComponent.Play();
        // 9- Cuando deje de sonar, hay que destruirlo (performance)
        StartCoroutine(WaitForAudio(audioSourceComponent));

        return audioSourceComponent;
    }

    private IEnumerator WaitForAudio(AudioSource source)
    {
        if (source.loop)
        {
            yield return null;
        }
        else
        {
            // esperamos mientras el audio este sonando
            while (source.isPlaying)
            {
                yield return new WaitForSeconds(0.3f);
            }

            // cuando el audio deja de sonar, lo destruimos
            Destroy(source.gameObject);
        }
    }
}
