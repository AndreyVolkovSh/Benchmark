using System;
using System.IO;

namespace Benchmark.Internal {
    public static class ResourceHelper {
        public static Stream GetStream(string name, Type type) {
            return GetStream(GetResourceName(type, name), type.Assembly);
        }
        public static Stream GetStream(string name, System.Reflection.Assembly asm) {
            return asm.GetManifestResourceStream(name);
        }
        public static byte[] GetBytes(string name, System.Reflection.Assembly asm) {
            using(Stream stream = GetStream(name, asm)) {
                byte[] bytes = new byte[stream.Length];
                stream.Read(bytes, 0, bytes.Length);
                return bytes;
            }
        }
        public static string GetResourceName(Type baseType, string name) {
            return string.Format("{0}.{1}", baseType.Namespace, name);
        }
        public static StreamReader CreateStreamReader(string resourcePath) {
            Stream stream = ResourceHelper.GetStream(resourcePath, typeof(ResourceHelper).Assembly);
            if(stream == null) return null;
            return new StreamReader(stream);
        }
        public static string GetString(string resourcePath) {
            StreamReader stream = CreateStreamReader(resourcePath);
            if(stream == null) return null;
            return stream.ReadToEnd();
        }
    }
    public static class AttributeHelper {
        public static T GetAttribute<T>(System.Reflection.MemberInfo type) where T : Attribute {
            Attribute attribute = null;
            try {
                if(type != null)
                    attribute = Attribute.GetCustomAttribute(type, typeof(T));
            }
            catch { }
            return attribute == null ? null : (T)attribute;
        }
        public static T GetAssemblyAttribute<T>(System.Reflection.Assembly assembly) where T : Attribute {
            object[] attributes = assembly.GetCustomAttributes(typeof(T), false);
            if(attributes == null || attributes.Length == 0) return null;
            return (T)attributes[0];
        }
    }
}