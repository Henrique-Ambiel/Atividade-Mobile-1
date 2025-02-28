using UnityEngine; 
using UnityEngine.UI; 
public class TouchTest : MonoBehaviour
{
    public Text logBox; // Referência pública para o campo de texto onde serão exibidos os logs dos cliques do mouse.
    public Text logCountTouches; // Referência pública para o campo de texto onde será exibido o número de toques na tela.

    void Start()
    {

    }

    private void OnMouseDown() // Este método é chamado quando o mouse é pressionado sobre o objeto que tem este script.
    {
        logBox.text += "\nOnMouseDown: " + Time.time; // Atualiza o texto da logBox, mostrando o momento em que o mouse foi pressionado.
    }

    private void Update() // Método Update é chamado a cada frame. Aqui verificamos entradas contínuas como toques na tela.
    {
        if (Input.touches.Length > 0) // Verifica se há toques detectados na tela.
        {
            // Atualiza o texto do logCountTouches para exibir o número de toques ativos na tela.
            logCountTouches.text = "Dedos na Tela: " + Input.touches.Length;

            Touch touch0 = Input.touches[0]; // Armazena o primeiro toque da tela (se houver toques).

            // Loop que percorre todos os toques na tela.
            foreach (Touch touch in Input.touches)
            {
                // Verifica a fase do toque atual e executa diferentes ações dependendo dessa fase.
                switch (touch.phase)
                {
                    case TouchPhase.Began: // O toque começou.
                        break;

                    case TouchPhase.Moved: // O toque foi movido.
                        break;

                    case TouchPhase.Stationary: // O toque está estacionário (não se moveu).
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

