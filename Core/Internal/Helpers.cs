using System;
using System.IO;

namespace Benchmark.Internal {
    public static class ResourceHelper {
        public static Stream GetStream(string name, Type type) {
            return GetStream(name, type.Assembly);
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
        public static StreamReader CreateStreamReader(Type type, string name) {
            if(type == null)
                type = typeof(ResourceHelper);
            Stream stream = ResourceHelper.GetStream(name, type.Assembly);
            if(stream == null) return null;
            return new StreamReader(stream);
        }
        public static string GetString(Type type, string resourcePath) {
            StreamReader stream = CreateStreamReader(type, resourcePath);
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