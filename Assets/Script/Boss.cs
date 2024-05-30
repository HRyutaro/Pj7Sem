using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public static Boss instance;
    public GameObject bookPrefab;
    public List<Transform> spawnPoints = new List<Transform>();
    private List<GameObject> spawnedBooks = new List<GameObject>(); // Lista para manter os livros spawnados


    private int ondas;
    private bool spawningBooks = false;

    public MeshRenderer MeshChave;
    public MeshCollider colChave;
    private Player playerControler;
    public GameObject colissorStarter;

    [Header("TimerConfig")]
    public float timerDuration = 10f; // Duração do timer em segundos
    public GameObject timerHud;
    public Slider timerSlide;
    private float currentTime = 0f;
    private bool timerRunning = false;

    private void Start()
    {
        GameObject p1 = GameObject.FindWithTag("Player");
        playerControler = p1.GetComponent<Player>();
        instance = this;
        timerHud.SetActive(false);

    }
    private void Update()
    {
        timerSlide.value = currentTime;
        if (timerRunning)
        {
            currentTime += Time.deltaTime; // Aumenta o tempo atual com o tempo passado desde o último frame
            timerSlide.value = currentTime;

            if (currentTime >= timerDuration)
            {
                // O timer atingiu a duração desejada
                TimerComplete();
            }
        }
    }
    public void SpawnBooks(int numBooks)
    {
        if (spawningBooks) return; // Evita a duplicação do spawn

        spawningBooks = true;

        for (int i = 0; i < numBooks; i++)
        {
            Transform spawnPoint = ChooseRandomSpawnPoint();
            GameObject bookInstance = Instantiate(bookPrefab, spawnPoint.position, spawnPoint.rotation);
            spawnedBooks.Add(bookInstance); // Adiciona o livro à lista de livros spawnados

        }

        spawningBooks = false;
    }

    private Transform ChooseRandomSpawnPoint()
    {
        int randomIndex = Random.Range(0, spawnPoints.Count);
        return spawnPoints[randomIndex];
    }

    public void OnBookDestroyed()
    {
        ondas += 1;
        Onda(ondas);
    }

    public void Onda(int num)
    {
        if(num == 1)
        {
            SpawnBooks(2);
            currentTime -= 7;
        }
        else if(num == 3)
        {
            SpawnBooks(3);
            currentTime -= 7;
        }
        else if (num == 6)
        {
            SpawnBooks(4);
            currentTime -= 7;
        }
        else if(num == 10)
        {
            timerRunning = false;
            MeshChave.enabled = true;
            colChave.enabled = true;
            timerHud.SetActive(false);
            GameController.instance.textDica.text = "Procure o Chuvisco";
            Destroy(gameObject,1);
        }
    }
    private void TimerComplete()
    {
        timerRunning = false;
        currentTime = 0f;
        playerControler.morrer();
        ondas = 0;
        timerHud.SetActive(false);
        DestroyAllBooks(); // Destroi todos os livros quando o timer atinge a duração
        Debug.Log("Timer completado!");
    }

    void DestroyAllBooks()
    {
        foreach (GameObject book in spawnedBooks)
        {
            if (book != null)
            {
                Destroy(book);
            }
        }
        spawnedBooks.Clear(); // Limpa a lista de livros spawnados
        colissorStarter.SetActive(true);
    }

    public void StartFight()
    {
        SpawnBooks(1); // Começa com um livro
        timerRunning = true;
        currentTime = 0f;
        timerSlide.value = currentTime;
        timerHud.SetActive(true);
        colissorStarter.SetActive(false);
    }
}
