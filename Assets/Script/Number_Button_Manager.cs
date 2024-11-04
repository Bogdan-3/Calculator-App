using UnityEngine;
using TMPro;
using System;

public class Number_Button_Manager : MonoBehaviour
{
    double nr = 0;
    double nr2 = 0;
    double aux;
    char operatie = '\0';
    bool calc = true;
    bool coma = false;
    double p=10;
    public TMP_Text Score;
    public TMP_Text Calc;

    void Afis()
    {
        if (operatie == '\0' || calc == true)
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
        Afis();
    }

    private void resetComa()
    {
        coma = false;
        p = 10;
    }

    public void equal()
    {
        calc = true;
        aux = nr2;
        Calc.text = nr.ToString() + operatie + aux.ToString() + '=';
        if (operatie == '+')
            nr += aux;
        if (operatie == '-')
            nr -= aux;
        if (operatie == '*')
            nr *= aux;
        if (operatie == '/')
            nr /= aux;
        if (operatie == '^')
            nr = Math.Pow(nr, aux);
        Afis();
        resetComa();
    }

    public void Sum()
    {
        resetComa() ;
        Calc.gameObject.SetActive(true);
        if (calc == true)
        {
            calc = false;
            operatie = '\0';
            nr2 = 0;
        }
        if (operatie == '\0')
        {
            operatie = '+';
        }
        else
        {
            if (operatie == '+')
                nr += nr2;
            if (operatie == '-')
                nr -= nr2;
            if (operatie == '*')
                nr *= nr2;
            if (operatie == '/')
                nr /= nr2;
            if (operatie == '^')
                nr = Math.Pow(nr, nr2);
            operatie = '+';
            calc = true;
            nr2 = 0;
        }
        Afis();
        Calc.text = nr.ToString() + operatie;
    }

    public void Dif()
    {
        resetComa();
        Calc.gameObject.SetActive(true);
        if (calc == true)
        {
            calc = false;
            operatie = '\0';
            nr2 = 0;
        }
        if (operatie == '\0')
        {
            operatie = '-';
        }
        else
        {
            if (operatie == '+')
                nr += nr2;
            if (operatie == '-')
                nr -= nr2;
            if (operatie == '*')
                nr *= nr2;
            if (operatie == '/')
                nr /= nr2;
            if (operatie == '^')
                nr = Math.Pow(nr, nr2);
            operatie = '-';
            calc = true;
            nr2 = 0;
        }
        Afis();
        Calc.text = nr.ToString() + operatie;
    }

    public void Multiply()
    {
        resetComa();
        Calc.gameObject.SetActive(true);
        if (calc == true)
        {
            calc = false;
            operatie = '\0';
            nr2 = 0;
        }
        if (operatie == '\0')
        {
            operatie = '*';
        }
        else
        {
            if (operatie == '+')
                nr += nr2;
            if (operatie == '-')
                nr -= nr2;
            if (operatie == '*')
                nr *= nr2;
            if (operatie == '/')
                nr /= nr2;
            if (operatie == '^')
                nr = Math.Pow(nr, nr2);
            operatie = '*';
            calc = true;
            nr2 = 0;
        }
        Afis();
        Calc.text = nr.ToString() + operatie;
    }

    public void Power()
    {
        resetComa();
        Calc.gameObject.SetActive(true);
        if (calc == true)
        {
            calc = false;
            operatie = '\0';
            nr2 = 0;
        }
        if (operatie == '\0')
        {
            operatie = '^';
        }
        else
        {
            if (operatie == '+')
                nr += nr2;
            if (operatie == '-')
                nr -= nr2;
            if (operatie == '*')
                nr *= nr2;
            if (operatie == '/')
                nr /= nr2;
            if (operatie == '^')
                nr = Math.Pow(nr, nr2);
            operatie = '^';
            calc = true;
            nr2 = 0;
        }
        Afis();
        Calc.text = nr.ToString() + operatie;
    }

    public void Division()
    {
        resetComa();
        Calc.gameObject.SetActive(true);
        if (calc == true)
        {
            calc = false;
            operatie = '\0';
            nr2 = 0;
        }
        if (operatie == '\0')
        {
            operatie = '/';
        }
        else
        {
            if (operatie == '+')
                nr += nr2;
            if (operatie == '-')
                nr -= nr2;
            if (operatie == '*')
                nr *= nr2;
            if (operatie == '/')
                nr /= nr2;
            if (operatie == '^')
                nr = Math.Pow(nr, nr2);
            operatie = '/';
            calc = true;
            nr2 = 0;
        }
        Afis();
        Calc.text = nr.ToString() + operatie;
    }

    public void procent()
    {
        if (operatie == '\0')
            nr /= 100;
        else
            nr2 /= 100;
        Afis();
    }

    public void clear()
    {
        resetComa();
        Calc.gameObject.SetActive(false);
        nr = 0;
        nr2 = 0;
        p = 10f;
        operatie = '\0';
        Afis();
    }

    public void semn()
    {
        if (operatie == '\0')
            nr = nr * (-1);
        else
            nr2 = nr2 * (-1);
        Afis();
    }

    public void zero()
    {
        if (coma == false)
        {
            if (operatie == '\0')
                nr = nr * 10 + 0f;
            else
                nr2 = nr2 * 10 + 0f;
        }
        else
        {
            if (operatie == '\0')
            {
                nr = nr + 0f / p;
                p *= 10f;
            }
            else
            {
                nr2 = nr2 + 0f/p;
                p *= 10f;
            }
        }
        Afis();
    }

    public void one()
    {
        if (coma == false)
        {
            if (operatie == '\0')
                nr = nr * 10 + 1;
            else
                nr2 = nr2 * 10 + 1;
        }
        else
        {
            if (operatie == '\0')
            {
                nr = nr + 1 / p;
                p *= 10;
            }
            else
            {
                nr2 = nr2 + 1 / p;
                p *= 10;
            }
        }
        Afis();
    }

    public void two()
    {
        if (coma == false)
        {
            if (operatie == '\0')
                nr = nr * 10 + 2;
            else
                nr2 = nr2 * 10 + 2;
        }
        else
        {
            if (operatie == '\0')
            {
                nr = nr + 2 / p;
                p *= 10;
            }
            else
            {
                nr2 = nr2 + 2 / p;
                p *= 10;
            }
        }
        Afis();
    }

    public void three()
    {
        if (coma == false)
        {
            if (operatie == '\0')
                nr = nr * 10 + 3;
            else
                nr2 = nr2 * 10 + 3;
        }
        else
        {
            if (operatie == '\0')
            {
                nr = nr + 3 / p;
                p *= 10;
            }
            else
            {
                nr2 = nr2 + 3 / p;
                p *= 10;
            }
        }
        Afis();
    }

    public void four()
    {
        if (coma == false)
        {
            if (operatie == '\0')
                nr = nr * 10 + 4;
            else
                nr2 = nr2 * 10 + 4;
        }
        else
        {
            if (operatie == '\0')
            {
                nr = nr + 4 / p;
                p *= 10;
            }
            else
            {
                nr2 = nr2 + 4 / p;
                p *= 10;
            }
        }
        Afis();
    }

    public void five()
    {
        if (coma == false)
        {
            if (operatie == '\0')
                nr = nr * 10 + 5;
            else
                nr2 = nr2 * 10 + 5;
        }
        else
        {
            if (operatie == '\0')
            {
                nr = nr + 5 / p;
                p *= 10;
            }
            else
            {
                nr2 = nr2 + 5 / p;
                p *= 10;
            }
        }
        Afis();
    }

    public void six()
    {
        if (coma == false)
        {
            if (operatie == '\0')
                nr = nr * 10 + 6;
            else
                nr2 = nr2 * 10 + 6;
        }
        else
        {
            if (operatie == '\0')
            {
                nr = nr + 6 / p;
                p *= 10;
            }
            else
            {
                nr2 = nr2 + 6 / p;
                p *= 10;
            }
        }
        Afis();
    }

    public void seven()
    {
        if (coma == false)
        {
            if (operatie == '\0')
                nr = nr * 10 + 7;
            else
                nr2 = nr2 * 10 + 7;
        }
        else
        {
            if (operatie == '\0')
            {
                nr = nr + 7 / p;
                p *= 10;
            }
            else
            {
                nr2 = nr2 + 7 / p;
                p *= 10;
            }
        }
        Afis();
    }

    public void eight()
    {
        if (coma == false)
        {
            if (operatie == '\0')
                nr = nr * 10 + 8;
            else
                nr2 = nr2 * 10 + 8;
        }
        else
        {
            if (operatie == '\0')
            {
                nr = nr + 8 / p;
                p *= 10;
            }
            else
            {
                nr2 = nr2 + 8 / p;
                p *= 10;
            }
        }
        Afis();
    }

    public void nine()
    {
        if (coma == false)
        {
            if (operatie == '\0')
                nr = nr * 10 + 9;
            else
                nr2 = nr2 * 10 + 9;
        }
        else
        {
            if (operatie == '\0')
            {
                nr = nr + 9 / p;
                p *= 10;
            }
            else
            {
                nr2 = nr2 + 9 / p;
                p *= 10;
            }
        }
        Afis();
    }
}
