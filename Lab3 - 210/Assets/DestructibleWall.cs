using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleWall : MonoBehaviour
{
    public List<GameObject> deathButtonsList = new List<GameObject>();
    public GameObject[] deathButtons;
    public int bombIndex;

    private void Start()
    {
        foreach (Transform child in transform)
        {
            DeathButton childButton = child.gameObject.GetComponent<DeathButton>();
            if (childButton != null)
            {
                deathButtonsList.Add(child.gameObject);
            }
        }

        deathButtons = deathButtonsList.ToArray();
        bombIndex = Random.Range(0, deathButtons.Length);
        //Debug.Log("Index of Bomb: " + bombIndex);
        deathButtons[bombIndex].GetComponent<DeathButton>().setBomb();

    }

    public void PassWall()
    {
        Debug.Log("You have survived!");
        Destroy(gameObject);
    }
}
