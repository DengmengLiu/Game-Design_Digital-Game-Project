using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject playPauseButtonGameObj;
    private Button playPauseButton;

    public Sprite playButtonSprite;
    public Sprite pauseButtonSprite;
    public Sprite replayButtonSprite;
    public Sprite crossButtonSprite;

    public GameObject moneyTextGameObj;
    public GameObject moneyGoalTextGameObj;
    public GameObject timeTextGameObj;

    private TextMeshProUGUI moneyText;
    private TextMeshProUGUI moneyGoalText;
    private TextMeshProUGUI timeText;

    private Image image;

    public GameObject statusPanel;

    public GameObject TutorialUI;
    public GameObject tutorialMainPanelParent;
    public GameObject tutorialCompletePanelObj;

    public GameObject speedSliderGameObj;
    private Slider speedSlider;

    private void Awake()
    {
        speedSlider = speedSliderGameObj.GetComponent<Slider>();
        playPauseButton = playPauseButtonGameObj.GetComponent<Button>();
        playPauseButton.onClick.AddListener(ButtonClicked);
        image = playPauseButtonGameObj.GetComponent<Image>();

        var canvas = GameObject.Find("Canvas").transform.Find("ScoringPanel");

        moneyText = moneyTextGameObj.GetComponent<TextMeshProUGUI>();
        moneyGoalText = moneyGoalTextGameObj.GetComponent<TextMeshProUGUI>();
        timeText = timeTextGameObj.GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        if (TutorialUI != null &&
            !GameManager.Instance.isMainMenu) TutorialUI.SetActive(true);
    }


    public void SetTextMoney(string newText)
    {
        moneyText.text = newText;
    }

    public void SetTextMoneyGoal(string newText)
    {
        moneyGoalText.text = newText;
    }

    public void SetTextTimer(string newText)
    {
        timeText.text = newText;
    }


    public void ButtonClicked()
    {
        statusPanel.SetActive(false);


        if (GameManager.Instance.buttonState == ButtonState.Pause)
        {
            ButtonChangedToPlay();
            GameManager.Instance.StopFacrotyAndReset();
        }
        else if (GameManager.Instance.buttonState == ButtonState.Play)
        {
            ButtonChangedToPause();
            GameManager.Instance.PlayFactory();
        }
        else if(GameManager.Instance.buttonState == ButtonState.Replay)
        {
            ButtonChangedToPlay();
            GameManager.Instance.StopFacrotyAndReset();
        }
    }

    public void ButtonChangedToPause()
    {
        image.sprite = pauseButtonSprite;
    }

    public void ButtonChangedToPlay()
    {
        image.sprite = playButtonSprite;
    }

    public void ButtonChangedToReplay()
    {
        image.sprite = replayButtonSprite;
    }

    public void ButtonChangedToCross()
    {
        image.sprite = crossButtonSprite;
    }

    public void UpdateStatusPanelText(string text)
    {
        var textGameObj = statusPanel.transform.Find("Status Text");
        var statusPanelText = textGameObj.GetComponent<TextMeshProUGUI>();

        statusPanelText.text = text;
    }

    public float SpeedSliderValue()
    {
        return speedSlider.value;
    }

    public void CompleteTutorial()
    {
        if (tutorialMainPanelParent != null)
        tutorialMainPanelParent.SetActive(false);

        if (tutorialCompletePanelObj != null)
            tutorialCompletePanelObj.SetActive(true);
    }

}
