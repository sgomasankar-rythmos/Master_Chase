using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] monsterReference;

    private GameObject spawnMonster;

    public Player Player;

    [SerializeField]
    private Transform leftPos, rightPos;

    public Texture btnTexture;
    

    private int randomIndex, randomSide;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    private void OnGUI()
    {


        if (GUI.Button(new Rect(10, 10, 50, 50), btnTexture))
        {
            Player.Reset_Player();
            var Enemies = FindObjectsOfType<Monster>();
            foreach (Monster a in Enemies)
            GameObject.Destroy(a.gameObject);
            
        }
        
    }

    IEnumerator SpawnMonsters()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));
            randomIndex = Random.Range(0, monsterReference.Length);

            randomSide = Random.Range(0, 2);

            spawnMonster = Instantiate(monsterReference[randomIndex]);

            if (randomSide == 0)
            {
                spawnMonster.transform.position = leftPos.position;
                spawnMonster.GetComponent<Monster>().speed = Random.Range(4, 7);

            }

            else
            {
                spawnMonster.transform.position = rightPos.position;
                spawnMonster.GetComponent<Monster>().speed = -Random.Range(4, 7);
                spawnMonster.transform.localScale = new Vector3(-1f, 1f, 1f);

            }
        }

    }
    
}
