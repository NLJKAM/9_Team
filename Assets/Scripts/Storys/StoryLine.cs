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
        sequence.Append(text.DOText("안녕하세요 안녕하세요 안녕하세요 안녕하세요 안녕하세요 안녕하세요 안녕하세요 안녕하세요 안녕하세요 안녕하세요 " +
            "안녕하세요 안녕하세요 안녕하세요 안녕하세요 안녕하세요 안녕하세요 안녕하세요 안녕하세요 안녕하세요 안녕하세요 안녕하세요 안녕하세요 안녕하세요" +
            "안녕하세요 안녕하세요 안녕하세요", 10f).From(""));
        btn1.gameObject.SetActive(false);
        btn2.gameObject.SetActive(true);
    }
    public void Line2()
    {
        sequence.Append(text.DOText("제발 돼라 제발 돼라 제발 돼라 제발 돼라 제발 돼라 제발 돼라 제발 돼라 제발 돼라 제발 돼라 " +
            " 제발 돼라 제발 돼라 제발 돼라 제발 돼라 제발 돼라 제발 돼라 제발 돼라 제발 돼라 제발 돼라 제발 돼라", 10f).From(""));
        btn2.gameObject.SetActive(false);
        endBtn.gameObject.SetActive(true);
    }
    public void Line21()
    {
        sequence.Append(text.DOText("이건 어떠냐 이건 어떠냐 이건 어떠냐 이건 어떠냐 이건 어떠냐 이건 어떠냐 이건 어떠냐 이건 어떠냐", 10f).From(""));
        btn1.gameObject.SetActive(false);
        btn2.gameObject.SetActive(true);
    }
    public void Line22()
    {
        sequence.Append(text.DOText("안 되기만 해? 안 되기만 해? 안 되기만 해? 안 되기만 해? 안 되기만 해? 안 되기만 해? 안 되기만 해? 안 되기만 해?", 10f).From(""));
        btn2.gameObject.SetActive(false);
        endBtn.gameObject.SetActive(true);
    }
    public void EndScene()
    {
        TextBackGround.SetActive(false);
    }
}
