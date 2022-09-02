Imports System.Data.SQLite
Imports System.IO

Module SQLite

    Private ReadOnly AppData As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
    Public ReadOnly AppDataDirectoryApp As String = AppData & "\Authenticator\"
    Private ReadOnly FileDataBase As String = AppDataDirectoryApp & "data.sqlite"
    Private ReadOnly DataSource As String = "Data Source=" & FileDataBase & "; Version=3; Compress=True"

    Public Function CheckName(name As String) As Boolean
        Dim SQLconnect As SQLiteConnection

        Try
            SQLconnect = New SQLiteConnection With {
                .ConnectionString = DataSource
            }
            SQLconnect.Open()

            Dim SQLcommand = SQLconnect.CreateCommand
            SQLcommand.CommandText = "SELECT * FROM AuthorizationCode WHERE Name = '" & name & "'"

            Dim reader = SQLcommand.ExecuteReader

            If reader.HasRows Then
                reader.Close()
                SQLconnect.Close()
                Return True
            Else
                reader.Close()
                SQLconnect.Close()
                Return False
            End If
        Catch e As Exception
            MsgBox("Check name fail: " & e.Message)
            Return False
        End Try
    End Function

    Public Function InsertCode(name As String, code As String, Optional period As Integer = 30) As Boolean
        Try
            Dim SQLconnect = New SQLiteConnection With {
                .ConnectionString = DataSource
            }
            SQLconnect.Open()

            Dim SQLcommand = SQLconnect.CreateCommand
            SQLcommand.CommandText = "INSERT INTO AuthorizationCode (Name, Code, Period, Active) values ('" & name & "','" & code & "','" & period & "',1)"
            SQLcommand.ExecuteNonQuery()

            SQLconnect.Close()
            Return True
        Catch e As Exception
            MsgBox("Insert code fail: " & e.Message)
            Return False
        End Try
    End Function

    Public Function UpdateName(name As String, newName As String) As Boolean
        Try
            Dim SQLconnect = New SQLiteConnection With {
                .ConnectionString = DataSource
            }
            SQLconnect.Open()

            Dim SQLcommand = SQLconnect.CreateCommand
            SQLcommand.CommandText = "UPDATE AuthorizationCode SET Name = '" & newName & "' WHERE Name = '" & name & "'"
            SQLcommand.ExecuteNonQuery()

            SQLconnect.Close()
            Return True
        Catch e As Exception
            MsgBox("Update name fail: " & e.Message)
            Return False
        End Try
    End Function

    Public Function DeleteItem(name As String) As Boolean
        Try
            Dim SQLconnect = New SQLiteConnection With {
                .ConnectionString = DataSource
            }
            SQLconnect.Open()

            Dim SQLcommand = SQLconnect.CreateCommand
            SQLcommand.CommandText = "DELETE FROM AuthorizationCode WHERE Name = '" & name & "'"
            SQLcommand.ExecuteNonQuery()

            SQLconnect.Close()
            Return True
        Catch e As Exception
            MsgBox("Delete item fail: " & e.Message)
            Return False
        End Try
    End Function

    Public Function GetCodes() As List(Of NumCodes)
        Dim arrRet As New List(Of NumCodes)

        Try
            Dim SQLconnect = New SQLiteConnection With {
                .ConnectionString = DataSource
            }
            SQLconnect.Open()

            Dim sadapter As New SQLiteDataAdapter("SELECT * FROM AuthorizationCode", SQLconnect)
            Dim sqltable As New DataTable

            sadapter.Fill(sqltable)

            For i As Integer = 0 To sqltable.Rows.Count - 1
                Dim row = sqltable.Rows(i)

                Dim name As String = row("Name")
                Dim secretKey As String = row("Code")
                Dim period As Integer = row("Period")
                Dim active As Integer = row("Active")

                arrRet.Add(New NumCodes(name, secretKey, period, active))
            Next

            SQLconnect.Close()
        Catch e As Exception
            MsgBox("Load codes fail: " & e.Message)
        End Try

        Return arrRet
    End Function

    Public Function CreateDB() As Boolean
        Try
            If File.Exists(FileDataBase) Then
                Return False
            Else
                If Not My.Computer.FileSystem.GetDirectoryInfo(AppDataDirectoryApp).Exists Then My.Computer.FileSystem.CreateDirectory(AppDataDirectoryApp)

                SQLiteConnection.CreateFile(FileDataBase)

                Dim SQLconnect = New SQLiteConnection With {
                    .ConnectionString = DataSource
                }

                SQLconnect.Open()

                Dim SQLcommand = SQLconnect.CreateCommand
                SQLcommand.CommandText = "CREATE TABLE AuthorizationCode (ID INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, Code TEXT, Period TEXT, Active INTEGER);"
                SQLcommand.ExecuteNonQuery()

                SQLconnect.Close()
                Return True
            End If
        Catch
            Return False
        End Try
    End Function

End Module
