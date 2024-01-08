using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryLinePopup : MonoBehaviour
{
    [SerializeField] private GameObject popup;
    [SerializeField] private GameObject storyLine1;
    [SerializeField] private GameObject storyLine2;
    [SerializeField] private GameObject storyLine3;
    [SerializeField] private GameObject storyLine4;

    public int storyLineIndex;


    private void Start()
    {
        storyLineIndex = 1;
    }

    public void OnPopup()
    {
        popup.SetActive(true);

        if (storyLineIndex == 1)
        {
            storyLine1.SetActive(true);
        }
        else if (storyLineIndex == 2)
        {
            storyLine2.SetActive(true);
        }
        else if(storyLineIndex == 3)
        {
            storyLine3.SetActive(true);
        }
        else if (storyLineIndex == 4)
        {
            storyLine4.SetActive(true);
        }
    }

    public void DisablePopup()
    {
        popup.SetActive(false);

        if (storyLineIndex == 1)
        {
            storyLine1.SetActive(false);
        }
        else if (storyLineIndex == 2)
        {
            storyLine2.SetActive(false);
        }
        else if (storyLineIndex == 3)
        {
            storyLine3.SetActive(false);
        }
        else if (storyLineIndex == 4)
        {
            storyLine4.SetActive(false);
        }
    }
}
