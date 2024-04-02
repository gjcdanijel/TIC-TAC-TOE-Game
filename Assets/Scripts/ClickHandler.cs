using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ClickHandler : MonoBehaviour
{
    int buttonIndex;
    int playerThatClicked;
    [Header("Button!")]
    [SerializeField] public List<Button> buttons;
    //private Image overlayImage;
    int imageIndex;
    ImageController imageController;
    [Header("Images")]
    [SerializeField] public List<Image> images;
    string objectName;

    void Awake()
    {
        //buttons = GetComponent<List<Button>>();
        imageController = FindObjectOfType<ImageController>();
        //overlayImage = GetComponent<Image>();

        objectName = gameObject.name;
        Debug.Log(objectName); Debug.Log("Index before: " + buttonIndex);

    }
    void Start()
    {
        disableImages();
        buttonIndex = GetIndexFromName(objectName);
        imageIndex = buttonIndex;
        //images[imageIndex].enabled = false;
        Debug.Log("Index after: " + buttonIndex);
    }

    public void HandleButtonClick(int playerThatClicked, int playedFieldsIndex)
    {
        SetOverlayImage(playerThatClicked, images[playedFieldsIndex]);
    }



    public void SetOverlayImage(int playerThatClicked, Image overlayImage)
    {
        Debug.Log("Tying to set overlay image... " + buttonIndex);
        if (playerThatClicked != 0) overlayImage.enabled = true;
        //for (int i = 0; i  < 9; i++)
        //{
        {

            Debug.Log("Entered the IF");
            if (playerThatClicked == 0)
            {
                //overlayImage.color = new Color(1f, 1f, 1f, 1f);
                overlayImage.sprite = null;
            }
            if (playerThatClicked == 1)
            {
                //overlayImage.color = new Color(1f, 1f, 1f, 1f);
                overlayImage.sprite = imageController.GetXSprite();
            }
            if (playerThatClicked == 2)
            {
                //overlayImage.color = new Color(1f, 1f, 1f, 1f);
                overlayImage.sprite = imageController.GetOSprite();
            }
        }
        //}
    }
    public int GetIndexFromName(string name)
    {
        string numberStr = "";
        foreach (char c in name)
        {
            if (char.IsDigit(c))
            {
                numberStr += c;
            }
        }
        if (!string.IsNullOrEmpty(numberStr))
        {
            return int.Parse(numberStr);
        }
        return 0;
    }
    public void disableButtons()
    {
        foreach (Button button in buttons)
        {
            button.interactable = false;
        }
    }
    public void disableImages()
    {
        foreach (Image image in images)
        {
            image.enabled = false;
        }
    }
}
