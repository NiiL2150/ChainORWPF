using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChainORWPF.Model;

namespace ChainORWPF.Service
{
    public interface IFileService
    {
        List<User> Open(string fileName);
        void Save(string fileName, List<User> movies);
    }
}
