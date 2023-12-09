using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace tl2_tp10_2023_FloresHAdrian;

public class TareaRepository : ITareaRepository {
    private string cadenaConexion = "Data Source=DB/kanban.db;Cache=Shared";

    public void Create(int idTable, Tarea tarea)
    {
        var query = $"INSERT INTO Tarea(id_tablero, nombre,estado,  descripcion,color) VALUES (@idTable , @nombre,@estado, @descripcion,@color);";
        using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
        {

            connection.Open();
            var command = new SQLiteCommand(query, connection);

            command.Parameters.Add(new SQLiteParameter("@idTable", tarea.IdTablero));
            command.Parameters.Add(new SQLiteParameter("@nombre", tarea.Nombre));
            command.Parameters.Add(new SQLiteParameter("@estado", tarea.Estado));
            command.Parameters.Add(new SQLiteParameter("@descripcion", tarea.Descripcion));
            command.Parameters.Add(new SQLiteParameter("@color", tarea.Color));
            command.ExecuteNonQuery();

            connection.Close();
        }
    }

    public void Update (int id,Tarea  Tarea){

        var query = $"UPDATE Tarea SET id_tablero= @idTable, nombre=@name,estado=@estado, descripcion =@descripcion, color=@color  WHERE id=@id;";
        using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
        {
            connection.Open();
            var command = new SQLiteCommand(query, connection);

            command.Parameters.Add(new SQLiteParameter("@idTable", Tarea.IdTablero));
            command.Parameters.Add(new SQLiteParameter("@nombre", Tarea.Nombre));
            command.Parameters.Add(new SQLiteParameter("@estado", Tarea.Estado));
            command.Parameters.Add(new SQLiteParameter("@descripcion", Tarea.Descripcion));
            command.Parameters.Add(new SQLiteParameter("@color", Tarea.Color));
            command.Parameters.Add(new SQLiteParameter("@id",id));

            command.ExecuteNonQuery();
            connection.Close();
        }
    }


    public Tarea GetById(int id){
        var query = $"SELECT * FROM Tarea WHERE id= @id;";
        var Tarea = new Tarea();

        using(SQLiteConnection connection = new SQLiteConnection(cadenaConexion)){

            connection.Open();
            var command= new SQLiteCommand(query,connection);
            command.Parameters.Add(new SQLiteParameter("@id", id));

            using( SQLiteDataReader reader = command.ExecuteReader()){
                while(reader.Read()){
                    Tarea.Id= Convert.ToInt32(reader["id"]) ;
                    Tarea.IdTablero = Convert.ToInt32(reader["id_tablero"]);
                    Tarea.Nombre =reader["nombre"].ToString() ;
                    Tarea.Estado =(EstadoTarea)reader["estado"];
                    Tarea.Descripcion = reader["descripcion"].ToString();
                    Tarea.IdUsuarioPropietario = Convert.ToInt32(reader["id_usuario_propietario"]);
                    Tarea.Color = reader["color"].ToString();
                }
            }

            connection.Close();
        }
        return Tarea;
    }
/*
    public List<Tarea> GetAll(){
        var query = @"SELECT * FROM Tarea;";
        List<Tarea> lista = new List<Tarea>();

        using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion)){
            connection.Open();
            var command = new SQLiteCommand(query, connection);

            using(SQLiteDataReader reader = command.ExecuteReader()){
                while(reader.Read()){
                    var Tarea = new Tarea();
                    Tarea.Id= Convert.ToInt32(reader["id"]) ;
                    Tarea.IdUsuarioPropietario = Convert.ToInt32(reader["id_usuario_propietario"]);
                    Tarea.Nombre =reader["nombre"].ToString() ;
                    Tarea.Descripcion = reader["descripcion"].ToString();
                    lista.Add(Tarea);
                }
            }

            connection.Close();
        }

        return lista;
    }*/

    public List<Tarea> GetAllByUserId(int idUsuario){
        var query = $"SELECT * FROM Tarea WHERE id_usuario_propietario= @idUser;";
        List<Tarea> lista = new List<Tarea>();

        using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion)){
            connection.Open();
            var command = new SQLiteCommand(query, connection);
            command.Parameters.Add(new SQLiteParameter("@id", idUsuario));

            using(SQLiteDataReader reader = command.ExecuteReader()){
                while(reader.Read()){
                    var Tarea = new Tarea();
                    Tarea.Id= Convert.ToInt32(reader["id"]) ;
                    Tarea.IdTablero = Convert.ToInt32(reader["id_tablero"]);
                    Tarea.Nombre =reader["nombre"].ToString() ;
                    Tarea.Estado =(EstadoTarea)reader["estado"];
                    Tarea.Descripcion = reader["descripcion"].ToString();
                    Tarea.IdUsuarioPropietario = Convert.ToInt32(reader["id_usuario_propietario"]);
                    Tarea.Color = reader["color"].ToString();
                    lista.Add(Tarea);
                }
            }

            connection.Close();
        }

        return lista;
    }

    public List<Tarea> GetAllByTableId(int idTable){
        var query = $"SELECT * FROM Tarea WHERE id_tablero= @idTable;";
        List<Tarea> lista = new List<Tarea>();

        using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion)){
            connection.Open();
            var command = new SQLiteCommand(query, connection);
            command.Parameters.Add(new SQLiteParameter("@idTable", idTable));

        using(SQLiteDataReader reader = command.ExecuteReader()){
                while(reader.Read()){
                    var Tarea = new Tarea();
                    Tarea.Id= Convert.ToInt32(reader["id"]) ;
                    Tarea.IdTablero = Convert.ToInt32(reader["id_tablero"]);
                    Tarea.Nombre =reader["nombre"].ToString() ;
                    Tarea.Estado =(EstadoTarea)reader["estado"];
                    Tarea.Descripcion = reader["descripcion"].ToString();
                    Tarea.IdUsuarioPropietario = Convert.ToInt32(reader["id_usuario_propietario"]);
                    Tarea.Color = reader["color"].ToString();
                    lista.Add(Tarea);
                }
            }
            
            connection.Close();
        }

        return lista;
    }


    public void Remove(int idTarea){
        var query = $"DELETE FROM Tarea WHERE id=@id;";
        using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
        {
            connection.Open();
            var command = new SQLiteCommand(query, connection);
            command.Parameters.Add(new SQLiteParameter("@id",idTarea));
            command.ExecuteNonQuery();
            connection.Close();
        }
    }

    public void AssignUserToTask(int idUser, int idTask){
        var query = $"UPDATE Tarea SET id_usuario_propietario= @idUserWHERE id=@idTask";
        using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
        {
            connection.Open();
            var command = new SQLiteCommand(query, connection);

            command.Parameters.Add(new SQLiteParameter("@idUser",idUser ));
            command.Parameters.Add(new SQLiteParameter("@id",idTask));

            command.ExecuteNonQuery();
            connection.Close();
        }
        
    }

}