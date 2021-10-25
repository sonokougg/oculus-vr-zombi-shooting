using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Zombi : MonoBehaviour
{

    Animator animator;
    public float destroyTime = 1.0f;
    // 射程距離
    public float rangeDistance = 0.5f;
    GameObject player;
    public float gameoverTime = 1.0f;

    public bool CanWalk { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");

        CanWalk = true;
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーの位置
        var playerPosition = player.transform.position;

        // ゾンビの位置
        var zombiPosition = transform.position;

        // ゾンビとプレイヤーがどれだけはなれているか
        var offset = Mathf.Abs(playerPosition.z - zombiPosition.z);

        // プレイヤーとゾンビの距離がちかくなったら攻撃
        if(offset <= rangeDistance)
        {
            Attack();
        }

    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Bullet")
        {
            // ゾンビが倒れる
            FallDown();
        }
    }

    void Attack()
    {
        // 攻撃するアニメーションを流す
        animator.SetTrigger("Attack");

        // ゲームオーバー画面に移動
        Invoke("Gameover", gameoverTime);
    }

    void FallDown() 
    {
        // 動きを止める
        CanWalk = false;

        // 倒れるアニメーションを流す
        animator.SetTrigger("FallDown");

        // ゾンビを倒す
        Invoke("DestroyZombi", destroyTime);
    }

    void Gameover()
    {
        SceneManager.LoadScene("GameOver");
    }

    void DestroyZombi()
    {
        Destroy(gameObject);
    }
}
