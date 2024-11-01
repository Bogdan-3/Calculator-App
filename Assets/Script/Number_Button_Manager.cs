using UnityEngine;
using TMPro;

public class Number_Button_Manager : MonoBehaviour
{
    double nr = 0f;
    double nr2 = 0f;
    double aux;
    char operatie = '\0';
    bool calc = true;
    bool afis=false;
    public TMP_Text Score;
    public TMP_Text Calc;
    void Update()
    {
        if (operatie == '\0' || calc == true)
        {
            Score.text = nr.ToString();
            calc = false;
        }
        else if (nr2 != 0)
        {
            Score.text = nr2.ToString();
        }   
    }

    public void equal()
    {
        calc = true;
        if (nr2 != 0)
            aux = nr2;
        nr2 = 0;
        Calc.text = nr.ToString() + operatie + aux.ToString() + '=';
        if (operatie == '+')
            nr += aux;
        if (operatie == '-')
            nr -= aux;
        if (operatie == '*')
            nr *= aux;
        if (operatie == '/')
            nr /= aux;
    }

    public void Sum()
    {
        Calc.gameObject.SetActive(true);
        calc = false;
        if (operatie == '\0')
            operatie = '+';
        else if (nr2 != 0)
        {
            if (operatie == '+')
                nr += nr2;
            if (operatie == '-')
                nr -= nr2;
            if (operatie == '*')
                nr *= nr2;
            if (operatie == '/')
                nr /= nr2;
            operatie = '+';
            calc = true;
            nr2 = 0;
        }
        Calc.text = nr.ToString() + operatie;
    }

    public void Dif()
    {
        Calc.gameObject.SetActive(true);
        calc = false;
        if (operatie == '\0')
            operatie = '-';
        else if (nr2 != 0)
        {
            if (operatie == '+')
                nr += nr2;
            if (operatie == '-')
                nr -= nr2;
            if (operatie == '*')
                nr *= nr2;
            if (operatie == '/')
                nr /= nr2;
            operatie = '-';
            calc = true;
            nr2 = 0;
        }
        Calc.text = nr.ToString() + operatie;
    }

    public void Multiply()
    {
        Calc.gameObject.SetActive(true);
        calc = false;
        if (operatie == '\0')
            operatie = '*';
        else if (nr2 != 0)
        {
            if (operatie == '+')
                nr += nr2;
            if (operatie == '-')
                nr -= nr2;
            if (operatie == '*')
                nr *= nr2;
            if (operatie == '/')
                nr /= nr2;
            operatie = '*';
            calc = true;
            nr2 = 0;
        }
        Calc.text = nr.ToString() + operatie;
    }

    public void Division()
    {
        Calc.gameObject.SetActive(true);
        calc = false;
        if (operatie == '\0')
            operatie = '/';
        else if(nr2!=0)
        {
            if (operatie == '+')
                nr += nr2;
            if (operatie == '-')
                nr -= nr2;
            if (operatie == '*')
                nr *= nr2;
            if (operatie == '/')
                nr /= nr2;
            operatie = '/';
            calc = true;
            nr2 = 0;
        }
        Calc.text = nr.ToString() + operatie;
    }

    public void clear()
    {
        Calc.gameObject.SetActive(false);
        nr = 0;
        nr2 = 0;
        operatie = '\0';
    }

    public void zero()
    {
        if (nr <= 9999999999)
            if (operatie == '\0')
                nr = nr * 10 + 0;
            else
                nr2 = nr2 * 10 + 0;
    }

    public void one()
    {
        if (operatie == '\0')
            nr = nr * 10f + 1f;
        else
            nr2 = nr2 * 10f + 1f;
    }

    public void two()
    {
        if (operatie == '\0')
            nr = nr * 10f + 2f;
        else
            nr2 = nr2 * 10f + 2f;
    }

    public void three()
    {
        if (operatie == '\0')
            nr = nr * 10f + 3f;
        else
            nr2 = nr2 * 10f + 3f;
    }

    public void four()
    {
        if (operatie == '\0')
            nr = nr * 10f + 4f;
        else
            nr2 = nr2 * 10f + 4f;
    }

    public void five()
    {
        if (operatie == '\0')
            nr = nr * 10f + 5f;
        else
            nr2 = nr2 * 10f + 5f;
    }

    public void six()
    {
        if (operatie == '\0')
            nr = nr * 10f + 6f;
        else
            nr2 = nr2 * 10f + 6f;
    }

    public void seven()
    {
        if (operatie == '\0')
            nr = nr * 10f + 7f;
        else
            nr2 = nr2 * 10f + 7f;
    }

    public void eight()
    {
        if (operatie == '\0')
            nr = nr * 10f + 8f;
        else
            nr2 = nr2 * 10f + 8f;
    }

    public void nine()
    {
        if (operatie == '\0')
            nr = nr * 10f + 9f;
        else
            nr2 = nr2 * 10f + 9f;
    }
}
