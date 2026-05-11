using Ink.Runtime;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public class ChatController : MonoBehaviour 
{
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
    public GameObject imageBubblePrefab; // Prefab untuk bubble gambar

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
        // Bersihkan pilihan lama
        foreach (Transform child in choiceGroup.transform) Destroy(child.gameObject);
        choiceGroup.SetActive(false);
        finishButton.SetActive(false);

        while (story.canContinue) 
        {
            string text = story.Continue().Trim();
            List<string> tags = story.currentTags;

            // 1. DETEKSI TAG GAMBAR
            string imgName = "";
            foreach (string tag in tags) {
                if (tag.StartsWith("img_bubble:")) {
                    imgName = tag.Split(':')[1].Trim();
                }
            }

            // 2. MUNCULKAN BUBBLE GAMBAR (Dulu jika ada tag-nya)
            if (!string.IsNullOrEmpty(imgName)) {
                CreateImageBubble(imgName);
                yield return new WaitForSeconds(delayBetweenBubbles);
                
                // Scroll otomatis setelah gambar masuk
                ScrollToBottom();
            }

            // 3. MUNCULKAN BUBBLE TEKS (Jika baris tersebut ada teksnya)
            if (!string.IsNullOrEmpty(text)) {
                string type = "NPC"; 
                if (tags.Contains("Player")) type = "Player";
                else if (tags.Contains("Narrative")) type = "Narrative";
                
                CreateFullBubble(text, type);

                if (AudioManager.instance != null) {
                    AudioManager.instance.PlaySFX(AudioManager.instance.dialogue);
                }

                yield return new WaitForSeconds(delayBetweenBubbles);
                
                // Scroll otomatis setelah teks masuk
                ScrollToBottom();
            }
        }

        // Tampilkan pilihan jika ada
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

    void CreateImageBubble(string fileName) 
    {
        if (imageBubblePrefab == null) return;

        GameObject instance = Instantiate(imageBubblePrefab, chatContent);
        
        // Mengambil komponen Image di dalam prefab
        Image imgComponent = instance.GetComponentInChildren<Image>();
        
        Sprite loadedSprite = Resources.Load<Sprite>("Bukti/" + fileName);
        if (loadedSprite != null) {
            imgComponent.sprite = loadedSprite;
            
            // AGAR TIDAK STRETCH:
            imgComponent.preserveAspect = true; 
        }
        else {
            Debug.LogError("File gambar tidak ditemukan di Resources/Bukti/" + fileName);
        }
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
                if (AudioManager.instance != null) {
                    AudioManager.instance.PlaySFX(AudioManager.instance.buttons);
                }

                story.ChooseChoiceIndex(choice.index);
                RefreshView();
            });
        }
        ScrollToBottom();
    }

    void ScrollToBottom()
    {
        Canvas.ForceUpdateCanvases();
        scrollRect.verticalNormalizedPosition = 0f;
    }

    public void OnFinishClicked() 
{
    if (AudioManager.instance != null)
        AudioManager.instance.PlaySFX(AudioManager.instance.buttons);

    if (levelCompletePanel != null) 
        levelCompletePanel.SetActive(true);

    if (AudioManager.instance != null)
        AudioManager.instance.PlaySFX(AudioManager.instance.gameComplete);

    if (chatCanvasGroup != null) 
    {
        chatCanvasGroup.interactable = false;
        chatCanvasGroup.blocksRaycasts = false;
    }

    int levelDipilih = PlayerPrefs.GetInt("levelDipilih", 1);

    Debug.Log("Finish levelDipilih: " + levelDipilih);

    int levelTerbuka = PlayerPrefs.GetInt("levelTerbuka", 1);

    int maxLevel = 7;

    // hanya unlock level berikutnya
    if (levelDipilih == levelTerbuka && levelTerbuka < maxLevel)
    {
        levelTerbuka++;

        PlayerPrefs.SetInt("levelTerbuka", levelTerbuka);

        Debug.Log("Unlock level: " + levelTerbuka);
    }
    else
    {
        Debug.Log("Replay level - tidak unlock");
    }
}
}