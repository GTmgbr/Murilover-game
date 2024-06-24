using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager AudioManagerInstance { get; private set; }

    AudioSource audioSource;

    [SerializeField] Slider audioSlider;

    private void Awake()
    {
        if (AudioManagerInstance == null)
        {
            AudioManagerInstance = FindObjectOfType<AudioManager>();
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
        audioSource = GetComponent<AudioSource>();

        audioSlider.onValueChanged.AddListener(delegate { RecebeValorSlider(); });

        if (PlayerPrefs.HasKey("Volume"))
        {
            audioSource.volume = PlayerPrefs.GetFloat("Volume");
            audioSlider.value = audioSource.volume;
        }
        else
        {
            audioSource.volume = 0.5f;
            audioSlider.value = audioSource.volume;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RecebeValorSlider()
    {
        audioSource.volume = audioSlider.value;
        PlayerPrefs.SetFloat("Volume", audioSource.volume);
    }
}
