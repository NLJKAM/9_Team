using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class StorySceneButton : MonoBehaviour
{
    [SerializeField] private GameObject TextBackGround;
    [SerializeField] private GameObject LoadingBackground;
    [SerializeField] private GameObject Button;
    [SerializeField] private Animator Anim;
    [SerializeField] private GameObject storyPopup;

    public void PressedButton()
    {
        TextBackGround.SetActive(true);
        LoadingBackground.SetActive(true);
        Button.SetActive(false);
        storyPopup.SetActive(false);

        Invoke("SetAnimationTrue", 3f);
        Invoke("SetBoolFalse", 4.5f);
    }

    public void SetAnimationTrue()
    {
        Anim.SetBool("SetAnimation", true);
    }

    public void SetBoolFalse()
    {
        LoadingBackground.SetActive(false);
    }
}
