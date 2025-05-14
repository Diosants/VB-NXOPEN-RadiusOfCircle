Option Explicit Off
Imports NXOpen
Imports NXOpen.Preferences

Public Class RadiusOfCircle

    Public Shared Sub Main()
        Dim theSession As Session = Session.GetSession()

        Dim sel = NXOpen.UI.GetUI.SelectionManager
        Dim myView As View = Nothing
        Dim p1, p2, p3 As Point3d

        ' Get three points from user
        sel.SelectScreenPosition("Specify first point", myView, p1)
        sel.SelectScreenPosition("Specify second point", myView, p2)
        sel.SelectScreenPosition("Specify third point", myView, p3)

        ' Calculate vectors
        Dim u As New Vector3d(p2.X - p1.X, p2.Y - p1.Y, p2.Z - p1.Z)
        Dim v As New Vector3d(p3.X - p1.X, p3.Y - p1.Y, p3.Z - p1.Z)

        ' Dot products
        Dim uu As Double = u.X * u.X + u.Y * u.Y + u.Z * u.Z
        Dim uv As Double = u.X * v.X + u.Y * v.Y + u.Z * v.Z
        Dim vv As Double = v.X * v.X + v.Y * v.Y + v.Z * v.Z

        ' Determinant
        Dim det As Double = uu * vv - uv * uv
        If System.Math.Abs(det) < 0.0000000001 Then
            NXOpen.UI.GetUI().NXMessageBox.Show("Error", NXOpen.NXMessageBox.DialogType.Error, "Points are colinear or too close to each other. Cannot compute circle.")
            Return
        End If

        ' Calculate barycentric coordinates
        Dim alpha As Double = (vv * (uu - uv)) / (2 * det)
        Dim beta As Double = (uu * (vv - uv)) / (2 * det)

        ' Center vector from p1
        Dim rx As Double = alpha * u.X + beta * v.X
        Dim ry As Double = alpha * u.Y + beta * v.Y
        Dim rz As Double = alpha * u.Z + beta * v.Z

        Dim radius As Double = System.Math.Sqrt(rx * rx + ry * ry + rz * rz)

        NXOpen.UI.GetUI().NXMessageBox.Show("Result", NXOpen.NXMessageBox.DialogType.Information, "Radius of circle: " & radius.ToString("G6"))
    End Sub

End Class