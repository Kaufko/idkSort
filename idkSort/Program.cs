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

    for(int i = 0; i < size; i++)
    {
        for (int j = 0; j < size; j++) 
        {
            timesRan++;
            if(list[i] > list[j])
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
    return timesRan;
}
int size = 1000000;
Console.WriteLine(idkSort(CreateRandomList(size), size));