using Newtonsoft.Json.Linq;

namespace MWS.Business.Shared.Business.Business
{

    public delegate object retObjFunc();


    public interface IValueHelper
    {
        string getOneOfTwoStrings(string strInput, string strSpare);

        string toStringSave(object value);

        string toStringSave(retObjFunc func);
        T toTypeSave<T>(retObjFunc func);
        T toTypeObjSave<T>(object value);


        List<string> toListSave(string str, string splitter = ",");
        List<string> toListSave(retObjFunc func, string splitter = ",");

        void copyObjectToObject(object source, object dest);
        T createDestFromSource<T>(object source) where T : class;

        object toTypeOrStringSafe(retObjFunc func);

        object toTypeOrStringObjSave(object val);

        T NVL<T>(T val, T nullVal);

        string getNullValue(object val);

        bool ValIn(object val, params object[] values);

        object Decode(params object[] values);

    }
    public class ValueHelper : IValueHelper
    {
        public string getNullValue(object val)
        {
            if (val == null)
                return null;

            return val.ToString();
        }

        public object toTypeOrStringObjSave(object value)
        {
            if (value == null)
            {
                return "";
            }
            return value;
        }


        public object toTypeOrStringSafe(retObjFunc func)
        {
            object val = null;
            try
            {
                val = func();
            }
            catch
            {
                val = null;
            }
            return this.toTypeOrStringObjSave(val);
        }


        public string toStringSave(object value)
        {
            if (value == null)
            {
                return "";
            }

            return value.ToString();
        }

        public string toStringSave(retObjFunc func)
        {
            object val = null;
            try
            {
                val = func();
            }
            catch
            {
                val = null;
            }

            return this.toStringSave(val);
        }


        public T toTypeObjSave<T>(object value)
        {
            try
            {
                if (value == null)
                {
                    return default(T);
                }


                JToken token = JToken.FromObject(value);
                T ret = token.ToObject<T>();
                return ret;
            }
            catch
            {
                return default(T);
            }
        }

        public T toTypeSave<T>(retObjFunc func)
        {
            object val = null;
            try
            {
                val = func();
            }
            catch
            {
                val = null;
            }

            return this.toTypeObjSave<T>(val);
        }






        public string getOneOfTwoStrings(string strInput, string strSpare)
        {
            if (string.IsNullOrWhiteSpace(strInput) && string.IsNullOrWhiteSpace(strSpare))
            {
                return "";
            }
            if (!string.IsNullOrWhiteSpace(strInput))
                return strInput;

            return strSpare;
        }

        public List<string> toListSave(string str, string splitter = ",")
        {
            if (string.IsNullOrWhiteSpace(str))
                return new List<string>();

            var lstRet = str.Split(new string[] { splitter }, StringSplitOptions.RemoveEmptyEntries).ToList();
            return lstRet;
        }


        public List<string> toListSave(retObjFunc func, string splitter = ",")
        {
            object val = null;
            try
            {
                val = func();
            }
            catch
            {
                val = null;
            }

            string str = this.toStringSave(val);
            return this.toListSave(str, splitter);


        }

        public T createDestFromSource<T>(object source) where T : class
        {
            T dest = null;
            if (source == null)
            {
                dest = null;
                return dest;
            }
            var sourceToken = JToken.FromObject(source);
            var destToken = sourceToken;
            dest = (T)destToken.ToObject(typeof(T));
            return dest;
        }

        public void copyObjectToObject(object source, object dest)
        {


            var properties = source.GetType().GetProperties();
            if (properties.Length > 0)
            {
                foreach (var prop in properties)
                {
                    try
                    {
                        if (prop.GetValue(source) != null)
                        {

                            var value = prop.GetValue(source);
                            if (!string.IsNullOrWhiteSpace(value.ToString()))
                            {
                                prop.SetValue(dest, value);
                            }

                        }
                    }
                    catch
                    {
                    }
                }
            }

        }


        public T NVL<T>(T val, T nullVal)
        {
            if (val == null)
            {
                return nullVal;

            }

            return val;
        }

        public bool ValIn(object val, params object[] values)
        {
            foreach (var v in values)
            {
                if (val == v)
                {
                    return true;
                }
            }

            return false;
        }

        public object Decode(params object[] values)
        {
            object el = null;
            if (values.Length % 2 == 0)
            {
                el = values[values.Length - 1];
                values = values.Take(values.Length - 1).ToArray();
            }



            for (int i = 1; i < values.Length; i += 2)
            {
                if (values[0] == values[i])
                {
                    return values[i + 1];
                }
            }

            return el;


        }
    }
}
