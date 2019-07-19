using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI hpText;
    public RectTransform hpBar;

    public bool turn = false;

    public Monster character;
    public float currentHealth;
    public List<Move> moveList;
    public List<int> moveEnergy;
    public List<Button> moveButtons;

    private ColorBlock buttonColor;

    public Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        playerName.text = character.monsterName;
        currentHealth = character.maxHealth;

        for (int i = 0; i < moveList.Count; i++)
        {
            moveButtons[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = moveList[i].name;
            moveButtons[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = moveList[i].type;

            buttonColor = moveButtons[i].GetComponent<Button>().colors;
            buttonColor.normalColor = moveList[i].color;
            buttonColor.selectedColor = moveList[i].color;
            buttonColor.pressedColor = moveList[i].color + Color.HSVToRGB(0f, 0f, -0.3f);
            buttonColor.highlightedColor = moveList[i].color + Color.HSVToRGB(0f,0f,-0.1f);
            moveButtons[i].GetComponent<Button>().colors = buttonColor;
        }

        for (int i = 0; i < moveList.Count; i++)
        {
            moveEnergy[i] = moveList[i].energy;    
        }
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.sizeDelta = new Vector2(currentHealth * (200/ character.maxHealth), hpBar.rect.height);
        hpBar.GetComponent<RawImage>().color = Color.HSVToRGB(currentHealth * (((130f / 360f) / character.maxHealth)), 1f, 1f);
        hpText.text = (Mathf.RoundToInt(currentHealth) + "/" + Mathf.RoundToInt(character.maxHealth));

        for (int i = 0; i < moveList.Count; i++)
        {
            moveButtons[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = moveEnergy[i].ToString() + "/" + moveList[i].energy.ToString();
        }
    }

    public void useMove(int moveNum)
    {
        if (moveEnergy[moveNum] > 0)
        {
            GameObject moveParticle = Instantiate(moveList[moveNum].moveEffect, this.transform);
            Destroy(moveParticle, 2f);
            enemy.currentHealth -= moveList[moveNum].damage;
            moveEnergy[moveNum]--;
        }  
    }
}
