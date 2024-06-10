using Microsoft.VisualBasic.FileIO;
using System.ComponentModel.Design;

Random random = new Random();
List<int> CreateRandomList(int size)
{
    List<int> list = new List<int>();
    for (int i = 0; i < size; i++)
    {
        list.Add(random.Next(0, size));
    }
    return list;
}

int idkSort(List<int> list, int size)
{
    int timesRan = 0;
    int tempIndex;
    int addIndex;
    if (size < 1000) addIndex = 10;
    else addIndex = (int) Math.Pow(10, size.ToString().Length / 2);

    for (int i = 0; i < size; i++)
    {
        tempIndex = addIndex;
        while(true)
        {
            timesRan++;
            if (tempIndex < size && list[i] > list[tempIndex])
            {
                tempIndex += addIndex;
                continue;
            }
            else
            {
                tempIndex -= addIndex;
                for (int j = tempIndex; j < size; j++)
                {
                    timesRan++;
                    if (list[i] > list[j])
                    {
                        continue;
                    }
                    else
                    {
                        int tempval = list[i];
                        if (j > i) j--;
                        list.RemoveAt(i);
                        list.Insert(j, tempval);
                        break;
                    }
                }
            }
            break;
        }
    }
    return timesRan;
}
int siz = 100000;
Console.WriteLine(idkSort(CreateRandomList(siz), siz));
