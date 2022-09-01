Imports System.Data.SQLite
Imports System.IO

Module SQLite

    Public Const FILENAME As String = "Authenticator.sqlite"
    Private Const DataSource As String = "Data Source=" & FILENAME & "; Version=3; Compress=True"

    Dim SQLconnect As SQLiteConnection
    Dim SQLcommand As SQLiteCommand

    Public Function CheckName(Name As String) As Boolean
        Try
            SQLconnect = New SQLiteConnection With {
                .ConnectionString = DataSource
            }
            Using Query As New SQLiteCommand()
                SQLconnect.Open()
                With Query
                    .Connection = SQLconnect
                    .CommandText = "SELECT * FROM Secure_Auth WHERE Name = @user"
                    .Parameters.AddWithValue("@user", Name)
                    .Prepare()
                End With

                Dim Reader As SQLiteDataReader = Query.ExecuteReader

                If Reader.HasRows Then
                    Query.Parameters.Clear()
                    Reader.Close()
                    SQLconnect.Close()
                    Return True
                Else
                    Query.Parameters.Clear()
                    Reader.Close()
                    SQLconnect.Close()
                    Return False
                End If
            End Using
        Catch
            SQLconnect.Close()
            Return False
        End Try
    End Function

    Public Function InsertCode(Name As String, Code As String, Optional Period As Integer = 30) As Boolean
        Try
            SQLconnect = New SQLiteConnection With {
                .ConnectionString = DataSource
            }
            SQLconnect.Open()

            SQLcommand = SQLconnect.CreateCommand
            SQLcommand.CommandText = "INSERT INTO Secure_Auth (Name, Code, Period, Active) values ('" & Name & "','" & Code & "','" & Period & "',1)"
            SQLcommand.ExecuteNonQuery()

            SQLconnect.Close()
            Return True
        Catch
            Return False
        End Try
    End Function

    Public Function UpdateName(name As String, newName As String) As Boolean
        Try
            SQLconnect = New SQLiteConnection With {
                .ConnectionString = DataSource
            }
            SQLconnect.Open()

            SQLcommand = SQLconnect.CreateCommand
            SQLcommand.CommandText = "UPDATE Secure_Auth SET Name = '" & newName & "' WHERE Name = '" & name & "'"
            SQLcommand.ExecuteNonQuery()

            SQLconnect.Close()
            Return True
        Catch
            SQLconnect.Close()
            Return False
        End Try
    End Function

    Public Function DeleteItem(name As String) As Boolean
        Try
            SQLconnect = New SQLiteConnection With {
                .ConnectionString = DataSource
            }
            SQLconnect.Open()

            SQLcommand = SQLconnect.CreateCommand
            SQLcommand.CommandText = "DELETE FROM Secure_Auth WHERE Name = '" & name & "'"
            SQLcommand.ExecuteNonQuery()

            SQLconnect.Close()
            Return True
        Catch
            SQLconnect.Close()
            Return False
        End Try
    End Function

    Public Function LoadCode() As Boolean
        Try
            FormMain.panelCodes.Controls.Clear()

            SQLconnect = New SQLiteConnection With {
                .ConnectionString = DataSource
            }
            SQLconnect.Open()

            SQLcommand = SQLconnect.CreateCommand

            Dim sadapter As New SQLiteDataAdapter
            Dim sqltable As New DataTable

            With SQLcommand
                .CommandText = "SELECT * FROM Secure_Auth"
                .Connection = SQLconnect
            End With
            With sadapter
                .SelectCommand = SQLcommand
                .Fill(sqltable)
            End With

            For i As Integer = 0 To sqltable.Rows.Count - 1
                Dim row = sqltable.Rows(i)

                Dim Name As String = row("Name")
                Dim SecretKey As String = row("Code")
                Dim Period As String = row("Period")
                Dim Active As Integer = row("Active")

                If Active = 0 Then Continue For

                Dim otp = CalculateOTP(SecretKey)

                FormMain.Add(Name, otp)
            Next

            SQLconnect.Close()
            Return True
        Catch e As Exception
            Debug.WriteLine(e.ToString)
            SQLconnect.Close()
            Return False
        End Try
    End Function

    Public Function CreateDB() As Boolean
        Try
            If File.Exists(FILENAME) Then
                Return False
            Else
                SQLiteConnection.CreateFile(FILENAME)

                SQLconnect = New SQLiteConnection With {
                    .ConnectionString = DataSource
                }

                SQLconnect.Open()
                SQLcommand = SQLconnect.CreateCommand
                SQLcommand.CommandText = "CREATE TABLE Secure_Auth (ID INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, Code TEXT, Period TEXT, Active INTEGER);"
                SQLcommand.ExecuteNonQuery()
                SQLconnect.Close()
                Return True
            End If
        Catch
            Return False
        End Try
    End Function

End Module
