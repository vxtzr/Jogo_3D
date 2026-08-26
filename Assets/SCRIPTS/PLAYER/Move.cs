using UnityEngine; //biblioteca da unity

public class Move : MonoBehaviour // classe do script
{
    public float moveSpeed = 5f; //variável de velocidade
    private Rigidbody rb; //variável de gravidade
    public float jumpForce = 10f; //variável de pulo
    private bool IsGrounded; //variável para verificar se está no chão


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() //inicia apenas uma vez 
    {
        rb = GetComponent<Rigidbody>(); // busca o componente rigidbody2d que está anexado ao jogador e guarda na variável 'rb'
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal"); //coloca o input nas teclas para andar
        float moveInput1 = Input.GetAxis("Vertical");
        rb.linearVelocity = new Vector3(moveInput * moveSpeed, rb.linearVelocity.y, moveInput1 * moveSpeed); //aplica a velocidade no rigidbody


        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded) //condição se apertar espaço e estiver no chão
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //aplica impulso para cima
            IsGrounded = false; //avisa que não está mais no chão
        }
    }

    private void OnCollisionEnter(Collision collision) //quando o pé do jogador encosta no chão
    {
        if (collision.gameObject.tag.Contains("Ground")) //se tiver a tag "ground"
        {
            IsGrounded=true; //agora pode pular denovo
        }
    }
    private void OnCollisionExit(Collision collision) //quando sair de cima de algo
    {
        if (collision.gameObject.tag.Contains("Ground")) //se parar de tocar no "ground"
        {
            IsGrounded=false; //bloqueia o pulo até encostar no chão denovo
        }
    }
}
