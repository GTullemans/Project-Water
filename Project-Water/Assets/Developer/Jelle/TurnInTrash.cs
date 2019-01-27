using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnInTrash : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI[] m_PlayerScoreText;

    private int[] _PlayerScore = new int[4];
    private bool[] PlayerEntered = new bool[4];
    private bool GiveScoreBool;
    private bool DeleteTrash;
    private int TrashCount;
    private int BoatCount;
    void Start()
    {

    }

    void Update()
    {
        if(BoatCount == 2)
        {
            Invoke("GiveScore", 1f);
        }
        else
        {

        }
       // print(BoatCount);
        //print(TrashCount);
        m_PlayerScoreText[0].text = "Player 1: " + _PlayerScore[0];
        m_PlayerScoreText[1].text = "Player 1: " + _PlayerScore[1];
        m_PlayerScoreText[2].text = "Player 1: " + _PlayerScore[2];
        m_PlayerScoreText[3].text = "Player 1: " + _PlayerScore[3];
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Boat1")
        {
            PlayerEntered[0] = true;
            BoatCount += 1;
        }
        if (other.gameObject.name == "Boat2")
        {
            PlayerEntered[1] = true;
            BoatCount += 1;
        }
        if (other.gameObject.name == "Boat3")
        {
            PlayerEntered[2] = true;
            BoatCount += 1;
        }
        if (other.gameObject.name == "Boat4")
        {
            PlayerEntered[3] = true;
            BoatCount += 1;
        }
        if (other.gameObject.tag == "Trash")
        {
            TrashCount += 1;
            other.gameObject.SetActive(false);
            //GiveScore();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Boat1")
        {
            PlayerEntered[0] = false;
            BoatCount -= 1;
        }
        if (other.gameObject.name == "Boat2")
        {
            PlayerEntered[1] = false;
            BoatCount -= 1;
        }
        if (other.gameObject.name == "Boat3")
        {
            PlayerEntered[2] = false;
            BoatCount -= 1;
        }
        if (other.gameObject.name == "Boat4")
        {
            PlayerEntered[3] = false;
            BoatCount -= 1;
        }
        if(other.gameObject.tag == "Trash")
        {
            TrashCount -= 1;
        }
    }
    private void GiveScore()
    {
        for (int i = 0; i < PlayerEntered.Length; i++)
        {
            if (PlayerEntered[i])
            {
                _PlayerScore[i] += TrashCount / 2;
                //PlayerEntered[i] = false;
            }
        }
        TrashCount = 0;
    }
}
