using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class AbilitySelect : MonoBehaviour
{
    public GameObject SelectionPanel;
    public GameObject ChoicePanel;
    public List<MemorySO> MemoryList;

    private Dictionary<string, MemorySO> chosenMemories;
    private int numberOfAbilities;
    private int numberOfChoices;
    private const string iconName = "AbilityIcon";
    private const string fileName = "/chosenMemories.dat";
    private const string abilityScreen = "AbilitySelectScreen";
    private const int descriptionBoxNumber = 1;
    private const int iconChildNumber = 0;
    private const int nameNumber = 0;
    private const int descriptionNumber = 1;

    private void Awake()
    {
        numberOfAbilities = SelectionPanel.transform.childCount;
        numberOfChoices = ChoicePanel.transform.childCount;
        InitializeMemories();
        AddDescriptions();
        AddButtonFunctionality();
    }

    private void InitializeMemories()
    {
        chosenMemories = new Dictionary<string, MemorySO>();
    }

    private void AddDescriptions()
    {
        for (int memory = 0; memory < numberOfAbilities; memory++)
        {
            //TODO: set icon based on MemorySO icon
            Transform abilityBox = SelectionPanel.transform.GetChild(memory).GetChild(descriptionBoxNumber);
            abilityBox.GetChild(nameNumber).gameObject.GetComponent<Text>().text = MemoryList[memory].MemoryName;
            abilityBox.GetChild(descriptionNumber).gameObject.GetComponent<Text>().text = MemoryList[memory].Description;

        }
    }

    private void AddButtonFunctionality()
    {
        for (int memory = 0; memory < numberOfAbilities; memory++)
        {
            GameObject abilityButton = SelectionPanel.transform.GetChild(memory).gameObject;
            MemorySO theMemory = MemoryList[memory];
            abilityButton.GetComponent<Button>().onClick.AddListener(() => AddAbility(abilityButton, theMemory));
        }

        for (int button = 0; button < numberOfChoices; button++)
        {
            GameObject abilityButton = ChoicePanel.transform.GetChild(button).gameObject;
            abilityButton.GetComponent<Button>().onClick.AddListener(() => RemoveAbility(abilityButton));
        }
    }

    private void AddAbility(GameObject abilityButton, MemorySO memory)
    {
        Sprite icon = abilityButton.transform.GetChild(iconChildNumber).GetComponent<Image>().sprite;
        for (int button = 0; button < numberOfChoices; button++)
        {
            GameObject buttonObject = ChoicePanel.transform.GetChild(button).GetChild(iconChildNumber).gameObject;
            Image image = buttonObject.GetComponent<Image>();
            if(!image.enabled)
            {
                if(chosenMemories.ContainsKey(memory.name))
                {
                    break;
                }
                chosenMemories.Add(memory.name, memory);
                image.enabled = true;
                //TODO: set image based on MemorySO icon
                image.sprite = icon;
                image.gameObject.name = memory.name;
                abilityButton.GetComponent<Button>().enabled = false;
                break;
            }
        }
    }

    private void RemoveAbility(GameObject buttonObject)
    {
        GameObject button = buttonObject.transform.GetChild(iconChildNumber).gameObject;
        Image image = button.GetComponent<Image>();
        if(image.enabled)
        {
            image.enabled = false;
            image.sprite = null;
            chosenMemories.Remove(image.gameObject.name);
            int index = 0;
            for(int memoryButton = 0; memoryButton < numberOfAbilities; memoryButton++)
            {
                if(MemoryList[memoryButton].name == image.gameObject.name)
                {
                    index = memoryButton;
                    break;
                }
            }
            Button chooseButton = SelectionPanel.transform.GetChild(index).GetComponent<Button>();
            chooseButton.enabled = true;
            image.gameObject.name = iconName;
        }
    }

    public void RemoveAbility(MemorySO memory)
    {
        if(chosenMemories.ContainsValue(memory))
        {
            chosenMemories.Remove(memory.name);
            Scene scene = SceneManager.GetActiveScene();
            if(scene.name == abilityScreen)
            {
                int index = 0;
                for (int memoryButton = 0; memoryButton < numberOfAbilities; memoryButton++)
                {
                    if (MemoryList[memoryButton].name == memory.name)
                    {
                        index = memoryButton;
                        break;
                    }
                }
                Button selectButton = SelectionPanel.transform.GetChild(index).GetComponent<Button>();
                selectButton.enabled = true;
                for (int choiceButton = 0; choiceButton < numberOfChoices; choiceButton++)
                {
                    Button chooseButton = ChoicePanel.transform.GetChild(choiceButton).GetComponent<Button>();
                    Image image = chooseButton.transform.GetChild(iconChildNumber).GetComponent<Image>();
                    if (image.name == memory.name)
                    {
                        image.gameObject.name = iconName;
                        image.sprite = null;
                        image.enabled = false;
                        break;
                    }
                }
            }
        }
    }

    public void SaveAbilities()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = File.Open(Application.persistentDataPath + fileName, FileMode.OpenOrCreate);
        MemoryData data = new MemoryData();
        List<string> memorySONames = new List<string>();
        foreach(KeyValuePair<string, MemorySO> keyValuePair in chosenMemories)
        {
            memorySONames.Add(keyValuePair.Key);
        }
        data.memoryNames = memorySONames;
        formatter.Serialize(stream, data);
        stream.Close();
    }
}
