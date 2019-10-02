using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebAPI.Models;
using WebAPI.Repositorio.Model;

public class ClienteRepository : AbstractRepository<Cliente, int>
{
    ///<summary>Exclui uma pessoa pela entidade
    ///<param name="cliente">Referência de Pessoa que será excluída.</param>
    ///</summary>
    public override void Delete(Cliente cliente)
    {
        using (var conn = new SqlConnection(StringConnection))
        {
            string sql = "DELETE TBCliente Where Id=@ID";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", cliente.ID );
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }

    ///<summary>Exclui uma pessoa pelo ID
    ///<param name="id">Id do registro que será excluído.</param>
    ///</summary>
    public override void DeleteById(int id)
    {
        using (var conn = new SqlConnection(StringConnection))
        {
            string sql = "DELETE TBCliente Where Id=@ID";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }

    ///<summary>Obtém todas as pessoas
    ///<returns>Retorna as pessoas cadastradas.</returns>
    ///</summary>
    public override List<Cliente> GetAll()
    {
        string sql = "Select Id, Nome, Email FROM TBCliente ORDER BY Id";
        using (var conn = new SqlConnection(StringConnection))
        {
            var cmd = new SqlCommand(sql, conn);
            List<Cliente> list = new List<Cliente>();
            Cliente cliente = null;
            try
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        cliente = new Cliente();

                        cliente.ID = (int)reader["Id"];
                        cliente.nome = reader["Nome"].ToString();
                        cliente.email = reader["Email"].ToString();
                        
                        list.Add(cliente);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return list;
        }
    }

    ///<summary>Obtém uma pessoa pelo ID
    ///<param name="id">Id do registro que obtido.</param>
    ///<returns>Retorna uma referência de Pessoa do registro encontrado ou null se ele não for encontrado.</returns>
    ///</summary>
    public override Cliente GetById(int id)
    {
        using (var conn = new SqlConnection(StringConnection))
        {
            string sql = "Select Id, Nome, Email FROM TBCliente WHERE Id=@Id";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            Cliente cliente = null;
            try
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            cliente = new Cliente();
                            cliente.ID = (int)reader["Id"];
                            cliente.nome = reader["Nome"].ToString();
                            cliente.email = reader["Email"].ToString();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return cliente;
        }
    }

    ///<summary>Salva a pessoa no banco
    ///<param name="entity">Referência de Pessoa que será salva.</param>
    ///</summary>
    public override void Save(Cliente entity)
    {
        using (var conn = new SqlConnection(StringConnection))
        {
            string sql = "INSERT INTO TBCliente (Nome, Email) VALUES (@Nome, @Email)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Nome", entity.nome);
            cmd.Parameters.AddWithValue("@Email", entity.email);
            
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }

    ///<summary>Atualiza a pessoa no banco
    ///<param name="entity">Referência de Pessoa que será atualizada.</param>
    ///</summary>
    public override void Update(Cliente cliente)
    {
        using (var conn = new SqlConnection(StringConnection))
        {
            string sql = "UPDATE TBCliente SET Nome=@Nome, Email=@Email  WHERE Id=@Id";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", cliente.ID);
            cmd.Parameters.AddWithValue("@Nome", cliente.nome);
            cmd.Parameters.AddWithValue("@Email", cliente.email);
            
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}