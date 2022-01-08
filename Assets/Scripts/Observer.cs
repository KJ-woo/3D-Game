using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player; //gameending에서는 Object로 선언하고 여기서는 Transform으로 사용하는 이유?
    public GameEnding gameEnding;
    

    bool m_IsplayerInRange;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            m_IsplayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform ==player)
        {
            m_IsplayerInRange = false;
        }
    }

    void Update()
    {
        if (m_IsplayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;//벡터는 A부터 B까지의 벡터는 B-A이므로 그래서
            // PointOfView 게임오브젝트에서 JohnLemon까지의 방향임
            //JohnLemon의 포지션은 두 발 사이의 지면임. 따라서 관찰자가 JohnLemon의 질량 중심을 볼 수 있도록 Vector3.up을 추가하여
            //방향을 한단위 위로 향하게 함 Vecor3.Up은 (0,1,0)의 단축키라고 보면됨 up, left, down, right 다 존재함.
            //이건 방향키 입력하는 값으로써 사용된적이 존재함.

            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            if(Physics.Raycast(ray, out raycastHit))// 뜻 정확하게 이해하지 못함.
            {
                if (raycastHit.collider.transform == player)
                {
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }
}
