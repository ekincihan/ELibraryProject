using System;
using System.Collections.Generic;
using System.Text;

namespace ELibrary.API.Base
{
    public abstract class SingletonBase<T>
     where T : SingletonBase<T>, new()
    {
        private static T _instance = new T();
        public static T Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}
