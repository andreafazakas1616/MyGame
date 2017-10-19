using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.DAL.Repositories
{
    public class FileRepository
    {
        private readonly MyGameEntities _context = null;
        public FileRepository(MyGameEntities context)
        {
            _context = context;
        }

        public List<File> GetAll()
        {
            return _context.Files.ToList();
        }

        public int Add(string fileName)
        {
            File entity = new File();
            entity.FileName = fileName;
            _context.Files.Add(entity);
            _context.SaveChanges();
            return entity.id;
        }

    }
}
