using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [HideInInspector]
    static public int score = 0;
    [SerializeField]
    private TextMesh _score_text;
    [SerializeField]
    private TextMesh _high_text;
    [SerializeField][Range(0,9_999_999)]
    private int _max_score;
    private int _high_score = 0;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        score = Mathf.Min(score, _max_score);
        _high_score = Mathf.Max(_high_score, score);
        _score_text.text = "Score:" + score;
        _high_text.text = "HighScore:" + _high_score;
    }
}
