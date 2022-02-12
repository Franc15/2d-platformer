using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public static MenuController instance = null;

    [SerializeField]
    private Sprite [] musicBtnSprite;

    [SerializeField]
    private Button musicBtn;

    private bool musicOn;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void ToggleMusic()
    {
        if (musicOn)
        {
            musicBtn.GetComponent<Image>().sprite = musicBtnSprite[1];
            musicOn = false;
        }
        else
        {
            musicBtn.GetComponent<Image>().sprite = musicBtnSprite[0];
            musicOn = true;
        }
    }
    
}
