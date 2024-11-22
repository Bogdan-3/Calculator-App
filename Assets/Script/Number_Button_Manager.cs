using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;

public class Number_Button_Manager : MonoBehaviour
{
    bool Semn = true;
    double nr = 0;
    double nr2 = 0;
    double aux;
    string operatie = null;
    bool coma = false;
    bool nr1 = true;
    bool egal = false;
    double p = 10;
    public TMP_Text Score;
    public TMP_Text Calc;

    void Afis()
    {
        if (nr1 == true)
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
        Semn = true;
        aux = nr2;
        egal = true;
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
        nr1 = true;
        Afis();
        resetComa();
    }

    public void Operatie(string Operatie)
    {
        resetComa();
        Calc.gameObject.SetActive(true);
        Semn = true;
        if (egal == true)
        {
            egal = false;
            operatie = null;
            nr2 = 0;
        }
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
        if (nr1 == true)
        {
            if (coma == false)
            {
                int x = (int)nr;
                x /= 10;
                nr = (float)x;
            }
            else
            {
                nr = nr * p;
                int x = (int)nr;
                x /= 10;
                nr = (float)x;
                if (p > 10)
                {
                    p /= 10;
                    nr /= p;
                }
            }
        }
        else
        {
            if (coma == false)
            {
                int x = (int)nr2;
                x /= 10;
                nr2 = (float)x;
            }
            else
            {

                nr2 = nr2 * p;
                int x = (int)nr2;
                x /= 10;
                nr2 = (float)x;
                if (p > 10)
                {
                    p /= 10;
                    nr2 /= p;
                }
            }
        }
        Afis();
    }

    public void clearEntry()
    {
        resetComa();
        if (nr1 == true)
            nr = 0;
        else
            nr2 = 0;
        p = 10f;
        Semn=true;
        Afis();
    }

    public void clear()
    {
        resetComa();
        Calc.gameObject.SetActive(false);
        nr = 0;
        nr2 = 0;
        p = 10f;
        nr1 = true;
        Semn=true;
        operatie = null;
        Afis();
    }

    public void semn()
    {
        if (Semn == true)
            Semn = false;
        else
            Semn = true;
        if (nr1 == true)
            nr = nr * (-1);
        else
            nr2 = nr2 * (-1);
        Afis();
    }

    public void fraction()
    {
        Calc.gameObject.SetActive(true);
        Calc.text = "1/" + nr.ToString();
        if (nr1 == true)
            nr = 1 / nr;
        else
            nr2 = 1 / nr2;
        Afis();
    }

    public void sqrt()
    {
        Calc.gameObject.SetActive(true);
        Calc.text = "√" + nr.ToString();
        if (nr1 == true)
            nr = Math.Sqrt(nr);
        else
            nr2 = Math.Sqrt(nr2);
        Afis();
    }

    public void Number(float number)
    {
        if (coma == false)
        {
            if (Semn == true)
            {
                if (nr1 == true)
                    nr = nr * 10 + number;
                else
                    nr2 = nr2 * 10 + number;
            }
            else
            {
                if (nr1 == true)
                    nr = nr * 10 + number * (-1);
                else
                    nr2 = nr2 * 10 + number * (-1);
            }
        }
        else
        {
            if (Semn == true)
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
            else
            {
                if (nr1 == true)
                {
                    nr = nr + number / p * (-1);
                    p *= 10f;
                }
                else
                {
                    nr2 = nr2 + number / p * (-1);
                    p *= 10f;
                }
            }
        }
        Afis();
    }
}
