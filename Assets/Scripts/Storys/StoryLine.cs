using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.X86.Avx;

public class StoryLine : MonoBehaviour
{
    private Text text;
    [SerializeField] private Button btn1;
    [SerializeField] private Button btn2;
    [SerializeField] private Button endBtn;
    [SerializeField] private GameObject TextBackGround;
    private Sequence sequence;

    void Start()
    {
        text = GetComponent<Text>();
        OnPlay();
        btn1.gameObject.SetActive(true);
    }

    void OnPlay()
    {
        sequence.Play();
    }

    public void Line1()
    {
        sequence.Append(text.DOText("첫 번째 스토리 입니다. ", 2f).From(""));
        btn1.gameObject.SetActive(false);
        btn2.gameObject.SetActive(true);
    }
    public void Line2()
    {
        sequence.Append(text.DOText("첫 번째 스토리 2번 대사 입니다. ", 2f).From(""));
        btn2.gameObject.SetActive(false);
        endBtn.gameObject.SetActive(true);
    }
    public void Line21()
    {
        sequence.Append(text.DOText("두 번째 스토리 입니다. ", 2f).From(""));
        btn1.gameObject.SetActive(false);
        btn2.gameObject.SetActive(true);
    }
    public void Line22()
    {
        sequence.Append(text.DOText("두 번째 스토리 2번 대사 입니다.", 2f).From(""));
        btn2.gameObject.SetActive(false);
        endBtn.gameObject.SetActive(true);
    }
    public void Line31()
    {
        sequence.Append(text.DOText("세 번째 스토리 입니다. ", 2f).From(""));
        btn1.gameObject.SetActive(false);
        btn2.gameObject.SetActive(true);
    }
    public void Line32()
    {
        sequence.Append(text.DOText("세 번째 스토리 2번 대사 입니다. ", 2f).From(""));
        btn2.gameObject.SetActive(false);
        endBtn.gameObject.SetActive(true);
    }
    public void Line41()
    {
        sequence.Append(text.DOText("네 번째 스토리 입니다. ", 2f).From(""));
        btn1.gameObject.SetActive(false);
        btn2.gameObject.SetActive(true);
    }
    public void Line42()
    {
        sequence.Append(text.DOText("네 번째 스토리 2번 대사 입니다. ", 2f).From(""));
        btn2.gameObject.SetActive(false);
        endBtn.gameObject.SetActive(true);
    }
    public void EndScene(StoryLinePopup storyLinePopup)
    {
        storyLinePopup.storyLineIndex++;
        TextBackGround.SetActive(false);
    }
}
