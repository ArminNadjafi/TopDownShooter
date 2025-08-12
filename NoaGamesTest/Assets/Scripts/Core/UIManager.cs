using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public TMP_Text waveText;
    public TMP_Text healthText;
    public TMP_Text ammoText;
    public GameObject winPanel;
    public GameObject losePanel;
    public Slider weapon2CooldownSlider;
    public Slider weapon3CooldownSlider;


    private void Awake()
    {
        Instance = this;
    }

    public void UpdateAmmo(int current, int max)
    {
        ammoText.text = $"{current} / {max}";
    }

    public void ShowWaveText(string messeage)
    {
        StartCoroutine(ShowWaveTextCoroutine(messeage));
    }

    private IEnumerator ShowWaveTextCoroutine(string messeage)
    {
        waveText.gameObject.SetActive(true);
        waveText.text = messeage;
        yield return new WaitForSeconds(1.5f);
        waveText.gameObject.SetActive(false);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void SetKeyboardControl()
    {
      GameManager.Instance.player.SetControlState(new KeyboardControlState());
    }

    public void SetTouchControl()
    {
        GameManager.Instance.player. SetControlState(new TouchControlState());
    }
}