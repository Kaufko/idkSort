using Plotly.NET;

Random random = new Random(123);
List<int> CreateRandomList(int size)
{
    List<int> list = new List<int>();
    for (int i = 0; i < size; i++)
    {
        list.Add(random.Next(0, size));
    }
    return list;
}

int IdkSort(List<int> list, int size)
{
    int timesRan = 0;
    int tempIndex;
    int addIndex;
    if (size < 1000) addIndex = 10;
    else addIndex = (int)Math.Pow(10, size.ToString().Length / 2.55f);

    for (int i = 0; i < size; i++)
    {
        tempIndex = addIndex;
        while (true)
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

int Sort(int size)
{
    int temp = 0;
    for (int i = 0; i < 5; i++)
    {
        temp += IdkSort(CreateRandomList(size), size);
    }
    Console.WriteLine(Convert.ToInt32((float)temp / 5));
    return Convert.ToInt32((float)temp / 5);
}


int siz = 10000;

List<int> resultList = new List<int>();

for(int i = 1; i < siz; i++)
{
    resultList.Add(Sort(i));
}

Plotly.NET.CSharp.Chart.Point<int, int, string>(
    x: resultList,
    y: Enumerable.Range(1, siz).ToList()
)
.WithTraceInfo("IdkSort")
.Show();
