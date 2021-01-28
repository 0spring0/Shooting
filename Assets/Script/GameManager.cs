using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private OVRGrabbable _ovr_grabbable;
    [SerializeField]
    private int _max_generate_num;
    [SerializeField]
    private float _generate_time;
    [SerializeField]
    private GameObject _generate_prefub;
    [SerializeField]
    private GameObject _ball_prefub;

    private GameObject _target;
    private GameObject _ball;
    private bool _is_start;


    //ゲーム開始時にActiveを変更するオブジェクト
    [SerializeField]
    private GameObject _score;
    [SerializeField]
    private GameObject _start_text;
    [SerializeField]
    private TextMesh _hold_hand;

    void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        _score.SetActive(false);
        _start_text.SetActive(true);
        _is_start = false;
        _target = null;
        _ball = null;
        _hold_hand.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        //シーンの再スタート
        Restert();

        //ゲームの開始確認
        if (IsStart() == false)
            return;

        //的の生成
        GenerateTarget();
        //弾の生成
        GenerateBall();
    }


    private bool IsStart()
    {
        if (_is_start == true)
            return true;

        if (_ovr_grabbable.isGrabbed == true)
        {
            _is_start = true;
            _score.SetActive(true);
            _start_text.SetActive(false);
        }

        return _is_start;
    }

    private void GenerateTarget()
    {
        if (_target != null)
            return;

        Vector3 generate_pos = new Vector3(Random.Range(-3.0F, 3.0F), Random.Range(-2.0F, 2.0F), Random.value);
        _target = Instantiate(_generate_prefub, generate_pos, Quaternion.identity);
    }
    private void GenerateBall()
    {
        _hold_hand.text = "";
        if (_ball != null)
            return;

        if (_ovr_grabbable.grabbedBy == null)
            return;

        _hold_hand.text = "Hold Shoulder";

        //左ショルダーが押されたときにボール生成
        if (OVRInput.Get(OVRInput.RawButton.LIndexTrigger))
            _ball = Instantiate(_ball_prefub);
    }


    private void Restert()
    {
        //積んだ時用のリセット処理
        if (OVRInput.GetDown(OVRInput.RawButton.Start))
        {
            //現在のシーンを再読み込み
            var active_scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(active_scene.name);
        }
    }
}
