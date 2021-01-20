using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [HideInInspector]
    static public int score;
    [SerializeField]
    private TextMesh _text;
    [SerializeField][Range(0,9_999_999)]
    private int _max_score;


    private void Update()
    {
        score = Mathf.Min(score, _max_score);
        _text.text = "Score:" + score;
    }
}
