using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ScratchTutorial
{
    public class XmlHeaderReader : IHeaderReader
    {
        // TODO: 
        private const string TagTitle = "title";
        private const string TagDescription = "description";
        protected const string Extension = ".xml";

        public string ReadDescription(string path)
        {
            path = PathToFile(path);
            using (var reader = new XmlTextReader(path))
            {
                // TODO: checks
                reader.MoveToContent();
                reader.ReadToDescendant(TagTitle);
                var title = reader.ReadString();
                reader.ReadToNextSibling(TagDescription);
                var description = reader.ReadString();
                return String.Format("{0}\n{1}", title, description);
            }
        }

        public string ReadTitle(string path)
        {
            path = PathToFile(path);
            return Path.GetFileNameWithoutExtension(path);
        }

        protected static string PathToFile(string path)
        {
            // TODO: remade
            if (Directory.Exists(path))
            {
                path = Directory.EnumerateFiles(path).FirstOrDefault(x => x.EndsWith(".xml"));
            }
            if (!File.Exists(path))
                throw new FileNotFoundException(path);
            if (!path.EndsWith(Extension))
                throw new Exception("Ожидался файл XML");
            return path;
        }
    }
}
