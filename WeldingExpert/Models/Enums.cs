using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Data.Entity;

namespace WeldingExpert.Models
{
    public enum UserRoleEnum
    {
        Worker,
        Engineer,
        SeniorEngineer,
        Admin,
        End
    }

    public class UserRole
    {
        public int Value { get; set; }
        public string Name { get; set; }

        public UserRole(int val)
        {
            Value = val;
            Name = ((UserRoleEnum)val).ToString();
        }

        public static SelectList GetSelectList()
        {
            List<UserRole> levels = new List<UserRole>();

            for (int level = 0; level < (int)UserRoleEnum.End; level++)
            {
                levels.Add(new UserRole(level));
            }

            return new SelectList(levels, "Value", "Name");
        }
    }

    public enum WelderLevelEnum
    {
        初级焊工,
        中级焊工,
        高级焊工,
        初级焊师,
        中级焊师,
        高级焊师,
        初级焊接专家,
        中级焊接专家,
        高级焊接专家,
        End,
    }

    public class WelderLevel
    {
        [Key]
        public int Value { get; set; }
        public string Name { get; set; }

        public WelderLevel(int val)
        {
            Value = val;
            Name = ((WelderLevelEnum)val).ToString();
        }

        public static List<WelderLevel> GetAllLevels()
        {
            List<WelderLevel> levels = new List<WelderLevel>();

            for (int level = 0; level < (int)WelderLevelEnum.End; level++)
            {
                levels.Add(new WelderLevel(level));
            }

            WelderLevelEnum e = WelderLevelEnum.End;

            e.Equals(1);

            return levels;
        }
    }

    public class Enum<T> where T : struct
    {
        public int Value { get; set; }
        public string Name { get; set; }

        public Enum(int val)
        {
            Value = val;
            Name = Enum.GetName(typeof(T), val);
        }

        public static List<Enum<T>> GetAllOptions()
        {
            if (typeof(T).IsEnum)
            {
                Array arr = System.Enum.GetValues(typeof(T));
                List<Enum<T>> opts = new List<Enum<T>>();

                for (int i = 0; i < arr.Length - 1; i++)
                {
                    opts.Add(new Enum<T>(arr[i]));
                }
                return opts;
            }


            return null;
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
