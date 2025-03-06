using UnityEngine;
using System.Collections.Generic;

public class TouchDrag : MonoBehaviour
{
    private Camera cam; // Referência para a câmera principal
    private Dictionary<int, Transform> activeTouches = new Dictionary<int, Transform>(); // Dicionário para armazenar os toques ativos e os objetos sendo movidos

    void Start()
    {
        cam = Camera.main; // Obtém a referência da câmera principal
    }

    void Update()
    {
        // Percorre todos os toques na tela
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began) // Quando o toque começa
            {
                Ray ray = cam.ScreenPointToRay(touch.position); // Cria um raio a partir da posição do toque
                RaycastHit hit;

                // Verifica se o raio colidiu com um objeto que tem a tag "Draggable"
                if (Physics.Raycast(ray, out hit) && hit.transform.CompareTag("Draggable"))
                {
                    activeTouches[touch.fingerId] = hit.transform; // Associa o ID do toque ao objeto tocado
                }
            }
            else if (touch.phase == TouchPhase.Moved && activeTouches.ContainsKey(touch.fingerId)) // Se o toque está se movendo e é um toque válido
            {
                // Converte a posição do toque na tela para o espaço do mundo
                Vector3 touchPosition = cam.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, cam.transform.position.y));

                // Move o objeto para a nova posição mantendo sua altura original
                activeTouches[touch.fingerId].position = new Vector3(touchPosition.x, activeTouches[touch.fingerId].position.y, touchPosition.z);
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) // Quando o toque termina ou é cancelado
            {
                activeTouches.Remove(touch.fingerId); // Remove o toque da lista de toques ativos
            }
        }
    }
}

