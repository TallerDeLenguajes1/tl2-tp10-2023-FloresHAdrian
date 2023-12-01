using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tl2_tp10_2023_FloresHAdrian;

public interface ITableroRepository{
    public  void Create(Tablero tablero);
    public void Update (int id,Tablero  tablero);
    public Tablero GetById(int id);
    public List<Tablero> GetAll();
    public List<Tablero> GetAllByUserId(int idUsuario);
    public void Remove(int id);
}