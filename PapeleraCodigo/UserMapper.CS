public class UserMapper
{
public User FindByID(int id)
public User FindByEmailAddress(string emailAddress)
public IEnumerable<User> FindByName(string name)
public IEnumerable<User> FindAll()
public void Update(User user)
public int Insert(User user)
public void Delete(User user)
}




public UserMapper(string connectionString)
{
_connectionString = connectionString;
}
private string _connectionString;
private IDbConnection _databaseConnection;
private bool ConnectToDatabase(string connectionString)
{
bool success = false;
_databaseConnection = new SqlConnection(connectionString);
try
{
_databaseConnection.Open();
success = true;
}
catch (Exception)
{
success = false;
}
return success;
}
private void DisconnectFromDatabase()
{
if (_databaseConnection.State != ConnectionState.Open)
{
_databaseConnection.Close();
}
}
private IDataReader ExecuteReadCommand(IDbCommand command)
{
IDataReader dataReader = null;
if (_databaseConnection.State == ConnectionState.Open)
{
dataReader = command.ExecuteReader();
}
return dataReader;
}
private User CreateUserFromReader(IDataReader dataReader)
{
int id = dataReader.GetInt32(0);
string name = dataReader.GetString(1);
string emailAddress = dataReader.GetString(2);
string password = dataReader.GetString(2);
return new User(id, name, emailAddress, password);
}
private IEnumerable<User> Find(string sqlCommand)
{
ConnectToDatabase(_connectionString);
IDbCommand findByIDCommandCommand = new SqlCommand(sqlCommand,
(SqlConnection)_databaseConnection);
IDataReader userReader = ExecuteReadCommand(findByIDCommandCommand);
ICollection<User> users = new List<User>();
while (userReader.Read())
{
users.Add(CreateUserFromReader(userReader));
}
DisconnectFromDatabase();
return users;
}

//-----------------------------------------------------------------------
public User FindByID(int id)
{
IEnumerable<User> users = Find(string.Format("SELECT * FROM User WHERE ID = {0}", id));
return users.SingleOrDefault();
}
public User FindByEmailAddress(string emailAddress)
{
IEnumerable<User> users = Find(string.Format("SELECT * FROM User WHERE EmailAddress ={0}", emailAddress));
return users.SingleOrDefault();
}
public IEnumerable<User> FindByName(string name)
{
return Find(string.Format("SELECT * FROM User WHERE Name LIKE '%{0}%'", name));
}
public IEnumerable<User> FindAll()
{
return Find("SELECT * FROM User");
}
public void Update(User user)
{
string updateUserCommandText = string.Format("UPDATE User SET Name='{0}',EmailAddress='{1}', Password='{2}' WHERE ID={3}", user.Name, user.EmailAddress,
user.Password, user.ID);
IDbCommand updateCommand = new SqlCommand(updateUserCommandText,
(SqlConnection)_databaseConnection);
updateCommand.ExecuteNonQuery();
}
public int Insert(User user)
{
string insertUserCommandText = string.Format("INSERT INTO User(Name, EmailAddress,Password) VALUES('{0}', '{1}', '{2}')", user.Name, user.EmailAddress, user.Password);
IDbCommand insertCommand = new SqlCommand(insertUserCommandText,(SqlConnection)_databaseConnection);
int userID = (int)insertCommand.ExecuteScalar();
return userID;
}
public void Delete(User user)
{
string deleteUserCommandText = string.Format("DELETE FROM User WHERE ID={0}", user.ID);
IDbCommand deleteCommand = new SqlCommand(deleteUserCommandText,(SqlConnection)_databaseConnection);
deleteCommand.ExecuteNonQuery();
}