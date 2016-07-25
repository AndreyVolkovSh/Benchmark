using System;
using System.IO;

namespace Benchmark.Internal {
    public static class ResourceStreamHelper {
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
    }
}