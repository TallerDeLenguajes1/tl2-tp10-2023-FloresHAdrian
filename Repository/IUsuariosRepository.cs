using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kanban;

public interface IUsuariosRepository{
    public void Create(Usuario usuario);
    public void Update (int id,Usuario usuario);
    public List<Usuario> GetAll();
    public Usuario GetById(int id);
    public void Remove(int id);
}