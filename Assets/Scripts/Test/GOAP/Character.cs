using TMPro;
using UnityEngine;

public class Character : MonoBehaviour
{
    public bool isAttack;
    public bool isMove;
    public void ShowText(string text)
    {
        Debug.Log(text);
    }
}
public class WindowsUI
{
    Rigidbody2D rb;
    Collider2D cl;
    public TextMeshProUGUI textAmountKIll;
    string currentText ;
    int amount;
    public void Update()
    {
        textAmountKIll.text = currentText;
    }
    public void GetAmountKill(int amount)
    {
        this.amount += amount;
        currentText = "Amount Kill - " + this.amount.ToString();
    }

    
}