using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
//Ajout de la Library MySql
using MySql.Data.MySqlClient;

namespace pizzeria
{
    class fonctions
    {
        static public MySqlConnection connection;
        static public MySqlCommand cmd;
        static public string connectionString;
        static public string server;
        static public string database;
        static public string uid;
        static public string password;

        static public void OuvrirConnection()
        {
            server = "localhost";
            database = "db_pizzeria";
            uid = "root";
            password = "";
            connectionString = ""
                            + "SERVER=" + server
                            + ";DATABASE=" + database
                            + ";UID=" + uid
                            + ";PASSWORD=" + password
                            + ";";
            connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
            }
            catch (MySqlException ex)
            {
                //Les deux nombres les plus communs pour une erreur de connection sont les suivants:
                //0: impossible de se connecter au server
                //1045: nom d'utilisateur et/ou mot de passe incorret(s)
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Impossible de se connecter au server!");
                        break;

                    case 1045:
                        MessageBox.Show("Nom utilisateur et/ou mot de passe incorret(s)!");
                        break;
                }
            }
        }

        static public void FermerConnection()
        {
            if (connection.State != ConnectionState.Open)
            { MessageBox.Show("Connection non ouverte!"); }
            else
            { connection.Close(); }
        }

        //Fonction pour lire une requete Sql
        static public MySqlDataReader Lire(string requete)
        {            
            MySqlDataReader myReader;
            cmd = new MySqlCommand();
            try
            {
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = requete;
                myReader = cmd.ExecuteReader();
                return myReader; 
            }
            catch (MySqlException ex)
            { throw new ApplicationException("Echec lecture " + ex.Message, ex); }
        }

        //Fonction pour executer une commande Sql
        static public int ExecCmd(string requete)
        {
            try
            {
                cmd = new MySqlCommand(requete, connection);
                return cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            { throw new ApplicationException("Echec lecture " + ex.Message, ex); }
        }

        //Fonction pour vérifier l'existence d'une ou plusieurs ligne de résultat d'une requête Sql
        static public bool Existe(string requete)
        {            
            try
            {
                //Creation de la commande, assignation de la requete et de la connection
                cmd = new MySqlCommand(requete, connection);
                //Creation du reader et execution
                MySqlDataReader myReader = cmd.ExecuteReader();
                //Lecture des données et stockage                    
                return myReader.Read();
            }
            catch (MySqlException ex)
            { throw new ApplicationException("Echec lecture " + ex.Message, ex);  }  
           
        }

        //Fonction pour lire le nombre de lignes d'une table
        static public int CompteLigne(string table)
        {
            //Exemple: SELECT count(*) FROM noms
            //Code: int nbr = BDConnect.Compte("noms")
            string requete = "SELECT count(*) FROM " + table;
            int Compte = -1;

            try
            {                
                cmd = new MySqlCommand(requete, connection);
                Compte = int.Parse(cmd.ExecuteScalar() + "");
                return Compte;
            }
            catch (MySqlException ex)
            { throw new ApplicationException("Echec lecture " + ex.Message, ex); }            
        }

        //Fonction pour compter
        static public int Compte(string requete)
        {            
            try
            {
                cmd = new MySqlCommand(requete, connection);
                int nbr = Convert.ToInt32(cmd.ExecuteScalar());
                return nbr;
            }
            catch (MySqlException ex)
            { throw new ApplicationException("Echec lecture " + ex.Message, ex); }
        }

        //Fonction pour remplire une DataTable à partir d'une requête sql
        static public DataTable Adapt(string requete)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(requete, connection);
                MySqlDataAdapter myAdapt = new MySqlDataAdapter();
                myAdapt.SelectCommand = cmd;
                DataTable myTable = new DataTable();
                myAdapt.Fill(myTable);
                return myTable;
            }
            catch (MySqlException ex)
            { throw new ApplicationException("Echec lecture " + ex.Message); }
        }

        //Inserer des valeurs dans la base de données
        static public void Inserer(string table, string valeur)
        {
            //Exemple: INSERT INTO noms (nom, age) VALUES ('Dupont', '33')
            //Code: BDConnect.Inserer("noms", "nom, age", "Dupont, 33");
            string requete = "INSERT INTO " + table +  " VALUES (" + valeur + ")";

            //Ouvrir la connection
            fonctions.OuvrirConnection();
            try
            {
                //Creation de la commande, assignation de la requete et de la connection
                MySqlCommand cmd = new MySqlCommand(requete, connection);
                //Executer la commande
                cmd.ExecuteNonQuery();
                //Fermeture de la connection
                fonctions.FermerConnection();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erreur lors de l'insert! " + ex.Message);
                fonctions.FermerConnection();
            }
        }

        //Mettre à jour des valeurs dans la base de données
        static public void MiseAjour(string table, string set, string where)
        {
            //Exemple: UPDATE noms SET nom='Durand", age='22' WHERE nom='Dupont'
            //Code: BDConnect.MiseAJour("noms", "nom='Durand', age='22'", "nom='Dupont'");
            string requete = "UPDATE " + table + " SET " + set + " WHERE " + where;

            //Ouvrir la connection
            fonctions.OuvrirConnection();
            try
            {
                //Creation de la commande, assignation de la requête et de la connection
                MySqlCommand cmd = new MySqlCommand(requete, connection);
                //Executer la commande
                cmd.ExecuteNonQuery();
                //Fermeture de la connection
                fonctions.FermerConnection();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erreur lors de la mise à jour! " + ex.Message);
                fonctions.FermerConnection();
            }
        }

        //Supprimer une ligne dans la base de données
        static public void Supprimer(string table, string where)
        {
            //Exemple: DELETE FROM noms WHERE nom='Dupont'
            //Code: BDConnect.Supprimer("noms", "nom='Dupont'");
            string requete = "DELETE FROM " + table + " WHERE " + where;

            //Ouvrir la connection
            fonctions.OuvrirConnection();
            try
            {
                //Creation de la commande, assignation de la requête et de la connection
                MySqlCommand cmd = new MySqlCommand(requete, connection);
                //Executer la commande
                cmd.ExecuteNonQuery();
                //Fermeture de la connection
                fonctions.FermerConnection();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erreur lors de la suppréssion! " + ex.Message);
                fonctions.FermerConnection();
            }
        }
    }
}
