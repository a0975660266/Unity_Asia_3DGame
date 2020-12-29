using UnityEngine;
using UnityEngine.AI;        //引用 人工智慧  API

public class Enemy : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent nav;
    private Animator ani;
    private float timer;

    private void Awake()
    {
        //取得身上的元件<代理器>
        nav = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();

        //尋找其他遊戲物件("物件名稱").變形元件
        player = GameObject.Find("主機").transform;
        //代理器 的 速度 與 停止距離
        nav.speed = speed;
        nav.stoppingDistance = stopDistance;
    }

    [Header("移動速度"), Range(0, 50)]
    public float speed = 3;
    [Header("停止距離"), Range(0, 50)]
    public float stopDistance = 2.5f;
    [Header("攻擊間隔"), Range(0, 50)]
    public float CD = 1.5f;

    private void Update()
    {
        Track();
        Attack();
    }

    /// <summary>
    /// 追蹤
    /// </summary>
    private void Track()
    {
        //代理器.設定目的地(玩家的座標)
        nav.SetDestination(player.position);

        ani.SetBool("跑步開關", nav.remainingDistance > stopDistance);
    }

    /// <summary>
    /// 攻擊
    /// </summary>
    private void Attack()
    {
        if(nav.remainingDistance < stopDistance)
        {
            //時間 累加(一偵的時間)
            timer += Time.deltaTime;
            //取得玩家的座標
            Vector3 pos = player.position;
            //將玩家的座標Y軸 指定為 本物件的Y軸
            pos.y = transform.position.y;
            //看向(玩家的座標)
            transform.LookAt(pos);

            //如果 計時器 >=冷卻時間 就攻擊 並且計時器歸零
            if(timer >= CD)
             {
                ani.SetTrigger("攻擊觸發");
                timer = 0;
             }
            
        }
    }
}
