using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankInterface
{
    public interface ICard
    {
        //账户金额
        double Money { get; set; }
        //获取账户信息
        string GetCountInfo();
        //存钱
        void SaveMoney(double money);
        //取钱
        void CheckOutMoney(double money);
    }
    public interface IMetaData
    {
        string CardType { get; }
    }

    //在接口上面写注解，这样只要实现了这个接口的类都会导出，而不需要在每个类上面都写注解
    [InheritedExport]
    public interface ICard2
    {
        //账户金额
        double Money { get; set; }
        //获取账户信息
        string GetCountInfo();
        //存钱
        void SaveMoney(double money);
        //取钱
        void CheckOutMoney(double money);
    }
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ExportCardAttribute : ExportAttribute
    {
        public ExportCardAttribute()
           : base(typeof(ICard))
        {
        }

        public string CardType { get; set; }
    }
}
