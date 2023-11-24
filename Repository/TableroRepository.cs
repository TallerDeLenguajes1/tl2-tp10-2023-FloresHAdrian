using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace kanban;

public class TableroRepository : ITableroRepository {
    private string cadenaConexion = "Data Source=DB/kanban.db;Cache=Shared";

    public void Create(Tablero tablero)
    {
        var query = $"INSERT INTO Tablero(id_usuario_propietario, nombre, descripcion) VALUES (@id , @nombre, @descripcion);";
        using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
        {

            connection.Open();
            var command = new SQLiteCommand(query, connection);
            command.Parameters.Add(new SQLiteParameter("@id", tablero.IdUsuarioPropietario));
            command.Parameters.Add(new SQLiteParameter("@nombre", tablero.Nombre));
            command.Parameters.Add(new SQLiteParameter("@descripcion", tablero.Descripcion));
            command.ExecuteNonQuery();
            connection.Close();
        }
    }

    public void Update (int id,Tablero  tablero){

        var query = $"UPDATE Tablero SET id_usuario_propietario= @id_usuario_propietario, nombre=@name, descripcion =@descripcion  WHERE id=@id;";
        using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
        {
            connection.Open();
            var command = new SQLiteCommand(query, connection);
            command.Parameters.Add(new SQLiteParameter("@id_usuario_propietario", tablero.IdUsuarioPropietario));
            command.Parameters.Add(new SQLiteParameter("@nombre", tablero.Nombre));
            command.Parameters.Add(new SQLiteParameter("@descripcion", tablero.Descripcion));
            command.Parameters.Add(new SQLiteParameter("@id",id));
            command.ExecuteNonQuery();
            connection.Close();
        }
    }


    public Tablero GetById(int id){
        var query = $"SELECT * FROM Tablero WHERE id= @id;";
        var tablero = new Tablero();

        using(SQLiteConnection connection = new SQLiteConnection(cadenaConexion)){
            connection.Open();
            var command= new SQLiteCommand(query,connection);
            command.Parameters.Add(new SQLiteParameter("@id", id));
            using( SQLiteDataReader reader = command.ExecuteReader()){
                while(reader.Read()){
                    tablero.Id= Convert.ToInt32(reader["id"]) ;
                    tablero.IdUsuarioPropietario = Convert.ToInt32(reader["id_usuario_propietario"]);
                    tablero.Nombre =reader["nombre"].ToString() ;
                    tablero.Descripcion = reader["descripcion"].ToString();
                }
            }
            connection.Close();
        }
        return tablero;
    }

    public List<Tablero> GetAll(){
        var query = @"SELECT * FROM Tablero;";
        List<Tablero> lista = new List<Tablero>();

        using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion)){
            connection.Open();
            var command = new SQLiteCommand(query, connection);

            using(SQLiteDataReader reader = command.ExecuteReader()){
                while(reader.Read()){
                    var tablero = new Tablero();
                    tablero.Id= Convert.ToInt32(reader["id"]) ;
                    tablero.IdUsuarioPropietario = Convert.ToInt32(reader["id_usuario_propietario"]);
                    tablero.Nombre =reader["nombre"].ToString() ;
                    tablero.Descripcion = reader["descripcion"].ToString();
                    lista.Add(tablero);
                }
            }
            connection.Close();
        }

        return lista;
    }

    public List<Tablero> GetAllByUserId(int idUsuario){
        var query = $"SELECT * FROM Tablero WHERE id_usuario_propietario= @idUser;";
        List<Tablero> lista = new List<Tablero>();

        using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion)){
            connection.Open();
            var command = new SQLiteCommand(query, connection);
            command.Parameters.Add(new SQLiteParameter("@id", idUsuario));

            using(SQLiteDataReader reader = command.ExecuteReader()){
                while(reader.Read()){
                    var tablero = new Tablero();
                    tablero.Id= Convert.ToInt32(reader["id"]) ;
                    tablero.IdUsuarioPropietario = Convert.ToInt32(reader["id_usuario_propietario"]);
                    tablero.Nombre =reader["nombre"].ToString() ;
                    tablero.Descripcion = reader["descripcion"].ToString();
                    lista.Add(tablero);
                }
            }
            connection.Close();
        }

        return lista;
    }


    public void Remove(int id){
        var query = $"DELETE FROM Tablero WHERE id=@id;";
        using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
        {
            connection.Open();
            var command = new SQLiteCommand(query, connection);
            command.Parameters.Add(new SQLiteParameter("@id",id));
            command.ExecuteNonQuery();
            connection.Close();
        }
    }

}