Imports System.Data
Imports System.Data.OleDb
Public Class wwtbam_DB
    Dim con As OleDbConnection
    Dim cmd As OleDbCommand
    Dim dr As OleDbDataReader
    Dim number As Integer
    Dim re As String = ""
    Dim n As Integer
    Public Sub New()
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=wwtbam.mdb")
    End Sub

    Public Sub opencon()
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
    End Sub

    Public Sub closecon()
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
    End Sub

    Public Function getquest(num As Integer) As Array
        Dim hold() As String = New String(5) {}
        Try
            opencon()
            cmd = New OleDbCommand("Select questions, option_A, option_B, option_C, option_D from wwtbam_tbl where ID = @num", con)
            cmd.Parameters.AddWithValue("@ID", num)
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While (dr.Read())
                    hold(0) = dr(0).ToString()
                    hold(1) = dr(1).ToString()
                    hold(2) = dr(2).ToString()
                    hold(3) = dr(3).ToString()
                    hold(4) = dr(4).ToString()
                End While
            Else
                hold(0) = "False"
            End If
            dr.Close()
            closecon()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return hold
    End Function

    Public Function GetTotal_questn() As Integer
        Dim num As Int32
        Try
            opencon()
            cmd = New OleDbCommand("select count(*) from wwtbam_tbl", con)
            num = cmd.ExecuteScalar()
            closecon()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return num
    End Function

    Public Function GetNextQuest(id As String) As Array
        Dim hold() As String = New String(5) {}
        Try
            opencon()
            cmd = New OleDbCommand("Select questions, option_A, option_B, option_C, option_D from wwtbam_tbl where ID= @quest", con)
            cmd.Parameters.AddWithValue("@quest", id)
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While (dr.Read())
                    hold(0) = dr(0).ToString()
                    hold(1) = dr(1).ToString()
                    hold(2) = dr(2).ToString()
                    hold(3) = dr(3).ToString()
                    hold(4) = dr(4).ToString()
                End While
            Else
                hold(0) = "False"
            End If
            dr.Close()
            closecon()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return hold
    End Function

    Public Function getUserAns(userAns As String)
        Dim res As String = ""
        Try
            opencon()
            cmd = New OleDbCommand("select my_ans from wwtbam_tbl where my_ans = @userAns", con)
            cmd.Parameters.AddWithValue("@my_ans", userAns)
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    If userAns = dr.GetString(0) Then
                        res = "1"
                    End If
                End While
            Else
                res = ""
            End If
            closecon()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return res
    End Function

    Public Function getCorrectAns(a As String, b As String, c As String, d As String)
        Try
            opencon()
            cmd = New OleDbCommand("Select my_ans from wwtbam_tbl where my_ans = @a or my_ans = @b or my_ans = @c or my_ans = @d", con)
            With cmd
                .Parameters.AddWithValue("@my_ans", a)
                .Parameters.AddWithValue("@my_ans", b)
                .Parameters.AddWithValue("@my_ans", c)
                .Parameters.AddWithValue("@my_ans", d)
            End With
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    re = dr.GetString(0)
                End While
            End If
            closecon()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return re
    End Function

    Public Function life5050(textA As String, textB As String, textC As String, textD As String, r As Int32)
        Dim num As Int32 = r
        Dim fi As String = ""
        Dim hold() As String = New String(5) {}
        Try
            opencon()
            cmd = New OleDbCommand("Select option_A, option_B, option_C, option_D, my_ans from wwtbam_tbl where ID = @num", con)
            cmd.Parameters.AddWithValue("@ID", num)
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    hold(0) = dr.GetString(0)
                    hold(1) = dr.GetString(1)
                    hold(2) = dr.GetString(2)
                    hold(3) = dr.GetString(3)
                    hold(4) = dr.GetString(4)
                End While
                If (hold(4) = textA) Or (hold(4) = textB) Or (hold(4) = textC) Or (hold(4) = textD) Then
                    fi = hold(4)
                End If
            End If
            closecon()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return fi
    End Function

    Public Function returnID(txt As String)
        Try
            opencon()
            cmd = New OleDbCommand("select ID from wwtbam_tbl where questions = @txt", con)
            cmd.Parameters.AddWithValue("@questions", txt)
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    n = dr.GetInt32(0)
                End While
            End If
            closecon()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return n
    End Function
End Class
