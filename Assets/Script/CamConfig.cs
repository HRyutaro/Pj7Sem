using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CamConfig : MonoBehaviour
{
    public Transform characterBody;
    public Transform characterHead;

    public float sensitivityX = 0.5f;
    public float sensitivityY = 0.5f;

    float rotationX = 0;
    float rotationY = 0;

    float angleYmin = -90;
    float angleYmax = 90;

    float smoothRotx = 0;
    float smoothRoty = 0;

    public float smoothCoefx = 0.005f;
    public float smoothCoefy = 0.005f;
    public float range = 5;
    public float offsetDistance = 1.0f;


    OutlineObject outlineObject;
    Porta porta;
    Chave chave;
    PaginaItem pagitem;
    GravadorItem gravadorItem;
    Gaveta gaveta;
    interruptor Interruptor;
    Armario armario;
    LivroAmaldicoado livroAA;
    Cranios cranio;

    void Start()
    {

    }
    private void LateUpdate()
    {
        transform.position = characterHead.position;
    }

    void Update()
    {
        if (GameController.instance.isPause == false && Inventario.invetarioOpen == false)
        {
            if (Player.parado == false)
            {
                ControleCam();
            }
            look();
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
       
    }
    void ControleCam()
    {
        float verticalDelta = Input.GetAxisRaw("Mouse Y") * sensitivityY;
        float horizontalDelta = Input.GetAxisRaw("Mouse X") * sensitivityX;

        smoothRotx = Mathf.Lerp(smoothRotx, horizontalDelta, smoothCoefx);
        smoothRoty = Mathf.Lerp(smoothRoty, verticalDelta, smoothCoefy);

        rotationX += smoothRotx;
        rotationY += smoothRoty;

        rotationY = Mathf.Clamp(rotationY, angleYmin, angleYmax);

        characterBody.localEulerAngles = new Vector3(0, rotationX, 0);

        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
    }
    void look()
    {
        Vector3 direction = Vector3.forward;
        Vector3 startOffset = transform.forward * offsetDistance;
        Ray theRay = new Ray(transform.position + startOffset, transform.TransformDirection(direction * range));
        Debug.DrawRay(transform.position + startOffset, transform.TransformDirection(direction * range), Color.red);

        // Verifica se o raio colidiu com algum objeto
        if (Physics.Raycast(theRay, out RaycastHit hit, range))
        {
            // Verifica se o objeto destacado mudou
            if (outlineObject != null)
            {
                if (outlineObject.transform != hit.transform)
                {
                    GameController.instance.hideInteracao();
                    outlineObject.Deselect();
                    outlineObject = null;
                }
            }

            // Obt�m o componente OutlineObject do objeto atingido
            outlineObject = hit.transform.GetComponent<OutlineObject>();
            if (outlineObject != null)
            {
                outlineObject.Select();
                HandleOutlineObject(hit); // Processa o objeto destacado
            }
        }
        else if (outlineObject != null) // Caso n�o haja colis�o e um objeto estava destacado
        {
            GameController.instance.hideInteracao();
            outlineObject.Deselect();
            outlineObject = null;
        }
    }
    void HandleOutlineObject(RaycastHit hit)
    {
        // Processa a intera��o com o objeto destacado de acordo com a tag
        if (outlineObject.CompareTag("Porta"))
        {
            porta = hit.transform.GetComponent<Porta>();
            GameController.instance.ShowInteracao("Aperte 'E' para Abrir");

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (porta.trancada)
                {
                    porta.DestrancarPortaRecepcao();
                }
                else
                {
                    porta.ToggleInteracao();
                }
                outlineObject.Deselect();
            }
        }
        else if (outlineObject.CompareTag("Chave"))
        {
            chave = hit.transform.GetComponent<Chave>();
            GameController.instance.ShowInteracao("Aperte 'E' para Pegar");

            if (Input.GetKeyDown(KeyCode.E))
            {
                chave.toggle();
                outlineObject.Deselect();
            }
        }
        else if (outlineObject.CompareTag("PagItem"))
        {
            pagitem = hit.transform.GetComponent<PaginaItem>();
            GameController.instance.ShowInteracao("Aperte 'E' para Pegar");

            if (Input.GetKeyDown(KeyCode.E))
            {
                pagitem.toggle();
                outlineObject.Deselect();
            }
        }
        else if (outlineObject.CompareTag("Gaveta"))
        {
            gaveta = hit.transform.GetComponent<Gaveta>();
            GameController.instance.ShowInteracao("Aperte 'E' para Abrir/fechar");

            if (Input.GetKeyDown(KeyCode.E))
            {
                gaveta.toggleGaveta();
            }
        }
        else if (outlineObject.CompareTag("Gravador"))
        {
            gravadorItem = hit.transform.GetComponent<GravadorItem>();
            GameController.instance.ShowInteracao("Aperte 'E' para Pegar");

            if (Input.GetKeyDown(KeyCode.E))
            {
                gravadorItem.toggleGravador();
                outlineObject.Deselect();
            }
        }
        else if (outlineObject.CompareTag("Interruptor"))
        {
            Interruptor = hit.transform.GetComponent<interruptor>();
            GameController.instance.ShowInteracao("Aperte 'E' para Ligar");

            if (Input.GetKeyDown(KeyCode.E))
            {
                Interruptor.ToggleLigarLuz();
            }
        }
        else if (outlineObject.CompareTag("Armario"))
        {
            armario = hit.transform.GetComponent<Armario>();
            GameController.instance.ShowInteracao("Aperte 'E' para Entrar");

            if (Input.GetKeyDown(KeyCode.E))
            {
                armario.toggleEntrarArmario();
                outlineObject.Deselect();
            }
        }
        else if (outlineObject.CompareTag("LivroAA"))
        {
            livroAA = hit.transform.GetComponent<LivroAmaldicoado>();
            GameController.instance.ShowInteracao("Aperte 'E' para destruir");

            if (Input.GetKeyDown(KeyCode.E))
            {
                livroAA.toggleLivro();
                outlineObject.Deselect();
            }
        }
        else if (outlineObject.CompareTag("CranioChuvisco"))
        {
            cranio = hit.transform.GetComponent<Cranios>();
            GameController.instance.ShowInteracao("Aperte 'E' para destruir");

            if (Input.GetKeyDown(KeyCode.E))
            {
                outlineObject.Deselect();
                cranio.toggleInteracao();
                Debug.Log("destruiu " + puzzlePorta.destruiuCranios);
                Player.parado = true;
                GameController.instance.ShowDialogo("Chuvisco - A� como eu fui descuidado... Tentei dar uma de her�i e acabei realmente sendo pego," +
                "devia ter ficado escondido, que droga... Mas pelo menos espero que aquele coelho que encontrei na sala de corpos l� em cima," +
                "tenha conseguido fugir.");
            }
        }
        else if (outlineObject.CompareTag("CranioBen"))
        {
            cranio = hit.transform.GetComponent<Cranios>();
            GameController.instance.ShowInteracao("Aperte 'E' para destruir");

            if (Input.GetKeyDown(KeyCode.E))
            {
                outlineObject.Deselect();
                cranio.toggleInteracao();
                Debug.Log("destruiu " + puzzlePorta.destruiuCranios);
                Player.parado = true;
                GameController.instance.ShowDialogo("Ben tornado - Eu morri?? Caramba, os ditados dizem que a curiosidade matou o gato," +
                    " mas parece que ela matou foi o coelho mesmo! Hahaha sem piadas agora," +
                    " bem que aqueles irm�os no armaz�m me avisaram sobre o perigo de vir at� a sala de corpos...");
            }
        }
        else if (outlineObject.CompareTag("CranioBranca"))
        {
            cranio = hit.transform.GetComponent<Cranios>();
            GameController.instance.ShowInteracao("Aperte 'E' para destruir");

            if (Input.GetKeyDown(KeyCode.E))
            {
                outlineObject.Deselect();
                cranio.toggleInteracao();
                Debug.Log("destruiu " + puzzlePorta.destruiuCranios);
                Player.parado = true;
                GameController.instance.ShowDialogo("Branca de neve - Ser� que o soneca t� bem? Aquele carneiro esquentado e burro! N�s est�vamos escondidos" +
                    " s� esperando algum resgate e ele teve que perder a paci�ncia e ir em dire��o � sala do legista eu nem sei exatamente como morri... " +
                    "Fiquei com tanto medo de seguir ele e acabar sendo pega, mas acabei presa aqui, longe dele...");
            }
        }
        else if (outlineObject.CompareTag("CranioSoneca"))
        {
            cranio = hit.transform.GetComponent<Cranios>();
            GameController.instance.ShowInteracao("Aperte 'E' para destruir");

            if (Input.GetKeyDown(KeyCode.E))
            {
                outlineObject.Deselect();
                cranio.toggleInteracao();
                Debug.Log("destruiu " + puzzlePorta.destruiuCranios);
                Player.parado = true;
                GameController.instance.ShowDialogo("Soneca - DROGA! Se n�o fosse por aqueles espectros," +
                    " eu teria acabado com a ra�a do zangado, e o Pula Cerca, que p�ssimo dono ele foi, contratando um carneiro que certamente traria problemas," +
                    " e ainda n�o teve nem coragem de tentar enfrentar! S� ficou se escondendo atr�s daqueles arquivos dele, que merda! Como eu fui emocionado tamb�m," +
                    " deixei a Branca de Neve sozinha s� por conta da minha raiva... Que belo irm�o eu fui...");
            }
        }
        else if (outlineObject.CompareTag("CranioCerca"))
        {
            cranio = hit.transform.GetComponent<Cranios>();
            GameController.instance.ShowInteracao("Aperte 'E' para destruir");

            if (Input.GetKeyDown(KeyCode.E))
            {
                outlineObject.Deselect();
                cranio.toggleInteracao();
                Debug.Log("destruiu " + puzzlePorta.destruiuCranios);
                Player.parado = true;
                GameController.instance.ShowDialogo("Pula Cerca - Anos e Anos de trabalho duro jogados no ralo, que tristeza..." +
                    " E pensar que quem acabou com tudo foi o carneiro mais caro contratado!!! " +
                    "Zangado Montauciel, eu te odeio com todas as minhas for�as! Deveria ter tentado sair pela recep��o quando comecei a ouvir gritaria," +
                    " mas pensei que fosse algum familiar na sala de vel�rio, que tolice...");
            }
        }
        else if (outlineObject.CompareTag("CranioDolly"))
        {
            cranio = hit.transform.GetComponent<Cranios>();
            GameController.instance.ShowInteracao("Aperte 'E' para destruir");

            if (Input.GetKeyDown(KeyCode.E))
            {
                outlineObject.Deselect();
                cranio.toggleInteracao();
                Debug.Log("destruiu " + puzzlePorta.destruiuCranios);
                Player.parado = true;
                GameController.instance.ShowDialogo("Dolly a recepcionista cr�nio - ah zangado... Por que?" +
                    " Voc� n�o conseguiu nem olhar nos meus olhos enquanto fazia aquilo..." +
                    " Pensei que tiv�ssemos uma conex�o, desde o seu primeiro dia aqui me cortejando," +
                    " eu adorava nossas conversas, voc� era t�o inteligente, ser� que voc� realmente gostava de mim ou s� estava me manipulando pra conseguir acesso �s escadas?" +
                    " Talvez se eu contasse antes que estava gostando de voc�, as coisas poderiam ter sido diferentes..." +
                    " Enfim, acho que nunca vou entender o que realmente se passa na sua cabe�a");
            }
        }
        else if (outlineObject.CompareTag("Cofre"))
        {
            GameController.instance.ShowInteracao("Aperte 'E' interagir");

            if (Input.GetKeyDown(KeyCode.E))
            {
                GameController.instance.OpenPanelCode();
            }
        }
        else if (outlineObject.CompareTag("Quadro"))
        {
            GameController.instance.ShowInteracao("Aperte 'E' interagir");

            if (Input.GetKeyDown(KeyCode.E))
            {
                // Move o objeto para cima
                hit.transform.position += Vector3.up * 0.5f; // Mova o quadro 0.1 unidades para cima
                outlineObject.Deselect(); // Desseleciona o objeto ap�s a intera��o
                hit.transform.tag = "QuadroMovido";
            }
        }
    }
    private void OnDrawGizmos()
    {
        Vector3 direction = Vector3.forward;
        Vector3 startOffset = transform.forward * offsetDistance;

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position + startOffset, transform.TransformDirection(direction * range));
    }
}