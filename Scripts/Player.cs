using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Player : MonoBehaviour
{
    Animator _playerAnimator;
    Rigidbody2D _playerRb;
    BoxCollider2D _playerBoxCollider;

    [SerializeField] float player_Jump;
    bool doubleJump = true;

    private int valorVida = 3;
    private int valorPontos = 0;
    private bool canJump = true;
    private bool gameOver = false;
    private int scene = 1;
    private bool ind = false;

    [SerializeField]
    int puntosObjetivo = 5;

    public Vida_UI vidaUI;
    public Pontuacao_UI pontuacaoUI;
    
    public List<GameObject> componentesMoveis = new List<GameObject>();

    [SerializeField]
    GameObject BlastPrefab;
    [SerializeField]
    GameObject gameOverPanel;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        UpdateComponentList();
    }

    void UpdateComponentList()
    {
        
        componentesMoveis.Clear();


        GameObject[] divs = GameObject.FindGameObjectsWithTag("Div");
        GameObject objectManager = GameObject.FindWithTag("ObjectManager");

        
        componentesMoveis.AddRange(divs);
        if (objectManager != null) componentesMoveis.Add(objectManager);
    }

    void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
        _playerBoxCollider = GetComponent<BoxCollider2D>();

    }

    void Update()
    {
        bool isJumping = Mathf.Abs(_playerRb.velocity.y) > Mathf.Epsilon;
        _playerAnimator.SetBool("isJumping", isJumping);

    }

    void OnJump(InputValue inputValue)
    {
        if (inputValue.isPressed && canJump)
        {
            Jump();
        }
    }

    void Jump()
    {
        if (_playerBoxCollider.IsTouchingLayers(LayerMask.GetMask("Foreground")))
        {
            _playerRb.velocity = new Vector2(_playerRb.velocity.x, _playerRb.velocity.y + player_Jump);
            doubleJump = true;
        }
        else if (doubleJump == true)
        {
            _playerRb.velocity = new Vector2(_playerRb.velocity.x, _playerRb.velocity.y + player_Jump);
            doubleJump = false;
        }
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if ((other.CompareTag("obstaculo1") || other.CompareTag("obstaculo2")) && canJump)
        {
            AudioSource otherAudio = other.GetComponent<AudioSource>();
            AudioSource.PlayClipAtPoint(otherAudio.clip, other.transform.position);
            AtualizaVida(-1,other);
            canJump = false;

            
            StartCoroutine(BlinkEffect());
        }

        if (other.CompareTag("vida"))
        {
            AudioSource otherAudio = other.GetComponent<AudioSource>();
            AudioSource.PlayClipAtPoint(otherAudio.clip, other.transform.position);
            AtualizaVida(1,other);
            
        }

        if (other.CompareTag("dinheiro"))
        {
            
            AtualizaPontuacao(1, other);
            
        }

        if (other.CompareTag("indestrutivel"))
        {
            ind = true;
            StartCoroutine(indes());
            Destroy(other.gameObject);
            
        }
    }

    void AtualizaVida(int mu, Collider2D other)
    {
        if (!ind)
        {
            valorVida += mu;
            vidaUI.AtualizaVida(valorVida);
        }
        Destroy(other.gameObject);
        GameObject blastClone = Instantiate(BlastPrefab, other.transform.position, Quaternion.identity);
        Destroy(blastClone, 1.5f);

        if (valorVida <= 0)
        {
            UpdateComponentList();
            StartCoroutine(GameOver());
        }


    }

    void AtualizaPontuacao(int cambio, Collider2D other)
    {
        AudioSource otherAudio = other.GetComponent<AudioSource>();
        AudioSource.PlayClipAtPoint(otherAudio.clip, other.transform.position);
        valorPontos += cambio;
        pontuacaoUI.AtualizaPontuacao(valorPontos);
        Destroy(other.gameObject);
        GameObject blastClone = Instantiate(BlastPrefab, other.transform.position, Quaternion.identity);
        Destroy(blastClone, 1.5f);

        if (valorPontos >= puntosObjetivo && scene == 1)
        {
            TrocarScene();
        }
    }

    IEnumerator indes()
    {
        Vector2 originalScale = transform.localScale;

        transform.localScale = originalScale * 1.3f;
        yield return new WaitForSeconds(5f);
        ind = false;
        transform.localScale = originalScale;
    }

    IEnumerator BlinkEffect()
    {
        float duration = 1.0f; 
        float blinkTime = 0.1f; 

        int blinkCount = Mathf.FloorToInt(duration / blinkTime);

        for (int i = 0; i < blinkCount; i++)
        {
            
            GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;

           
            yield return new WaitForSeconds(blinkTime);
        }

        
        GetComponent<SpriteRenderer>().enabled = true;

        
        canJump = true;
    }

    IEnumerator GameOver()
    {
        gameOver = true;
        _playerAnimator.SetBool("isOver", gameOver);
        PausarObjetos(true);
        yield return new WaitForSeconds(1.5f);

        gameOverPanel.SetActive(true);

        Time.timeScale = 0f;

    }

    void PausarObjetos(bool pausar)
    {

        foreach (var objetoMovil in componentesMoveis)
        {
            MonoBehaviour[] scripts = objetoMovil.GetComponents<MonoBehaviour>();

            foreach (var script in scripts)
            {
                
                script.enabled = !pausar;
            }
        }
    }

    void TrocarScene()
    {
        scene = 2;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
