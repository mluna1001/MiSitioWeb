using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace Comun.Tool
{
    public static class ExtMethods
    {
        public static bool IsNullEmpty(this string cadena)
        {
            if (string.IsNullOrEmpty(cadena) || string.IsNullOrWhiteSpace(cadena))
                return true;

            return false;
        }

        #region Parse

        public static string ToJson(this object obj)
        {
            //var ti = obj.GetType().GetTypeInfo().GenericTypeArguments[0];
            //if (obj == null) return default(ti);
            //var t = obj ? (T)(object)typedValue : default(T);

            var jsonResolver = new IgnorableSerializerContractResolver();
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                PreserveReferencesHandling = PreserveReferencesHandling.None,
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ContractResolver = jsonResolver,
                NullValueHandling = NullValueHandling.Ignore,
                TypeNameHandling = TypeNameHandling.None,
                Binder = new EntityFrameworkSerializationBinder()
            };
            string json = JsonConvert.SerializeObject(obj, settings);
            return json;
        }

        public static T To<T>(this object obj)
        {
            if (obj == null) return default(T);

            var jsonResolver = new IgnorableSerializerContractResolver();

            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                PreserveReferencesHandling = PreserveReferencesHandling.None,
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ContractResolver = jsonResolver,
                NullValueHandling = NullValueHandling.Ignore,
                TypeNameHandling = TypeNameHandling.None,
                Binder = new EntityFrameworkSerializationBinder()
            };
            string json = JsonConvert.SerializeObject(obj, settings);

            T res = JsonConvert.DeserializeObject<T>(json);

            return res;
        }

        public static string XMLFromObject(this object o)
        {
            StringWriter sw = new StringWriter();
            XmlTextWriter tw = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(o.GetType());
                tw = new XmlTextWriter(sw);
                serializer.Serialize(tw, o);
            }
            catch (Exception ex)
            {
                //Handle Exception Code
                //ex.ToError();
            }
            finally
            {
                sw.Close();
                if (tw != null)
                {
                    tw.Close();
                }
            }
            return sw.ToString();
        }

        #endregion Parse
    }

    public class IgnorableSerializerContractResolver : DefaultContractResolver
    {
        protected readonly Dictionary<Type, HashSet<string>> Ignores;

        public IgnorableSerializerContractResolver()
        {
            this.Ignores = new Dictionary<Type, HashSet<string>>();
        }

        /// <summary>
        /// Explicitly ignore the given property(s) for the given type
        /// </summary>
        /// <param name="type"></param>
        /// <param name="propertyName">one or more properties to ignore.  Leave empty to ignore the type entirely.</param>
        public void Ignore(Type type, params string[] propertyName)
        {
            // start bucket if DNE
            if (!this.Ignores.ContainsKey(type)) this.Ignores[type] = new HashSet<string>();

            foreach (var prop in propertyName)
            {
                this.Ignores[type].Add(prop);
            }
        }

        /// <summary>
        /// Is the given property for the given type ignored?
        /// </summary>
        /// <param name="type"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public bool IsIgnored(Type type, string propertyName)
        {
            if (!this.Ignores.ContainsKey(type)) return false;

            // if no properties provided, ignore the type entirely
            if (this.Ignores[type].Count == 0) return true;

            return this.Ignores[type].Contains(propertyName);
        }

        /// <summary>
        /// The decision logic goes here
        /// </summary>
        /// <param name="member"></param>
        /// <param name="memberSerialization"></param>
        /// <returns></returns>
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty prop = base.CreateProperty(member, memberSerialization);
            var propInfo = member as PropertyInfo;
            if (propInfo != null)
            {
                if (propInfo.GetMethod.IsVirtual && !propInfo.GetMethod.IsFinal)
                {
                    prop.ShouldSerialize = obj => false;
                }
            }

            return prop;
            //JsonProperty property = base.CreateProperty(member, memberSerialization);

            //if (this.IsIgnored(property.DeclaringType, property.PropertyName)
            //// need to check basetype as well for EF -- @per comment by user576838
            //|| this.IsIgnored(property.DeclaringType.BaseType, property.PropertyName))
            //{
            //    property.ShouldSerialize = instance => { return false; };
            //}

            //return property;
        }
    }

    internal class EntityFrameworkSerializationBinder : SerializationBinder
    {
        public override void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            assemblyName = null;

            if (serializedType.Namespace == "System.Data.Entity.DynamicProxies")
                typeName = serializedType.BaseType.FullName;
            else
                typeName = serializedType.FullName;
        }

        public override Type BindToType(string assemblyName, string typeName)
        {
            throw new NotImplementedException();
        }
    }
}