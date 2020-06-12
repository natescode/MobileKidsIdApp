﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using MobileKidsIdApp.Models;

namespace MobileKidsIdApp.Services
{
    public partial class FamilyRepository
    {
        private readonly string FileName = "f.htbox";
        private readonly char[] PaddingChars = new char[]
        {
            (char)0x0e, (char)0x01, (char)0x02, (char)0x03, (char)0x04,
            (char)0x05, (char)0x06, (char)0x07, (char)0x08, (char)0x09, (char)0x10
        };

        private string BasePath => Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private string FilePath => Path.Combine(BasePath, FileName);

        private List<Child> LoadChildren()
        {
            if (File.Exists(FilePath))
            {
                byte[] encrypted = File.ReadAllBytes(FilePath);
                string json = Decrypt(encrypted).TrimEnd(PaddingChars);
                return DeserializeChildren(json);
            }

            return new List<Child>();
        }

        private void StoreChildren()
        { 
            string json = SerializeChildren(Children);
            byte[] encrypted = Encrypt(json);
            if (File.Exists(FilePath)) File.Delete(FilePath);
            File.WriteAllBytes(FilePath, encrypted);
        }

        private string SerializeChildren(List<Child> children)
            => JsonSerializer.Serialize(children);

        private List<Child> DeserializeChildren(string json)
            => JsonSerializer.Deserialize<List<Child>>(json);
    }
}
