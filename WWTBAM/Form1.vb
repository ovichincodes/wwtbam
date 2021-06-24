Public Class Form1
    'Public Shared str As String = ""
    Dim num As Integer = 1
    Dim who As New wwtbam_DB()
    Dim res As String = ""
    Dim nex As String = ""
    Dim n As Integer = 0
    Dim x As Integer = 0
    Dim cnt As Integer = 30
    Dim s As Integer = -1
    Dim number As Integer
    Dim perA, perB, perC, perD As Int32
    Dim arr() As String = New String(15) {}
    Dim ran As Integer = 0

    Public Sub genRandNum()
        Dim nu As Integer
        For i = 0 To arr.Length - 1
            Randomize()
            nu = Int(Rnd(1) * 45) + 1
            If (Not (arr.Contains(nu.ToString()))) Then
                arr(i) = nu.ToString()
            Else
                nu = Int(Rnd(1) * 45) + 1
                arr(i) = nu.ToString()
            End If
        Next
        Dim r As String = ""
        For i = 0 To arr.Length - 1
            r += arr(i) + " "
        Next
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        genRandNum()
        Me.Width = 875
        Me.Height = 578
        Timer3.Start()
        blinkLbl.Visible = False
        PictureBox1.Visible = False
        PictureBox2.Visible = False
        PictureBox3.Visible = False
        surePanel.Visible = False
        quitPanel.Visible = False
        yesQuitPanel.Visible = False
        wrongAnsPanel.Visible = False
        correctAnsPanel.Visible = False
        Label34.Visible = False
        phonePercentLbl.Visible = False
        Label28.Visible = True
        Label29.Visible = True
        phoneOptionLbl.Visible = True
        Label37.Visible = False
        phonePanel.Visible = False
        Label31.Visible = False
        Label32.Visible = False
        Label33.Visible = False
        audPanel.Visible = False
        WinningPanel.Visible = False
        WinningPanel.Location = New Point(0, 24)
        WinningPanel.Size = New System.Drawing.Size(657, 315)
        audPanelCloseBtn.Visible = False
        OvalShape1.Visible = False
        timerLbl.Visible = False
        surePanel.Location = New Point(186, 126)
        quitPanel.Location = New Point(186, 126)
        phonePanel.Location = New Point(186, 126)
        audPanel.Location = New Point(227, 68)
        yesQuitPanel.Location = New Point(0, 24)
        yesQuitPanel.Size = New System.Drawing.Size(657, 315)
        wrongAnsPanel.Size = New System.Drawing.Size(657, 315)
        wrongAnsPanel.Location = New Point(0, 23)
    End Sub

    Private Sub quitBtn_Click(sender As Object, e As EventArgs) Handles quitBtn.Click
        quitPanel.Visible = True
        lifeLineLbL.Text = lifeline()
    End Sub

    Public Sub nextquest()
        ran += 1
        num = num + 1
        Dim hold() As String = New String(5) {}
        hold = who.GetNextQuest(arr(ran))
        If hold(0) = "False" Then
            MsgBox("Invalid")
        ElseIf num > 15 Then
            WinningPanel.Visible = True
            'WinningPanel.BringToFront()
            ButtonA.Enabled = False
            ButtonB.Enabled = False
            ButtonC.Enabled = False
            ButtonD.Enabled = False
            fifty.Enabled = False
            phone.Enabled = False
            audience.Enabled = False
        Else
            questLbL.Text = hold(0)
            ButtonA.Text = hold(1)
            ButtonB.Text = hold(2)
            ButtonC.Text = hold(3)
            ButtonD.Text = hold(4)
            quitBtn.Visible = True
            ButtonA.BackColor = Color.Transparent
            ButtonB.BackColor = Color.Transparent
            ButtonC.BackColor = Color.Transparent
            ButtonD.BackColor = Color.Transparent
        End If
    End Sub

    Public Sub movepanelUp()
        Dim m As Integer = movePanel.Location.Y
        Dim s As Integer = 25
        movePanel.Location = New Point(0, (m) - s)
        If m = 117 Then
            movePanel.Location = New Point(0, 117)
        End If
    End Sub

    Public Sub btngreen(btnA As Button, btnB As Button, btnC As Button, btnD As Button)
        btnA = ButtonA
        btnB = ButtonB
        btnC = ButtonC
        btnD = ButtonD
        If btnA.Enabled = True Then
            ButtonA.BackColor = Color.LawnGreen
        ElseIf btnB.Enabled = True Then
            ButtonB.BackColor = Color.LawnGreen
        ElseIf btnC.Enabled = True Then
            ButtonC.BackColor = Color.LawnGreen
        ElseIf btnD.Enabled = True Then
            ButtonD.BackColor = Color.LawnGreen
        End If
    End Sub

    Public Sub btnred(btnA As Button, btnB As Button, btnC As Button, btnD As Button)
        btnA = ButtonA
        btnB = ButtonB
        btnC = ButtonC
        btnD = ButtonD
        If btnA.Enabled = True Then
            ButtonA.BackColor = Color.Red
        ElseIf btnB.Enabled = True Then
            ButtonB.BackColor = Color.Red
        ElseIf btnC.Enabled = True Then
            ButtonC.BackColor = Color.Red
        ElseIf btnD.Enabled = True Then
            ButtonD.BackColor = Color.Red
        End If
    End Sub


    Private Sub noBtn_Click(sender As Object, e As EventArgs) Handles noBtn.Click
        surePanel.Visible = False
        quitBtn.Visible = True
        ButtonA.Enabled = True
        ButtonB.Enabled = True
        ButtonC.Enabled = True
        ButtonD.Enabled = True
        fifty.Enabled = True
        phone.Enabled = True
        audience.Enabled = True
        ButtonA.BackColor = Color.Transparent
        ButtonB.BackColor = Color.Transparent
        ButtonC.BackColor = Color.Transparent
        ButtonD.BackColor = Color.Transparent
    End Sub

    Private Sub corPanelNxtQuestbtn_Click(sender As Object, e As EventArgs) Handles corPanelNxtQuestbtn.Click
        Timer5.Stop()
        Timer6.Stop()
        Timer7.Stop()
        Label39.Location = New Point(648, 38)
        Label40.Location = New Point(652, 119)
        Label41.Location = New Point(652, 182)
        Timer2.Stop()
        My.Computer.Audio.Stop()
        surePanel.Visible = False
        nextquest()
        movepanelUp()
        Dim text() As String
        Dim nex = getNextScore()
        Dim k = ""
        text = nex.Split("N")
        For i = 0 To text.Length - 1
            k = text(1)
        Next
        changeLBL.Text = k.ToString()
        ButtonA.Visible = True
        ButtonB.Visible = True
        ButtonC.Visible = True
        ButtonD.Visible = True
        correctAnsPanel.Visible = False
    End Sub

    Private Sub yesBtn_Click(sender As Object, e As EventArgs) Handles yesBtn.Click
        Dim hold = who.getUserAns(res)
        Dim sco(14) As String
        sco = {"5,000", "7,500", "10,000", "15,000", "20,000", "45,000", "70,000", "120,000", "250,000", "500,000", "1 MILLION", "2 MILLION", "5 MILLION", "10 MILLION"}
        If hold = "1" Then
            Timer2.Start()
            btngreen(ButtonA, ButtonB, ButtonC, ButtonD)
            ButtonA.Enabled = True
            ButtonB.Enabled = True
            ButtonC.Enabled = True
            ButtonD.Enabled = True
            Timer5.Start()
            correctAnsPanel.Location = New Point(0, 23)
            correctAnsPanel.Visible = True
            My.Computer.Audio.Play(My.Resources._02___God_Rest_Ye_Merry_Gentlemen____Musicfire_in_, AudioPlayMode.BackgroundLoop)
            If s <= 13 Then
                s += 1
                If s = 14 Then
                    WinningPanel.Visible = True
                Else
                    Label40.Text = "You just won N" + sco(s)
                End If
            End If
        Else
            Timer2.Start()
            My.Computer.Audio.Play(My.Resources._02___God_Rest_Ye_Merry_Gentlemen____Musicfire_in_, AudioPlayMode.Background)
            btnred(ButtonA, ButtonB, ButtonC, ButtonD)
            Dim hol As String = who.getCorrectAns(ButtonA.Text, ButtonB.Text, ButtonC.Text, ButtonD.Text)
            If ButtonA.Text = hol Then
                ButtonA.BackColor = Color.LawnGreen
            ElseIf ButtonB.Text = hol Then
                ButtonB.BackColor = Color.LawnGreen
            ElseIf ButtonC.Text = hol Then
                ButtonC.BackColor = Color.LawnGreen
            ElseIf ButtonD.Text = hol Then
                ButtonD.BackColor = Color.LawnGreen
            End If
            ButtonA.Visible = True
            ButtonB.Visible = True
            ButtonC.Visible = True
            ButtonD.Visible = True
            ButtonA.Enabled = False
            ButtonB.Enabled = False
            ButtonC.Enabled = False
            ButtonD.Enabled = False
            fifty.Enabled = False
            phone.Enabled = False
            audience.Enabled = False
            surePanel.Visible = False
            wrongAnsPanel.Visible = True
            Label24.Text = leavingAmount()
            MessageBox.Show("Wrong Answer")
            Timer2.Stop()
            My.Computer.Audio.Stop()
        End If
    End Sub

    Public Function leavingAmount()
        Dim amount As Integer
        Dim money As String = ""
        Dim amo As String = ""
        Dim am As String = ""
        Dim text() As String
        If changeLBL.Text = " 0" Then
            money = "0"
        ElseIf changeLBL.Text.Contains("MILLION") Then
            Dim txt() As String
            txt = changeLBL.Text.Split("N")
            For j = 0 To txt.Length - 1
                money = txt(0)
            Next
        ElseIf changeLBL.Text.Contains(",") Then
            text = changeLBL.Text.Split(",")
            For i = 0 To text.Length - 1
                amo = text(0)
                am = text(1)
            Next
            Dim d As String = (amo + am)
            amount = Convert.ToInt32(d)
            Dim lbl1 = splitString(Label1.Text)
            Dim lbl5 = splitString(Label5.Text)
            Dim lbl10 = splitString(Label10.Text)
            If amount > lbl1 And amount < lbl5 Then
                money = "0"
            ElseIf amount >= lbl5 And amount < lbl10 Then
                money = "20,000"
            ElseIf amount = lbl10 Then
                money = "500,000"
            Else
                money = "0"
            End If
        End If
        Return money
    End Function

    Public Function splitString(str As String)
        Dim a As String = ""
        Dim b As String = ""
        Dim c As String = ""
        Dim text(), txt() As String
        text = str.Split("N")
        For i = 0 To text.Length - 1
            a = text(1)
        Next
        txt = a.Split(",")
        For i = 0 To txt.Length - 1
            b = txt(0)
            c = txt(1)
        Next
        Dim d As String = (b + c)
        Dim e As Integer = Convert.ToInt32(d)
        Return e
    End Function

    Public Function getNextScore() As String
        Dim score(15) As String
        score = {Label1.Text, Label2.Text, Label3.Text, Label4.Text, Label5.Text, Label6.Text, Label7.Text, Label8.Text, Label9.Text, Label10.Text, Label11.Text, Label12.Text, Label13.Text, Label14.Text, Label15.Text}
        nex = score(n)
        n += 1
        If n > 14 Then
            n = 14
            nex = score(n)
        End If
        Return nex.ToString()
    End Function

    Private Sub ButtonA_Click(sender As Object, e As EventArgs) Handles ButtonA.Click
        'fifty.Enabled = False
        'phone.Enabled = False
        'audience.Enabled = False
        ButtonB.Enabled = False
        ButtonC.Enabled = False
        ButtonD.Enabled = False
        ButtonA.BackColor = Color.Orange
        surePanel.Visible = True
        quitBtn.Visible = False
        res = ButtonA.Text
    End Sub

    Private Sub ButtonB_Click(sender As Object, e As EventArgs) Handles ButtonB.Click
        'fifty.Enabled = False
        'phone.Enabled = False
        'audience.Enabled = False
        ButtonA.Enabled = False
        ButtonC.Enabled = False
        ButtonD.Enabled = False
        ButtonB.BackColor = Color.Orange
        surePanel.Visible = True
        quitBtn.Visible = False
        res = ButtonB.Text
    End Sub

    Private Sub ButtonC_Click(sender As Object, e As EventArgs) Handles ButtonC.Click
        'fifty.Enabled = False
        'phone.Enabled = False
        'audience.Enabled = False
        ButtonA.Enabled = False
        ButtonB.Enabled = False
        ButtonD.Enabled = False
        ButtonC.BackColor = Color.Orange
        surePanel.Visible = True
        quitBtn.Visible = False
        res = ButtonC.Text
    End Sub

    Private Sub ButtonD_Click(sender As Object, e As EventArgs) Handles ButtonD.Click
        'fifty.Enabled = False
        'phone.Enabled = False
        'audience.Enabled = False
        ButtonA.Enabled = False
        ButtonB.Enabled = False
        ButtonC.Enabled = False
        ButtonD.BackColor = Color.Orange
        surePanel.Visible = True
        quitBtn.Visible = False
        res = ButtonD.Text
    End Sub

    Private Sub fifty_Click(sender As Object, e As EventArgs) Handles fifty.Click
        PictureBox1.Visible = True
        PictureBox1.Location = New Point(13, 23)
        fifty.Enabled = False
        phone.Enabled = True
        audience.Enabled = True
        Dim r = who.returnID(questLbL.Text)
        Dim h = who.life5050(ButtonA.Text, ButtonB.Text, ButtonC.Text, ButtonD.Text, r)
        removeFiftyBtn(h)
    End Sub

    'Makes the fifty-fifty lifeline work
    Private Sub removeFiftyBtn(re As String)
        Randomize()
        Dim n As Int32 = Int(Rnd(1) * 3) + 1
        If re = ButtonA.Text Then
            If n = 1 Then
                ButtonC.Visible = False
                ButtonD.Visible = False
            ElseIf n = 2 Then
                ButtonB.Visible = False
                ButtonD.Visible = False
            ElseIf n = 3 Then
                ButtonB.Visible = False
                ButtonC.Visible = False
            End If
        ElseIf re = ButtonB.Text Then
            If n = 1 Then
                ButtonC.Visible = False
                ButtonD.Visible = False
            ElseIf n = 2 Then
                ButtonA.Visible = False
                ButtonD.Visible = False
            ElseIf n = 3 Then
                ButtonA.Visible = False
                ButtonC.Visible = False
            End If
        ElseIf re = ButtonC.Text Then
            If n = 1 Then
                ButtonB.Visible = False
                ButtonD.Visible = False
            ElseIf n = 2 Then
                ButtonA.Visible = False
                ButtonD.Visible = False
            ElseIf n = 3 Then
                ButtonA.Visible = False
                ButtonB.Visible = False
            End If
        ElseIf re = ButtonD.Text Then
            If n = 1 Then
                ButtonB.Visible = False
                ButtonC.Visible = False
            ElseIf n = 2 Then
                ButtonA.Visible = False
                ButtonC.Visible = False
            ElseIf n = 3 Then
                ButtonA.Visible = False
                ButtonB.Visible = False
            End If
        End If
    End Sub

    Private Sub phone_Click(sender As Object, e As EventArgs) Handles phone.Click
        ButtonA.Enabled = False
        ButtonB.Enabled = False
        ButtonC.Enabled = False
        ButtonD.Enabled = False
        fifty.Enabled = False
        audience.Enabled = False
        OvalShape1.Visible = True
        timerLbl.Visible = True
        phonePanel.Visible = True
        Timer1.Start()
        phoneOptionLbl.Text = returnPhoneRandOption()
        phonePercentLbl.Text = returnPhoneRandPercent()
        PictureBox2.Visible = True
        PictureBox2.Location = New Point(77, 23)
        phone.Enabled = False
    End Sub

    Public Function returnPhoneRandOption()
        Dim options As String = ""
        Randomize()
        number = Int(Rnd(1) * 4) + 1
        If number = 1 Then
            options = "A"
        ElseIf number = 2 Then
            options = "B"
        ElseIf number = 3 Then
            options = "C"
        ElseIf number = 4 Then
            options = "D"
        End If
        Return options
    End Function

    Public Function returnPhoneRandPercent()
        Dim per As String = ""
        Dim percent As String = ""
        Randomize()
        number = Int(Rnd(50) * 100) + 1
        per = number.ToString()
        percent = per & "%"
        Return percent
    End Function

    Public Sub returnAudRandPercent()
        Randomize()
        number = Int(Rnd(1) * 100) + 1
        If number < 100 Then
            perA = number
            returnPercentLevel(perA, RectangleShapeA)
            audPanelA.Text = perA.ToString() + "%"
        End If
        If (100 - perA) <> 0 Then
            perB = 100 - perA
            perB = Int(Rnd(1) * perB) + 1
            returnPercentLevel(perB, RectangleShapeB)
            audPanelB.Text = perB.ToString() + "%"
        End If
        If (100 - (perA + perB)) <> 0 Then
            perC = 100 - (perA + perB)
            perC = Int(Rnd(1) * perC) + 1
            returnPercentLevel(perC, RectangleShapeC)
            audPanelC.Text = perC.ToString() + "%"
        End If
        If (100 - (perA + perB + perC)) <> 0 Then
            perD = 100 - (perA + perB + perC)
            perD = Int(Rnd(1) * perD) + 1
            returnPercentLevel(perD, RectangleShapeD)
            audPanelD.Text = perD.ToString() + "%"
        End If
    End Sub

    Public Sub returnPercentLevel(per As Integer, srec As PowerPacks.RectangleShape)
        Dim hA As Integer = srec.Size.Height
        If (per >= 90 And per < 100) Then
            srec.Size = New System.Drawing.Size(15, hA)
        ElseIf (per >= 80 And per < 90) Then
            srec.Size = New System.Drawing.Size(15, (hA - 16))
        ElseIf (per >= 70 And per < 80) Then
            srec.Size = New System.Drawing.Size(15, (hA - 32))
        ElseIf (per >= 60 And per < 70) Then
            srec.Size = New System.Drawing.Size(15, (hA - 48))
        ElseIf (per >= 50 And per < 60) Then
            srec.Size = New System.Drawing.Size(15, (hA - 64))
        ElseIf (per >= 40 And per < 50) Then
            srec.Size = New System.Drawing.Size(15, (hA - 80))
        ElseIf (per >= 30 And per < 40) Then
            srec.Size = New System.Drawing.Size(15, (hA - 96))
        ElseIf (per >= 20 And per < 30) Then
            srec.Size = New System.Drawing.Size(15, (hA - 112))
        ElseIf (per >= 10 And per < 20) Then
            srec.Size = New System.Drawing.Size(15, (hA - 128))
        ElseIf (per >= 0 And per < 10) Then
            srec.Size = New System.Drawing.Size(15, (hA - 144))
        End If
    End Sub

    Private Sub audience_Click(sender As Object, e As EventArgs) Handles audience.Click
        PictureBox3.Visible = True
        PictureBox3.Location = New Point(136, 23)
        audience.Enabled = False
        fifty.Enabled = False
        phone.Enabled = False
        audPanel.Visible = True
        audPanelCloseBtn.Visible = True
        returnAudRandPercent()
    End Sub

    Private Sub noQuit_Click(sender As Object, e As EventArgs) Handles noQuit.Click
        quitPanel.Visible = False
    End Sub

    Private Sub yesQuit_Click(sender As Object, e As EventArgs) Handles yesQuit.Click
        quitPanel.Visible = False
        yesQuitPanel.Visible = True
        Label26.Text = changeLBL.Text
    End Sub

    'Diable and enable lifeline
    Public Function lifeline()
        Dim life As Integer
        If fifty.Enabled = False And phone.Enabled = False And audience.Enabled = False Then
            life = 0
        ElseIf (fifty.Enabled = False And phone.Enabled = False) Or (fifty.Enabled = False And audience.Enabled = False) Then
            life = 1
        ElseIf (phone.Enabled = False And audience.Enabled = False) Or (phone.Enabled = False And fifty.Enabled = False) Then
            life = 1
        ElseIf (fifty.Enabled = False Or phone.Enabled = False Or audience.Enabled = False) Then
            life = 2
        Else
            life = 3
        End If
        Return life
    End Function

    Private Sub btnWrongExitGame_Click(sender As Object, e As EventArgs) Handles btnWrongExitGame.Click
        Application.Exit()
    End Sub

    Private Sub btnWrongPlayAgain_Click(sender As Object, e As EventArgs) Handles btnWrongPlayAgain.Click
        Application.Restart()
    End Sub

    Private Sub yesQuitPlayAgain_Click(sender As Object, e As EventArgs) Handles yesQuitPlayAgain.Click
        Application.Restart()
    End Sub

    Private Sub yesQuitExitGame_Click(sender As Object, e As EventArgs) Handles yesQuitExitGame.Click
        Application.Exit()
    End Sub

    Private Sub hangUpbtn_Click(sender As Object, e As EventArgs) Handles hangUpbtn.Click
        ButtonA.Enabled = True
        ButtonB.Enabled = True
        ButtonC.Enabled = True
        ButtonD.Enabled = True
        fifty.Enabled = True
        audience.Enabled = True
        Timer1.Stop()
        timerLbl.Visible = False
        OvalShape1.Visible = False
        phonePanel.Visible = False
    End Sub

    Private Sub hangUpbtn_MouseHover(sender As Object, e As EventArgs) Handles hangUpbtn.MouseHover
        hangUpbtn.Font = New Font("Microsoft Sans Serif", 9, FontStyle.Bold)
    End Sub

    Private Sub hangUpbtn_MouseLeave(sender As Object, e As EventArgs) Handles hangUpbtn.MouseLeave
        hangUpbtn.Font = New Font("Microsoft Sans Serif", 9)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If cnt > 0 Then
            cnt = cnt - 1
            If cnt = 23 Then
                Label31.Visible = True
                Label37.Visible = True
            ElseIf cnt = 16 Then
                Label32.Visible = True
                Label33.Visible = True
                phonePercentLbl.Visible = True
                Label34.Visible = True
            ElseIf cnt = 9 Then
                timerLbl.Location = New Point(310, 84)
            ElseIf cnt = 0 Then
                OvalShape1.Visible = False
                timerLbl.Visible = False
                phonePanel.Visible = False
                ButtonA.Enabled = True
                ButtonB.Enabled = True
                ButtonC.Enabled = True
                ButtonD.Enabled = True
                fifty.Enabled = True
                audience.Enabled = True
            End If
            timerLbl.Text = cnt.ToString()
        Else
            timerLbl.Text = "0"
        End If
    End Sub

    Private Sub winningExitGame_Click(sender As Object, e As EventArgs) Handles winningExitGame.Click
        Application.Exit()
    End Sub

    Private Sub winningPlayAgain_Click(sender As Object, e As EventArgs) Handles winningPlayAgain.Click
        Application.Restart()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim na As Integer = Convert.ToInt32(blinkLbl.Text)
        If na > 0 Then
            na = na - 1
            Dim hol As String = who.getCorrectAns(ButtonA.Text, ButtonB.Text, ButtonC.Text, ButtonD.Text)
            If na Mod 2 = 0 Then
                If ButtonA.Text = hol Then
                    ButtonA.BackColor = Color.LawnGreen
                ElseIf ButtonB.Text = hol Then
                    ButtonB.BackColor = Color.LawnGreen
                ElseIf ButtonC.Text = hol Then
                    ButtonC.BackColor = Color.LawnGreen
                ElseIf ButtonD.Text = hol Then
                    ButtonD.BackColor = Color.LawnGreen
                End If
            Else
                If ButtonA.Text = hol Then
                    ButtonA.BackColor = Color.Transparent
                ElseIf ButtonB.Text = hol Then
                    ButtonB.BackColor = Color.Transparent
                ElseIf ButtonC.Text = hol Then
                    ButtonC.BackColor = Color.Transparent
                ElseIf ButtonD.Text = hol Then
                    ButtonD.BackColor = Color.Transparent
                End If
            End If
            blinkLbl.Text = na.ToString("0")
        Else
            blinkLbl.Text = "0"
        End If
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        ButtonA.Enabled = False
        ButtonB.Enabled = False
        ButtonC.Enabled = False
        ButtonD.Enabled = False
        fifty.Enabled = False
        phone.Enabled = False
        audience.Enabled = False
        quitBtn.Visible = False
        Dim m As Integer = movePanel.Location.Y
        Dim s As Int32 = 25
        If m = 117 Then
            If movePanel.BackColor = Color.Orange Then
                movePanel.BackColor = Color.Transparent
            Else
                movePanel.BackColor = Color.Orange
                x += 1
                If x = 6 Then
                    Timer3.Stop()
                    Timer4.Start()
                End If
            End If
        Else
            movePanel.Location = New Point(0, (m - s))
        End If
    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        Dim m As Integer = movePanel.Location.Y
        Dim s As Int32 = 25
        If m = 467 Then
            Timer4.Stop()
            ButtonA.Enabled = True
            ButtonB.Enabled = True
            ButtonC.Enabled = True
            ButtonD.Enabled = True
            fifty.Enabled = True
            phone.Enabled = True
            audience.Enabled = True
            quitBtn.Visible = True
            Dim hold() As String = New String(5) {}
            hold = who.getquest(Convert.ToInt32(arr(ran)))
            If hold(0) = "False" Then
                MsgBox("Invalid")
            Else
                questLbL.Text = hold(0)
                ButtonA.Text = hold(1)
                ButtonB.Text = hold(2)
                ButtonC.Text = hold(3)
                ButtonD.Text = hold(4)
            End If
        Else
            movePanel.Location = New Point(0, (m + s))
        End If
    End Sub


    Private Sub audPanelCloseBtn_Click(sender As Object, e As EventArgs) Handles audPanelCloseBtn.Click
        audPanel.Visible = False
        audPanelCloseBtn.Visible = False
        phone.Enabled = True
        fifty.Enabled = True
    End Sub

    Private Sub audPanelCloseBtn_MouseHover(sender As Object, e As EventArgs) Handles audPanelCloseBtn.MouseHover
        audPanelCloseBtn.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
    End Sub

    Private Sub audPanelCloseBtn_MouseLeave(sender As Object, e As EventArgs) Handles audPanelCloseBtn.MouseLeave
        audPanelCloseBtn.Font = New Font("Microsoft Sans Serif", 9)
        fifty.Enabled = True
        phone.Enabled = True
    End Sub

    Dim xa As Integer
    Private Sub Timer5_Tick(sender As Object, e As EventArgs) Handles Timer5.Tick
        xa = Label39.Location.X
        If xa > 200 Then
            xa -= 4
            Label39.Location = New Point(xa, 38)
            If xa = 200 Then
                Timer5.Stop()
                Timer6.Start()
            End If
        End If
    End Sub

    Dim ax As Integer
    Private Sub Timer6_Tick(sender As Object, e As EventArgs) Handles Timer6.Tick
        ax = Label40.Location.X
        If ax > 80 Then
            ax -= 4
            Label40.Location = New Point(ax, 107)
            If ax = 80 Then
                Timer6.Stop()
                Timer7.Start()
            End If
        End If
    End Sub

    Dim ab As Integer
    Private Sub Timer7_Tick(sender As Object, e As EventArgs) Handles Timer7.Tick
        ab = Label41.Location.X
        If ab > 4 Then
            ab -= 4
            Label41.Location = New Point(ab, 182)
            If ab = 4 Then
                Timer7.Stop()
            End If
        End If
    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click

    End Sub
End Class
