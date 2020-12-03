using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections;

/// <summary>
/// Shuffle의 요약 설명입니다.
/// </summary>
public class Shuffle
{
    private Queue queue;
    private int psize = 0;

    public Shuffle(int size)
    {
        queue = new Queue(size);
        psize = size;

        setQueue();
    }    

    public string[] getQueue()
    {
        int basicNum = 3;
        string[] result = new string[basicNum];        

        result[0] = queue.Dequeue().ToString();
        result[1] = queue.Dequeue().ToString();
        result[2] = queue.Dequeue().ToString();

        return result;
    }

    public void setQueue()
    {
        int dAttack = Convert.ToInt32(psize * 0.55);
        int dMagic = Convert.ToInt32(psize * 0.25);
        int dDefense = Convert.ToInt32(psize * 0.2);

        int num = 0;
        Random rn = new Random();

        for (int i = 0; i < psize; i++)
        {
            num = rn.Next(1, 10);
            switch (num)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                    num = 1;
                    break;
                case 7:
                case 8:
                    num = 3;
                    break;
                case 9:                
                case 10:
                    num = 2;
                    break;
                default:
                    num = 1;
                    break;
            }            

            if (num == 1)
            {
                if (dAttack != 0)
                {
                    queue.Enqueue("공");
                    dAttack--;
                }
                else if (dMagic != 0)
                {
                    queue.Enqueue("마");
                    dMagic--;
                }
                else
                {
                    queue.Enqueue("방");
                    dDefense--;
                }
            } 
            else if (num == 2)
            {
                if (dMagic != 0)
                {
                    queue.Enqueue("마");
                    dMagic--;
                }
                else if (dAttack != 0)
                {
                    queue.Enqueue("공");
                    dAttack--;
                }
                else
                {
                    queue.Enqueue("방");
                    dDefense--;
                }
            }
            else if (num == 3)
            {
                if (dDefense != 0)
                {
                    queue.Enqueue("방");
                    dDefense--;
                }
                else if (dMagic != 0)
                {
                    queue.Enqueue("마");
                    dMagic--;
                }
                else
                {
                    queue.Enqueue("공");
                    dAttack--;
                }
            }
        }
    }

    public void initQueue()
    {
        queue.Clear();
    }

    public int lengthQueue()
    {
        return queue.Count;
    }
}
