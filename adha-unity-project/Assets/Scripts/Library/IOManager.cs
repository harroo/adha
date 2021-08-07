
// useful for unity

// basicly just changes all io calls to be in
// users home directory, useful

// DEPS: UNITYENGINE;

using UnityEngine;

using System;
using System.IO;

namespace IOManager {

    public static class IOManager {

        public static string homeDir;

        public static string GetBase () {

            if (!booted) Boot();

            return homeDir + "/";
        }
        public static string GetBase (string s)  {

            if (!booted) Boot();

            return homeDir + "/" + s;
        }

        private static bool booted = false;

        [RuntimeInitializeOnLoadMethod]
        public static void Boot () {

            if (booted) return;
            booted = true;

            if (Application.platform == RuntimePlatform.LinuxPlayer || Application.platform == RuntimePlatform.LinuxEditor) {

                homeDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/.adha";

            } else if (Application.platform == RuntimePlatform.WindowsPlayer) {

                homeDir = "C:/Users/" + Environment.UserName + "/AppData/Roaming/.adha";

            } else {

                homeDir = ".adha";
            }

            if (!Directory.Exists(homeDir))
                Directory.CreateDirectory(homeDir);
        }
    }

    public static class IOMFile {

        public static byte[] ReadAllBytes (string path) {

            if (File.Exists(IOManager.GetBase(path)))
                return File.ReadAllBytes(IOManager.GetBase(path));

            return null;
        }
        public static void WriteAllBytes (string path, byte[] data) {

            File.WriteAllBytes(IOManager.GetBase(path), data);
        }

        public static string ReadAllText (string path) {

            if (File.Exists(IOManager.GetBase(path)))
                return File.ReadAllText(IOManager.GetBase(path));

            return null;
        }
        public static void WriteAllText (string path, string text) {

            File.WriteAllText(IOManager.GetBase(path), text);
        }

        public static bool Exists (string path) {

            return File.Exists(IOManager.GetBase(path));
        }
    }

    public static class IOMDirectory {

        public static void EnsureDirectory (string s) { CheckDirectory(s); }
        public static void CheckDirectory (string directoryName) {

            if (!Directory.Exists(IOManager.GetBase(directoryName)))
                Directory.CreateDirectory(IOManager.GetBase(directoryName));
        }
    }
}
