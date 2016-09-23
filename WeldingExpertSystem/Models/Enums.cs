using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Data.Entity;

namespace WeldingExpertSystem.Models
{
    public enum UserRole
    {
        焊工,
        工程师,
        高级工程师,
        管理员
    }

    public enum WelderLevel
    {
        初级焊工,
        中级焊工,
        高级焊工,
        初级焊师,
        中级焊师,
        高级焊师,
        初级焊接专家,
        中级焊接专家,
        高级焊接专家
    }

    public enum MechanLevel
    {
        手动,
        机械,
        半自动,
        自动
    }

    public class Enum<T>
    {
        public int Index { get; set; }
        public string Name { get; set; }

        public Enum(int val)
        {
            Index = val;
            Name = Enum.GetName(typeof(T), val);
        }

        public static List<Enum<T>> GetValues()
        {
            if (!typeof(T).IsEnum)
                throw new Exception("泛型参数类型不是枚举");

            Array arr = System.Enum.GetValues(typeof(T));
            List<Enum<T>> opts = new List<Enum<T>>();

            for (int i = 0; i < arr.Length; i++)
            {
                opts.Add(new Enum<T>(i));
            }

            return opts;
        }

        public static SelectList GetSelectList()
        {
            return new SelectList(GetValues(), "Index", "Name");
        }
    }

    /*
    public class MechanLevel : Enum
    {
        static Dictionary<int, string> dict = new Dictionary<int, string>
        {
            {0, "手工"},{1, "机械"},{2, "半自动"},{3, "自动"}
        };

        public MechanLevel(int val)
        {
            Value = val;
            Name = dict[val];
        }

        public static List<MechanLevel> GetAllOptions()
        {
            List<MechanLevel> opts = new List<MechanLevel>();
            foreach (var v in dict)
            {
                opts.Add(new MechanLevel(v.Key));
            }

            return opts;
        }
    }*/
}
