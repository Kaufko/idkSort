using Plotly.NET;

//123 = seed (so testing is easier and more correct)
Random random = new Random(123);
//creates a random list of ints
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
    //timesRan is for testing
    int timesRan = 0;
    int tempIndex;
    int addIndex;
    if (size < 500) addIndex = 10;
    //finds suitable number to increase the index by
    else addIndex = (int)Math.Pow(10, size.ToString().Length / 2.55f);

    //iterates over every number in the array and sorts it
    for (int i = 0; i < size; i++)
    {
        tempIndex = addIndex;
        while (true)
        {
            timesRan++;
            //checks if index isn't out of range and if the current number is higher than the number at the temporary index
            if (tempIndex < size && list[i] > list[tempIndex])
            {
                tempIndex += addIndex;
                continue;
            }
            else
            {
                //removes addIndex from tempIndex so the current index is below correct index
                tempIndex -= addIndex;
                //goes up by 1 index and checks if it's the right index to insert at
                for (int j = tempIndex; j < size; j++)
                {
                    timesRan++;
                    //continues if the number it's sorting is higher than current index
                    if (list[i] > list[j])
                    {
                        continue;
                    }
                    else
                    {
                        int tempval = list[i];
                        //checks if the number we are sorting has a lower index than the one we are inserting at the temporary index
                        //if it is, we have to remove 1 from the index cause the position would not be correct
                        if (j > i) j--;
                        //removes number it's sorting and inserts it at the correct index
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

//Testing section
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


//this number is used to test arrays with length 1 -> siz
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
