'****************************************
'* Purpose: This class supports printing
'* for a program.  It accepts a string
'* and prints it to a report with headings
'* and page numbers etc.  It will word wrap
'* a memo string.
'*
'* Author:  Les Smith
'* Date Created: 02/28/2004 at 11:15:08
'* CopyRight:  KnowDotNet
'****************************************
Imports System
Imports System.Drawing
Imports System.Drawing.Text
Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Public Class CPrintReportString

#Region " Class Level Variables "
   '` The following methods are exposed by this
   '' object.
   '` 1) InitializeReport - Sets up font for detail
   '' printing.
   '` 2) PrintString - Call to print a string object of
   '' multiple lines.
   '` Internally, a PrintDocument object will be
   '` instantiated, along with a PrintPage Event.
   '` Calling the .Print method of the PrintDocument
   '` instance will automatically fire the PrintPage
   '` event to get the next page to print.  In VB6,
   '` printing was done linearly.  In VB.NET, it is
   '` done through an Event methodology.  The user
   '` initiates the printing object and the object
   '' calls the PrintPage event to get a page to print.
   ''
   ' 
   ' Print directives allow you to change properites
   ' dynamically within the print string.
   ' <:CH1>Heading 1
   ' <:CH2>Heading 2
   ' <:CH3>Heading 3
   ' <:CH4>Heading 4
   ' <:NEWPAGE>
   ' <:NOLINES>
   ' <:LINES>
   ' <:SUBTITLE>New SubTitle Line
   ' <:PAGENBR0>  resets the page count
   Public Enum Align
      Left
      Right
      Center
   End Enum
   Public Enum FormatString
      [Default]
      Currency
      DateTime
      YesNo
      [Boolean]
   End Enum
   Public Enum CharsPerLine
      CPL80
      CPL96
      CPL120
      CPL160
   End Enum
   Public Enum PrintOrientation
      Portrait
      Landscape
   End Enum
   Public Enum PrintPreview
      Print
      Preview
   End Enum
   Public Enum TitleStyle
      [Default]
      Bold
      Italic
      BoldItalic
   End Enum
   Public Enum MarginExtender
      None
      OneTenthInch
      OneQuarterInch
      OneHalfInch
      ThreeQuarterInch
      OneInch
   End Enum
   Private _ColHdr1 As String = String.Empty
   Private _ColHdr2 As String = String.Empty
   Private _ColHdr3 As String = String.Empty
   Private _ColHdr4 As String = String.Empty
   Private _SubTitle2 As String = ""
   Private _SubTitle3 As String = ""
   Private _SubTitle4 As String = ""
   Private _Title As String
   Private _SubTitle As String
   Private _WordWrap As Integer = 0
   Private _SepLines As Boolean = False
   Private _TitleFontSize As Single = 12
   Private _TitleFontStyle As TitleStyle
   Private _PrintFooter As Boolean = True
   Private _DrawBox As Boolean
   Private _LeftMarginExtender As MarginExtender
   Private _RightMarginExtender As MarginExtender
   Private _TopMarginExtender As MarginExtender
   Private _BottomMarginExtender As MarginExtender
   Private WithEvents PrintDoc As Printing.PrintDocument
   Private msRptString As String ' holds the report string
   Private miNL As Integer ' number of lines in the report
   Private miNL2 As Integer ' number of sub lines in line
   Private mI As Integer
   Private mI2 As Integer
   Private CurrentLine As Integer ' curr print line on a page
   Private miChrPerLine As Integer ' nbr chars to print per line
   Private PageNbr As Integer
   Private Portrait As Boolean = True ' landscape if false
   Private ColHdrArrayList As New ArrayList
   Private ColHdrCount As Integer = 0
   Public Heading As String
   Private DetailFontSize As Single
   Dim oUtil As CUtilities
   Dim oUtil2 As CUtilities
   Dim msLine As String
   Dim msToken As String
   Dim sFooter As String
   Dim miFileType As Integer
   Dim miWordWrap As Integer = 0
   Const DETAIL_FONT As String = "Courier New"
   Const DETAIL_FONT_SIZE_80 As Integer = 10
   Const DETAIL_FONT_SIZE_96 As Integer = 9
   Const DETAIL_FONT_SIZE_120 As Integer = 8 '118 with 1/4 margins
   Const DETAIL_FONT_SIZE_160 As Integer = 6
   Const DETAIL_FONT_BOLD As Boolean = True
#End Region

#Region " Public Methods "
   Public Sub PrintOrPreview(ByVal CPL As CharsPerLine, _
         ByRef PPrintBlock As String, ByVal PTitle As String, _
         ByVal PSubTitle As String, ByVal PVOption As PrintPreview, _
         ByVal Layout As PrintOrientation)
      PrintOrPreview(CPL, PPrintBlock, PTitle, PSubTitle, PVOption, Layout, "", "", "", "")
   End Sub

   Public Sub PrintOrPreview(ByVal CPL As CharsPerLine, _
          ByRef PPrintBlock As String, ByVal PTitle As String, _
          ByVal PSubTitle As String, ByVal PVOption As PrintPreview, _
          ByVal Layout As PrintOrientation, ByVal ColHdr1 As String)
      PrintOrPreview(CPL, PPrintBlock, PTitle, PSubTitle, PVOption, Layout, ColHdr1, "", "", "")
   End Sub

   Public Sub PrintOrPreview(ByVal CPL As CharsPerLine, _
         ByRef PPrintBlock As String, ByVal PTitle As String, _
         ByVal PSubTitle As String, ByVal PVOption As PrintPreview, _
         ByVal Layout As PrintOrientation, ByVal ColHdr1 As String, _
         ByVal ColHdr2 As String)
      PrintOrPreview(CPL, PPrintBlock, PTitle, PSubTitle, PVOption, Layout, ColHdr1, ColHdr2, "", "")
   End Sub

   Public Sub PrintOrPreview(ByVal CPL As CharsPerLine, _
       ByRef PPrintBlock As String, ByVal PTitle As String, _
       ByVal PSubTitle As String, ByVal PVOption As PrintPreview, _
       ByVal Layout As PrintOrientation, ByVal ColHdr1 As String, _
       ByVal ColHdr2 As String, ByVal ColHdr3 As String)
      PrintOrPreview(CPL, PPrintBlock, PTitle, PSubTitle, PVOption, Layout, ColHdr1, ColHdr2, ColHdr3, "")
   End Sub


   Public Sub PrintOrPreview(ByVal CPL As CharsPerLine, _
      ByRef PPrintBlock As String, _
      ByVal PTitle As String, _
      ByVal PSubTitle As String, _
      ByVal PVOption As PrintPreview, _
      ByVal Layout As PrintOrientation, _
      ByVal ColHdr1 As String, _
      ByVal ColHdr2 As String, _
      ByVal ColHdr3 As String, _
      ByVal ColHdr4 As String)

      Dim previewDialog As PrintPreviewDialog
      Try
         miWordWrap = WordWrap
         Portrait = (Layout = PrintOrientation.Portrait)
         msRptString = PPrintBlock
			Title = PSubTitle
         SubTitle = PSubTitle
         SetUpColHdrArray(ColHdr1, ColHdr2, ColHdr3, ColHdr4)
         miChrPerLine = CPL
         ' create two objects so that we can use
         ' nested calls to MemoLine w/o stepping
         ' on each other... used when wordwrap is on
         oUtil = New CUtilities
         oUtil2 = New CUtilities

         sFooter = "Printed on: " & Now.ToString
         ' chars per line will vary based on the margins
         Select Case CPL
            Case CharsPerLine.CPL80 : DetailFontSize = DETAIL_FONT_SIZE_80
            Case CharsPerLine.CPL96 : DetailFontSize = DETAIL_FONT_SIZE_96
            Case CharsPerLine.CPL120 : DetailFontSize = DETAIL_FONT_SIZE_120
            Case CharsPerLine.CPL160 : DetailFontSize = DETAIL_FONT_SIZE_160
            Case Else
               Throw New System.Exception("Invalid CharsPerLine parameter")
         End Select

         ' set up memoline
         miNL = oUtil.MLCount(msRptString, WordWrap)
         If miNL = 0 Then
            MsgBox("No lines to print in report string.", _
               MsgBoxStyle.Exclamation)
            Exit Sub
         End If

         mI = 1
         PrintDoc = New Printing.PrintDocument
         PrintDoc.DefaultPageSettings.Landscape = _
            (Layout = PrintOrientation.Landscape)
         PrintDoc.DocumentName = Title

         If PVOption = PrintPreview.Preview Then
            previewDialog = New PrintPreviewDialog
            previewDialog.Document = PrintDoc
            previewDialog.ShowDialog()
            previewDialog.Dispose()
         Else
            PrintDoc.Print()
         End If

         PrintDoc.Dispose()

      Catch ex As System.Exception
         MsgBox(ex.ToString)
      End Try
   End Sub


#End Region

#Region " Private Methods "

   Private Sub PrtDoc_PrintPage(ByVal sender As Object, _
      ByVal e As System.Drawing.Printing.PrintPageEventArgs) _
      Handles PrintDoc.PrintPage

      '` This method handles the event from the PrtDoc
      '` object.  It supplies the line(s) to be printed by
      '` calling the DrawString method of the events
      '` PrintPageEventArgs parameter, supplied to the
      '' event.
      '-------------------------------------------------------'
      ' method to determine how wide a sub string is
      ' Dim sz As Drawing.SizeF
      ' sz = e.Graphics.MeasureString("This string", PrintFont)
      ' h = sz.Height
      ' Dim w As Integer = sz.Width
      ' xPos += w
      '-------------------------------------------------------'
      Dim LineHeight As Single
      Dim LineWidth As Single
      Dim yPos As Single
      Dim xPos As Single
      Dim PrintFont As Font

      Try
         Static i As Integer
			'Static nL As Integer
         Static sLine As String
			'Dim br As Brushes
			'Dim o As Object
			'Static Quotes As Integer
			'Static iChrB4NonSpace As Integer
         Dim sHdrLine As String
         Dim CharWidth As Single
         Dim chartest As String = " "
         Dim sz As Drawing.SizeF
         Dim TextWidth As Single
         Dim sPageNbr As String
			'Dim bDoneWithString As Boolean
         Dim x1 As Single
         Dim y1 As Single
         Dim x2 As Single
         Dim y2 As Single
         Dim drPen As New Pen(Color.Black, 1)
         Dim LeftMargin As Single
         Dim RightMargin As Single
         Dim TopMargin As Single
         Dim BottomMargin As Single
         Dim iLineLen As Integer = miChrPerLine

         ' Compute the margins after determining
         ' landscape or portrait
         PrintFont = New Font(DETAIL_FONT, DetailFontSize)
         sz = e.Graphics.MeasureString("M", PrintFont)
         CharWidth = sz.Width

         ' check for marginextenders
         Dim lmExt As Integer = 0
         Dim rmExt As Integer = 0
         Dim tmExt As Integer = 0
         Dim bmExt As Integer = 0
         GetMarginExtenders(lmExt, rmExt, tmExt, bmExt)

         ' determine the print area
         Dim rect As New System.Drawing.Rectangle(e.PageBounds.X + 15 + lmExt, _
                                                  e.PageBounds.Y + 15 + tmExt, _
                                                  e.PageBounds.Width - (80 + rmExt), _
                                                  e.PageBounds.Height - (75 + bmExt))
         RightMargin = rect.Right
         LeftMargin = rect.Left

         TopMargin = rect.Top 'e.MarginBounds.Top - (4 * sz.Height)
         BottomMargin = rect.Bottom 'e.MarginBounds.Bottom + (2 * sz.Height)

         xPos = LeftMargin
         yPos = TopMargin

         If _DrawBox Then
            Dim drPen2 As New Pen(Color.Black, 2)
            e.Graphics.DrawRectangle(drPen2, rect)
         End If

         ' Print the header on this page first thing
         ' First, print the title
         PageNbr += 1
         If _TitleFontStyle = TitleStyle.BoldItalic Then
            PrintFont = New Font("Arial", _TitleFontSize, FontStyle.Italic Or FontStyle.Bold)
         ElseIf _TitleFontStyle = TitleStyle.Bold Then
            PrintFont = New Font("Arial", _TitleFontSize, FontStyle.Bold)
         ElseIf _TitleFontStyle = TitleStyle.Italic Then
            PrintFont = New Font("Arial", _TitleFontSize, FontStyle.Italic)
         Else
            PrintFont = New Font("Arial", _TitleFontSize)
         End If

         LineHeight = PrintFont.GetHeight(e.Graphics)
         sz = e.Graphics.MeasureString(Title, PrintFont)
         TextWidth = sz.Width
         LineWidth = RightMargin + LeftMargin

         xPos = (LineWidth - TextWidth) / 2
         e.Graphics.DrawString(Title, _
                                 PrintFont, _
                                 Brushes.Black, _
                                 xPos, _
                                 yPos, _
                                 New StringFormat)
         yPos += LineHeight

         ' Second, print the SubTitle
         PrintFont = New Font("Arial", 10, FontStyle.Bold)
         xPos = LeftMargin
         LineHeight = PrintFont.GetHeight(e.Graphics)
         sHdrLine = _SubTitle
         e.Graphics.DrawString(sHdrLine, _
            PrintFont, _
            Brushes.Black, _
            xPos, _
            yPos, _
            New StringFormat)

         ' next print the page number on the right end
         ' of the last subtitle line
         If _SubTitle2.Length = 0 Then
            sPageNbr = PageNbr.ToString
            xPos = RightMargin - (7 * CharWidth)
            e.Graphics.DrawString("Page: " & sPageNbr, PrintFont, Brushes.Black, xPos, yPos, New StringFormat)
         End If
         yPos += LineHeight

         'print subtitile2 if extant
         ' Second, print the SubTitle
         If _SubTitle2.Length > 0 Then
            PrintFont = New Font("Arial", 10, FontStyle.Bold)
            xPos = LeftMargin
            LineHeight = PrintFont.GetHeight(e.Graphics)
            sHdrLine = _SubTitle2
            e.Graphics.DrawString(sHdrLine, _
               PrintFont, _
               Brushes.Black, _
               xPos, _
               yPos, _
               New StringFormat)
            ' next print the page number on the right end
            ' of the last subtitle line
            If _SubTitle3.Length = 0 Then
               sPageNbr = PageNbr.ToString
               xPos = RightMargin - (7 * CharWidth)
               e.Graphics.DrawString("Page: " & sPageNbr, PrintFont, Brushes.Black, xPos, yPos, New StringFormat)
            End If
            yPos += LineHeight
         End If

         'print subtitile3 if extant
         ' Second, print the SubTitle
         If _SubTitle3.Length > 0 Then
            PrintFont = New Font("Arial", 10, FontStyle.Bold)
            xPos = LeftMargin
            LineHeight = PrintFont.GetHeight(e.Graphics)
            sHdrLine = _SubTitle3
            e.Graphics.DrawString(sHdrLine, _
               PrintFont, _
               Brushes.Black, _
               xPos, _
               yPos, _
               New StringFormat)
            ' next print the page number on the right end
            ' of the last subtitle line
            If _SubTitle4.Length = 0 Then
               sPageNbr = PageNbr.ToString
               xPos = RightMargin - (7 * CharWidth)
               e.Graphics.DrawString("Page: " & sPageNbr, PrintFont, Brushes.Black, xPos, yPos, New StringFormat)
            End If
            yPos += LineHeight
         End If

         'print subtitile4 if extant
         ' Second, print the SubTitle
         If _SubTitle4.Length > 0 Then
            PrintFont = New Font("Arial", 10, FontStyle.Bold)
            xPos = LeftMargin
            LineHeight = PrintFont.GetHeight(e.Graphics)
            sHdrLine = _SubTitle4
            e.Graphics.DrawString(sHdrLine, _
               PrintFont, _
               Brushes.Black, _
               xPos, _
               yPos, _
               New StringFormat)
            ' next print the page number on the right end
            ' of the last subtitle line
            sPageNbr = PageNbr.ToString
            xPos = RightMargin - (7 * CharWidth)
            e.Graphics.DrawString("Page: " & sPageNbr, PrintFont, Brushes.Black, xPos, yPos, New StringFormat)
            yPos += LineHeight
         End If
         ' now print a line
         ' put a little space before the line
         x1 = LeftMargin
         y1 = yPos
         x2 = RightMargin
         y2 = yPos
         e.Graphics.DrawLine(drPen, x1, y1, x2, y2)

         PrintFont = New Font(DETAIL_FONT, DetailFontSize, FontStyle.Bold)

         ' if a headings are extant, print them
         If ColHdrCount > 0 Then
            Dim p As Integer
            For p = 0 To ColHdrCount - 1
               yPos += 2
               If CStr(ColHdrArrayList(p)).Length > 0 Then
                  xPos = LeftMargin
                  LineHeight = PrintFont.GetHeight(e.Graphics)
                  sHdrLine = SubTitle
                  e.Graphics.DrawString(CStr(ColHdrArrayList(p)), _
                     PrintFont, _
                     Brushes.Black, _
                     xPos, _
                     yPos, _
                     New StringFormat)
                  yPos += LineHeight

               End If
            Next p
         End If

         ' now print a line
         ' put a little space before the line
         yPos += 4
         x1 = LeftMargin 'e.MarginBounds.Left
         y1 = yPos
         x2 = RightMargin 'e.MarginBounds.Right
         y2 = yPos
         e.Graphics.DrawLine(drPen, x1, y1, x2, y2)
         yPos += 4
         ' now print a line
         ' put a little space before the line
         x1 = LeftMargin 'e.MarginBounds.Left
         y1 = yPos
         x2 = RightMargin 'e.MarginBounds.Right
         y2 = yPos
         e.Graphics.DrawLine(drPen, x1, y1, x2, y2)

         yPos += 4

         ' we can just call memoline limiting the lines to
         ' a length that will fit on a line of print

         ' if we have a blank line, don't print a sep line
         ' after it...
         Dim bBlank As Boolean

         ' Print directives
         ' <:CH1>Heading 1
         ' <:CH2>Heading 2
         ' <:CH3>Heading 3
         ' <:CH4>Heading 4
         ' <:NEWPAGE>
         ' <:NOLINES>
         ' <:LINES>
         ' <:SUBTITLE>New SubTitle Line
         ' <:SUBTITLE2>New SubTitle Line
         ' <:SUBTITLE3>New SubTitle Line
         ' <:SUBTITLE4>New SubTitle Line
         ' <:PAGENBR0>  resets the page count
         For i = mI To miNL
            ' just get a line and print it and then
            ' check to see if there is enough room to print another
            ' line.
            sLine = oUtil.MemoLine(msRptString, miWordWrap, i)

            ' ck for print directives
            If sLine.Length > 0 Then
               If sLine.Substring(0, 2) = "<:" Then
                  ' we have a print directive telling us to change something
                  If sLine.Substring(2, 3) = "CH1" Then
                     ' <:CH>New col heading 1
                     ColHdrArrayList(0) = sLine.Substring(6)
                     GoTo GetNextLine
                  ElseIf sLine.Substring(2, 3) = "CH2" Then
                     ' <:CH>New col heading 1
                     ColHdrArrayList(1) = sLine.Substring(6)
                     GoTo GetNextLine
                  ElseIf sLine.Substring(2, 3) = "CH3" Then
                     ' <:CH>New col heading 1
                     ColHdrArrayList(2) = sLine.Substring(6)
                     GoTo GetNextLine
                  ElseIf sLine.Substring(2, 3) = "CH4" Then
                     ' <:CH>New col heading 1
                     ColHdrArrayList(3) = sLine.Substring(6)
                     GoTo GetNextLine
                  ElseIf sLine.Substring(2, 7).StartsWith("NEWPAGE") Then
                     GoTo EndPage
                  ElseIf sLine.Substring(2, 7).StartsWith("NOLINES") Then
                     _SepLines = False
                  ElseIf sLine.Substring(2, 5).StartsWith("LINES") Then
                     _SepLines = True
                  ElseIf sLine.Substring(2, 8).StartsWith("PAGENBR0") Then
                     PageNbr = 0 : GoTo GetNextLine
                  ElseIf sLine.Substring(2, 9).StartsWith("SUBTITLE1") Then
                     ' <:SUBTITLE1>NEW sub title line
                     Me._SubTitle = sLine.Substring(12)
                     GoTo GetNextLine
                  ElseIf sLine.Substring(2, 9).StartsWith("SUBTITLE2") Then
                     ' <:SUBTITLE2>NEW sub title line
                     Me._SubTitle2 = sLine.Substring(12)
                     GoTo GetNextLine
                  ElseIf sLine.Substring(2, 9).StartsWith("SUBTITLE3") Then
                     ' <:SUBTITLE3>NEW sub title line
                     Me._SubTitle3 = sLine.Substring(12)
                     GoTo GetNextLine
                  ElseIf sLine.Substring(2, 9).StartsWith("SUBTITLE4") Then
                     ' <:SUBTITLE4>NEW sub title line
                     Me._SubTitle4 = sLine.Substring(12)
                     GoTo GetNextLine
                  End If
               End If
            End If


            If (sLine Is Nothing OrElse sLine.Length = 0) Then
               ' dont print a blank line, just bump yPos
               bBlank = True
            Else
               LineHeight = PrintFont.GetHeight(e.Graphics)
               xPos = LeftMargin
               bBlank = False
            End If

            PrintFont = New Font(DETAIL_FONT, DetailFontSize, FontStyle.Bold)
            e.Graphics.DrawString(sLine, _
                                 PrintFont, _
                                 Brushes.Black, _
                                 xPos, _
                                 yPos, _
                                 New StringFormat)
            yPos += LineHeight

            If _SepLines Then
               If Not bBlank Then
                  ' insert the print of a seperator line if SepLines=True
                  ' put a little space before the line
                  yPos += 2
                  x1 = LeftMargin
                  y1 = yPos
                  x2 = RightMargin
                  y2 = yPos
                  e.Graphics.DrawLine(drPen, x1, y1, x2, y2)
                  yPos += 2
               End If
            End If

            ' check to see if we are at the end of the page
            If yPos >= (BottomMargin - (2 * LineHeight)) Then
               ' end of page, ck for more lines to print
               ' after print the footer
               ' put a little space before the line
EndPage:
               yPos = BottomMargin - (2 * LineHeight)
               yPos += 14
               x1 = LeftMargin
               y1 = yPos
               x2 = RightMargin
               y2 = yPos
               If Not _PrintFooter Then GoTo EndPage2
               e.Graphics.DrawLine(drPen, x1, y1, x2, y2)
               yPos += 4

               PrintFont.Dispose()
               PrintFont = New Font("Arial", 10)
               xPos = LeftMargin
               e.Graphics.DrawString(sFooter, _
                  PrintFont, _
                  Brushes.Black, _
                  xPos, _
                  yPos, _
                  New StringFormat)
EndPage2:
               ' ck for more lines to print
               If i < miNL Then
                  e.HasMorePages = True
                  ' set ptr to next line back
                  mI = i + 1
                  Exit Sub
               Else
                  e.HasMorePages = False
                  PageNbr = 0 ' in case called again from preview print
                  Exit Sub
               End If
            End If
GetNextLine:
         Next

         e.HasMorePages = False
         PageNbr = 0 ' in case called again from preview print
         mI = 1 ' for preview calling again
         'print a footer on the last page
         yPos = BottomMargin - LineHeight
         x1 = LeftMargin
         y1 = yPos
         x2 = RightMargin
         y2 = yPos
         e.Graphics.DrawLine(drPen, x1, y1, x2, y2)
         PrintFont.Dispose()
         PrintFont = New Font("Arial", 10)
         xPos = LeftMargin
         e.Graphics.DrawString(sFooter, _
            PrintFont, _
            Brushes.Black, _
            xPos, _
            yPos, _
            New StringFormat)
      Catch ex As System.Exception
         MsgBox(ex.ToString)
      End Try
   End Sub


   Private Sub GetMarginExtenders(ByRef lmExt As Integer, ByRef rmExt As Integer, ByRef tmExt As Integer, ByRef bmExt As Integer)
      lmExt = GetOneMarginExtender(_LeftMarginExtender)
      rmExt = GetOneMarginExtender(_RightMarginExtender)
      tmExt = GetOneMarginExtender(_TopMarginExtender)
      bmExt = GetOneMarginExtender(_BottomMarginExtender)
   End Sub
   Private Function GetOneMarginExtender(ByVal ext As MarginExtender) As Integer
      Const oneTenth As Integer = 5
      Const oneQtr As Integer = 15
      Const onehalf As Integer = 30
      Const threeQtr As Integer = 45
      Const oneInch As Integer = 60
      Select Case ext
         Case MarginExtender.None : Return 0
         Case MarginExtender.OneTenthInch : Return oneTenth
         Case MarginExtender.OneQuarterInch : Return oneQtr
         Case MarginExtender.OneHalfInch : Return onehalf
         Case MarginExtender.ThreeQuarterInch : Return threeQtr
         Case MarginExtender.OneInch : Return oneInch
         Case Else : Return 0
      End Select
   End Function

   Private Sub SetUpColHdrArray(ByVal ColHdr1 As String, ByVal ColHdr2 As String, _
         ByVal ColHdr3 As String, ByVal ColHdr4 As String)
      If ColHdr1.Length > 0 Then
         ColHdrArrayList.Add(ColHdr1)
         ColHdrCount += 1
      End If
      If ColHdr2.Length > 0 Then
         ColHdrArrayList.Add(ColHdr2)
         ColHdrCount += 1
      End If
      If ColHdr3.Length > 0 Then
         ColHdrArrayList.Add(ColHdr3)
         ColHdrCount += 1
      End If
      If ColHdr4.Length > 0 Then
         ColHdrArrayList.Add(ColHdr4)
         ColHdrCount += 1
      End If
   End Sub

#End Region

#Region " Public Properties "
   Public Property SubTitle2() As String
      Get
         Return _SubTitle2
      End Get
      Set(ByVal Value As String)
         _SubTitle2 = Value
      End Set
   End Property

   Public Property SubTitle3() As String
      Get
         Return _SubTitle3
      End Get
      Set(ByVal Value As String)
         _SubTitle3 = Value
      End Set
   End Property

   Public Property SubTitle4() As String
      Get
         Return _SubTitle4
      End Get
      Set(ByVal Value As String)
         _SubTitle4 = Value
      End Set
   End Property


   Public Property LeftMarginExtender() As MarginExtender
      Get
         Return _LeftMarginExtender
      End Get
      Set(ByVal Value As MarginExtender)
         _LeftMarginExtender = Value
      End Set
   End Property

   Public Property RightMarginExtender() As MarginExtender
      Get
         Return _RightMarginExtender
      End Get
      Set(ByVal Value As MarginExtender)
         _RightMarginExtender = Value
      End Set
   End Property

   Public Property TopMarginExtender() As MarginExtender
      Get
         Return _TopMarginExtender
      End Get
      Set(ByVal Value As MarginExtender)
         _TopMarginExtender = Value
      End Set
   End Property

   Public Property BottomMarginExtender() As MarginExtender
      Get
         Return _BottomMarginExtender
      End Get
      Set(ByVal Value As MarginExtender)
         _BottomMarginExtender = Value
      End Set
   End Property


   Public Property DrawBox() As Boolean
      Get
         Return _DrawBox
      End Get
      Set(ByVal Value As Boolean)
         _DrawBox = Value
      End Set
   End Property

   Public Property TitleFontStyle() As TitleStyle
      Get
         Return _TitleFontStyle
      End Get
      Set(ByVal Value As TitleStyle)
         _TitleFontStyle = Value
      End Set
   End Property


   Public Property TitleFontSize() As Single
      Get
         Return _TitleFontSize
      End Get
      Set(ByVal Value As Single)
         _TitleFontSize = Value
      End Set
   End Property

   Public Property PrintFooter() As Boolean
      Get
         Return _PrintFooter
      End Get
      Set(ByVal Value As Boolean)
         _PrintFooter = Value
      End Set
   End Property



   Public Property ColHdr1() As String
      Get
         Return _ColHdr1
      End Get
      Set(ByVal Value As String)
         _ColHdr1 = Value
      End Set
   End Property

   Public Property ColHdr2() As String
      Get
         Return _ColHdr2
      End Get
      Set(ByVal Value As String)
         _ColHdr2 = Value
      End Set
   End Property

   Public Property ColHdr3() As String
      Get
         Return _ColHdr3
      End Get
      Set(ByVal Value As String)
         _ColHdr3 = Value
      End Set
   End Property

   Public Property ColHdr4() As String
      Get
         Return _ColHdr4
      End Get
      Set(ByVal Value As String)
         _ColHdr4 = Value
      End Set
   End Property

	Public Property Title() As String
		Get
			Return _Title
		End Get
		Set(ByVal Value As String)
			_Title = Value
		End Set
	End Property

   Public Property SubTitle() As String
      Get
         Return _SubTitle
      End Get
      Set(ByVal Value As String)
         _SubTitle = Value
      End Set
   End Property

   Public Property WordWrap() As Integer
      Get
         Return _WordWrap
      End Get
      Set(ByVal Value As Integer)
         _WordWrap = Value
      End Set
   End Property

   Public Property SepLines() As Boolean
      Get
         Return _SepLines
      End Get
      Set(ByVal Value As Boolean)
         _SepLines = Value
      End Set
   End Property

#End Region

#Region " CUtilities Class "

   Public Class CUtilities
      Public LastLineWrapped As Boolean
      Friend Overloads Function MLCount(ByVal cStrng As String, ByVal nL As Integer) As Integer
         '-----
         ' VB Replacement for Clipper MLCount Function
         ' It does handle word wrap, nL is the max char
         ' count per line.
         '-----
         Dim nStptr As Integer, nLenStr As Integer, nLineCtr As Integer
         Dim sTemp As String
         Dim i As Integer

         ' nStPtr is the pointer to position in cStrng

         Try
            nStptr = 1
            nLenStr = Len(cStrng)
            nLineCtr = 0

            While True
               ' If the pointer to the beginning of the next line
               ' is >= the length of the string, we are outta here!
               If nStptr >= nLenStr Then
                  Return nLineCtr
                  Exit Function
               End If

               ' Get the next line, not to exceed the length of nL
               ' if nL was greater than 0
               If nL > 0 Then
                  sTemp = Mid$(cStrng, nStptr, nL)
                  If InStr(sTemp, vbCrLf) > 0 Then
                     ' there is a CRLF in the string
                     sTemp = Mid(sTemp, 1, sTemp.IndexOf(vbCrLf) - 1)
                     nStptr = nStptr + Len(sTemp) + 2
                  Else
                     ' new code to handle lines with no crlf
                     If Len(sTemp) = nL Then
                        ' we have a full line left (at least)
                        i = sTemp.LastIndexOf(" ")
                        ' truncate the partial word from the end
                        sTemp = Mid(sTemp, 1, i - 1)
                        'set the pointer to start the next line at
                        'current start point + len(stemp)
                        nStptr = nStptr + Len(sTemp)
                     Else
                        ' this is the last line, because the string is
                        ' shorter than the nL length
                        Return nLineCtr + 1
                        Exit Function
                     End If
                  End If
               Else
                  ' nL was supplied as 0 meaning we just look for CRLf
                  nStptr = InStr(nStptr, cStrng, vbCrLf) + 2
               End If

               ' if the ptr = 2 then there was no crlf in the line
               If nStptr = 2 Then
                  Return nLineCtr + 1
               End If

               nLineCtr = nLineCtr + 1
               If nStptr + 1 > nLenStr Then
                  Return nLineCtr
               End If
            End While
            Exit Function
         Catch ex As System.Exception
            MsgBox(ex.ToString)
         End Try
      End Function

      Friend Overloads Function MemoLine(ByVal cStrng As String, ByVal nLL As Integer, ByVal nL As Integer) As String
         '***************************************
         '* Name: MemoLine
         '* Purpose:
         '*   VB Replacement for Clipper MemoLine() Function.
         '*   Handles Word Wrap.  nLL is the max char/line.
         '*   Note that if the user asks for a line that is beyond the
         '*   end of the string, i.e. more lines than are in the string
         '*   unpredictable results will be returned, assuming we
         '*   return at all.  Therefore, MLCount() must be called
         '*   before calling MemoLine() and MemoLine must not be called
         '*   to return a line numbered higher than MLCount() returened.
         '*
         '* Parameters:
         '*   cStrng
         '*   nLL As Integer
         '*   nL As Integer
         '*
         '* Returns:
         '*
         '* Author: Les Smith
         '* Date Created: 11/10/1997
         '* Copyright: HHI Software
         '* Date Last Changed: to allow fetch of any line
         '* in word wrap.
         '***************************************

         Try
            Static nStptr As Integer
            Dim i As Integer
				'Dim nTmpPtr As Integer
            Dim sTemp As String
            Static j As Integer
            Dim iSt As Integer

            ' if NL is 1 > than J then
            ' this is a subsequent call to get the next
            ' line
            If j = 0 Then
               nStptr = 1
            End If
            If nL - j = 1 Then
               iSt = nL
            Else
               nStptr = 1
               iSt = 1
            End If

            LastLineWrapped = False

            If nStptr >= Len(cStrng) Then
               MemoLine = ""
               Exit Function
            End If

            ' Loop through the string until we find the requested line.
            For j = iSt To nL
               ' Get the next line, not to exceed the length of nLL
               ' if nL was greater than 0
               If nLL = 0 Then
                  ' nL was supplied as 0 meaning we just look for vbCrLf
                  i = InStr(nStptr, cStrng, vbCrLf, CompareMethod.Text)

                  If i = 0 Then
                     ' no vbcrlf, return the whole remaining portion of string
                     MemoLine = Mid(cStrng, nStptr) 'Trim(Mid(cStrng, nStptr))

                     ' set the next ptr at the end of the string
                     ' in case the user calls for the next line, which
                     ' if mlcount worked properly, they should not do...
                     nStptr = Len(cStrng)
                     Exit Function
                  ElseIf i = nStptr Then
                     ' the first chars in the current line are vbcrlf
                     nStptr = nStptr + 2
                     MemoLine = ""
                     If j < nL Then
                        GoTo BottomOfLoop
                     Else
                        Exit Function
                     End If
                  Else
                     MemoLine = Mid(cStrng, nStptr, i - nStptr) 'Trim(Mid(cStrng, nStptr, i - nStptr))
                     nStptr = i + 2
                     If j < nL Then
                        GoTo BottomOfLoop
                     Else
                        Exit Function
                     End If
                  End If
               Else
                  ' user specified max length of lines to be returned,
                  ' i.e. word wrap is called for...
                  sTemp = Mid$(cStrng, nStptr, nLL)
                  If InStr(sTemp, vbCrLf) > 0 Then
                     ' there is a vbCrLf in the string
                     sTemp = Mid(sTemp, 1, InStr(sTemp, vbCrLf) - 1)
                     nStptr = nStptr + Len(sTemp) + 2
                     MemoLine = sTemp 'Trim(sTemp)
                     If j < nL Then
                        GoTo BottomOfLoop
                     Else
                        Exit Function
                     End If
                  Else
                     ' no vbCrLf in string, find end of last full word
                     ' see if the line is shorter than the requested line
                     If Len(sTemp) < nLL Then
                        ' line is less than requested length,
                        ' we are at the end of the input string
                        ' set the pointer to the next line past the
                        ' end of the string
                        nStptr = Len(cStrng) + 1
                        MemoLine = sTemp
                        Exit Function
                     Else
                        ' this is not the last line, .'. find the
                        ' last space in the line, assuming there is one...
                        i = InStrRev(sTemp, " ")

                        If i = 0 Then
                           ' there is no space in the line
                           MemoLine = sTemp 'Trim(sTemp)
                           nStptr = nStptr + Len(sTemp) '+ 1
                           If j < nL Then
                              GoTo BottomOfLoop
                           Else
                              LastLineWrapped = True
                              Exit Function
                           End If
                        Else
                           ' there is a space in the line
                           sTemp = Mid(sTemp, 1, i)
                           MemoLine = sTemp 'Trim(sTemp)
                           nStptr = nStptr + i
                           If j < nL Then
                              GoTo BottomOfLoop
                           Else
                              LastLineWrapped = True
                              Exit Function
                           End If
                        End If
                     End If
                  End If
               End If
BottomOfLoop:
            Next j
         Catch ex As System.Exception
            MsgBox(ex.ToString)
			End Try
			Return Nothing
      End Function
   End Class

#End Region
   ' Strongly typed collection of type PrintStructureDataGrid
   Public Class PrintGridCollection
      Inherits CollectionBase

      Default Public Property Item(ByVal index As Integer) As PrintStructureDataGrid
         Get
            Return CType(Me.List(index), PrintStructureDataGrid)
         End Get
         Set(ByVal Value As PrintStructureDataGrid)
            Me.List(index) = Value
         End Set
      End Property

      Public Sub Add(ByVal item As PrintStructureDataGrid)
         Me.List.Add(item)
      End Sub

      Public Function Contains(ByVal value As PrintStructureDataGrid) As Boolean
         Return Me.List.Contains(value)
      End Function

      Public Sub CopyTo(ByVal array As System.Array, ByVal index As Integer)
         Me.List.CopyTo(array, index)
      End Sub

      Public Function IndexOf(ByVal value As PrintStructureDataGrid) As Integer
         Return Me.List.IndexOf(value)
      End Function

      Public Sub Insert(ByVal index As Integer, ByVal value As PrintStructureDataGrid)
         Me.List.Insert(index, value)
      End Sub

      Public Sub Remove(ByVal value As PrintStructureDataGrid)
         Me.Remove(value)
      End Sub

   End Class

   ' Strongly typed collection of type PrintStructureDataGrid
   Public Class PrintListViewCollection
      Inherits CollectionBase

      Default Public Property Item(ByVal index As Integer) As PrintStructureListView
         Get
            Return CType(Me.List(index), PrintStructureListView)
         End Get
         Set(ByVal Value As PrintStructureListView)
            Me.List(index) = Value
         End Set
      End Property

      Public Sub Add(ByVal item As PrintStructureListView)
         Me.List.Add(item)
      End Sub

      Public Function Contains(ByVal value As PrintStructureListView) As Boolean
         Return Me.List.Contains(value)
      End Function

      Public Sub CopyTo(ByVal array As System.Array, ByVal index As Integer)
         Me.List.CopyTo(array, index)
      End Sub

      Public Function IndexOf(ByVal value As PrintStructureListView) As Integer
         Return Me.List.IndexOf(value)
      End Function

      Public Sub Insert(ByVal index As Integer, ByVal value As PrintStructureListView)
         Me.List.Insert(index, value)
      End Sub

      Public Sub Remove(ByVal value As PrintStructureListView)
         Me.Remove(value)
      End Sub

   End Class
   ' Data Class to describe each column to be printed
   Public Class PrintStructureDataGrid
      Public Column As Short
      Public Format As FormatString
      Public NumberDataColumnChars As Short
      Public Alignment As Align
      Public PrintColumnWidth As Short
   End Class
   ' data class to describe each listview column to be printed
   Public Class PrintStructureListView
      Public Column As Short
      Public NumberDataColumnChars As Short
      Public Alignment As Align
      Public PrintColumnWidth As Short
   End Class
   ' Data Class to describe Print Options to CPrintReportString
   Public Class PrintOptions
      Public CharsPerLine As CharsPerLine
      Public PrintString As String = String.Empty
      Public Title As String = String.Empty
      Public SubTitle As String = String.Empty
      Public SubTitle2 As String = String.Empty
      Public SubTitle3 As String = String.Empty
      Public SubTitle4 As String = String.Empty
      Public ColHdr1 As String = String.Empty
      Public ColHdr2 As String = String.Empty
      Public ColHdr3 As String = String.Empty
      Public ColHdr4 As String = String.Empty
      Public Portrait As PrintOrientation
      Public PrintFooter As Boolean = True
      Public PrintOrPreview As PrintPreview
      Public Boxed As Boolean
      Public LeftMarginExtender As MarginExtender
      Public RightMarginExtender As MarginExtender
      Public TopMarginExtender As MarginExtender
      Public BottomMarginExtender As MarginExtender
   End Class
   Public Class CPrintGrid

#Region " Public Methods "
      Public Sub PrintGrid(ByRef dt As DataTable, ByRef col As PrintGridCollection, ByRef colPO As PrintOptions)
         Dim sb As New System.Text.StringBuilder
         Dim dr As DataRow

         Dim ps As PrintStructureDataGrid

         For i As Integer = 0 To dt.Rows.Count - 1
            dr = dt.Rows(i)
            ' loop thru the collection of columns to print
            For j As Integer = 0 To col.Count - 1
               ps = col(j)
               FormatColumn(sb, dr, ps)
            Next
            sb.Append(vbCrLf)
         Next

         ' the print string is set up, print it
         CallPrintPreview(sb, colPO)

      End Sub
      Public Sub PrintGrid(ByRef dv As DataView, ByRef col As PrintGridCollection, ByRef colPO As PrintOptions)
         Dim sb As New System.Text.StringBuilder
         Dim dr As DataRow
         Dim ps As PrintStructureDataGrid

         For i As Integer = 0 To dv.Count - 1
            dr = dv.Item(i).Row
            ' loop thru the collection of columns to print
            For j As Integer = 0 To col.Count - 1
               ps = col(j)
               FormatColumn(sb, dr, ps)
            Next
            sb.Append(vbCrLf)
         Next

         ' the print string is set up, print it
         CallPrintPreview(sb, colPO)

      End Sub
      ' print contents of a ListView
      Public Sub PrintGrid(ByRef lv As ListView, ByRef col As PrintListViewCollection, ByRef colPO As PrintOptions)
         Dim ps As PrintStructureListView
         Dim sb As New System.Text.StringBuilder
         Dim item As ListViewItem

         For i As Integer = 0 To lv.Items.Count - 1
            ' loop thru the collection of columns to print
            If lv.CheckBoxes Then
               If lv.Items(i).Checked Then
                  sb.Append(" v ")
               Else
                  sb.Append("   ")
               End If
            End If
            For j As Integer = 0 To col.Count - 1
               ps = col(j)
               item = lv.Items(i)
               FormatColumn(sb, item, ps)
            Next
            sb.Append(vbCrLf)
         Next

         CallPrintPreview(sb, colPO)
      End Sub
      Public Function GetDataSource(ByRef frm As Form, ByRef dg As DataGrid) As DataView
         Return CType(CType(frm.BindingContext(dg.DataSource, dg.DataMember), CurrencyManager).List, DataView)
      End Function

#End Region

#Region " Private Methods "
      Private Sub CallPrintPreview(ByRef sb As StringBuilder, ByRef colPO As PrintOptions)
         Dim pr As New CPrintReportString
         pr.LeftMarginExtender = colPO.LeftMarginExtender
         pr.RightMarginExtender = colPO.RightMarginExtender
         pr.TopMarginExtender = colPO.TopMarginExtender
         pr.BottomMarginExtender = colPO.BottomMarginExtender
         pr.DrawBox = colPO.Boxed

         pr.PrintOrPreview(colPO.CharsPerLine, sb.ToString, _
            colPO.Title, colPO.SubTitle, colPO.PrintOrPreview, colPO.Portrait, _
            colPO.ColHdr1, colPO.ColHdr2, colPO.ColHdr3, colPO.ColHdr4)
      End Sub
      ' format the passed listview item into the sb
      Private Sub FormatColumn(ByRef sb As StringBuilder, ByRef item As ListViewItem, ByRef ps As PrintStructureListView)
         Dim s As String
         s = item.SubItems(ps.Column).Text
         AlignAndPad(ps.NumberDataColumnChars, ps.PrintColumnWidth, ps.Alignment, sb, s)
      End Sub
      ' format the passed column into the stringbuilder
      Private Sub FormatColumn(ByRef sb As StringBuilder, ByVal dr As DataRow, ByRef ps As PrintStructureDataGrid)
			Dim s As Object = Nothing

         With ps
            If IsDBNull(dr(ps.Column)) Then
               s = String.Empty
            Else
               Select Case ps.Format
                  Case FormatString.Boolean
                     s = IIf(dr(ps.Column), "v", " ")
                  Case FormatString.Currency
                     s = Format(dr(ps.Column), "$#,##0.00")
                  Case FormatString.DateTime
                     s = Format(dr(ps.Column), "MM/dd/yyyy hh:mm:ss tt")
                  Case FormatString.YesNo
                     s = IIf(dr(ps.Column), "Yes", "No")
                  Case FormatString.Default
                     s = CStr(dr(ps.Column))
               End Select
            End If

            ' pad, align, and add cell to sb
            AlignAndPad(ps.NumberDataColumnChars, ps.PrintColumnWidth, ps.Alignment, sb, s)

         End With
      End Sub
      Private Sub AlignAndPad(ByVal pcChars As Integer, ByVal pcWidth As Integer, ByVal Alignment As Align, ByRef sb As StringBuilder, ByVal s As String)
         ' now set up the alignment and padding
         If s.Trim.Length > pcChars Then
            s = s.Substring(0, pcChars)
         End If
         If Alignment = Align.Right Then
            s = s.PadLeft(pcWidth)
         ElseIf Alignment = Align.Left Then
            s = s.PadRight(pcWidth)
         Else
            s = PadCenter(s, pcWidth)
         End If

         ' add to sb
         sb.Append(s)
      End Sub
      ' Replacement for Non existant PadCenter method of string object
      Private Function PadCenter(ByVal s As String, ByVal n As Integer) As String
         Return s.PadRight(s.Length + _
            Math.Max((n - s.Length), 0) \ 2).PadLeft(n).Substring(0, n)
      End Function
#End Region
   End Class



End Class
