using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUnitGrouping
{
    public class GroupingService
    {
        //public List<int> Grouping(List<Order> source, int groupSize)
        //{
        //    List<int> result = new List<int>();

        //    if (groupSize < 1)
        //        throw new ArgumentException("size should >0");

        //    int groupSet = source.Count / groupSize;
        //    int remainder = source.Count % groupSize;

        //    for (int indexCount = 0; indexCount <= groupSet; indexCount ++)
        //    {
        //        var groupSource = source.GetRange(indexCount * groupSize, groupSet == indexCount ? remainder : groupSize);
        //        int sum = 0;
        //        foreach(var s in groupSource)
        //        {
        //            sum += s.Cost;
        //        }

        //        result.Add(sum);
        //    }

        //    return result;
        //}

        //public List<int> Grouping(List<Order> source, int groupSize, Func<Order, int> selectProp)
        //{
        //    List<int> result = new List<int>();

        //    if (groupSize < 1)
        //        throw new ArgumentException("size should >0");

        //    int groupSet = source.Count / groupSize;
        //    int remainder = source.Count % groupSize;

        //    for (int indexCount = 0; indexCount <= groupSet; indexCount++)
        //    {
        //        var groupSource = source.GetRange(indexCount * groupSize, groupSet == indexCount ? remainder : groupSize);
        //        int sum = 0;
        //        foreach (var s in groupSource)
        //        {
        //            sum += selectProp(s);
        //        }

        //        result.Add(sum);
        //    }

        //    return result;
        //}

        public IEnumerable<int> Grouping<T>(IEnumerable<T> source, int groupSize, Func<T, int> selectProp)
        {
            //List<int> result = new List<int>();

            if (groupSize < 1)
                throw new ArgumentException("size should >0");

            int groupSet = source.Count() / groupSize;
            int remainder = source.Count() % groupSize;

            for (int indexCount = 0; indexCount <= groupSet; indexCount++)
            {
                var groupSource = source.Skip(indexCount * groupSize).Take(groupSet == indexCount ? remainder : groupSize);
                int sum = 0;
                foreach (var s in groupSource)
                {
                    sum += selectProp(s);
                }

                yield return (sum);
                //result.Add(sum);
            }

            //return result;
        }
    }
}
