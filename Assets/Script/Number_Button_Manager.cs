using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;

public class Number_Button_Manager : MonoBehaviour
{
    double nr = 0;
    double nr2 = 0;
    double aux;
    string operatie = null;
    bool coma = false;
    bool nr1 = true;
    double p = 10;
    public TMP_Text Score;
    public TMP_Text Calc;

    void Afis()
    {
        if (nr1==true)
        {
            Score.text = nr.ToString();
        }
        else
        {
            Score.text = nr2.ToString();
        }
    }

    private void Start()
    {
        Afis();
    }

    public void Coma()
    {
        coma = true;
    }

    private void resetComa()
    {
        coma = false;
        p = 10;
    }

    public void equal()
    {
        aux = nr2;
        Calc.text = nr.ToString() + operatie + aux.ToString() + '=';
        if (operatie == "+")
            nr += aux;
        if (operatie == "-")
            nr -= aux;
        if (operatie == "*")
            nr *= aux;
        if (operatie == "/")
            nr /= aux;
        if (operatie == "^")
            nr = Math.Pow(nr, aux);
        nr1=true;
        Afis();
        resetComa();
        nr1= false;
    }

    public void Operatie(string Operatie)
    {
        resetComa();
        Calc.gameObject.SetActive(true);  
        if (operatie == null)
        {
            operatie = Operatie;
            nr1 = false;
        }
        else
        {
            if (operatie == "+")
                nr += nr2;
            if (operatie == "-")
                nr -= nr2;
            if (operatie == "*")
                nr *= nr2;
            if (operatie == "/")
                nr /= nr2;
            if (operatie == "^")
                nr = Math.Pow(nr, nr2);
            operatie = Operatie;
            nr2 = 0;
        }
        Afis();
        Calc.text = nr.ToString() + operatie;
    }

    public void procent()
    {
        if (nr1 == true)
            nr /= 100;
        else
            nr2 /= 100;
        Afis();
    }

    public void BACK()
    {
        if (nr1==true)
        {
            int x = (int)nr;
            x /= 10;
            nr = (float)x;
        }
        else
        {
            int x = (int)nr2;
            x /= 10;
            nr2 = (float)x;
        }
        Afis();
    }

    public void clear()
    {
        resetComa();
        Calc.gameObject.SetActive(false);
        nr = 0;
        nr2 = 0;
        p = 10f;
        nr1=true;
        operatie = null;
        Afis();
    }

    public void semn()
    {
        if (nr1 == true)
            nr = nr * (-1);
        else
            nr2 = nr2 * (-1);
        Afis();
    }

    public void Number(float number)
    {
        if (coma == false)
        {
            if (nr1 == true)
                nr = nr * 10 + number;
            else
                nr2 = nr2 * 10 + number;
        }
        else
        {
            if (nr1 == true)
            {
                nr = nr + number / p;
                p *= 10f;
            }
            else
            {
                nr2 = nr2 + number / p;
                p *= 10f;
            }
        }
        Afis();
    }
}
