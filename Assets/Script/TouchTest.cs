using UnityEngine; 
using UnityEngine.UI; 
public class TouchTest : MonoBehaviour
{
    public Text logBox; // Refer�ncia p�blica para o campo de texto onde ser�o exibidos os logs dos cliques do mouse.
    public Text logCountTouches; // Refer�ncia p�blica para o campo de texto onde ser� exibido o n�mero de toques na tela.

    void Start()
    {

    }

    private void OnMouseDown() // Este m�todo � chamado quando o mouse � pressionado sobre o objeto que tem este script.
    {
        logBox.text += "\nOnMouseDown: " + Time.time; // Atualiza o texto da logBox, mostrando o momento em que o mouse foi pressionado.
    }

    private void Update() // M�todo Update � chamado a cada frame. Aqui verificamos entradas cont�nuas como toques na tela.
    {
        if (Input.touches.Length > 0) // Verifica se h� toques detectados na tela.
        {
            // Atualiza o texto do logCountTouches para exibir o n�mero de toques ativos na tela.
            logCountTouches.text = "Dedos na Tela: " + Input.touches.Length;

            Touch touch0 = Input.touches[0]; // Armazena o primeiro toque da tela (se houver toques).

            // Loop que percorre todos os toques na tela.
            foreach (Touch touch in Input.touches)
            {
                // Verifica a fase do toque atual e executa diferentes a��es dependendo dessa fase.
                switch (touch.phase)
                {
                    case TouchPhase.Began: // O toque come�ou.
                        break;

                    case TouchPhase.Moved: // O toque foi movido.
                        break;

                    case TouchPhase.Stationary: // O toque est� estacion�rio (n�o se moveu).
                        break;

                    case TouchPhase.Ended: // O toque foi removido da tela.
                        break;

                    case TouchPhase.Canceled: // O toque foi cancelado (ex: perda de sinal).
                        break;
                }
            }
        }
    }
}

