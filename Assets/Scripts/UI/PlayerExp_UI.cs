using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExp_UI : MonoBehaviour
{
    [SerializeField] private Slider expBar;
    [SerializeField] private PlayerExp playerExp;
    [SerializeField] private TextMeshProUGUI levelText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateLevelText();
        playerExp.OnLevelUp += UpdateLevelText;
    }

    // Update is called once per frame
    void Update()
    {
        float fill = (float)playerExp.CurrentExp / playerExp.ExpToNextLevel;
        expBar.value = fill;
    }

    void UpdateLevelText()
    {
        levelText.text = playerExp.PlayerLevel.ToString();
    }
}

