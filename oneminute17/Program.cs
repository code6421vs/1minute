using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oneminute17
{
    class Program
    {
        public static string ToChinese(ulong value)
        {
            string[] number = { "零", "壹", "貳", "叁", "肆", "伍", "陸", "柒", "捌", "玖" };
            string[] unit = { "", "拾", "佰", "仟", "萬", "拾", "佰", "仟", "億", "拾", "佰", "仟", "兆", "拾", "佰", "仟" };
            string temp = value.ToString();

            return string.Join("",
                temp.Select((a, idx) => number[(int)a - '0'] + unit[(temp.Length - (idx + 1)) % 16]));
        }

        static void Main(string[] args)
        {
            Console.WriteLine(ToChinese(135790));
            Console.ReadLine();
        }
    }
}
