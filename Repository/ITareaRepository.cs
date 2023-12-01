using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tl2_tp10_2023_FloresHAdrian;

public interface ITareaRepository{
    public  void Create(int idTable,Tarea Tarea);
    public void Update (int id,Tarea  Tarea);
    public Tarea GetById(int id);
    public List<Tarea> GetAllByUserId(int idUser);
    public List<Tarea> GetAllByTableId(int idTable);
    public void Remove(int id);
    public void AssignUserToTask(int idUser, int idTask);
}