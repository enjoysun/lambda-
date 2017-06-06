using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    using System.Linq.Expressions;
    class Program
    {
        static void Main(string[] args)
        {
            //var test = new testwebservice.BasicDataService();
            //Parallel.For(10, 20, c =>
            //{
            //    test.Errorlogrecardtodb("test", c.ToString(), "三星", 0, null, null);
            //});
            //var user=typeof(User).GetProperties();
            //foreach (var item in user)
            //{
            //    Console.WriteLine(item.Name);
            //}
            //Console.ReadKey();
            Expression<Func<User, User>> la = c => new User() { UserName = "123", UserPassWord = "456", UserBirthday = DateTime.Now };
            string str = Getexpstr(la.Body as MemberInitExpression);
            Console.WriteLine(str);
            Console.WriteLine("-------------------------------------------------------");
            //Expression<Func<User, bool>> where = c => c.UserID > 6;
            //Console.WriteLine(ResolveExpression<User>(where));
            Console.ReadKey();
        }


        public static string Getcanstr(ConstantExpression exp)
        {
            string str = string.Empty;
            object obj = exp.Value;
            if (obj is string)
            {
                str = string.Format("'{0}'", obj.ToString());
            }
            else if (obj is DateTime)
            {
                DateTime time = (DateTime)obj;
                str = string.Format("'{0}'", time.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else
            {
                str = obj.ToString();
            }
            return str;
        }
        public static string Getexpstr(MemberInitExpression exp)
        {
            string str = string.Empty;
            List<string> member = new List<string>();
            //注; item必须为MemberAssignment类型否者没有expression属性
            foreach (MemberAssignment item in exp.Bindings)
            {
                if (item.Expression.NodeType == ExpressionType.Constant)
                {
                    String update = item.Member.Name + "=" + Getcanstr((ConstantExpression)item.Expression);
                    member.Add(update);
                }
                else if (item.Expression.NodeType == ExpressionType.MemberAccess)
                {
                    var bin = (BinaryExpression)item.Expression;
                }

            }
            str = string.Join(",", member);
            return str;

        }

        #region 解析lambda中含有一个表达式
        public static string ResolveExpression<T>(Expression<Func<T, bool>> where)
        {
            var binarytype = where.Body as BinaryExpression;
            var leftnode = binarytype.Left as MemberExpression;
            var rightnode = binarytype.Right as ConstantExpression;
            return string.Format("{0} {2} {1}", leftnode.Member.Name, rightnode.Value, TransferExpressionType(binarytype.NodeType));
        }
        public static string TransferExpressionType(ExpressionType expressionType)
        {
            string type = "";
            switch (expressionType)
            {
                case ExpressionType.Equal:
                    type = "="; break;
                case ExpressionType.GreaterThanOrEqual:
                    type = ">="; break;
                case ExpressionType.LessThanOrEqual:
                    type = "<="; break;
                case ExpressionType.NotEqual:
                    type = "!="; break;
                case ExpressionType.AndAlso:
                    type = "And"; break;
                case ExpressionType.OrElse:
                    type = "Or"; break;
                case ExpressionType.GreaterThan:
                    type = ">";break;
                case ExpressionType.LessThan:
                    type = "<"; break;
            }
            return type;
        }
        
        #endregion

    }
}
