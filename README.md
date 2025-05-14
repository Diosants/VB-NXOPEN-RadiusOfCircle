"# VB-NXOPEN-RadiusOfCircle" 
"# VB-NXOPEN-RadiusOfCircle" 


# RadiusOfCircle - NX Open VB.NET Example

This NX Open automation script prompts the user to select three points on the screen and calculates the radius of the circle passing through those points. The program is written in Visual Basic .NET and uses the NXOpen API.

---

##  Features

- Interactively selects 3 points using the screen cursor.
- Calculates vectors and dot products.
- Checks for collinear or invalid point sets.
- Computes the **radius** using geometric principles.
- Displays the result in a message box within Siemens NX.

---

## 🛠 Requirements

- Siemens NX (any version supporting NX Open VB.NET)
- Visual Studio (with .NET and NX Open libraries referenced)
- NX Open environment is properly configured

---

##  How to Run

1. Open **Visual Studio**.
2. Create a **VB.NET Class Library** project.
3. Reference the following NXOpen libraries:
    - `NXOpen.dll`
    - `NXOpen.Utilities.dll`
    - `NXOpen.UF.dll`
4. Copy the code into your `RadiusOfCircle.vb` file.
5. Build the `.dll` and register it with Siemens NX for use as a journal or custom plugin.

---

##  Notes

- The program **does not create geometry** — it only calculates and displays the radius.
- If the three points are **colinear** or **very close**, an error message will appear.



