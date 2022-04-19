using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class LevelSetUp : MonoBehaviour
{
    public GameObject pauseMenuPrefab;
    public List<MemorySO> MemoryList;
    private const string fileName = "/chosenMemories.dat";
    private string homeName = "MainMenu";
    private GameObject pauseMenu;
    private MemoryData memoryData = new MemoryData();
    private bool pauseMenuOpen = false;
    private const int possibleMemoriesCount = 8;
    private int abilityButton = 0;
    private int resumeButton = 1;
    private int menuButton = 2;
    private int exitButton = 3;
    private int panelNumber = 4;
    private int scrollViewNumber = 2;
    private int viewportNumber = 0;
    private int contentNumber = 0;
    private int iconNumber = 0;
    private int descriptionBoxNumber = 1;
    private int nameNumber = 0;
    private int loreNumber = 1;
    private int descriptionNumber = 2;
    private int backButtonNumber = 0;
    private float pausedTime = 0f;
    private float activeTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            InstantiatePauseMenu();
            LoadAbilities();
        }
    }

    public void InstantiatePauseMenu()
    {
        pauseMenu = Instantiate(pauseMenuPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        pauseMenu.SetActive(false);
        pauseMenu.transform.GetChild(abilityButton).GetComponent<Button>().onClick.AddListener(ShowAbilities);
        pauseMenu.transform.GetChild(resumeButton).GetComponent<Button>().onClick.AddListener(ResumeGame);
        pauseMenu.transform.GetChild(menuButton).GetComponent<Button>().onClick.AddListener(ReturnToHomeScreen);
        pauseMenu.transform.GetChild(exitButton).GetComponent<Button>().onClick.AddListener(QuitGame);
        pauseMenu.transform.GetChild(panelNumber).GetChild(backButtonNumber).GetComponent<Button>().onClick.AddListener(HideAbilities);
        pauseMenu.transform.GetChild(panelNumber).gameObject.SetActive(false);
    }

    private void FillAbilitiesPanel(List<MemorySO> memories)
    {
        for(int memoryNumber = 0; memoryNumber < possibleMemoriesCount; memoryNumber++)
        {
            GameObject memoryDescriptionBox = pauseMenu.transform.GetChild(panelNumber).GetChild(scrollViewNumber).GetChild(viewportNumber).GetChild(contentNumber).GetChild(memoryNumber).gameObject;
            if (memoryNumber >= memories.Count)
            {
                memoryDescriptionBox.transform.GetChild(iconNumber).gameObject.SetActive(false);
                memoryDescriptionBox.transform.GetChild(descriptionBoxNumber).gameObject.SetActive(false);
            } else
            {
                //TODO: Add icon based on MemorySO
                //memoryDescriptionBox.transform.GetChild(iconNumber).gameObject.GetComponent<Image>().sprite = memories[memoryNumber].icon;
                GameObject memoryDescription = memoryDescriptionBox.transform.GetChild(descriptionBoxNumber).gameObject;
                memoryDescription.transform.GetChild(nameNumber).gameObject.GetComponent<Text>().text = memories[memoryNumber].MemoryName;
                memoryDescription.transform.GetChild(loreNumber).gameObject.GetComponent<Text>().text = memories[memoryNumber].FlavorText;
                memoryDescription.transform.GetChild(descriptionNumber).gameObject.GetComponent<Text>().text = memories[memoryNumber].Description;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name != "MainMenu")
            {
                if (pauseMenuOpen)
                {
                    ClosePauseMenu();
                }
                else
                {
                    OpenPauseMenu();
                }
            }
        }
    }

    private void ShowAbilities()
    {
        pauseMenu.transform.GetChild(panelNumber).gameObject.SetActive(true);
    }

    private void HideAbilities()
    {
        pauseMenu.transform.GetChild(panelNumber).gameObject.SetActive(false);
    }

    private void ResumeGame()
    {
        ClosePauseMenu();
        Time.timeScale = activeTime;
    }

    private void ReturnToHomeScreen()
    {
        SceneManager.LoadScene(homeName);
    }

    private void OpenPauseMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = pausedTime;
    }

    private void ClosePauseMenu()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = activeTime;
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void LoadAbilities()
    {
        if (File.Exists(Application.persistentDataPath + fileName))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Open(Application.persistentDataPath + fileName, FileMode.Open, FileAccess.Read);
            MemoryData data = (MemoryData)bf.Deserialize(fs);
            fs.Close();

            memoryData.memoryNames = data.memoryNames;
            List<MemorySO> memorySOMemories = new List<MemorySO>();
            foreach(String memoryName in memoryData.memoryNames)
            {
                for(int memoryNumber = 0; memoryNumber < MemoryList.Count; memoryNumber++)
                {
                    if(MemoryList[memoryNumber].name == memoryName)
                    {
                        memorySOMemories.Add(MemoryList[memoryNumber]);
                    }
                }
            }
            FillAbilitiesPanel(memorySOMemories);
        }
    }
}
