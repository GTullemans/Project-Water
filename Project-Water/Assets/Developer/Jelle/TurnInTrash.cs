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
    private int TrashCount;
    void Start()
    {

    }

    void Update()
    {
        print(PlayerEntered[0]);
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
        }
        if (other.gameObject.name == "Boat2")
        {
            PlayerEntered[1] = true;
        }
        if (other.gameObject.name == "Boat3")
        {
            PlayerEntered[2] = true;
        }
        if (other.gameObject.name == "Boat4")
        {
            PlayerEntered[3] = true;
        }
        if (other.CompareTag("Trash"))
        {
            TrashCount += 1;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Boat1")
        {
            PlayerEntered[0] = false;
        }
        if (other.gameObject.name == "Boat2")
        {
            PlayerEntered[1] = false;
        }
        if (other.gameObject.name == "Boat3")
        {
            PlayerEntered[2] = false;
        }
        if (other.gameObject.name == "Boat4")
        {
            PlayerEntered[3] = false;
        }
    }
    private void GiveScore()
    {
        for (int i = 0; i < PlayerEntered.Length; i++)
        {
            if (PlayerEntered[i])
            {
                _PlayerScore[i] += TrashCount / 2;
            }
        }

    }
}
