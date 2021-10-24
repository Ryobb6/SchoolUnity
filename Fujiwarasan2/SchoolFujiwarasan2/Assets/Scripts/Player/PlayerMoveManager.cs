using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveManager : MonoBehaviour
{   // _つけると変換が出やすくなる
    private Transform _transform; // transformもキャッシュして使うほうが高速
    [SerializeField] Transform _cameraTransform; // 何のTransformかわかるようにする(Positionとは異なるので、注意する事)
    [SerializeField] Vector3 _cameraPosition; // これがPositionをいれる変数

    private Animator _animator;
    private CharacterController _characterController;
    bool _runHash = false;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    [HideInInspector] public float _tes; // public ではあるが、Inspecter Viewから触りたくない場合



    /// <summary>
    /// Awakeはオブジェクトが生成された瞬間でスタートより前
    /// 非アクティブ(非表示)のオブジェクトに対しては、よばれない!!
    /// </summary>
    private void Awake()
    {
        // 自分自身がもつ参照からインスタンスを取得し、フィールドに入れて使うと処理が軽くなる。
        // (自分自身のTransfiormを)キャッシュするという
        _animator = GetComponent<Animator>();
        _transform = this.transform;
        _characterController = GetComponent<CharacterController>(); 
    }
    /// <summary>
    /// Startは、ObjectがInstaniate された直後かつファーストフレームの直前
    /// </summary>
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnEnable()
    {
        // ObjectがAvctiveになった際に呼ばれる
    }

    public void OnDisable()
    {
        // Objectが非表示になった際に呼ばれる
    }

    // Update is called once per frame
    void Update()
    {
        // そのコンポーネントにとってのforward(前)を指す、グローバルなベクトルを取得
        Vector3 cameraForward = _cameraTransform.forward;
        cameraForward.y = 0;

        cameraForward.Normalize(); // 方向は1の単位ベクトルとして考える (変数自体をNormalizeできる (Vector3))
               
        float inputAxisX = Input.GetAxisRaw("Horizontal"); // 軽くないので、使いすぎない(まず文字列の比較の時点で重い(ひともじずつ比較しているので))
        float inputAxisZ = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = (cameraForward * inputAxisZ + _cameraTransform.right * inputAxisX).normalized; // (normalizeした値(magunitud 1の方向ベクトル)を返す)
        
        // Vector3 moveDirection = Vector3.zero; // .zeroで (0,0,0)を返す
        // moveDirection.x = inputAxisX;
        // moveDirection.z = inputAxisZ;

        _characterController.Move(moveDirection*_moveSpeed * Time.deltaTime);     // キャラコン、リジッドボディのMoveメソッドはグローバル
        // _transform.rotation = Quaternion.Euler(0, 0, 0); オイラー角を指定して、回転を与える
        // transform.rotation = Quaternion.LookRotation(moveDirection);

        bool isRotateNeccesary = moveDirection != Vector3.zero; // 移動している時は、回転を与えれるようにする

        if (isRotateNeccesary)
        {
            Quaternion lookDirection = Quaternion.LookRotation(moveDirection);
            _transform.rotation = Quaternion.Slerp(_transform.rotation, lookDirection, _rotateSpeed * Time.deltaTime);

            _animator.SetBool("_runHash", true);
        }
        else
        {
            _animator.SetBool("_runHash", false);
        }

        // Vector3 temp = _transform.TransformDirection(moveDirection); // ローカル座標をワールド座標へ変換
        // tempの座標はtransformのローカルの座標として与えられたmoveDirectionがワールド座標として変換されて代入される

    }
}
