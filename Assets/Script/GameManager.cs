using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        _score.SetActive(false);
        _start_text.SetActive(true);
        _is_start = false;
        _target = null;
        _ball = null;
    }

    // Update is called once per frame
    void Update()
    {
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

        Vector3 generate_pos = new Vector3(Random.Range(-2.0F, 2.0F), Random.Range(-2.0F, 2.0F), Random.value);
        _target = Instantiate(_generate_prefub, generate_pos, Quaternion.identity);
    }
    private void GenerateBall()
    {
        if (_ball != null)
            return;

        var racket_controller = _ovr_grabbable.grabbedBy.OVRController;
        //ラケットを持つ手とは逆の手を握ったとき
        if (racket_controller == OVRInput.Controller.LTouch)
        {
            if (OVRInput.Get(OVRInput.RawButton.RHandTrigger))
                _ball = Instantiate(_ball_prefub, OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch), OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch));
        }
        else if(racket_controller == OVRInput.Controller.RTouch)
        {
            if (OVRInput.Get(OVRInput.RawButton.LHandTrigger))
                _ball = Instantiate(_ball_prefub, OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch), OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch));
        }
    }
}
