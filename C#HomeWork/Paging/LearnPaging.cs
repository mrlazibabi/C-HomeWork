using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paging
{
    public class LearnPaging
    {
        private List<int> data;

        public LearnPaging()
        {
            data = Enumerable.Range(0, 50).ToList();
        }

        public List<int> Paging(int pageIndex = 0, int pageSize = 10)
        {
            return data.Skip(pageIndex * pageSize).Take(pageSize).ToList();
        }

        public int TotalPages(int pageSize)
        {
            return (int)Math.Ceiling((double)data.Count / pageSize);
        }
    }
}
