using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum Player
{
    One, Two, Three, Four
}

public class PickUpScore : MonoBehaviour
{


    [SerializeField]
    private TextMeshProUGUI[] m_PlayerScoreText;

    private int[] _PlayerScore = new int[4];

    public Player Player;

    private void Start()
    {
        SwitchCase();
    }
    private void Update()
    {
        SwitchCase();
    }
    private void OnTriggerEnter(Collider other)
    {
        //if(gameObject.name == "Player 1 Net")
        //{
        //    print("hai");
        //    if (other.gameObject.tag == "Trash")
        //    {
        //        print("hooooooooooi");
        //        other.gameObject.SetActive(false);
        //        AddScore(1);
        //    }
        //}
        string trash = other.transform.tag;
        switch (Player)
        {
            case Player.One:
                if (other.gameObject.tag == "Trash")
                {
                    other.gameObject.SetActive(false);
                    AddScore(0);
                }
                break;
            case Player.Two:
                if (other.gameObject.tag == "Trash")
                {
                    other.gameObject.SetActive(false);
                    AddScore(1);
                }
                break;
            case Player.Three:
                if (other.gameObject.tag == "Trash")
                {
                    other.gameObject.SetActive(false);
                    AddScore(2);
                }
                break;
            case Player.Four:
                if (other.gameObject.tag == "Trash")
                {
                    other.gameObject.SetActive(false);
                    AddScore(3);
                }
                break;
        }
    }

    public void AddScore(int m_Player)
    {
        _PlayerScore[m_Player] += 1;
    }


    public void SwitchCase()
    {
        switch (Player)
        {
            case Player.One:
                m_PlayerScoreText[0].text = "Player 1: " + _PlayerScore[0];
                break;
            case Player.Two:
                m_PlayerScoreText[1].text = "Player 2: " + _PlayerScore[1];
                break;
            case Player.Three:
                m_PlayerScoreText[2].text = "Player 3: " + _PlayerScore[2];
                break;
            case Player.Four:
                m_PlayerScoreText[3].text = "Player 4: " + _PlayerScore[3];
                break;
        }
    }
    public void ResetScore(int m_Player)
    {
        _PlayerScore[m_Player] = 0;
    }
}
