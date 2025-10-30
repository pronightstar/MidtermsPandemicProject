using UnityEngine;

public class Die : MonoBehaviour
{
    public int RollDice()
    {
        float diceRoll = Random.Range(0, 14);
        return (int)diceRoll;
    }
}