using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    Player player;
    [SerializeField]
    GameObject[] prefab;

    LinkedList<Map> maps;
    
    Vector2 startPos;
    Vector2 endPos;

    int coinData;
    int jewelData;

    int count;
    int potion_count;
    int score;
    int coin;

    bool is_pause;

    float mapLength;
    float speed;
   
    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            EventManager.Instance.ScoreChanged(score);
        }
    }
    public int Coin
    {
        get { return coin; }
        set 
        { 
            coin = value;
            EventManager.Instance.CoinChanged(coin);
        }
    }
    public float Speed
    {
        get { return speed; }
        set 
        {
            speed = value;
            SetMapSpeed();
        }
    }
    protected override void Init()
    {
        maps = new LinkedList<Map>();
        mapLength = 30.0f;
        count = 1;
        potion_count = 10;

        is_pause = false;
        startPos = new Vector2(30.1f, 0f);
        endPos = new Vector2(-29.9f, 0f);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start()
    {
        EventManager.Instance.OnPlayerDie += GameOver;

        Score = 0;
        Coin = 0;
        Speed = 1;

    }

    public void Pause()
    {
        is_pause = !is_pause;
        player.Pause(is_pause);
        Time.timeScale = is_pause ? 0f : 1f;
    }

    private void SetMapSpeed()
    {
        foreach (Map map in maps)
        {
            map.Speed = speed;
        }
    }
    public void ChangeMap()
    {
        int index;
        if (count == potion_count)
        {
            index = 1;
        }
        else
        {
            index = UnityEngine.Random.Range(2, prefab.Length);
        }
        Vector2 pos = new Vector2(maps.Last.Value.transform.position.x + mapLength, 0); 
        CreateMap(index, pos);
        DestroyMap();
        count++;
    }
    private void CreateMap(int index, Vector2 pos)
    {
        GameObject obj = Instantiate(prefab[index]);
        Map map = obj.GetComponent<Map>();

        maps.AddLast(map);
        map.Init(endPos, speed);
        obj.transform.position = pos;
        
    }

    private void DestroyMap()
    {
        GameObject obj = maps.First.Value.gameObject;
        maps.RemoveFirst();
        Destroy(obj);
    }

    public void GameOver()
    {
        Pause();
        UIManager.Instance.ShowPanel("BackGroundUI");
        UIManager.Instance.ShowPanel("GameOverUI");

        DataManager.Instance.AddResult(Score, Coin);
        DataManager.Instance.SaveData();
    }

    public void ReStart()
    {
        Pause();
        GameStart();
    }

    public void GameStart()
    {
        count = 1;
        Score = 0;
        Coin = 0;
        Speed = 6;

        SceneManager.LoadScene("GameScene");
    }

    public void GameEnd()
    {
        Pause();
        SceneManager.LoadScene("StartScene");
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "GameScene")
        {
            Debug.Log("GameScene »ý¼º");
            maps.Clear();
            player = GameObject.Find("kara").GetComponent<Player>();
            CreateMap(0, new Vector2(0.1f, 0f));
            CreateMap(5, startPos);
        }
        else if(scene.name == "StartScene")
        {
            maps.Clear();
            Speed = 1;
            CreateMap(2, new Vector2(0.1f, 0f));
            CreateMap(5, startPos);
        }
        
    }
}
