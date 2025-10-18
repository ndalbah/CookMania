using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour
{
    public static OptionsUI Instance { get; private set; }

    [SerializeField] private Button soundEffectsButton;
    [SerializeField] private Button musicButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private TextMeshProUGUI soundEffectsText;
    [SerializeField] private TextMeshProUGUI musicText;
    private int volume = 5;
    private int musicVolume = 5;

    private void Awake()
    {
        Instance = this;

        soundEffectsButton.onClick.AddListener(() =>
        {
            // change sfx volume
            volume++;

            if (volume > 10)
            {
                volume = 0;
            }

            soundEffectsText.text = "Sound Effects: " + volume.ToString();

        });

        musicButton.onClick.AddListener(() =>
        {
            musicVolume++;

            if (musicVolume > 10)
            {
                musicVolume = 0;
            }

            musicText.text = "Music: " + musicVolume.ToString();
        });

        closeButton.onClick.AddListener(() =>
        {
            Hide();
        });
    }

    private void Start()
    {
        KitchenGameManager.Instance.OnGameUnpaused += KitchenGameManager_OnGameUnpaused;
        Hide();
    }

    private void KitchenGameManager_OnGameUnpaused(object sender, System.EventArgs e)
    {
        Hide();
    }

    //private void UpdateVisual()
    //{
    //    int volume = 0;
    //    if(volume < 10)
    //    {
    //        volume++;
    //        soundEffectsText.text = "Sound Effects: " + volume.ToString();
    //    }
    //    else
    //    {
    //        volume = 0;
    //    }

    //}

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
