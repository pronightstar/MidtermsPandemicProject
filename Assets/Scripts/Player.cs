using UnityEngine;

public class Player : MonoBehaviour
{
    Vector2 pos;
    bool isPlayerTurn = true;
    bool canPlayerAct = true;
    
    private void Start()
    {
        pos = transform.position;
    }

    public Vector2 GetPosition()
    {
        return pos;
    }

    public void SetPosition(Vector2 newPos)
    {
        pos = newPos;
        transform.position = newPos;
    }

    public bool GetPlayerTurn()
    {
        return isPlayerTurn;
    }

    public void SetPlayerTurn(bool hi)
    {
        isPlayerTurn = hi;
    }

    public bool GetPlayerAct()
    {
        return canPlayerAct;
    }

    public void SetPlayerAct(bool hi)
    {
        canPlayerAct = hi;
    }

    private void Update()
    {
        if ((Vector2)transform.position != pos)
        {
            transform.position = pos;
        }
    }
}
