using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Sequence = DG.Tweening.Sequence;
public class dungeon2letter : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI first;
    public TextMeshProUGUI second;
    public Dungeon2LevelTP dun2;
    public Image dark;
    bool Initial;
    bool initial;
    Sequence seq;
    public TextMeshProUGUI txt;
    public TextMeshProUGUI win;
    public int enemynum;
    Sequence win1;
    [Header("SFX")]
    public AudioClip win_SFX;
    void Start()
    {
        Initial = true;
        initial = false;
        enemynum = 0;
        win1 = DOTween.Sequence().SetAutoKill(false).Pause()
        .Append(win.DOFade(1f, 2f))
           .Append(win.DOFade(0f, 2f));
        seq = DOTween.Sequence().SetAutoKill(false).Pause()
            .Append(dark.DOFade(0f, 0.5f))
            .Append(first.DOFade(1f, 2f))
            .Append(first.DOFade(0f, 2f))
            .Append(second.DOFade(1f, 2f))
            .Join(txt.DOFade(1f, 2f));
        seq.Play();
    }
    void FixedUpdate()
    {
        
        enemynum = dun2.mob2;
        if (enemynum >= 14)
        {
            Initial = false;
        }
        txt.text = "남은 몬스터 수: " + enemynum.ToString();
        if (enemynum==0)
        {
            if (Initial == false)
            {
                winsound();
                win1.Play();
                txt.text = "포탈로 다시 이동해주세요.(E키)";
            }
        }
        else
        {
            win1.Rewind();
            
        }
    }
    // Update is called once per frame
    void winsound()
    {
        if (initial == false)
        {
            SoundManager.instance.SFXPlay("win", win_SFX);
            initial = true;
        }
            
      
    }
    void endtext()
    {
        txt.text = "포탈로 다시 이동해주세요.(E키)";
    }
}
