using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemygenerator : MonoBehaviour {

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject player;
    GameObject[] enemys ;
    private int wave = 1;


    private int remainingEnemy = 0;
    // Use this for initialization
    void Start () {
        // 最初に生成する
        genEnemy(enemy1, 3);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0)){
            float near = 0;
            float dis = 0;
            GameObject obj = null;
            enemys = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemys.Length > 0)
            {
                foreach (GameObject enemy in enemys)
                {
                    dis = Vector3.Distance(player.transform.position, enemy.transform.position);
                    if (near == 0 || near > dis)
                    {
                        near = dis;
                        obj = enemy;
                    }
                }
                Vector3 pos = obj.transform.position;
                pos.y = player.transform.position.y;
                player.transform.LookAt(pos);
            }
        }
	}
    // 次のwaveに進める
    public void NextWave()
    {
        wave++;

        switch (wave)
        {
            case 2:
                genEnemy(enemy1, 3);
                genEnemy(enemy2, 3);
                Debug.Log(remainingEnemy);

                break;
            case 3:
                genEnemy(enemy3, 3);
                break;
            case 4:
                Invoke("win",5f);
                break;
        }
    }
    public void DecreseEnemy()
    {
        remainingEnemy--;

        if (remainingEnemy <= 0)
        {
            NextWave();
        }
    }

    public void genEnemy(GameObject obj, int enemyNum)
    {
        for (int i = 0; i < enemyNum; i++)
        {
            GameObject enemyObj = Instantiate(obj) as GameObject;
            enemyObj.transform.position = new Vector3(i * 50, 1, 1);
        }

        // 生成した敵の数を設定
        remainingEnemy += enemyNum;
    }
    void win()
    {
        SceneManager.LoadScene("win");

    }
}

