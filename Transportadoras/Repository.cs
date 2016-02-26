using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Transportadoras
{
    public class Repository
    {
        public Repository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["StringConexao"].ConnectionString;
        }

        private static string _connectionString;

        #region Usuarios

        public IList UsuariosListagem()
        {
            var cn = new MySqlConnection(_connectionString);
            cn.Open();
            var command = new MySqlCommand("SELECT Id, Nome FROM usuario", cn);
            var reader = command.ExecuteReader();

            var res = new List<object>();

            while (reader.Read())
            {
                res.Add(new
                {
                    Id = (int)reader["Id"],
                    Nome = (string)reader["Nome"],
                });
            }

            reader.Close();
            command.Dispose();
            cn.Close();

            return res;
        }

        public Usuario UsuarioSelecionar(int id)
        {
            var cn = new MySqlConnection(_connectionString);
            cn.Open();
            var command = new MySqlCommand("SELECT * FROM usuario WHERE Id=" + id, cn);
            var reader = command.ExecuteReader();

            reader.Read();

            var res = new Usuario
                   {
                       Id = (int)reader["Id"],
                       Nome = (string)reader["Nome"],
                       Senha = (string)reader["Senha"],
                       Admin = reader["Admin"].ToString() == "1"
                   };

            command.Dispose();
            cn.Close();

            return res;
        }

        public void UsuarioExcluir(int id)
        {
            var cn = new MySqlConnection(_connectionString);
            cn.Open();
            var command = new MySqlCommand("DELETE FROM usuario WHERE Id=" + id, cn);
            command.ExecuteNonQuery();
            command.Dispose();
            cn.Close();
        }

        public void UsuarioSalvar(Usuario usuario)
        {
            var cn = new MySqlConnection(_connectionString);
            cn.Open();

            if (usuario.Id == 0)
            {
                var command = new MySqlCommand("INSERT INTO USUARIO (Nome, Senha, Admin) VALUES (@Nome, @Senha, @Admin)", cn);
                var parameter = command.CreateParameter();
                parameter.ParameterName = "@Nome";
                parameter.Value = usuario.Nome;
                command.Parameters.Add(parameter);

                parameter = command.CreateParameter();
                parameter.ParameterName = "@Senha";
                parameter.Value = usuario.Senha;
                command.Parameters.Add(parameter);

                parameter = command.CreateParameter();
                parameter.ParameterName = "@Admin";
                parameter.Value = usuario.Admin;
                command.Parameters.Add(parameter);

                command.ExecuteNonQuery();
                command.Dispose();
            }
            else
            {
                var command = new MySqlCommand("UPDATE USUARIO SET Nome = @Nome, Senha = @Senha, Admin = @Admin WHERE ID=" + usuario.Id, cn);
                var parameter = command.CreateParameter();
                parameter.ParameterName = "@Nome";
                parameter.Value = usuario.Nome;
                command.Parameters.Add(parameter);

                parameter = command.CreateParameter();
                parameter.ParameterName = "@Senha";
                parameter.Value = usuario.Senha;
                command.Parameters.Add(parameter);

                parameter = command.CreateParameter();
                parameter.ParameterName = "@Admin";
                parameter.Value = usuario.Admin;
                command.Parameters.Add(parameter);

                command.ExecuteNonQuery();
                command.Dispose();
            }

            cn.Close();
        }

        public Usuario Login(string usuario, string senha)
        {
            var cn = new MySqlConnection(_connectionString);
            cn.Open();
            var command = new MySqlCommand("SELECT Id FROM USUARIO WHERE nome=@nome AND senha=@senha", cn);

            var parameter = command.CreateParameter();
            parameter.ParameterName = "@nome";
            parameter.Value = usuario;
            command.Parameters.Add(parameter);

            parameter = command.CreateParameter();
            parameter.ParameterName = "@senha";
            parameter.Value = senha;
            command.Parameters.Add(parameter);

            var id = (int?)command.ExecuteScalar();
            cn.Close();
            return id != null ? UsuarioSelecionar(id.Value) : null;
        }

        #endregion Usuarios

        #region Transportadoras

        public IList TransportadoraListagem(int idUsuario)
        {
            var cn = new MySqlConnection(_connectionString);
            cn.Open();
            var command = new MySqlCommand("SELECT t.Id, Nome, Nota, (SELECT SUM(Nota)/Count(1) FROM nota WHERE idTransportadora=t.Id) as Media " +
                                           "FROM transportadora t " +
                                           "LEFT JOIN nota on t.id=nota.idtransportadora and nota.idusuario=" + idUsuario, cn);
            var reader = command.ExecuteReader();

            var res = new List<object>();

            while (reader.Read())
            {
                res.Add(new
                {
                    Id = (int)reader["Id"],
                    Nome = (string)reader["Nome"],
                    Nota = reader["Nota"].ToString(),
                    Media = (decimal)reader["Media"],
                });
            }

            reader.Close();
            command.Dispose();
            cn.Close();

            return res;
        }

        public Transportadora TransportadoraSelecionar(int id)
        {
            var cn = new MySqlConnection(_connectionString);
            cn.Open();
            var command = new MySqlCommand("SELECT * FROM transportadora WHERE Id=" + id, cn);
            var reader = command.ExecuteReader();

            reader.Read();

            var res = new Transportadora
            {
                Id = (int)reader["Id"],
                Nome = (string)reader["Nome"],
            };

            command.Dispose();
            cn.Close();

            return res;
        }

        public void TransportadoraExcluir(int id)
        {
            var cn = new MySqlConnection(_connectionString);
            cn.Open();
            var command = new MySqlCommand("DELETE FROM transportadora WHERE Id=" + id, cn);
            command.ExecuteNonQuery();
            command.Dispose();
            cn.Close();
        }

        public void TransportadoraSalvar(Transportadora transportadora)
        {
            var cn = new MySqlConnection(_connectionString);
            cn.Open();

            if (transportadora.Id == 0)
            {
                var command = new MySqlCommand("INSERT INTO TRANSPORTADORA (Nome) VALUES (@Nome)", cn);
                var parameter = command.CreateParameter();
                parameter.ParameterName = "@Nome";
                parameter.Value = transportadora.Nome;
                command.Parameters.Add(parameter);

                command.ExecuteNonQuery();
                command.Dispose();
            }
            else
            {
                var command = new MySqlCommand("UPDATE TRANSPORTADORA SET Nome = @Nome WHERE ID=" + transportadora.Id, cn);
                var parameter = command.CreateParameter();
                parameter.ParameterName = "@Nome";
                parameter.Value = transportadora.Nome;
                command.Parameters.Add(parameter);

                command.ExecuteNonQuery();
                command.Dispose();
            }

            cn.Close();
        }

        public void SetarNota(int idTransportadora, int idUsuario, int nota)
        {
            var cn = new MySqlConnection(_connectionString);
            cn.Open();

            var command = new MySqlCommand("SELECT 1 FROM nota WHERE IdTransportadora=" + idTransportadora + " AND idUsuario=" + idUsuario, cn);

            if (command.ExecuteScalar() == null)
            {
                var commandInsert = new MySqlCommand("INSERT INTO nota (IdTransportadora, IdUsuario, Nota) VALUES (@IdTransportadora, @IdUsuario, @Nota)", cn);
                var parameter = commandInsert.CreateParameter();
                parameter.ParameterName = "@IdTransportadora";
                parameter.Value = idTransportadora;
                commandInsert.Parameters.Add(parameter);

                parameter = commandInsert.CreateParameter();
                parameter.ParameterName = "@IdUsuario";
                parameter.Value = idUsuario;
                commandInsert.Parameters.Add(parameter);

                parameter = commandInsert.CreateParameter();
                parameter.ParameterName = "@Nota";
                parameter.Value = nota;
                commandInsert.Parameters.Add(parameter);

                commandInsert.ExecuteNonQuery();
                commandInsert.Dispose();
            }
            else
            {
                var commandInsert = new MySqlCommand("UPDATE nota SET Nota=@Nota WHERE IdTransportadora=" + idTransportadora + " AND idUsuario=" + idUsuario, cn);
                var parameter = commandInsert.CreateParameter();
                parameter.ParameterName = "@Nota";
                parameter.Value = nota;
                commandInsert.Parameters.Add(parameter);

                commandInsert.ExecuteNonQuery();
                commandInsert.Dispose();
            }

            command.ExecuteNonQuery();
            command.Dispose();

            cn.Close();
        }

        #endregion Transportadoras


    }
}