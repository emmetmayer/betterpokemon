using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    public TextMeshProUGUI enemyName;

    public bool turn = false;

    public Monster character;
    public float currentHealth;
    public RectTransform hpBar;

    // Start is called before the first frame update
    void Start()
    {
        enemyName.text = character.monsterName;
        currentHealth = character.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.sizeDelta = new Vector2(currentHealth * (200 / character.maxHealth), hpBar.rect.height);
        hpBar.GetComponent<RawImage>().color = Color.HSVToRGB(currentHealth * (((130f / 360f) / character.maxHealth)), 1f, 1f);
    }
}
