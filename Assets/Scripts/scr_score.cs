using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scr_score : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI textMeshProUGUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textMeshProUGUI.text = score.ToString();
    }
}
