using Ink.Runtime;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public class ChatController : MonoBehaviour 
{
    // ... (Variabel Header tetap sama seperti kode aslimu) ...
    [Header("Ink Configuration")]
    public TextAsset inkJSON;
    private Story story;

    [Header("UI Containers")]
    public Transform chatContent;
    public GameObject choiceGroup;
    public ScrollRect scrollRect;

    [Header("Prefabs")]
    public GameObject npcBubblePrefab;
    public GameObject playerBubblePrefab;
    public GameObject narrativePrefab; 
    public GameObject choiceButtonPrefab;
    public GameObject finishButton;

    [Header("Appearance Settings")]
    public float delayBetweenBubbles = 1.0f; 

    [Header("Finish UI")]
    public GameObject levelCompletePanel; 
    public CanvasGroup chatCanvasGroup;   

    private Coroutine displayCoroutine;

    void Start() 
    {
        Time.timeScale = 1f;
        if (inkJSON != null) 
        {
            story = new Story(inkJSON.text);
            RefreshView();
        }
    }

    public void RefreshView() 
    {
        if (displayCoroutine != null) StopCoroutine(displayCoroutine);
        displayCoroutine = StartCoroutine(DisplayNextLines());
    }

    IEnumerator DisplayNextLines() 
    {
        foreach (Transform child in choiceGroup.transform) Destroy(child.gameObject);
        choiceGroup.SetActive(false);
        finishButton.SetActive(false);

        while (story.canContinue) 
        {
            string text = story.Continue().Trim();
            List<string> tags = story.currentTags;
            
            string type = "NPC"; 
            if (tags.Contains("Player")) type = "Player";
            else if (tags.Contains("Narrative")) type = "Narrative";
            
            CreateFullBubble(text, type);

            // --- SFX SAAT BUBBLE MUNCUL ---
            if (AudioManager.instance != null) {
                AudioManager.instance.PlaySFX(AudioManager.instance.dialogue);
            }

            Canvas.ForceUpdateCanvases();
            scrollRect.verticalNormalizedPosition = 0f;

            yield return new WaitForSeconds(delayBetweenBubbles);
        }

        if (story.currentChoices.Count > 0) 
        {
            ShowChoices();
        } 
        else if (!story.canContinue) 
        {
            finishButton.SetActive(true); 
        }

        displayCoroutine = null;
    }

    void CreateFullBubble(string text, string type) 
    {
        if (string.IsNullOrEmpty(text)) return;

        GameObject prefab = (type == "Player") ? playerBubblePrefab : 
                            (type == "Narrative") ? narrativePrefab : npcBubblePrefab;

        GameObject instance = Instantiate(prefab, chatContent);
        TMP_Text textComponent = instance.GetComponentInChildren<TMP_Text>();

        string cleanText = (type == "Narrative") ? text : 
                           (text.Contains(":") ? text.Split(':')[1].Trim() : text);
        
        textComponent.text = cleanText;
    }

    void ShowChoices() 
    {
        choiceGroup.SetActive(true);
        foreach (Choice choice in story.currentChoices) 
        {
            GameObject buttonObj = Instantiate(choiceButtonPrefab, choiceGroup.transform);
            buttonObj.GetComponentInChildren<TMP_Text>().text = choice.text;
            
            buttonObj.GetComponent<Button>().onClick.AddListener(() => 
            {
                // --- SFX SAAT TOMBOL PILIHAN DI-KLIK ---
                if (AudioManager.instance != null) {
                    AudioManager.instance.PlaySFX(AudioManager.instance.buttons);
                }

                story.ChooseChoiceIndex(choice.index);
                RefreshView();
            });
        }
    }

    public void OnFinishClicked() 
    {
        // --- SFX SAAT TOMBOL FINISH DI-KLIK ---
        if (AudioManager.instance != null) {
            AudioManager.instance.PlaySFX(AudioManager.instance.buttons);
        }

        if (levelCompletePanel != null) levelCompletePanel.SetActive(true);
        if (chatCanvasGroup != null) 
        {
            chatCanvasGroup.interactable = false;
            chatCanvasGroup.blocksRaycasts = false;
        }
    }
}